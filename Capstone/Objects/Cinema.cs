using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Objects;

namespace Capstone.Shapes
{
    /// <summary>
    /// class for items for sale in the cinema
    /// </summary>
    internal class Cinema
    {
        public List<SaleItem> saleItems { get; private set; }

        public Cinema()
        {
            saleItems = new List<SaleItem>();
        }
        
        /// <summary>
        /// adds a item for sale to the list
        /// </summary>
        /// <param name="pSaleItem"></param>
        public void AddsaleItem(SaleItem pSaleItem)
        {
            saleItems.Add(pSaleItem);
        }
        /// <summary>
        /// qill output list of all shape and their colour and radius/lengths
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (SaleItem pSaleItem in saleItems)
            {
                sb.Append(pSaleItem.ToString() + Environment.NewLine);
            }
            return sb.ToString();

        }
    }
}
