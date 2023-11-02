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
                , testRecPath: _testResSavePathBox.Text
                , E2JWaitingTime: int.Parse(_E2JWaitTimeBox.Text)
                , J2BWaitingTime: int.Parse(_J2BWaitTimeBox.Text)
                , rfsWaitingTime: int.Parse(_rfsWaitTImeBox.Text)
                , recScope_L: int.Parse(_recScopeLBox.Text)
                , recScope_T: int.Parse(_recScopeTBox.Text)
                , recScope_W: int.Parse(_recScopeWBox.Text)
                , recScope_H: int.Parse(_recScopeHBox.Text)
                , recQuality: int.Parse(_recPropQlBox.Text)
                , recDurtion: int.Parse(_recPropDuBox.Text)
                );
            private set
            {
                _dataSrcPathBox.Text = value.DataSrcPath;
                _testResSavePathBox.Text = value.TestRecPath;
                _E2JWaitTimeBox.Text = value.E2JWaitingTime.ToString();
                _J2BWaitTimeBox.Text = value.J2BWaitingTime.ToString();
                _rfsWaitTImeBox.Text = value.RfsWaitingTime.ToString();
                _recScopeLBox.Text = value.RecScope_L.ToString();
                _recScopeTBox.Text = value.RecScope_T.ToString();
                _recScopeWBox.Text = value.RecScope_W.ToString();
                _recScopeHBox.Text = value.RecScope_H.ToString();
                _recPropQlBox.Text = value.RecQuality.ToString();
                _recPropDuBox.Text = value.RecDurtion.ToString();
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
