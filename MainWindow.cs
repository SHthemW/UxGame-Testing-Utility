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

        private void CleanBtn_Click(object sender, EventArgs e)
        {
            _logger.CleanLog();
        }
    }
}