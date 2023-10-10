﻿using System;
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
            _logStrBuilder.AppendLine($"[{level}] {msg}");
            UpdateLog();
        }
        internal void ShowLog(string[] msgs, LogLevel level)
        {
            Array.ForEach(
                msgs,
                msg => ShowLog(msg, level));
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
        inf = 0, err
    }
}
