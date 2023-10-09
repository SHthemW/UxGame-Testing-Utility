using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UxGame_Testing_Utility.Entities
{
    public readonly struct ErrInfo
    {
        public string Name { get; private init; }
        public string Reason { get; private init; }

        public ErrInfo(string name, string reason)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Reason = reason ?? throw new ArgumentNullException(nameof(reason));
        }
    }
}
