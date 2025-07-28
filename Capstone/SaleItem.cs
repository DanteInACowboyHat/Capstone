using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    internal abstract class SaleItem
    {
        private int _pencePrice;
        public int PencePrice { get { return _pencePrice; } }

        public SaleItem(int pencePrice)
        {
            if (pencePrice <= 0)
            {
                throw new ArgumentOutOfRangeException("Price must be above 0");
            }
            _pencePrice = pencePrice;
        }
        public override string ToString()
        {
            return $"{_pencePrice / 100:F2}";
        }
    }
}
