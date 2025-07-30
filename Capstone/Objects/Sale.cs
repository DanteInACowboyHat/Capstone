using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Objects
{
    internal class Sale
    {
        //private attributes so nothing can be accessed without methods
        private List<SaleItem> _saleItem;

        /// <summary>
        /// constructor for Sale class
        /// </summary>
        public Sale()
        {
            _saleItem = new List<SaleItem>();
        }
        /// <summary>
        /// adds an item to the sale list everytime the method is called
        /// </summary>
        /// <param name="saleItem"></param>
        public void AddSaleItem(SaleItem saleItem)
        {
            _saleItem.Add(saleItem);
        }
        /// <summary>
        /// adds up the price of everything in the list and outputs all the items and individual price and overall price
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //code beneath covers point 10 in selling tickets and concessions
            StringBuilder sb = new StringBuilder();
            int saleTotal = 0;
            foreach (SaleItem saleItem in _saleItem)
            {
                sb.Append(saleItem.ToString());
                saleTotal += saleItem.PencePrice;
            }
            sb.AppendLine($"Total: £{saleTotal / 100.0:F2}");
            return sb.ToString();
            //code above covers point 10 in selling tickets and concessions
        }
    }
}
