using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Objects
{
    internal class Sale
    {
        private List<SaleItem> _saleItem;

        public Sale()
        {
            _saleItem = new List<SaleItem>();
        }

        public void AddSaleItem(SaleItem saleItem)
        {
            _saleItem.Add(saleItem);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int saleTotal = 0;
            foreach (SaleItem saleItem in _saleItem)
            {
                sb.Append(saleItem.ToString());
                saleTotal += saleItem.PencePrice;
            }
            sb.AppendLine($"Total: £{saleTotal / 100.0:F2}");
            return sb.ToString();
        }
    }
}
