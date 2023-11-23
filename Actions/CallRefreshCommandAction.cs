using System;
using System.Collections.Generic;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility.Actions
{
    internal sealed class CallRefreshCommandAction : ExecutableAction
    {
        public CallRefreshCommandAction(IMainWindowService program) : base(program)
        {
        }

        public async Task Execute()
        {
            // startup server
            var server = new NetworkService();
            await server.ConnectToServer();

            #region Deploy: Convert Excel To Json

            _program.Console.ShowLog("calling E2J server in unity...", LogLevel.inf);

            var e2jOprMsg = await server.SendCommand(ClientCmd.CONV_EXCEL_TO_JSON);
            _program.Console.ShowLog($"{e2jOprMsg}. waiting for {_program.DataConfig.E2JWaitingTime} ms...", LogLevel.inf);

            await Task.Delay(_program.DataConfig.E2JWaitingTime);

            #endregion

            #region Deploy: Convert Json To Bin

            server = new NetworkService();
            await server.ConnectToServer();

            _program.Console.ShowLog("calling J2B server in unity...", LogLevel.inf);

            var j2bOprMsg = await server.SendCommand(ClientCmd.CONV_JSON_TO_BIN);
            _program.Console.ShowLog($"{j2bOprMsg}. waiting for {_program.DataConfig.J2BWaitingTime} ms...", LogLevel.inf);

            await Task.Delay(_program.DataConfig.J2BWaitingTime);

            #endregion

            #region Deploy: Refresh Unity Editor

            server = new NetworkService();
            await server.ConnectToServer();

            _program.Console.ShowLog("refreshing scripts in unity...", LogLevel.inf);

            var refreshOprMsg = await server.SendCommand(ClientCmd.REFRESH_SCRIPTS);
            _program.Console.ShowLog($"{refreshOprMsg}.", LogLevel.inf);

            await Task.Delay(_program.DataConfig.RfsWaitingTime);

            #endregion

            server.Dispose();
        }
    }
}
