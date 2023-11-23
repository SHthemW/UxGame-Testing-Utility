using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Xml.Linq;
using UxGame_Testing_Utility.Actions;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility
{
    public partial class MainWindow : Form
    {
        private const string VERSION_CODE = "v2.1";

        private readonly LogService _debugLogger;
        private readonly LogService _infoLogger;

        public MainWindow()
        {
            InitializeComponent();
            _versionCode.Text = VERSION_CODE;

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

                // init action
                var replaceDataAction = new ReplaceDataInTableAction (dataConf, userConf, _infoLogger, _debugLogger);
                var callRefreshAction = new CallRefreshCommandAction (dataConf, userConf, _infoLogger, _debugLogger);
                var callAutoTstAction = new CallAutoTestCommandAction(dataConf, userConf, _infoLogger, _debugLogger);

                // get test targets
                var testTargets = _skillIdBox.Text.Split(' ');

                if (testTargets.Length > 1 && !_enableSeqChkbox.Checked)
                {
                    _debugLogger.ShowLog($"cannot test continuous with no-seq option.", LogLevel.err);
                    return;
                }

                foreach (string testCase in testTargets)
                {
                    _debugLogger.ShowLog($"start to deploy case <{testCase}> :", LogLevel.inf);

                    bool testMaxLevel = testCase.Contains('*');
                    string testCaseName = testCase.Replace("*", "");

                    // apply test case in local
                    await replaceDataAction.Execute(testCaseName, testMaxLevel);

                    // connect to unity and deploy                 
                    await callRefreshAction.Execute();

                    // start test
                    if (_enableSeqChkbox.Checked)
                    {
                        await callAutoTstAction.Execute(testCaseName, testMaxLevel);
                        await Task.Delay(2000);
                    }

                    _debugLogger.ShowLog($"Deploy test case <{testCase}> done.", LogLevel.inf);
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
                // init config
                var (dataConf, userConf) = await GetConfig();

                // init action
                var callRefreshAction = new CallRefreshCommandAction(dataConf, userConf, _infoLogger, _debugLogger);

                await callRefreshAction.Execute();

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

                    if (dataConf.ContainsInvaild(out var errmsgs))
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
            if (_enableSeqChkbox.Checked)
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
    }
}