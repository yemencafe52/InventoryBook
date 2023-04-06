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
    public partial class frmInventoryTransction : Form
    {
        public frmInventoryTransction()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new invcore.DSet.tblItemTransctionsDataTable();
            new InventoryReport(new dbmgrlib.AccessDB(Constatns.ConnectionString)).GetReprt1(ref dt);

            ReportDataSource rdt = new ReportDataSource("tblTempTransctions", dt);
            frmReportViewer frv = new frmReportViewer(rdt, "InventoryBook.rptInventory.rdlc");
            frv.Show();
        }
    }
}
