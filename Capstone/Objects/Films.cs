using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Objects
{
    internal class Films
    {
        //attributes private so can not be edited or seen without methods
        private string _name;
        private string _Rating;
        private int _length;

        public Films(string name, string rating, int length)
        {
            //verifying that the name is only capital or lowercase letters or numbers or spaces
            string allowedChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890 ";
            foreach (char c in name)
            {
                if (!allowedChars.Contains(c))//going through every character of the name and making sure it is on the list
                {
                    throw new ArgumentException("Name can only be letters, numbers and spaces");//if not included on the previous list of allowed characters an error will happen
                }
            }
            _name = name;//if name within range it will be added to the instance of the object
            if (rating == "U" || rating == "12" || rating == "15" || rating == "18")
            {
                _Rating = rating;//making sure the rating is a real rating
            }
            else
            {
                throw new ArgumentException("Rating must be U, 12, 15 or 18");//if rating not correct it will cause an error
            }
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("length must be more than 0");//if the length of the film is less than or equal to zero an error will happen
            }
            _length = length;
        }
        /// <summary>
        /// returns a string containing the name rating and length of the choosen film
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{_name} - {_Rating} - {_length}";
        }
    }
}
