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
        public string TestRecPath { get; init; }

        public int E2JWaitingTime { get; init; }
        public int J2BWaitingTime { get; init; }
        public int RfsWaitingTime { get; init; }

        public int RecScope_L { get; init; }
        public int RecScope_T { get; init; }
        public int RecScope_W { get; init; }
        public int RecScope_H { get; init; }
        public int RecQuality { get; init; }
        public int RecDurtion { get; init; }

        public DataConfig() 
        {
            DataSrcPath = string.Empty;
            TestRecPath = string.Empty;
        }
        public DataConfig(
            string dataSrcPath,
            string testRecPath,
            int E2JWaitingTime,
            int J2BWaitingTime,
            int rfsWaitingTime,
            int recScope_L,
            int recScope_T,
            int recScope_W,
            int recScope_H,
            int recQuality,
            int recDurtion)
        {
            DataSrcPath = dataSrcPath ?? throw new ArgumentNullException(nameof(dataSrcPath));
            TestRecPath = testRecPath ?? throw new ArgumentNullException(nameof(testRecPath));
            this.E2JWaitingTime = E2JWaitingTime;
            this.J2BWaitingTime = J2BWaitingTime;
            this.RfsWaitingTime = rfsWaitingTime;
            RecScope_L = recScope_L;
            RecScope_T = recScope_T;
            RecScope_W = recScope_W;
            RecScope_H = recScope_H;
            RecQuality = recQuality;
            RecDurtion = recDurtion;
        }
        public bool ContainsInvaild(out string?[] errmsgs)
        {
            List<string?> errList = new();

            #region DataSrcPath

            if (!DataSrcPath.Contains('.'))
                errList.Add($"config {nameof(DataSrcPath)} must be a specific file.");

            if (!File.Exists(DataSrcPath))
                errList.Add($"file {nameof(DataSrcPath)} not exist.");

            #endregion

            #region TestRecPath

            if (TestRecPath.Contains('.'))
                errList.Add($"config {nameof(TestRecPath)} must be a directory, not file.");

            if (!TestRecPath.EndsWith('\\'))
                errList.Add($"config {nameof(TestRecPath)} must end with menu split char.");

            #endregion

            #region WaitingTime

            if (E2JWaitingTime > 20000 || J2BWaitingTime > 20000 || RfsWaitingTime > 20000)
                errList.Add($"action wait time seems too long. please check.");

            if (E2JWaitingTime == 0 || J2BWaitingTime == 0 || RfsWaitingTime == 0)
                errList.Add($"action wait time seems not initalized. please check.");

            #endregion

            errmsgs = errList.ToArray();
            return errmsgs.Length != 0;
        }

        public override string ToString()
        {
            return
                $"{nameof(DataSrcPath)}: {DataSrcPath} \n" +
                $"{nameof(TestRecPath)}: {TestRecPath} \n";
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
