using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace invcore
{
    public class clsTeset
    {
        static void Main()
        {
            //Item i = new Item(1, "صنف3", "003", "درزن", 12, "حبة", 1);
            //new ItemController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).Add(i);

            //  StockDocument doc = new StockDocument(11, DateTime.Now, 1, "test", new List<ItemMovement>() { new ItemMovement(3, 1, 11, 10, 0, 0, 0), new ItemMovement(4, 2, 11, 10, 0, 0, 0) },DocumentType.IncommingStockOrder);
            //  new StockDocumentController(new dbmgrlib.AccessDB(Constatns.ConnectionString)).Add(doc);

            //DataTable dt = new DSet.tblTempTransctionsDataTable();
            //bool res = new InCommingStockOrderReports(new dbmgrlib.AccessDB(Constatns.ConnectionString)).GetReprt1(11,ref dt);



            //DataTable dt = new invcore.DSet.tblItemTransctionsDataTable();

            //bool res = new ItemsTransctionReport(new AccessDB(Constatns.ConnectionString)).GetReprt1(ref dt);

            //ReportDataSource rds = new ReportDataSource("tblTempTransctions", dt);



            //DataTable dt = new invcore.DSet.tblItemTransctionsDataTable();


            //bool res = new InventoryReport(new AccessDB(Constatns.ConnectionString)).GetReprt1(ref dt);

            //ReportDataSource rds = new ReportDataSource("tblTempTransctions", dt);

            //Application.Run(new frmReportViewer(rds, "InventoryBook.rptInventory.rdlc"));


            //List<Item> items = new List<Item>();
            //new ItemController(new AccessDB(Constatns.ConnectionString)).Search("", ref items);

            //StockDocument doc1 = null;
            //new StockDocumentController(new AccessDB(Constatns.ConnectionString)).Query(11, ref doc1, DocumentType.IncommingStockOrder);


        }
    }
}
