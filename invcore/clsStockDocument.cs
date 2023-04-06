using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invcore
{
    public enum DocumentType:byte
    {
        IncommingStockOrder =1,
        OutgoingStockerOrder
    }

    public class StockDocument
    {
        private uint number;
        private DateTime date;
        private byte wh_no;
        private string desc;
        private List<ItemMovement> items = new List<ItemMovement>();
        private DocumentType dt;

        public StockDocument(
             uint number,
             DateTime date,
             byte wh_no,
             string desc,
             List<ItemMovement> items,
             DocumentType dt
         )
        {
            this.number = number;
            this.date = date;
            this.wh_no = wh_no;
            this.desc = desc;
            this.items.AddRange(items);
            this.dt = dt;
        }

        public uint Number
        {
            get
            {
                return this.number;
            }
        }


        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        public byte WareHouse
        {
            get
            {
                return this.wh_no;
            }
        }

        public string Descrption
        {
            get
            {
                return this.desc;
            }
        }

        public List<ItemMovement> Items
        {
            get
            {
                return this.items;
            }
        }

        public DocumentType Type
        {
            get
            {
                return this.dt;
            }
        }
    }
}
