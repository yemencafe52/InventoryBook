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
    public partial class frmLogin : Form
    {
        private bool success = false;

        public bool Success
        {
            get
            {
                return this.success;
            }
        }

        public frmLogin()
        {
            InitializeComponent();
            Preparing();
        }


        private bool Preparing()
        {
            bool res = false;
            CenterToParent();
            return res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            success = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
