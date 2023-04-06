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

namespace InventoryBook
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer(ReportDataSource rds,string tName)
        {
            InitializeComponent();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = tName;
            this.reportViewer1.LocalReport.DataSources.Add(rds);

        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
