using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Objects
{
    internal class Films
    {
        private string _name;
        private string _Rating;
        private int _length;

        public Films(string name, string rating, int length)
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
            if (rating == "U" || rating == "12" || rating == "15" || rating == "18")
            {
                _Rating = rating;
            }
            else
            {
                throw new ArgumentException("Rating must be U, 12, 15 or 18");
            }
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("length must be more than 0");
            }
            _length = length;
        }
    }
}
