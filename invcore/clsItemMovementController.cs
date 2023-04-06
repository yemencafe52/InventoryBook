using dbmgrlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace invcore
{
    public class ItemMovementController
    {
        private AccessDB db;
        public ItemMovementController(AccessDB db)
        {
            this.db = db;
        }

        public bool Add(ItemMovement item)
        {
            bool res = false;

            try
            {
                string sql = $"insert into tblItemTransctions (" +
                    $"item_no" +
                    $"," +
                    $"doc_no" +
                    $"," +
                    $"it_in" +
                    $"," +
                    $"it_out" +
                    $"," +
                    $"it_bit_in" +
                    $"," +
                    $"it_bit_out" +
                    $") values" +
                    $"(" +
                    $"{item.ItemNumber}" +
                    $"," +
                    $"{item.DocumentNumber}" +
                    $"," +
                    $"{item.ItemMovmentIN}" +
                    $"," +
                    $"{item.ItemMovementOut}" +
                    $"," +
                    $"{item.ItemMovementBitIN}" +
                    $"," +
                    $"{item.ItemMovementBitOut}" +
                    $")";
                    

                if (db.ExcuteNonQuery(sql) > 0) { res = true; }
            }
            catch { }
            return res;
        }

        public bool Update(ItemMovement item)
        {
            bool res = false;

            try
            {
                string sql = $"";

                if (db.ExcuteNonQuery(sql) > 0) { res = true; }
            }
            catch { }
            return res;
        }

        public bool Delete(ItemMovement item)
        {
            bool res = false;

            try
            {
                string sql = $"";

                if (db.ExcuteNonQuery(sql) > 0) { res = true; }
            }
            catch { }
            return res;
        }
        public bool Read(uint doc_number, ref List<ItemMovement> items)
        {
           
            bool res = false;

            string sql = $"select it_no,item_no,doc_no,it_in,it_out,it_bit_in,it_bit_out from tblItemTransctions where doc_no={doc_number}";

            DataTable dt = new DSet.tblItemTransctionsDataTable();

            if (db.ExcuteQuery(sql, ref dt))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    items.Add(new ItemMovement(
                        Convert.ToUInt32(dt.Rows[i]["it_no"])
                        ,
                        Convert.ToUInt32(dt.Rows[i]["item_no"])
                        ,
                        Convert.ToUInt32(dt.Rows[i]["doc_no"])
                        ,
                        Convert.ToUInt32(dt.Rows[i]["it_in"])
                        ,
                        Convert.ToUInt32(dt.Rows[i]["it_out"])
                        ,
                        Convert.ToUInt32(dt.Rows[i]["it_bit_in"])
                        ,
                        Convert.ToUInt32(dt.Rows[i]["it_bit_out"])
                        )
                        );
                }

                res = true;
            }

            return res;
        }

       
    }
     
}
