using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UxGame_Testing_Utility.Entities;
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility.Actions
{
    internal abstract class ExecutableAction
    {
        protected readonly DataConfig _dataConf;
        protected readonly UserConfig _userConf;

        protected readonly LogService _infoLogger;
        protected readonly LogService _debugLogger;

        internal ExecutableAction(DataConfig dataConf, UserConfig userConf, LogService infoLogger, LogService debugLogger)
        {
            _dataConf = dataConf ?? throw new ArgumentNullException(nameof(dataConf));
            _userConf = userConf ?? throw new ArgumentNullException(nameof(userConf));
            _infoLogger = infoLogger ?? throw new ArgumentNullException(nameof(infoLogger));
            _debugLogger = debugLogger ?? throw new ArgumentNullException(nameof(debugLogger));
        }

        private ExecutableAction() => throw new NotImplementedException();
    }
}
