using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Xml.Linq;
using UxGame_Testing_Utility.Actions;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility
{
    public partial class MainWindow : Form, IMainWindowService
    {
        private const string VERSION_CODE = "v2.1";

        private DataConfig? _dataConfig;
        private UserConfig? _userConfig;

        private readonly LogService _consLogger;
        private readonly LogService _infoLogger;
        
        DataConfig IMainWindowService.DataConfig => _dataConfig ?? throw new NullReferenceException();
        UserConfig IMainWindowService.UserConfig => _userConfig ?? throw new NullReferenceException();        
        LogService IMainWindowService.InfoWindow => _infoLogger;
        LogService IMainWindowService.Console    => _consLogger;
        string     IMainWindowService.CurrentInputContent
        {
            get
            {
                if (string.IsNullOrEmpty(_skillIdBox.Text))
                    throw new Exception("skill id is empty.");
                return _skillIdBox.Text;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            _versionCode.Text = VERSION_CODE;

            _consLogger = new(_logBox);
            _infoLogger = new(_infoBox);

            _ = UpdateConfigFromLocal();
        }
        public async Task UpdateConfigFromLocal()
        {
            this._dataConfig = await LocalService.TryLoadConfigDataFromLocal<DataConfig>();
            this._userConfig = await LocalService.TryLoadConfigDataFromLocal<UserConfig>();

            _consLogger.ShowLog("finished loading config.", LogLevel.inf);
        }

        /*
         *  UI
         */

        private async void ApplyAndDeployBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // init action
                ExecutableAction replaceData = new ReplaceDataInTableAction (this);
                ExecutableAction callRefresh = new CallRefreshCommandAction (this);
                ExecutableAction callAutoTst = new CallAutoTestCommandAction(this);

                // get test targets
                var testTargets = _skillIdBox.Text.Split(' ');

                if (testTargets.Length > 1 && !_enableSeqChkbox.Checked)
                {
                    _consLogger.ShowLog($"cannot test continuous with no-seq option.", LogLevel.err);
                    return;
                }

                foreach (string testCase in testTargets)
                {
                    _consLogger.ShowLog($"start to deploy case <{testCase}> :", LogLevel.inf);
                  
                    // apply test case in local
                    await replaceData.Execute();

                    // connect to unity and deploy                 
                    await callRefresh.Execute();

                    // start test
                    if (_enableSeqChkbox.Checked)
                    {
                        await callAutoTst.Execute();
                        await Task.Delay(2000);
                    }

                    _consLogger.ShowLog($"Deploy test case <{testCase}> done.", LogLevel.inf);
                }
            }
            catch (Exception ex)
            {
                _consLogger.ShowLog(ex.Message, LogLevel.err);
            }
        }
        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // init action
                ExecutableAction callRefresh = new CallRefreshCommandAction(this);

                await callRefresh.Execute();

                _consLogger.ShowLog("Refresh done.", LogLevel.inf);
            }
            catch (Exception ex)
            {
                _consLogger.ShowLog(ex.Message, LogLevel.err);
            }
        }

        private void CleanBtn_Click(object sender, EventArgs e)
        {
            _consLogger.CleanLog();
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

                    _ = UpdateConfigFromLocal();
                    _consLogger.ShowLog($"config data is saved.", LogLevel.inf);
                }
            }
            catch (Exception ex)
            {
                _consLogger.ShowLog(ex.Message, LogLevel.err);
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
    }
}