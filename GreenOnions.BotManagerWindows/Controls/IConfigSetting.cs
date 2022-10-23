using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.BotManagerWindows.Controls
{
    internal interface IConfigSetting
    {
        void LoadConfig();
        void SaveConfig();
        void UpdateCache();
    }
}
