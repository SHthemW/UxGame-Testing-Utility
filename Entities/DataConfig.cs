using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UxGame_Testing_Utility.Entities
{
    public readonly struct DataConfig
    {
        public string DataSrcPath { get; private init; }
        public string DplProgPath { get; private init; }
        public DataConfig(string dataSrcPath, string dplProgPath)
        {
            DataSrcPath = dataSrcPath ?? throw new ArgumentNullException(nameof(dataSrcPath));
            DplProgPath = dplProgPath ?? throw new ArgumentNullException(nameof(dplProgPath));
        }

        public override string ToString()
        {
            return 
                $"{nameof(DataSrcPath)}: {DataSrcPath} \n" +
                $"{nameof(DplProgPath)}: {DplProgPath} \n";
        }

        public static bool CheckVaild(DataConfig conf, out string?[] errmsgs)
        {
            List<string?> errList = new();

            if (!PathIsValid(conf.DataSrcPath, out var reason_datasrc))
                errList.Add($"config {nameof(conf.DataSrcPath)} is invalid. {reason_datasrc}");

            if (!PathIsValid(conf.DplProgPath, out var reason_dplprog))
                errList.Add($"config {nameof(conf.DplProgPath)} is invalid. {reason_dplprog}");

            errmsgs = errList.ToArray();
            return errmsgs.Length == 0;

            static bool PathIsValid(string path, out string? errmsg) 
            {
                if (string.IsNullOrEmpty(path))
                {
                    errmsg = "path str is empty.";
                    return false;
                }

                if (!File.Exists(path))
                {
                    errmsg = "such file was not found.";
                    return false;
                }

                errmsg = null;
                return true;
            }
        }
    }  

    public readonly struct UserConfig
    {
        public bool ShowSKillDetailsAfterLoad { get; private init; }

        public UserConfig(bool showSKillDetailsAfterLoad)
        {
            ShowSKillDetailsAfterLoad = showSKillDetailsAfterLoad;
        }
    }
}
