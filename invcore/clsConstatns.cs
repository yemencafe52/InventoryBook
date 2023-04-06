using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace invcore
{
    static public class Constatns
    {
        private static string dbPath = Application.StartupPath + "\\database\\db.accdb";
        private static string connectionStirng = $"provider=microsoft.ace.oledb.12.0;data source={dbPath}";

        public static string DbPath
        {
            get
            {
                return dbPath;
            }
        }

        public static string ConnectionString
        {
            get
            {
                return connectionStirng;
            }
        }
    }
}
