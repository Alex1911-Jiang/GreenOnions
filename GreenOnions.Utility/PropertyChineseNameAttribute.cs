using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.Utility
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyChineseNameAttribute : Attribute
    {
        public readonly string ChineseName = "";
        public PropertyChineseNameAttribute(string chineseName)
        {
            ChineseName = chineseName;
        }
    }
}
