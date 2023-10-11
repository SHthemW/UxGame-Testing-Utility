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

        private void StartBtn_Click(object sender, EventArgs e)
        {
            #region Load Config

            if (string.IsNullOrEmpty(_skillIdBox.Text))
            {
                _logger.ShowLog("skill id is empty.", LogLevel.err);
                return;
            }
            if (!LocalService.TryLoadConfigDataFromLocal(out DataConfig dataConf, out var errmsg_local_data))
            {
                _logger.ShowLog(errmsg_local_data!, LogLevel.err);
                return;
            }
            if (!LocalService.TryLoadConfigDataFromLocal(out UserConfig userConf, out var errmsg_local_user))
            {
                _logger.ShowLog(errmsg_local_user!, LogLevel.err);
                return;
            }
            if (!DataConfig.CheckVaild(dataConf, out var errmsg_conf))
            {
                _logger.ShowLog(errmsg_conf!, LogLevel.err);
                return;
            }

            _logger.ShowLog("finished loading config.", LogLevel.inf);

            #endregion

            // excel file name: dataTab
            #region Load Excel File

            var dataTab = new ExcelService(dataConf.DataSrcPath, out var errmsg_tabfile);
            if (errmsg_tabfile != null)
            {
                _logger.ShowLog(errmsg_tabfile, LogLevel.err);
                return;
            }

            _logger.ShowLog("finished open xlsx.", LogLevel.inf);

            #endregion

            #region Get Test Target

            if (!dataTab.GetSkillGroup(_skillIdBox.Text, out var group, out var errmsg_skill))
            {
                _logger.ShowLog(errmsg_skill!, LogLevel.err);
                return;
            }
            _logger.ShowLog($"finished get test data. found {group.Count} skills.", LogLevel.inf);

            if (userConf.ShowSKillDetailsAfterLoad)
            {
                Array.ForEach(
                    group.Skills,
                    skill => _logger.ShowLog(skill.ToString(), LogLevel.inf));
            }

            #endregion

            #region Flush Test Data On Runtime

            if (!dataTab.ApplySkillGroupDataOn(group, 1, out var errmsg_write))
            {
                _logger.ShowLog(errmsg_write!, LogLevel.err);
                return;
            }
            _logger.ShowLog($"finished flush data.", LogLevel.inf);

            #endregion
        }

        private void CleanBtn_Click(object sender, EventArgs e)
        {
            _logger.CleanLog();
        }
        private void ConfigBtn_Click(object sender, EventArgs e)
        {
            using ConfigWindow confWindow = new();

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