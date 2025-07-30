using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Capstone.Objects
{
    internal class Screening
    {
        //private attributes so cant be edited or seen without methods for security
        private string _film;
        private int _timeH;
        private int _timeM;
        private string _Screen;
        private int _sSeats;
        private int _pSeats;
        public string film
        {
            get { return _film; }
        }
      
        public int timeH
        {
            get { return _timeH; }
        }
        public int timeM
        {
            get { return _timeM; }
        }
        public string Screen
        {
            get { return _Screen; }
        }
        public int sSeats
        {
            get { return _sSeats; }
            set { _sSeats = value; }
        }
        public int pSeats 
        {
            get { return _pSeats; }
            set { _pSeats = value; }
        }
        public Screening(string film, int timeH, int timeM, string screen, int sSeats, int pSeats)
        {
            string allowedChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890 ";//list of viable characters for the film name
            foreach (char c in film)
            {
                if (!allowedChars.Contains(c))//cheacking each character againsts the list to make sure it is valid
                {
                    throw new ArgumentException("Name can only be letters, numbers and spaces");//If not valid an error happens
                }
            }
            _film = film;
            if (timeH < 0 || timeH >= 24)//making sure the hour time is within the range of the day midnight to 11pm
            {
                throw new ArgumentOutOfRangeException("Hour time must be between 0(midnight) and 23(inclusive)");//if not an error happens
            }
            _timeH = timeH;
            if (timeM < 0 || timeM >= 60)//makes sure the minute time is within the range of an hour 0 to 59
            {
                throw new ArgumentOutOfRangeException("Minute time must be between 0 and 59 inclusive");//if not an error happens
            }
            _timeM = timeM;
            _Screen = screen;
            _sSeats = sSeats;
            _pSeats = pSeats;
        }

        /// <summary>
        /// returns a string of the screening with which fil it is, at what time it is, what screen it is at and what seats are remainging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{_film} - {_timeH}:{_timeM} - in Screen {_Screen} - remaining standard seats {_sSeats} - remaining premium seats {_pSeats}";
        }
    }
}
