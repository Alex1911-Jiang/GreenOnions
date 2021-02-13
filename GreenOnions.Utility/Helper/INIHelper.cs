using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace GreenOnions.Utility.Helper
{
    [Obsolete]
    public class INIHelper
    {
        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 读取ini文件
        /// </summary>
        /// <param name="iniFilePath">ini文件地址</param>
        /// <param name="Section">名称</param>
        /// <param name="Key">关键字</param>
        /// <returns>读取到的结果</returns>
        public static string GetValue(string iniFilePath, string Section, string Key)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, "", temp, 1024, iniFilePath);
                return temp.ToString();
            }
            return "";
        }

        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="iniFilePath">ini文件地址</param>
        /// <param name="Section">名称</param>
        /// <param name="Key">关键字</param>
        /// <param name="Value">值</param>
        /// <returns>是否写入成功</returns>
        public static bool SetValue(string iniFilePath, string Section, string Key, string Value)
        {
            var pat = Path.GetDirectoryName(iniFilePath);
            if (!Directory.Exists(pat))
            {
                Directory.CreateDirectory(pat);
            }
            if (!File.Exists(iniFilePath))
            {
                File.Create(iniFilePath).Close();
            }
            long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
            if (OpStation == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void WriteLog(string iniFilePath, string log)
        {
            var pat = Path.GetDirectoryName(iniFilePath);
            if (!Directory.Exists(pat))
            {
                Directory.CreateDirectory(pat);
            }
            if (!File.Exists(iniFilePath))
            {
                File.Create(iniFilePath).Close();
            }
            File.WriteAllText(iniFilePath, log + "  " + DateTime.Now.ToString() + "\r\n");
        }
    }
}
