using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invcore
{
    public class Item
    {
        private byte number;
        private string name;
        private string code;
        private string unitName;
        private uint unitQuntity;
        private string unitBitName;
        private uint unitBitQuntity;

        public Item(
             byte number,
             string name,
             string code,
             string unitName,
             uint unitQuntity,
             string unitBitName,
             uint unitBitQuntity   
        )
        {
            this.number = number;
            this.name = name;
            this.code = code;
            this.unitName = unitName;
            this.unitQuntity = unitQuntity;
            this.unitBitName = unitBitName;
            this.unitBitQuntity = unitBitQuntity;
        }

        public byte Number
        {
            get
            {
                return this.number;
            }
        }

        public string Name
        {
            get
            { return this.name; }
        }

        public string Code
        { get { return this.code; } }


        public string UnitName
        {
            get
            {
                return this.unitName;
            }
        }

        public uint UnitQuatity
        {
            get
            {
                return this.unitQuntity;
            }
        }

        public string UnitBitName
        {
            get
            {
                return this.unitBitName;
            }
        }

        public uint UnitBitQuantity
        {
            get
            {
                return this.unitBitQuntity;
            }
        }
    }
}
