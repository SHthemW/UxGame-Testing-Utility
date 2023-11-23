using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UxGame_Testing_Utility.Entities;

namespace UxGame_Testing_Utility.Services
{
    internal interface IMainWindowService
    {
        DataConfig DataConfig { get; }
        UserConfig UserConfig { get; }

        LogService Console { get; }
        LogService InfoWindow { get; }
    }
}
