using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Capstone.Objects
{
    internal class Ticket : SaleItem
    {
        private string _type;
        private int _pencePrice;

        public Ticket(string type, int pencePrice) : base(pencePrice)
        {
            if (type == "Standard" || type == "Premium")
            {
                _type=type;
            }
            else
            {
                throw new ArgumentException("ticket has to be standard or premium");
            }
        }
        public override string ToString()
        {
            return $"{_type} - {base.ToString()}";
        }
    }
}
