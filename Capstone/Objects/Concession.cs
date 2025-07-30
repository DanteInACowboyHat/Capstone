using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Objects
{
    internal class Concession : SaleItem
    {
        //private attributes so cant be accessed without methods
        private string _name;
        /// <summary>
        /// allows the name to be called in main code
        /// </summary>
        public string Name { get { return _name; } }
        /// <summary>
        /// inherits pence price from its parent class the SaleItem
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pencePrice"></param>
        /// <exception cref="ArgumentException"></exception>
        public Concession(string name, int pencePrice) : base(pencePrice)
        {
            string allowedChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890 ";//list of allowed characters
            foreach (char c in name)//loops for every character in the name
            {
                if (!allowedChars.Contains(c))//compares each character to the list to verify no invalid entry
                {
                    throw new ArgumentException("Name can only be letters, numbers and spaces");//causes error if invalid character
                }
            }
            _name = name;
        }
        /// <summary>
        /// outputs the name and price(via inheriting sale item .ToString())
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{_name} - {base.ToString()}";
        }
    }
}
