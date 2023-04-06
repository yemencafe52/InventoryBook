using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryBook
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Preparing();
        }

        private bool Preparing()
        {
            bool res = false;
            CenterToParent();

            res = true;
            return res;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;

            if (tn != null)
            {
                if(tn.Tag != null)
                {
                    byte index = byte.Parse(tn.Tag.ToString());

                    switch (index)
                    {
                        case 1:
                            {

                                break;
                            }
                        case 2:
                            {
                                frmItemsViewer fiv = new frmItemsViewer();
                                fiv.Show();
                                break;
                            }
                        case 3:
                            {
                                frmInCommingStockOrderEntry fisoe = new frmInCommingStockOrderEntry();
                                fisoe.Show();
                                break;
                            }
                        case 4:
                            {
                                frmOutGoingStockOrderEntry fogstoe = new frmOutGoingStockOrderEntry();
                                fogstoe.Show();
                                break;
                            }
                        case 5:
                            {
                                frmItemsReport fir = new frmItemsReport();
                                fir.Show();
                                break;
                            }
                        case 6:
                            {
                                frmInComingStockOrderReport ficsor = new frmInComingStockOrderReport();
                                ficsor.Show();
                                break;
                            }
                        case 7:
                            {
                                frmOutGoinStockOrderReport fosor = new frmOutGoinStockOrderReport();
                                //fosor.MdiParent = this;
                                fosor.Show();
                                break;
                            }
                        case 8:
                            {
                                frmDetaileTransctionReport fdtr = new frmDetaileTransctionReport();
                                fdtr.Show();
                                break;
                            }
                        case 9:
                            {
                                frmTotalTransctionReport fttr = new frmTotalTransctionReport();
                                fttr.Show();
                                break;
                            }
                        case 10:
                            {
                                frmInventoryTransction fit = new frmInventoryTransction();
                                fit.Show();
                                break;
                            }
                        case 11:
                            {
                                frmChangePassword fcp = new frmChangePassword();
                                fcp.ShowDialog();
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }

    
}
