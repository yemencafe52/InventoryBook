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

namespace InventoryBook
{
    public partial class frmItemMgr : Form
    {
        public frmItemMgr()
        {
            InitializeComponent();
            Preparing();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool Preparing()
        {
            bool res = false;
            
            return res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Focus();
                return;
            }

            if (!(numericUpDown1.Value > 0))
            {
                numericUpDown1.Focus();
                return;
            }

            if (!(numericUpDown2.Value > 0))
            {
                numericUpDown2.Focus();
                return;
            }


            Item i = new Item(0, textBox2.Text, textBox1.Text,textBox3.Text, (uint)numericUpDown1.Value, textBox4.Text, (uint)numericUpDown2.Value);
            
            if(!(new ItemController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).Add(i)))
            {
                MessageBox.Show("OOPS, SOMETHING WENT WRONG :(");
                return;
            }

            this.Close();

        }
    }
}
