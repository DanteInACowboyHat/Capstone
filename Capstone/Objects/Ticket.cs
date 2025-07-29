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
        //private attributes so cant be edited or seen without methods for security
        private string _type;
        private int _pencePrice;

        public Ticket(string type, int pencePrice) : base(pencePrice)
        {
            if (type == "Standard" || type == "Premium")//making sure the tickete type is valid
            {
                _type=type;
            }
            else
            {
                throw new ArgumentException("ticket has to be standard or premium");//if not an error happens
            }
        }
        /// <summary>
        /// returns a string of the ticket type and price
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{_type} - £{base.ToString()}";
        }
    }
}
