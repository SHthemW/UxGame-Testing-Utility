using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UxGame_Testing_Utility.Services
{
    internal sealed class LogService
    {
        private readonly StringBuilder _logStrBuilder = new();
        private readonly TextBox? _logBox;

        internal LogService(TextBox logBox)
        {
            _logBox = logBox ?? throw new ArgumentNullException(nameof(logBox));
        }    
        internal void ShowLog(string msg, LogLevel level)
        {
            string prefix = level switch
            {         
                LogLevel.err => "[err]",
                LogLevel.inf => "[inf]",
                _ => string.Empty,
            };

            _logStrBuilder.AppendLine($"{prefix} {msg}");
            UpdateLog();
        }
        internal void CleanLog()
        {
            _logStrBuilder.Clear();
            UpdateLog();
        }

        private LogService()
        {
            _logBox = default;
        }
        private void UpdateLog()
        {
            _logBox!.Text = _logStrBuilder.ToString();
        }
    }

    internal enum LogLevel
    {
        inf = 0, err, non
    }
}
