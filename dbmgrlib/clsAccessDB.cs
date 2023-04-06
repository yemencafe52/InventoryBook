using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbmgrlib
{
    public class AccessDB
    {
        private string connectionString;

        public AccessDB(string connectoinString)
        {
            this.connectionString = connectoinString;
        }
        public int ExcuteNonQuery(string sql)
        {
            int res = 0;

            try
            {
                OleDbConnection con = new OleDbConnection(connectionString);
                con.Open();
              
                OleDbCommand cmd = new OleDbCommand(sql, con);
                res = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return res;
        }

        public bool ExcuteQuery(string sql, ref DataTable dt)
        {
            bool res = false;

            try
            {
                using(OleDbDataAdapter ad = new OleDbDataAdapter(sql,new OleDbConnection(connectionString)))
                {
                    ad.Fill(dt);

                    if(dt.Rows.Count > 0)
                    {
                        res = true;
                    }
                }
            }
            catch { }
            return res;
        }
    }

}
