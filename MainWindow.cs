using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility
{
    public partial class MainWindow : Form
    {
        private readonly LogService _logger;

        public MainWindow()
        {
            InitializeComponent();

            _logger = new(_logBox);
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

                var (dataConf, userConf) = await GetConfig();
                await ApplyTestCase(dataConf, userConf);
                await RefreshDataInUnity(dataConf);

                _logger.ShowLog("Apply new test case done.", LogLevel.inf);
            }
            catch (Exception ex)
            {
                _logger.ShowLog(ex.Message, LogLevel.err);
            }
        }
        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var (dataConf, userConf) = await GetConfig();
                await RefreshDataInUnity(dataConf);

                _logger.ShowLog("Refresh done.", LogLevel.inf);
            }
            catch (Exception ex)
            {
                _logger.ShowLog(ex.Message, LogLevel.err);
            }
        }

        private void CleanBtn_Click(object sender, EventArgs e)
        {
            _logger.CleanLog();
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
                    _logger.ShowLog($"config data is saved.", LogLevel.inf);
                }
            }
            catch (Exception ex)
            {
                _logger.ShowLog(ex.Message, LogLevel.err);
            }
        }
        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            _logBox.SelectionStart = _logBox.Text.Length;
            _logBox.ScrollToCaret();
        }

        /*
         *  Functions
         */

        private async Task<(DataConfig dataConf, UserConfig userConf)> GetConfig()
        {            
            var dataConf = await LocalService.TryLoadConfigDataFromLocal<DataConfig>();

            var userConf = await LocalService.TryLoadConfigDataFromLocal<UserConfig>();

            _logger.ShowLog("finished loading config.", LogLevel.inf);

            return (dataConf, userConf);
        }
        private async Task ApplyTestCase(DataConfig dataConf, UserConfig userConf)
        {
            # region Close File Before Process

            if (userConf.AutoCloseFileIfOccupying)
                ProcessService.KillWindow($"{Path.GetFileName(dataConf.DataSrcPath)} - LibreOffice Calc");

            # endregion

            // excel file name: dataTab
            #region Load Excel File

            var dataTab = new ExcelService(dataConf.DataSrcPath);
            await dataTab.InitExcelFile();

            _logger.ShowLog("finished open xlsx.", LogLevel.inf);

            #endregion

            #region Get Test Target

            var group = await dataTab.GetSkillGroup(_skillIdBox.Text);

            _logger.ShowLog($"finished get test data. found {group.Count} skills.", LogLevel.inf);

            if (userConf.ShowSKillDetailsAfterLoad)
            {
                Array.ForEach(
                    group.Skills,
                    skill => _logger.ShowLog(skill.ToString(), LogLevel.inf));
            }

            #endregion

            #region Flush Test Data On Runtime

            await dataTab.ApplySkillGroupDataOn(group, 1);

            _logger.ShowLog($"finished flush data.", LogLevel.inf);

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

            _logger.ShowLog("calling E2J server in unity...", LogLevel.inf);

            var e2jOprMsg = await server.SendCommand(ClientCmd.CONV_EXCEL_TO_JSON);
            _logger.ShowLog($"{e2jOprMsg}. waiting for {dataConf.E2JWaitingTime} ms...", LogLevel.inf);

            await Task.Delay(dataConf.E2JWaitingTime);

            #endregion

            #region Deploy: Convert Json To Bin

            server = new NetworkService();
            await server.ConnectToServer();

            _logger.ShowLog("calling J2B server in unity...", LogLevel.inf);

            var j2bOprMsg = await server.SendCommand(ClientCmd.CONV_JSON_TO_BIN);
            _logger.ShowLog($"{j2bOprMsg}. waiting for {dataConf.J2BWaitingTime} ms...", LogLevel.inf);

            await Task.Delay(dataConf.J2BWaitingTime);

            #endregion

            #region Deploy: Refresh Unity Editor

            server = new NetworkService();
            await server.ConnectToServer();

            _logger.ShowLog("refreshing scripts in unity...", LogLevel.inf);

            var refreshOprMsg = await server.SendCommand(ClientCmd.REFRESH_SCRIPTS);
            _logger.ShowLog($"{refreshOprMsg}.", LogLevel.inf);

            #endregion
        }

    }
}