using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Xml.Linq;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility
{
    public partial class MainWindow : Form
    {
        private readonly LogService _debugLogger;
        private readonly LogService _infoLogger;

        public MainWindow()
        {
            InitializeComponent();

            _debugLogger = new(_logBox);
            _infoLogger = new(_infoBox);
        }

        /*
         *  UI
         */

        private async void ApplyAndDeployBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_skillIdBox.Text))
                    throw new Exception("skill id is empty.");

                // init config
                var (dataConf, userConf) = await GetConfig();

                // get test targets
                var testTargets = _skillIdBox.Text.Split(' ');

                if (testTargets.Length > 1 && !_enbaleSeqChkbox.Checked)
                {
                    _debugLogger.ShowLog($"cannot test continuous with no-seq option.", LogLevel.err);
                    return;
                }

                foreach (var toTest in testTargets)
                {
                    _debugLogger.ShowLog($"start to deploy case <{toTest}> :", LogLevel.inf);

                    // apply test case in local
                    await ApplyTestCase(toTest, dataConf, userConf);

                    // connect to unity and deploy
                    await RefreshDataInUnity(dataConf);

                    _debugLogger.ShowLog($"Deploy test case <{toTest}> done.", LogLevel.inf);
                }
            }
            catch (Exception ex)
            {
                _debugLogger.ShowLog(ex.Message, LogLevel.err);
            }
        }
        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var (dataConf, userConf) = await GetConfig();
                await RefreshDataInUnity(dataConf);

                _debugLogger.ShowLog("Refresh done.", LogLevel.inf);
            }
            catch (Exception ex)
            {
                _debugLogger.ShowLog(ex.Message, LogLevel.err);
            }
        }

        private void CleanBtn_Click(object sender, EventArgs e)
        {
            _debugLogger.CleanLog();
        }
        private void ConfigBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using ConfigWindow confWindow = new();
                _ = confWindow.InitShowData();

                var result = confWindow.ShowDialog();

                if (result is DialogResult.OK)
                {
                    var dataConf = confWindow.DataConfig;
                    var userConf = confWindow.UserConfig;

                    if (!DataConfig.CheckVaild(dataConf, out var errmsgs))
                        throw new Exception(errmsgs[0]);

                    LocalService.SaveConfigDataToLocal(dataConf);
                    LocalService.SaveConfigDataToLocal(userConf);
                    _debugLogger.ShowLog($"config data is saved.", LogLevel.inf);
                }
            }
            catch (Exception ex)
            {
                _debugLogger.ShowLog(ex.Message, LogLevel.err);
            }
        }
        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            _logBox.SelectionStart = _logBox.Text.Length;
            _logBox.ScrollToCaret();
        }
        private void EnbaleSeqChkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (_enbaleSeqChkbox.Checked)
            {
                _applyAndDeployBtn.Text = "执行自动测试";
                _refreshBtn.Enabled = false;
            }
            else
            {
                _applyAndDeployBtn.Text = "应用并部署";
                _refreshBtn.Enabled = true;
            }
        }

        /*
         *  Functions
         */

        private async Task<(DataConfig dataConf, UserConfig userConf)> GetConfig()
        {
            var dataConf = await LocalService.TryLoadConfigDataFromLocal<DataConfig>();

            var userConf = await LocalService.TryLoadConfigDataFromLocal<UserConfig>();

            _debugLogger.ShowLog("finished loading config.", LogLevel.inf);

            return (dataConf, userConf);
        }
        private async Task ApplyTestCase(string testCaseName, DataConfig dataConf, UserConfig userConf)
        {
            # region Close File Before Process

            if (userConf.AutoCloseFileIfOccupying)
                ProcessService.KillWindow($"{Path.GetFileName(dataConf.DataSrcPath)} - LibreOffice Calc");

            # endregion

            // excel file name: dataTab
            #region Load Excel File

            var dataTab = new ExcelService(dataConf.DataSrcPath);
            await dataTab.InitExcelFile();

            _debugLogger.ShowLog("finished open xlsx.", LogLevel.inf);

            #endregion

            #region Get Test Target

            var group = await dataTab.GetSkillGroup(testCaseName);

            _debugLogger.ShowLog($"finished get test data. found {group.Count} skills.", LogLevel.inf);

            if (userConf.ShowSKillDetailsAfterLoad)
            {
                _infoLogger.CleanLog();
                _infoLogger.ShowLog(group.ToString(), LogLevel.non);
            }

            #endregion

            #region Flush Test Data On Runtime

            await dataTab.ApplySkillGroupDataOn(group, 1);

            _debugLogger.ShowLog($"finished flush data.", LogLevel.inf);

            #endregion           

            #region Open File After Process

            if (userConf.AutoOpenFileAfterProcess)
                ProcessService.Startup(
                    @"C:\\Program Files\\LibreOffice\\program\\scalc.exe",
                    dataConf.DataSrcPath
                    );

            #endregion
        }
        private async Task RefreshDataInUnity(DataConfig dataConf)
        {
            #region Deploy: Connect To Unity

            var server = new NetworkService();
            await server.ConnectToServer();

            #endregion

            #region Deploy: Convert Excel To Json

            _debugLogger.ShowLog("calling E2J server in unity...", LogLevel.inf);

            var e2jOprMsg = await server.SendCommand(ClientCmd.CONV_EXCEL_TO_JSON);
            _debugLogger.ShowLog($"{e2jOprMsg}. waiting for {dataConf.E2JWaitingTime} ms...", LogLevel.inf);

            await Task.Delay(dataConf.E2JWaitingTime);

            #endregion

            #region Deploy: Convert Json To Bin

            server = new NetworkService();
            await server.ConnectToServer();

            _debugLogger.ShowLog("calling J2B server in unity...", LogLevel.inf);

            var j2bOprMsg = await server.SendCommand(ClientCmd.CONV_JSON_TO_BIN);
            _debugLogger.ShowLog($"{j2bOprMsg}. waiting for {dataConf.J2BWaitingTime} ms...", LogLevel.inf);

            await Task.Delay(dataConf.J2BWaitingTime);

            #endregion

            #region Deploy: Refresh Unity Editor

            server = new NetworkService();
            await server.ConnectToServer();

            _debugLogger.ShowLog("refreshing scripts in unity...", LogLevel.inf);

            var refreshOprMsg = await server.SendCommand(ClientCmd.REFRESH_SCRIPTS);
            _debugLogger.ShowLog($"{refreshOprMsg}.", LogLevel.inf);

            await Task.Delay(dataConf.J2BWaitingTime);

            #endregion
        }
        
    }
}