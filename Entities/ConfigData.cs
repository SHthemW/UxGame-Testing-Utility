using System;
using System.Collections.Generic;
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

        public static bool CheckVaild(ConfigData conf, out ErrInfo[] errs)
        {
            List<ErrInfo> errList = new();

            if (!PathIsValid(conf.DataSrcPath, out var reason_datasrc))
                errList.Add(new ErrInfo(nameof(conf.DataSrcPath), reason_datasrc.ToString()));

            if (!PathIsValid(conf.DplProgPath, out var reason_dplprog))
                errList.Add(new ErrInfo(nameof(conf.DplProgPath), reason_dplprog.ToString()));

            errs = errList.ToArray();
            return errs.Length == 0;

            static bool PathIsValid(string path, out string result) 
            {
                if (string.IsNullOrEmpty(path))
                {
                    result = "PathStrIsEmpty";
                    return false;
                }

                string fileName;

                try
                {
                    fileName = Path.GetExtension(path);
                }
                catch (ArgumentException)
                {
                    result = "PathStrBadFormat";
                    return false;
                }

                if (string.IsNullOrEmpty(fileName))
                {
                    result = "FileNotFound";
                    return false;
                }

                result = "OK";
                return true;
            }
        }
    }  
}
