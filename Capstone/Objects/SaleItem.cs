using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Objects
{
    internal abstract class SaleItem // abstract as saleItem is a category
    {
        //attributes ,ade private so unaccessible without methods for security
        private int _pencePrice;
        public int PencePrice { get { return _pencePrice; } }

        public SaleItem(int pencePrice)
        {
            if (pencePrice <= 0)
            {
                throw new ArgumentOutOfRangeException("Price must be above 0");//if the price in pence is less than or equal to 0 it will cause an error as it is out of range
            }
            _pencePrice = pencePrice;
        }
        /// <summary>
        /// overriding the ToString command to output the price in pounds with correct decemilisation and rounding
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"£{_pencePrice / 100.0:F2}";
        }
    }
}
