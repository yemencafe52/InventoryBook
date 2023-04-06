using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using invcore;
using Microsoft.Reporting.WinForms;

namespace InventoryBook
{
    public partial class frmTotalTransctionReport : Form
    {
        public frmTotalTransctionReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new invcore.DSet.tblStockDocumentsDataTable();
            new ItemTotalTransctionReport(new dbmgrlib.AccessDB(Constatns.ConnectionString)).GetReprt1(ref dt);

            ReportDataSource rdt = new ReportDataSource("tblTempTransctions", dt);
            frmReportViewer frv = new frmReportViewer(rdt, "InventoryBook.rptTotalTransction.rdlc");
            frv.Show();
        }
    }
}
