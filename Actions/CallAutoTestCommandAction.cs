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
        public CallAutoTestCommandAction(IMainWindowService program) : base(program)
        {
        }

        public async Task Execute(string testCaseName, bool useMaxLvSkill)
        {
            // startup server
            var server = new NetworkService();
            await server.ConnectToServer();

            #region Test: Call auto testing in Unity

            _program.Console.ShowLog("calling auto tester in unity...", LogLevel.inf);

            var autoTestMsg = await server.SendCommand(ClientCmd.BEGIN_AUTO_TEST);

            var message = autoTestMsg.Split("--")[0];
            var recordWaitingSec = float.Parse(autoTestMsg.Split("--")[1]);
            _program.Console.ShowLog($"{message} {recordWaitingSec}.", LogLevel.inf);

            await Task.Delay((int)recordWaitingSec * 1000);

            #endregion

            #region Test: Begin Record

            _program.Console.ShowLog("start record...", LogLevel.inf);

            string gifFileName = useMaxLvSkill ? testCaseName + "_maxLv" : testCaseName;

            await new ScreenRecorder(
                scope: (
                    Width: _program.DataConfig.RecScope_W,
                    Height: _program.DataConfig.RecScope_H,
                    Left: _program.DataConfig.RecScope_L,
                    Top: _program.DataConfig.RecScope_T
                ),
                config: new RecordProperty(
                    FPS: 30,
                    outputPath: $"{_program.DataConfig.TestRecPath}{gifFileName}.gif",
                    quality: _program.DataConfig.RecQuality
                ),
                durationSec: _program.DataConfig.RecDurtion)
            .Record();

            _program.Console.ShowLog("finished record...", LogLevel.inf);

            #endregion

            server.Dispose();
        }
    }
}
