using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Objects
{
    internal class Screen
    {
        //private attributes for security, cant be edited or seen without methods
        private string _name;
        private int _sSeat;
        private int _pSeat;
        public Screen(string name, int sSeat, int pSeat)
        {
            if (sSeat < 0)
            {
                throw new ArgumentOutOfRangeException("Standard seats must be above or equal to 0");//if seats are less than 0 error will happen
            }
            if (pSeat < 0)
            {
                throw new ArgumentOutOfRangeException("Premuim seats must be above or equal to 0");//if premium seats are less than 0 error will happen
            }

            _name = name;
            _sSeat = sSeat;
            _pSeat = pSeat;
        }
        public string getName()
        {
            return _name;
        }
        public int getSSeat()
        {
            return _sSeat;
        }
        public int getPSeat()
        {
            return _pSeat;
        }
        /// <summary>
        /// will output a string of the name of the screen and number of both types of seats
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Screen {_name} - standard seats {_sSeat} - premium seats {_pSeat}";
        }
    }
}

