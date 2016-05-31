using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Prepod
{
    static public class Settings
    {
        static public string TestPath = Application.StartupPath + "\\Тесты\\";
        static public string CompilerPath = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\csc.exe";
        //static public int NumberCore = 2;
        
    }
}
