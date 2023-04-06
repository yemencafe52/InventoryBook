using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using invcore;
using Microsoft.Reporting.WinForms;

using System.Data;
using System.Data.OleDb;

using dbmgrlib;


namespace InventoryBook
{
    static class clsEntryPoint
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin flogin = new frmLogin();
            flogin.ShowDialog();

            if (flogin.Success)
            {
                Application.Run(new frmMain());
            }
           
        }
    }
}
