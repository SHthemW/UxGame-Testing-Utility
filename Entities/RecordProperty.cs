using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UxGame_Testing_Utility.Entities
{
    public readonly struct RecordProperty
    {    
        public string OutputPath { get; private init; }
        public int Fps { get; private init; }
        public int FrameDelay => (int)1000 / Fps;

        public RecordProperty(string outputPath, int FPS)
        {
            OutputPath = outputPath;
            Fps = FPS;
        }
    }
}
