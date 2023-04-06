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
    public partial class frmOutGoingStockOrderEntry : Form
    {
        
        public frmOutGoingStockOrderEntry()
        {
            InitializeComponent();
            Preparing();
        }

        private bool Preparing()
        {
            bool res = false;

            DisableALL();
            Clear();

            button1.Enabled = true;
            button5.Enabled = true;

            return res;
        }

        private void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

            listView1.Items.Clear();
        }

        private void DisableALL()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

            dateTimePicker1.Enabled = false;


        }

        private void Save()
        {
            List<ItemMovement> items = new List<ItemMovement>();

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                Item item = null;
                new ItemController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).Query(listView1.Items[i].Text, ref item);

                items.Add(new ItemMovement(0, item.Number, (uint)numericUpDown1.Value,0, byte.Parse(listView1.Items[i].SubItems[3].Text) ,0,byte.Parse(listView1.Items[i].SubItems[4].Text)));
            }

            StockDocument sd = new StockDocument((uint)numericUpDown1.Value, dateTimePicker1.Value, (byte)numericUpDown2.Value, textBox1.Text, items, DocumentType.OutgoingStockerOrder);

            if (!(new StockDocumentController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).Add(sd)))
            {
                MessageBox.Show("OOPS, SOMETHING WENT WRONG :(");
                return;
            }

            Display(sd);
        }

        private void Search()
        {
            DisableALL();
            Clear();

            button6.Enabled = true;
            numericUpDown1.Enabled = true;
        }

        private void Cancel()
        {
            DisableALL();
            Clear();

            button1.Enabled = true;
            button5.Enabled = true;
        }

        private new void Update()
        {

        }

        private void New()
        {
            DisableALL();
            Clear();

            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown4.Enabled = true;
            numericUpDown5.Enabled = true;

            textBox1.Enabled = true;
            textBox2.Enabled = true;

            button8.Enabled = true;
            button9.Enabled = true;

            button4.Enabled = true;
            button6.Enabled = true;

            numericUpDown1.Value = new StockDocumentController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).GenerateNewDocumentNumber(DocumentType.OutgoingStockerOrder);
            numericUpDown2.Value = 1;
            numericUpDown2.Enabled = false;
        }

        private void Print()
        {
            DataTable dt = new invcore.DSet.tblStockDocumentsDataTable();
            new InCommingStockOrderReports(new dbmgrlib.AccessDB(Constatns.ConnectionString)).GetReprt1((int)numericUpDown1.Value, ref dt);

            ReportDataSource rdt = new ReportDataSource("tblTempTransctions", dt);
            frmReportViewer frv = new frmReportViewer(rdt, "InventoryBook.rptOutGoingStockOrderDocummenta.rdlc");
            frv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            New();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            InsertRecord();
        }

        private void InsertRecord()
        {
            Item item = null;
            if (new ItemController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).Query(textBox2.Text, ref item))
            {
                if (numericUpDown4.Value > 0)
                {
                    ListViewItem lvi = new ListViewItem(item.Code);
                    lvi.SubItems.Add(item.Name);
                    lvi.SubItems.Add(item.UnitName);
                    lvi.SubItems.Add(numericUpDown4.Value.ToString());
                    lvi.SubItems.Add(numericUpDown5.Value.ToString());

                    listView1.Items.Add(lvi);

                    numericUpDown3.Value = listView1.Items.Count;

                    ClearRecordEntry();
                    textBox2.Focus();

                }
                else if (numericUpDown5.Value > 0)
                {
                    ListViewItem lvi = new ListViewItem(item.Code);
                    lvi.SubItems.Add(item.Name);
                    lvi.SubItems.Add(item.UnitName);
                    lvi.SubItems.Add(numericUpDown4.Value.ToString());
                    lvi.SubItems.Add(numericUpDown5.Value.ToString());

                    listView1.Items.Add(lvi);

                    numericUpDown3.Value = listView1.Items.Count;

                    ClearRecordEntry();
                }
                else
                {
                    numericUpDown4.Focus();
                }
            }
        }

        private void ClearRecordEntry()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void DeleteRecord()
        {
            if (listView1.Items.Count > 0)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    int index = listView1.SelectedItems[0].Index;
                    listView1.Items.RemoveAt(index);
                    numericUpDown3.Value = listView1.Items.Count;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Item item = null;
            if (new ItemController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).Query(textBox2.Text, ref item))
            {
                textBox3.Text = item.Name;
                textBox4.Text = item.UnitName;
            }
            else
            {
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void Display(StockDocument document)
        {
            DisableALL();
            Clear();

            numericUpDown1.Value = document.Number;
            numericUpDown2.Value = document.WareHouse;

            dateTimePicker1.Value = document.Date;
            textBox1.Text = document.Descrption;

            for (int i = 0; i < document.Items.Count; i++)
            {
                Item item = null;
                new ItemController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).Query(document.Items[i].ItemNumber, ref item);

                ListViewItem lvi = new ListViewItem(item.Code);

                lvi.SubItems.Add(item.Name);
                lvi.SubItems.Add(item.UnitName.ToString());
                lvi.SubItems.Add(document.Items[i].ItemMovementOut.ToString());
                lvi.SubItems.Add(document.Items[i].ItemMovementBitOut.ToString());

                listView1.Items.Add(lvi);

            }

            numericUpDown3.Value = listView1.Items.Count;

            button1.Enabled = true;
            button5.Enabled = true;
            button7.Enabled = true;

        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StockDocument sd = null;
                if (new StockDocumentController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).Query((uint)numericUpDown1.Value, ref sd, DocumentType.OutgoingStockerOrder))
                {
                    Display(sd);
                }
            }
        }
    }
}
