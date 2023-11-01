using NPOI.HSSF.Record;
using SixLabors.ImageSharp.Formats.Gif;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UxGame_Testing_Utility.Entities;

namespace UxGame_Testing_Utility.Services
{
    public sealed class ScreenRecorder
    {
        private readonly int _durationSec;
        private readonly (int Width, int Height, int Left, int Top) _scope;
        private readonly RecordProperty _config;
        private int TotalFrameCount => _durationSec * _config.Fps;

        public ScreenRecorder((int Width, int Height, int Left, int Top) scope, int durationSec, RecordProperty config)
        {
            _scope = scope;
            _config = config;
            _durationSec = durationSec;
        }
        public async Task Record()
        {
            // 创建一个新的GIF动画
            using var gif = AnimatedGif.AnimatedGif.Create(_config.OutputPath, _config.FrameDelay);

            for (int i = 0; i < TotalFrameCount; i++)
            {
                using Bitmap bitmap = new(_scope.Width, _scope.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(_scope.Left, _scope.Top), Point.Empty, new Size(_scope.Width, _scope.Height));
                }
                await gif.AddFrameAsync(bitmap, quality: AnimatedGif.GifQuality.Bit8);
            }
        }

        private ScreenRecorder() { }  

    }
}
