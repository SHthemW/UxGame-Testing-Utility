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
            if (!LocalService.TryLoadConfigDataFromLocal(out var config, out var err))
            {
                _logger.ShowLog($"failed to load config. property: {err.Name}, reason: {err.Reason}", LogLevel.err);
                return;
            }

            _logger.ShowLog("finished loading config.", LogLevel.inf);

            #endregion

            #region Load Excel File

            var dataTab = new ExcelService(config.DataSrcPath, out var errmsg_tabfile);
            if (errmsg_tabfile != null) 
            {
                _logger.ShowLog(errmsg_tabfile, LogLevel.err);
                return;
            }

            _logger.ShowLog("finished open xlsx.", LogLevel.inf);

            #endregion

            if (!dataTab.GetSkillGroup(_skillIdBox.Text, out var group, out var errmsg_skill))
            {
                _logger.ShowLog(errmsg_skill!, LogLevel.err);
                return;
            }

            _logger.ShowLog($"finished get, found {group.Count} skills.", LogLevel.inf);
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
                var config = confWindow.Config;

                if (!ConfigData.CheckVaild(config, out ErrInfo[] errs))
                {
                    Array.ForEach(
                        errs,
                        e => _logger.ShowLog($"invalid config. property: {e.Name} reason: {e.Reason}", LogLevel.err));
                    return;
                }

                LocalService.SaveConfigDataToLocal(config);
                _logger.ShowLog($"config data is saved.", LogLevel.inf);
            }
        }
    }
}