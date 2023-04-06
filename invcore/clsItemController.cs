using dbmgrlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace invcore
{
    public class ItemController
    {
        private AccessDB db;

        public ItemController(AccessDB db)
        {
            this.db = db;
        }

        public bool Add(Item item)
        {
            bool res = false;

            try
            {
                string sql = $"insert into tblItems (item_no,item_name,item_code,item_unit_name,item_unit_quantity,item_unit_bit_name,item_unit_bit_quantity) values({GenerateNewItemNumber()},'{item.Name}','{item.Code}','{item.UnitName}',{item.UnitQuatity},'{item.UnitBitName}',{item.UnitBitQuantity})";

                if (db.ExcuteNonQuery(sql) > 0) { res = true; }
            }
            catch { }
            return res;
        }

        public bool Update(Item item)
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

        public bool Delete(Item item)
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

        public bool Query(uint number, ref Item item)
        {

            bool res = false;

            string sql = $"select item_no,item_name,item_code,item_unit_name,item_unit_quantity,item_unit_bit_name,item_unit_bit_quantity from tblItems where item_no={number}";

            DataTable dt = new DSet.tblItemsDataTable();

            if (db.ExcuteQuery(sql, ref dt))
            {
                item = new Item(
                        Convert.ToByte(dt.Rows[0]["item_no"])
                        ,
                        Convert.ToString(dt.Rows[0]["item_name"])
                        ,
                        Convert.ToString(dt.Rows[0]["item_code"])
                        ,
                        Convert.ToString(dt.Rows[0]["item_unit_name"])
                        ,
                        Convert.ToUInt32(dt.Rows[0]["item_unit_quantity"])
                        ,
                        Convert.ToString(dt.Rows[0]["item_unit_bit_name"])
                        ,
                        Convert.ToUInt32(dt.Rows[0]["item_unit_bit_quantity"])

                        );

                res = true;
            }

            return res;

        }

        public bool Query(string number, ref Item item)
        {

            bool res = false;

            string sql = $"select item_no,item_name,item_code,item_unit_name,item_unit_quantity,item_unit_bit_name,item_unit_bit_quantity from tblItems where item_code='{number}'";

            DataTable dt = new DSet.tblItemsDataTable();

            if (db.ExcuteQuery(sql, ref dt))
            {
                item = new Item(
                        Convert.ToByte(dt.Rows[0]["item_no"])
                        ,
                        Convert.ToString(dt.Rows[0]["item_name"])
                        ,
                        Convert.ToString(dt.Rows[0]["item_code"])
                        ,
                        Convert.ToString(dt.Rows[0]["item_unit_name"])
                        ,
                        Convert.ToUInt32(dt.Rows[0]["item_unit_quantity"])
                        ,
                        Convert.ToString(dt.Rows[0]["item_unit_bit_name"])
                        ,
                        Convert.ToUInt32(dt.Rows[0]["item_unit_bit_quantity"])

                        );

                res = true;
            }
            
            return res;
        }

        public bool ReadALL(ref List<Item> items)
        {
            bool res = false;
            return  res;
        }

        public bool Search(string name,ref List<Item> items)
        {
            bool res = false;

            string sql = $"select item_no,item_name,item_code,item_unit_name,item_unit_quantity,item_unit_bit_name,item_unit_bit_quantity from tblItems where item_name like('%{name}%')";

            DataTable dt = new DSet.tblItemsDataTable();

            if(db.ExcuteQuery(sql,ref dt))
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    items.Add(new Item(
                        Convert.ToByte(dt.Rows[i]["item_no"])
                        ,
                        Convert.ToString(dt.Rows[i]["item_name"])
                        ,
                        Convert.ToString(dt.Rows[i]["item_code"])
                        ,
                        Convert.ToString(dt.Rows[i]["item_unit_name"])
                        ,
                        Convert.ToUInt32(dt.Rows[i]["item_unit_quantity"])
                        ,
                        Convert.ToString(dt.Rows[i]["item_unit_bit_name"])
                        ,
                        Convert.ToUInt32(dt.Rows[i]["item_unit_bit_quantity"])

                        ));
                }

                res = true;
            }

            return res;
        }


        private byte GenerateNewItemNumber()
        {
            byte res = 1;

            try
            {
                string sql = "select max(item_no) as res from tblItems";
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
