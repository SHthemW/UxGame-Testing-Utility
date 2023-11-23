using System;
using System.Collections.Generic;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility.Actions
{
    internal sealed class CallRefreshCommandAction : ExecutableAction
    {
        public CallRefreshCommandAction(DataConfig dataConf, UserConfig userConf, LogService infoLogger, LogService debugLogger) : base(dataConf, userConf, infoLogger, debugLogger)
        {
        }

        public async Task Execute()
        {
            // startup server
            var server = new NetworkService();
            await server.ConnectToServer();

            #region Deploy: Convert Excel To Json

            _debugLogger.ShowLog("calling E2J server in unity...", LogLevel.inf);

            var e2jOprMsg = await server.SendCommand(ClientCmd.CONV_EXCEL_TO_JSON);
            _debugLogger.ShowLog($"{e2jOprMsg}. waiting for {_dataConf.E2JWaitingTime} ms...", LogLevel.inf);

            await Task.Delay(_dataConf.E2JWaitingTime);

            #endregion

            #region Deploy: Convert Json To Bin

            server = new NetworkService();
            await server.ConnectToServer();

            _debugLogger.ShowLog("calling J2B server in unity...", LogLevel.inf);

            var j2bOprMsg = await server.SendCommand(ClientCmd.CONV_JSON_TO_BIN);
            _debugLogger.ShowLog($"{j2bOprMsg}. waiting for {_dataConf.J2BWaitingTime} ms...", LogLevel.inf);

            await Task.Delay(_dataConf.J2BWaitingTime);

            #endregion

            #region Deploy: Refresh Unity Editor

            server = new NetworkService();
            await server.ConnectToServer();

            _debugLogger.ShowLog("refreshing scripts in unity...", LogLevel.inf);

            var refreshOprMsg = await server.SendCommand(ClientCmd.REFRESH_SCRIPTS);
            _debugLogger.ShowLog($"{refreshOprMsg}.", LogLevel.inf);

            await Task.Delay(_dataConf.RfsWaitingTime);

            #endregion

            server.Dispose();
        }
    }
}
