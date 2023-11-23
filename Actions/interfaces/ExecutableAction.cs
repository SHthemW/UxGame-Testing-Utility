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
        protected readonly IMainWindowService _program;

        public ExecutableAction(IMainWindowService program)
        {
            _program = program ?? throw new ArgumentNullException(nameof(program));
        }

        public abstract Task Execute();

        private ExecutableAction() => throw new NotImplementedException();
    }
}
