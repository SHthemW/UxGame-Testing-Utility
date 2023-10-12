using System.Diagnostics;
using System.Text;
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

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            #region Load Config

            if (string.IsNullOrEmpty(_skillIdBox.Text))
            {
                _logger.ShowLog("skill id is empty.", LogLevel.err);
                return;
            }

            var dataConfOpr = await LocalService.TryLoadConfigDataFromLocal<DataConfig>();
            if (!dataConfOpr.suc)
            {
                _logger.ShowLog(dataConfOpr.msg, LogLevel.err);
                return;
            }
            DataConfig dataConf = dataConfOpr.rst;

            var userConfOpr = await LocalService.TryLoadConfigDataFromLocal<UserConfig>();
            if (!userConfOpr.suc)
            {
                _logger.ShowLog(dataConfOpr.msg, LogLevel.err);
                return;
            }
            UserConfig userConf = userConfOpr.rst;

            if (!DataConfig.CheckVaild(dataConf, out var errmsg_conf))
            {
                _logger.ShowLog(errmsg_conf!, LogLevel.err);
                return;
            }

            _logger.ShowLog("finished loading config.", LogLevel.inf);

            #endregion

            # region Close File Before Process

            if (userConf.AutoCloseFileIfOccupying)
                ProcessService.KillWindow($"{Path.GetFileName(dataConf.DataSrcPath)} - LibreOffice Calc");

            # endregion

            // excel file name: dataTab
            #region Load Excel File

            var dataTab = new ExcelService(dataConf.DataSrcPath);
            var tabInitOpr = await dataTab.InitExcelFile();

            if (!tabInitOpr.suc)
            {
                _logger.ShowLog(tabInitOpr.msg, LogLevel.err);
                if (!userConf.AutoCloseFileIfOccupying)
                    _logger.ShowLog("if you want to close file automatically, go to [ÉèÖÃ].", LogLevel.inf);
                return;
            }

            _logger.ShowLog("finished open xlsx.", LogLevel.inf);

            #endregion

            #region Get Test Target

            var skillGroupGetOpr = await dataTab.GetSkillGroup(_skillIdBox.Text);

            if (!skillGroupGetOpr.suc)
            {
                _logger.ShowLog(skillGroupGetOpr.msg!, LogLevel.err);
                return;
            }
            SkillGroup group = skillGroupGetOpr.rst;

            _logger.ShowLog($"finished get test data. found {group.Count} skills.", LogLevel.inf);

            if (userConf.ShowSKillDetailsAfterLoad)
            {
                Array.ForEach(
                    group.Skills,
                    skill => _logger.ShowLog(skill.ToString(), LogLevel.inf));
            }

            #endregion

            #region Flush Test Data On Runtime

            var applyToFileOpr = await dataTab.ApplySkillGroupDataOn(group, 1);

            if (!applyToFileOpr.suc) 
            {
                _logger.ShowLog(applyToFileOpr.msg!, LogLevel.err);
                return;
            }

            _logger.ShowLog($"finished flush data.", LogLevel.inf);

            #endregion           

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

            # endregion

            #region Open File After Process

            if (userConf.AutoOpenFileAfterProcess)
                ProcessService.Startup(
                    @"C:\\Program Files\\LibreOffice\\program\\scalc.exe",
                    dataConf.DataSrcPath
                    );

            #endregion

            _logger.ShowLog("all actions is DONE.", LogLevel.inf);
        }

        private void CleanBtn_Click(object sender, EventArgs e)
        {
            _logger.CleanLog();
        }
        private void ConfigBtn_Click(object sender, EventArgs e)
        {
            using ConfigWindow confWindow = new();
            _ = confWindow.InitShowData();

            var result = confWindow.ShowDialog();

            if (result is DialogResult.OK)
            {
                var dataConf = confWindow.DataConfig;
                var userConf = confWindow.UserConfig;

                if (!DataConfig.CheckVaild(dataConf, out var errmsgs))
                {
                    _logger.ShowLog(errmsgs!, LogLevel.err);
                    return;
                }

                LocalService.SaveConfigDataToLocal(dataConf);
                LocalService.SaveConfigDataToLocal(userConf);
                _logger.ShowLog($"config data is saved.", LogLevel.inf);
            }
        }
    }
}