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
            if (string.IsNullOrEmpty(_skillIdBox.Text))
            {
                _logger.ShowLog("[err] skill id is empty.");
                return;
            }
            if (!LocalService.TryLoadConfigDataFromLocal(out var config, out var err))
            {
                _logger.ShowLog($"[err] failed to load config. property: {err.Name}, reason: {err.Reason}");
                return;
            }

            _logger.ShowLog("[inf] config load success.");
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
                        e => _logger.ShowLog($"[err] invalid config. property: {e.Name} reason: {e.Reason}"));
                    return;
                }

                LocalService.SaveConfigDataToLocal(config);
                _logger.ShowLog($"[conf] config data is saved.");
            }
        }
    }
}