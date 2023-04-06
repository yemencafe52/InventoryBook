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
    public partial class frmItemsViewer : Form
    {
        public frmItemsViewer()
        {
            InitializeComponent();
            Preparing();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool Preparing()
        {
            bool res = false;
           
            toolStripButton4.PerformClick();
            return res;
        }

        private void Clear()
        {
            listView1.Items.Clear();
            toolStripStatusLabel2.Text = "0";
        }

        private void Display(List<Item> items)
        {
            Clear();

            for(int i =0;i<items.Count;i++)
            {
                ListViewItem lvi = new ListViewItem(items[i].Code);
                lvi.SubItems.Add(items[i].Name);
                lvi.SubItems.Add(items[i].UnitName);

                listView1.Items.Add(lvi);
            }

            toolStripStatusLabel2.Text = items.Count.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmItemMgr fim = new frmItemMgr();
            fim.ShowDialog();

            toolStripButton4.PerformClick();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>();
            new ItemController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).Search(toolStripTextBox1.Text, ref items);
            Display(items);
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton4.PerformClick();
            }
        }

        private void frmItemsViewer_Shown(object sender, EventArgs e)
        {
            toolStripTextBox1.Focus();
        }
    }
}
