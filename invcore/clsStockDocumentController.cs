using dbmgrlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace invcore
{
    public class StockDocumentController
    {
        private AccessDB db;
        public StockDocumentController(AccessDB db)
        {
            this.db = db;
        }

        public bool Add(StockDocument doc)
        {
            bool res = false;

            try
            {
                if (!(doc.Items.Count > 0))
                {
                    throw new Exception();
                }

                uint i = 0;
                uint o = 0;
                uint bi = 0;
                uint bo = 0;

                foreach(ItemMovement im in doc.Items)
                {
                    i += im.ItemMovmentIN;
                    o += im.ItemMovementOut;

                    bi += im.ItemMovementBitIN;
                    bo += im.ItemMovementBitOut;
                }

                if ((i+o+bi+bo) == 0)
                {
                    throw new Exception();
                }

                string sql = $"insert into tblStockDocuments (doc_no,doc_date,doc_desc,doc_wh_no,dt_no) values({doc.Number},'{doc.Date.ToString()}','{doc.Descrption}',{doc.WareHouse},{(byte)doc.Type})";

                if (db.ExcuteNonQuery(sql) > 0) {
                    
                    foreach(ItemMovement im in doc.Items)
                    {
                        if(!(new ItemMovementController(db).Add(im)))
                        {
                            Delete(doc);
                            return res;
                        }
                    }

                    res = true; 
                }
            }
            catch { }
            return res;
        }

        public bool Update(StockDocument sd)
        {
            bool res = false;
            return res;
        }

        public bool Delete(StockDocument sd)
        {

            bool res = false;

            try
            {
                string sql = $"delete from tblStockDocuments where doc_no={sd.Number}";

                if (db.ExcuteNonQuery(sql) == 1)
                {
                    return res;
                }

            }
            catch { }
            return res;

        }

        public bool Search(DateTime from,DateTime to,ref List<StockDocument> r)
        {
            bool res = false;
            return res;
        }

        public bool Query(uint number,ref StockDocument sd,DocumentType type)
        {

            bool res = false;

            string sql = $"select doc_no,doc_date,doc_desc,doc_wh_no,dt_no from tblStockDocuments where dt_no={(byte)type} and doc_no={number}";

            DataTable dt = new DSet.tblStockDocumentsDataTable();

            if (db.ExcuteQuery(sql, ref dt))
            {
                List<ItemMovement> items = new List<ItemMovement>();
                uint docNumber = Convert.ToUInt32(dt.Rows[0]["doc_no"]);

                if (new ItemMovementController(db).Read(docNumber, ref items))
                {
                    sd = new StockDocument(docNumber
                        ,
                        Convert.ToDateTime(dt.Rows[0]["doc_date"])
                        ,
                        Convert.ToByte(dt.Rows[0]["doc_wh_no"])
                        ,
                        Convert.ToString(dt.Rows[0]["doc_desc"])
                        ,
                        items
                        ,
                        type
                        );
                        

                    res = true;
                }
            }

            return res;

        }


        public uint GenerateNewDocumentNumber(DocumentType type)
        {
            byte res = 1;

            try
            {
                string sql = $"select max(doc_no) as res from tblStockDocuments";
                //string sql = $"select max(doc_no) as res from tblStockDocuments where dt_no={(byte)type}";
                DataTable t = new DataTable("tblTemp");

                t.Columns.Add(new DataColumn("res"));

                if (db.ExcuteQuery(sql, ref t))
                {
                    res = byte.Parse(t.Rows[0]["res"].ToString());
                    res++;
                }
            }
            catch { }

            return res;
        }
    }
}
