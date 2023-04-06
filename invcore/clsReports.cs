using dbmgrlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace invcore
{
    public class Reports
    {
        private string connectionString;

        public Reports(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DataTable GetDetailsTransction()
        {
            DataTable res = new DSet.tblTempTransctionsDataTable();

            try
            {
                string sql = "";
                using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, new OleDbConnection(connectionString)))
                {
                    ad.Fill(res);
                }
            }
            catch { }
            return res;
        }

        public bool GetDetailsTransctionReprts(ref DataTable dt)
        {
            bool res = false;

            try
            {
                string sql = $"SELECT tblDocType.dt_no, tblDocType.dt_name, tblStockDocuments.doc_no, tblStockDocuments.doc_date, tblStockDocuments.doc_desc, tblStockDocuments.doc_wh_no, tblStockDocuments.dt_no AS Expr1, tblItemTransctions.it_no, tblItemTransctions.item_no, tblItemTransctions.doc_no AS Expr2, tblItemTransctions.it_in, tblItemTransctions.it_out, tblItemTransctions.it_bit_in, tblItemTransctions.it_bit_out, tblItems.item_no AS Expr3, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name, tblItems.item_unit_quantity, tblItems.item_unit_bit_name, tblItems.item_unit_bit_quantity FROM ((tblDocType INNER JOIN tblStockDocuments ON tblDocType.dt_no = tblStockDocuments.dt_no) INNER JOIN tblItemTransctions ON tblStockDocuments.doc_no = tblItemTransctions.doc_no) INNER JOIN tblItems ON tblItemTransctions.item_no = tblItems.item_no";
                AccessDB db = new AccessDB(connectionString);
                res = db.ExcuteQuery(sql, ref dt);
            }
            catch { }

            return res;
        }

    }

    public class InCommingStockOrderReports
    {
        private AccessDB db;
        public InCommingStockOrderReports(AccessDB db)
        {
            this.db = db;
        }

        public bool GetReprt1(int number,ref DataTable dt)
        {
            bool res = false;

            try
            {
                string sql = $"SELECT tblDocType.dt_no, tblDocType.dt_name, tblStockDocuments.doc_no, tblStockDocuments.doc_date, tblStockDocuments.doc_desc, tblStockDocuments.doc_wh_no, tblStockDocuments.dt_no AS Expr1, tblItemTransctions.it_no, tblItemTransctions.item_no, tblItemTransctions.doc_no AS Expr2, tblItemTransctions.it_in, tblItemTransctions.it_out, tblItemTransctions.it_bit_in, tblItemTransctions.it_bit_out, tblItems.item_no AS Expr3, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name, tblItems.item_unit_quantity, tblItems.item_unit_bit_name, tblItems.item_unit_bit_quantity FROM ((tblDocType INNER JOIN tblStockDocuments ON tblDocType.dt_no = tblStockDocuments.dt_no) INNER JOIN tblItemTransctions ON tblStockDocuments.doc_no = tblItemTransctions.doc_no) INNER JOIN tblItems ON tblItemTransctions.item_no = tblItems.item_no where tblStockDocuments.doc_no={number}";
                res = db.ExcuteQuery(sql, ref dt);
            }
            catch { }

            return res;
        }
    }

    public class OutGoingStockOrderReports
    {
        private AccessDB db;
        public OutGoingStockOrderReports(AccessDB db)
        {
            this.db = db;
        }

        public bool GetReprt1(int number, ref DataTable dt)
        {
            bool res = false;

            try
            {
                string sql = $"SELECT tblDocType.dt_no, tblDocType.dt_name, tblStockDocuments.doc_no, tblStockDocuments.doc_date, tblStockDocuments.doc_desc, tblStockDocuments.doc_wh_no, tblStockDocuments.dt_no AS Expr1, tblItemTransctions.it_no, tblItemTransctions.item_no, tblItemTransctions.doc_no AS Expr2, tblItemTransctions.it_in, tblItemTransctions.it_out, tblItemTransctions.it_bit_in, tblItemTransctions.it_bit_out, tblItems.item_no AS Expr3, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name, tblItems.item_unit_quantity, tblItems.item_unit_bit_name, tblItems.item_unit_bit_quantity FROM ((tblDocType INNER JOIN tblStockDocuments ON tblDocType.dt_no = tblStockDocuments.dt_no) INNER JOIN tblItemTransctions ON tblStockDocuments.doc_no = tblItemTransctions.doc_no) INNER JOIN tblItems ON tblItemTransctions.item_no = tblItems.item_no where tblStockDocuments.doc_no={number}";
                res = db.ExcuteQuery(sql, ref dt);
            }
            catch { }

            return res;
        }
    }

    public class ItemsTransctionReport
    {
        private AccessDB db;
        public ItemsTransctionReport(AccessDB db)
        {
            this.db = db;
        }

        public bool GetReprt1(ref DataTable dt)
        {
            bool res = false;

            try
            {
                string sql = $"SELECT tblDocType.dt_no, tblDocType.dt_name, tblStockDocuments.doc_no, tblStockDocuments.doc_date, tblStockDocuments.doc_desc, tblStockDocuments.doc_wh_no, tblStockDocuments.dt_no AS Expr1, tblItemTransctions.it_no, tblItemTransctions.item_no, tblItemTransctions.doc_no AS Expr2, tblItemTransctions.it_in, tblItemTransctions.it_out, tblItemTransctions.it_bit_in, tblItemTransctions.it_bit_out, tblItems.item_no AS Expr3, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name, tblItems.item_unit_quantity, tblItems.item_unit_bit_name, tblItems.item_unit_bit_quantity FROM ((tblDocType INNER JOIN tblStockDocuments ON tblDocType.dt_no = tblStockDocuments.dt_no) INNER JOIN tblItemTransctions ON tblStockDocuments.doc_no = tblItemTransctions.doc_no) INNER JOIN tblItems ON tblItemTransctions.item_no = tblItems.item_no";
                res = db.ExcuteQuery(sql, ref dt);
            }
            catch { }

            return res;
        }
    }

    public class ItemTotalTransctionReport
    {
        private AccessDB db;
        public ItemTotalTransctionReport(AccessDB db)
        {
            this.db = db;
        }

        public bool GetReprt1(ref DataTable dt)
        {
            bool res = false;

            try
            {
                string sql = $"SELECT tblStockDocuments.doc_wh_no, sum(tblItemTransctions.it_in) AS it_IN, sum(tblItemTransctions.it_out) AS it_OUT, sum(tblItemTransctions.it_bit_in) AS it_bit_in, sum(tblItemTransctions.it_bit_out) AS it_bit_out, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name FROM ((tblDocType INNER JOIN tblStockDocuments ON tblDocType.dt_no = tblStockDocuments.dt_no) INNER JOIN tblItemTransctions ON tblStockDocuments.doc_no = tblItemTransctions.doc_no) INNER JOIN tblItems ON tblItemTransctions.item_no = tblItems.item_no GROUP BY tblStockDocuments.doc_wh_no, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name";
                res = db.ExcuteQuery(sql, ref dt);
            }
            catch { }

            return res;
        }
    }

    public class InventoryReport
    {
        private AccessDB db;
        public InventoryReport(AccessDB db)
        {
            this.db = db;
        }

        public bool GetReprt1(ref DataTable dt,DateTime from ,DateTime to)
        {
            bool res = false;

            try
            {
                string sql = $"SELECT tblStockDocuments.doc_wh_no, ((((sum(tblItemTransctions.it_in* item_unit_quantity) +  sum(tblItemTransctions.it_bit_in))))) - (sum(tblItemTransctions.it_out* item_unit_quantity) +  sum(tblItemTransctions.it_bit_out)) AS it_IN, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name,item_unit_quantity FROM((tblDocType INNER JOIN tblStockDocuments ON tblDocType.dt_no = tblStockDocuments.dt_no) INNER JOIN tblItemTransctions ON tblStockDocuments.doc_no = tblItemTransctions.doc_no) INNER JOIN tblItems ON tblItemTransctions.item_no = tblItems.item_no GROUP BY tblStockDocuments.doc_wh_no, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name, item_unit_quantity";
                res = db.ExcuteQuery(sql, ref dt);
            }
            catch { }

            return res;
        }

        public bool GetReprt1(ref DataTable dt)
        {
            bool res = false;

            try
            {
                string sql = $"SELECT tblStockDocuments.doc_wh_no, ((((sum(tblItemTransctions.it_in* item_unit_quantity) +  sum(tblItemTransctions.it_bit_in))))) - (sum(tblItemTransctions.it_out* item_unit_quantity) +  sum(tblItemTransctions.it_bit_out)) AS it_IN, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name,item_unit_quantity FROM((tblDocType INNER JOIN tblStockDocuments ON tblDocType.dt_no = tblStockDocuments.dt_no) INNER JOIN tblItemTransctions ON tblStockDocuments.doc_no = tblItemTransctions.doc_no) INNER JOIN tblItems ON tblItemTransctions.item_no = tblItems.item_no GROUP BY tblStockDocuments.doc_wh_no, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name, item_unit_quantity";
                res = db.ExcuteQuery(sql, ref dt);
            }
            catch { }

            return res;
        }

        public bool GetReprt1(ref DataTable dt,Item fromItem,Item toItem)
        {
            bool res = false;

            try
            {
                string sql = $"SELECT tblStockDocuments.doc_wh_no, ((((sum(tblItemTransctions.it_in* item_unit_quantity) +  sum(tblItemTransctions.it_bit_in))))) - (sum(tblItemTransctions.it_out* item_unit_quantity) +  sum(tblItemTransctions.it_bit_out)) AS it_IN, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name,item_unit_quantity FROM((tblDocType INNER JOIN tblStockDocuments ON tblDocType.dt_no = tblStockDocuments.dt_no) INNER JOIN tblItemTransctions ON tblStockDocuments.doc_no = tblItemTransctions.doc_no) INNER JOIN tblItems ON tblItemTransctions.item_no = tblItems.item_no GROUP BY tblStockDocuments.doc_wh_no, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name, item_unit_quantity";
                res = db.ExcuteQuery(sql, ref dt);
            }
            catch { }

            return res;
        }

        public bool GetReprt1(ref DataTable dt, DateTime from, DateTime to, Item fromItem, Item toItem)
        {
            bool res = false;

            try
            {
                string sql = $"SELECT tblStockDocuments.doc_wh_no, ((((sum(tblItemTransctions.it_in* item_unit_quantity) +  sum(tblItemTransctions.it_bit_in))))) - (sum(tblItemTransctions.it_out* item_unit_quantity) +  sum(tblItemTransctions.it_bit_out)) AS it_IN, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name,item_unit_quantity FROM((tblDocType INNER JOIN tblStockDocuments ON tblDocType.dt_no = tblStockDocuments.dt_no) INNER JOIN tblItemTransctions ON tblStockDocuments.doc_no = tblItemTransctions.doc_no) INNER JOIN tblItems ON tblItemTransctions.item_no = tblItems.item_no GROUP BY tblStockDocuments.doc_wh_no, tblItems.item_name, tblItems.item_code, tblItems.item_unit_name, item_unit_quantity";
                res = db.ExcuteQuery(sql, ref dt);
            }
            catch { }

            return res;
        }
    }

    public class ItemInfoReport
    {
        private AccessDB db;

        public ItemInfoReport(AccessDB db)
        {
            this.db = db;
        }

        public bool GetItems(string from ,string to,ref DataTable dt)
        {
            bool res = false;

            try
            {
                string sql = $"select item_no,item_name,item_code,item_unit_name,item_unit_quantity,item_unit_bit_name,item_unit_bit_quantity from tblItems where item_code between '{from}' and '{to}'";

                if (this.db.ExcuteQuery(sql,ref dt))
                {
                    res = true;
                }
            }
            catch { }
            return res;
        }

    }
}





