using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoongEgg.LoongLogger
{
    public interface ILogger
    {
        bool WriteLine(MessageType type, string msg, string callerName, string path, int line);
    }
}
