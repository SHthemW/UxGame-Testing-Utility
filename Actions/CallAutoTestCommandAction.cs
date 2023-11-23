using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility.Actions
{
    internal sealed class CallAutoTestCommandAction : ExecutableAction
    {
        public CallAutoTestCommandAction(DataConfig dataConf, UserConfig userConf, LogService infoLogger, LogService debugLogger) : base(dataConf, userConf, infoLogger, debugLogger)
        {
        }

        public async Task Execute(string testCaseName, bool useMaxLvSkill)
        {
            // startup server
            var server = new NetworkService();
            await server.ConnectToServer();

            #region Test: Call auto testing in Unity

            _debugLogger.ShowLog("calling auto tester in unity...", LogLevel.inf);

            var autoTestMsg = await server.SendCommand(ClientCmd.BEGIN_AUTO_TEST);

            var message = autoTestMsg.Split("--")[0];
            var recordWaitingSec = float.Parse(autoTestMsg.Split("--")[1]);
            _debugLogger.ShowLog($"{message} {recordWaitingSec}.", LogLevel.inf);

            await Task.Delay((int)recordWaitingSec * 1000);

            #endregion

            #region Test: Begin Record

            _debugLogger.ShowLog("start record...", LogLevel.inf);

            string gifFileName = useMaxLvSkill ? testCaseName + "_maxLv" : testCaseName;

            await new ScreenRecorder(
                scope: (
                    Width: _dataConf.RecScope_W,
                    Height: _dataConf.RecScope_H,
                    Left: _dataConf.RecScope_L,
                    Top: _dataConf.RecScope_T
                ),
                config: new RecordProperty(
                    FPS: 30,
                    outputPath: $"{_dataConf.TestRecPath}{gifFileName}.gif",
                    quality: _dataConf.RecQuality
                ),
                durationSec: _dataConf.RecDurtion)
            .Record();

            _debugLogger.ShowLog("finished record...", LogLevel.inf);

            #endregion

            server.Dispose();
        }
    }
}
