using System;
using System.Collections.Generic;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility.Actions
{
    internal sealed class ReplaceDataInTableAction : ExecutableAction
    {
        public ReplaceDataInTableAction(DataConfig dataConf, UserConfig userConf, LogService infoLogger, LogService debugLogger) : base(dataConf, userConf, infoLogger, debugLogger)
        {
        }

        public async Task Execute(string testCaseName, bool useMaxLvSkill)
        {
            # region Close File Before Process

            if (_userConf.AutoCloseFileIfOccupying)
                ProcessService.KillWindow($"{Path.GetFileName(_dataConf.DataSrcPath)} - LibreOffice Calc");

            # endregion

            // excel file name: dataTab
            #region Load Excel File

            var dataTab = new ExcelService(_dataConf.DataSrcPath);
            await dataTab.InitExcelFile();

            _debugLogger.ShowLog("finished open xlsx.", LogLevel.inf);

            #endregion

            #region Get Test Target

            var group = await dataTab.GetSkillGroup(testCaseName);

            _debugLogger.ShowLog($"finished get test data. found {group.Count} skills.", LogLevel.inf);

            if (_userConf.ShowSKillDetailsAfterLoad)
            {
                _infoLogger.CleanLog();
                _infoLogger.ShowLog(group.ToString(), LogLevel.non);
            }

            #endregion

            #region Flush Test Data On Runtime

            await dataTab.ApplySkillGroupDataOn(group, 1);

            if (useMaxLvSkill)
                await dataTab.ApplySkillGroupDataOn(new SkillGroup(new Skill[1] { group.Skills[^1] }, testCaseName), 1);

            _debugLogger.ShowLog($"finished flush data.", LogLevel.inf);

            #endregion           

            #region Open File After Process

            if (_userConf.AutoOpenFileAfterProcess)
                ProcessService.Startup(
                    @"C:\\Program Files\\LibreOffice\\program\\scalc.exe",
                    _dataConf.DataSrcPath
                    );

            #endregion
        }
    }
}
