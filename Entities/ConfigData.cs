using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UxGame_Testing_Utility.Entities
{
    public readonly struct ConfigData
    {
        public string DataSrcPath { get; private init; }
        public string DplProgPath { get; private init; }
        public ConfigData(string dataSrcPath, string dplProgPath)
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

        public static bool CheckVaild(ConfigData conf, out string?[] errmsgs)
        {
            List<string?> errList = new();

            if (!PathIsValid(conf.DataSrcPath, out var reason_datasrc))
                errList.Add($"config {nameof(conf.DataSrcPath)} is invalid. code: {reason_datasrc}");

            if (!PathIsValid(conf.DplProgPath, out var reason_dplprog))
                errList.Add($"config {nameof(conf.DplProgPath)} is invalid. code: {reason_dplprog}");

            errmsgs = errList.ToArray();
            return errmsgs.Length == 0;

            static bool PathIsValid(string path, out string? errmsg) 
            {
                if (string.IsNullOrEmpty(path))
                {
                    errmsg = "PathStrIsEmpty";
                    return false;
                }

                string fileExtName;
                try
                {
                    fileExtName = Path.GetExtension(path);
                }
                catch (ArgumentException)
                {
                    errmsg = "PathStrBadFormat";
                    return false;
                }

                if (string.IsNullOrEmpty(fileExtName))
                {
                    errmsg = "FileNotFound";
                    return false;
                }

                errmsg = null;
                return true;
            }
        }
    }  
}
