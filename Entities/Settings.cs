using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UxGame_Testing_Utility.Entities
{
    public sealed class DataConfig
    {
        public string DataSrcPath { get; init; }
        public string DplProgPath { get; init; }

        /// <remarks>
        /// time unit: ms
        /// </remarks>
        public int E2JWaitingTime { get; init; }
        /// <remarks>
        /// time unit: ms
        /// </remarks>
        public int J2BWaitingTime { get; init; }

        public DataConfig() 
        {
            DataSrcPath = string.Empty;
            DplProgPath = string.Empty;
        }
        public DataConfig(string dataSrcPath, string testResPath, int E2JWaitingTime, int J2BWaitingTime)
        {
            DataSrcPath = dataSrcPath ?? throw new ArgumentNullException(nameof(dataSrcPath));
            DplProgPath = testResPath ?? throw new ArgumentNullException(nameof(testResPath));
            this.E2JWaitingTime = E2JWaitingTime;
            this.J2BWaitingTime = J2BWaitingTime;
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

        public override string ToString()
        {
            return
                $"{nameof(DataSrcPath)}: {DataSrcPath} \n" +
                $"{nameof(DplProgPath)}: {DplProgPath} \n";
        }
    }  

    public sealed class UserConfig
    {
        public bool ShowSKillDetailsAfterLoad { get; private init; }
        public bool AutoCloseFileIfOccupying { get; private init; }
        public bool AutoOpenFileAfterProcess { get; private init; }

        public UserConfig() { }
        public UserConfig(bool showSKillDetailsAfterLoad, bool autoCloseFileIfOccupying, bool autoOpenFileAfterProcess = false)
        {
            ShowSKillDetailsAfterLoad = showSKillDetailsAfterLoad;
            AutoCloseFileIfOccupying = autoCloseFileIfOccupying;
            AutoOpenFileAfterProcess = autoOpenFileAfterProcess;
        }

        public override string ToString()
        {
            return
                $"{nameof(ShowSKillDetailsAfterLoad)}: {ShowSKillDetailsAfterLoad} \n";
        }
    }
}
