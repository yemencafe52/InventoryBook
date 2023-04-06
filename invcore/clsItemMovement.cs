using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invcore
{
    public class ItemMovement
    {
        private uint it_no;
        private uint item_no;
        private uint doc_no; // it's okay now :)
        private uint it_in;
        private uint it_out;
        private uint it_bit_in;
        private uint it_bit_out;

        public ItemMovement(
         uint it_no,
         uint item_no,
         uint doc_no,
         uint it_in,
         uint it_out,
         uint it_bit_in,
         uint it_bit_out     
        )
        {
            this.it_no = it_no;
            this.item_no = item_no;
            this.doc_no = doc_no;
            this.it_in = it_in;
            this.it_out = it_out;
            this.it_bit_in = it_bit_in;
            this.it_bit_out = it_bit_out;
        }

        public uint ItemMovementNumber
        {
            get
            {
                return this.it_no;
            }
        }

        public uint ItemNumber
        {
            get
            {
                return this.item_no;
            }
        }

        public uint ItemMovmentIN
        {
            get
            {
                return this.it_in ;
            }
        }

        public uint ItemMovementOut
        {
            get
            {
                return this.it_out;
            }
        }

        public uint ItemMovementBitIN
        {
            get
            {
                return this.it_bit_in;
            }
        }

        public uint ItemMovementBitOut
        {
            get
            {
                return this.it_bit_out;
            }
        }

        public uint DocumentNumber
        {
            get
            {
                return this.doc_no;
            }
        }

       
    }
}
