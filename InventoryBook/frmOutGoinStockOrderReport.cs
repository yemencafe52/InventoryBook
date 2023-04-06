using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using invcore;

namespace InventoryBook
{
    public partial class frmOutGoinStockOrderReport : Form
    {
        public frmOutGoinStockOrderReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new invcore.DSet.tblStockDocumentsDataTable();
            new InCommingStockOrderReports(new dbmgrlib.AccessDB(Constatns.ConnectionString)).GetReprt1((int)numericUpDown1.Value, ref dt);

            ReportDataSource rdt = new ReportDataSource("tblTempTransctions", dt);
            frmReportViewer frv = new frmReportViewer(rdt, "InventoryBook.rptOutGoingStockOrderDocummenta.rdlc");
            frv.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = numericUpDown1.Value;
            numericUpDown2.Enabled = false;
        }
    }
}
