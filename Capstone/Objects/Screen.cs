using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Objects
{
    internal class Screen
    {
        private string _name;
        private int _sSeat;
        private int _pSeat;

        public string name { get { return _name; } }
        public int sSeat { get { return _sSeat; } }
        public int pSeat { get { return _pSeat; } }

        public Screen(string name, int sSeat, int pSeat)
        {
            if (sSeat < 0)
            {
                throw new ArgumentOutOfRangeException("Standard seats must be above 0");
            }
            if (pSeat < 0)
            {
                throw new ArgumentOutOfRangeException("Premuim seats must be above 0");
            }

            _name = name;
            _sSeat = sSeat;
            _pSeat = pSeat;
        }
        public override string ToString()
        {
            return $"{_name} - {_sSeat} - {_pSeat}";
        }
    }
}

