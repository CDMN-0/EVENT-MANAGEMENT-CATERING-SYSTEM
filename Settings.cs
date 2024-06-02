using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UserInput
{
    class Settings
    {
        public string iniPath = Application.StartupPath + @"\config.ini";

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string sectionName, string keyName, string defaultValue, StringBuilder returnedString, int size, string fileName);

        [DllImport("Kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string keyname, string value, string path);

        public StringBuilder sbTheme;
        public string theme { get; set; }

        public void readIni()
        {
            sbTheme = new StringBuilder(255); // Updated capacity to accommodate the returned string
            int resultSize = GetPrivateProfileString("SECTION", "key", "", sbTheme, sbTheme.Capacity, iniPath);
            this.theme = sbTheme.ToString();
        }

        public void writeIni(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, iniPath);
        }
    }
}