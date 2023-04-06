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
    public partial class frmItemsReport : Form
    {
        public frmItemsReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                return;
            }

            DataTable dt = new  invcore.DSet.tblItemsDataTable();
            new ItemInfoReport(new dbmgrlib.AccessDB(Constatns.ConnectionString)).GetItems(textBox1.Text, textBox2.Text, ref dt);

            ReportDataSource rds = new ReportDataSource("tblItems", dt);
            frmReportViewer frv = new frmReportViewer(rds, "InventoryBook.rptItemsInfo.rdlc");
            frv.Show();
        }
    }
}
