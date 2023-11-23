using System;
using System.Collections.Generic;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility.Actions
{
    internal sealed class ReplaceDataInTableAction : ExecutableAction
    {
        public ReplaceDataInTableAction(IMainWindowService program) : base(program)
        {
        }

        private string TestCaseName => _program.CurrentInputContent.Replace("*", "");
        private bool UseMaxLvSkill => _program.CurrentInputContent.Contains('*');

        public override async Task Execute()
        {
            # region Close File Before Process

            if (_program.UserConfig.AutoCloseFileIfOccupying)
                ProcessService.KillWindow($"{Path.GetFileName(_program.DataConfig.DataSrcPath)} - LibreOffice Calc");

            # endregion

            // excel file name: dataTab
            #region Load Excel File

            var dataTab = new ExcelService(_program.DataConfig.DataSrcPath);
            await dataTab.InitExcelFile();

            _program.Console.ShowLog("finished open xlsx.", LogLevel.inf);

            #endregion

            #region Get Test Target

            var group = await dataTab.GetSkillGroup(TestCaseName);

            _program.Console.ShowLog($"finished get test data. found {group.Count} skills.", LogLevel.inf);

            if (_program.UserConfig.ShowSKillDetailsAfterLoad)
            {
                _program.InfoWindow.CleanLog();
                _program.InfoWindow.ShowLog(group.ToString(), LogLevel.non);
            }

            #endregion

            #region Flush Test Data On Runtime

            await dataTab.ApplySkillGroupDataOn(group, 1);

            if (UseMaxLvSkill)
                await dataTab.ApplySkillGroupDataOn(new SkillGroup(new Skill[1] { group.Skills[^1] }, TestCaseName), 1);

            _program.Console.ShowLog($"finished flush data.", LogLevel.inf);

            #endregion           

            #region Open File After Process

            if (_program.UserConfig.AutoOpenFileAfterProcess)
                ProcessService.Startup(
                    @"C:\\Program Files\\LibreOffice\\program\\scalc.exe",
                    _program.DataConfig.DataSrcPath
                    );

            #endregion
        }
    }
}
