using NPOI.SS.Formula.Functions;
using NPOI.Util;
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
        }

        public DataConfig DataConfig
        {
            get => new(
                  dataSrcPath: _dataSrcPathBox.Text
                , testResPath: _testResSavePathBox.Text
                , E2JWaitingTime: int.Parse(_E2JWaitTimeBox.Text)
                , J2BWaitingTime: int.Parse(_J2BWaitTimeBox.Text)
                );
            private set
            {
                _dataSrcPathBox.Text = value.DataSrcPath;
                _testResSavePathBox.Text = value.DplProgPath;
                _E2JWaitTimeBox.Text = value.E2JWaitingTime.ToString();
                _J2BWaitTimeBox.Text = value.J2BWaitingTime.ToString();
            }
        }
        public UserConfig UserConfig
        {
            get => new(
                  _enableShowSkillDetailsChkBox.Checked
                , _autoCloseChkBox.Checked
                , _autoOpenChkBox.Checked
                );
            private set
            {
                _enableShowSkillDetailsChkBox.Checked = value.ShowSKillDetailsAfterLoad;
                _autoCloseChkBox.Checked = value.AutoCloseFileIfOccupying;
                _autoOpenChkBox.Checked = value.AutoOpenFileAfterProcess;
            }
        }

        public async Task InitShowData()
        {
            DataConfig = await LocalService.TryLoadConfigDataFromLocal<DataConfig>();
            UserConfig = await LocalService.TryLoadConfigDataFromLocal<UserConfig>();
        }
    }
}
