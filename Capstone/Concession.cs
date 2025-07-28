using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    internal class Concession : SaleItem
    {
        private string _name;

        public string Name { get { return _name; } }

        public Concession(string name, int pencePrice) : base(pencePrice)
        {
            string allowedChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890 ";
            foreach (char c in name)
            {
                if (!allowedChars.Contains(c))
                {
                    throw new ArgumentException("Name can only be letters, numbers and spaces");
                }
            }
                _name = name;
        }
        public override string ToString()
        {
            return $"{_name} - {base.ToString()}";
        }
    }
}
