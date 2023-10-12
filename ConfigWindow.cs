using System;
using System.Collections.Generic;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility
{
    public partial class ConfigWindow : Form
    {
        public ConfigWindow()
        {
            InitializeComponent();
            if (LocalService.TryLoadConfigDataFromLocal(out DataConfig dataConf, out _))
                this.DataConfig = dataConf;
            if (LocalService.TryLoadConfigDataFromLocal(out UserConfig userConf, out _))
                this.UserConfig = userConf;
        }

        public DataConfig DataConfig
        {
            get => new(
                 _dataSrcPathBox.Text
                ,_deployProgPathBox.Text
                );
            private set
            {
                _dataSrcPathBox.Text = value.DataSrcPath;
                _deployProgPathBox.Text = value.DplProgPath;
            }
        }
        public UserConfig UserConfig
        {
            get => new(
                 _enableShowSkillDetailsChkBox.Checked
                ,_autoCloseChkBox.Checked
                ,_autoOpenChkBox.Checked
                );
            private set
            {
                _enableShowSkillDetailsChkBox.Checked = value.ShowSKillDetailsAfterLoad;
                _autoCloseChkBox.Checked = value.AutoCloseFileIfOccupying;
                _autoOpenChkBox.Checked = value.AutoOpenFileAfterProcess;
            }
        }
    }
}
