using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlStart.Utils
{
    public static class IniFunc
    {
        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        private static string iniPath = System.Windows.Forms.Application.StartupPath + "\\Vision_Config" + "\\SystemInfo.ini";


        public static string ReadIniData(string Section, string Key)
        {
            if (File.Exists(iniPath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, "0", temp, 1024, iniPath);
                return temp.ToString();
            }
            else
            {
                File.Create(iniPath);
                return string.Empty;
            }
        }



        public static bool WriteIniData(string Section, string Key, string Value)
        {
            if (File.Exists(iniPath))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniPath);
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                File.Create(iniPath);
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniPath);
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

    }
}
