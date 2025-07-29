using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Capstone.Objects
{
    internal class Staff
    {
        private int _id;
        private string _fName;
        private string _sName;
        private string _level;

        public Staff(int id, string fName, string sName, string level)
        {
            _id = id;
            _fName = fName;
            _sName = sName;
            _level = level;

            string allowedChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm ";
            foreach (char c in fName)
            {
                if (!allowedChars.Contains(c))
                {
                    throw new ArgumentException("First name can only be letters, numbers and spaces");
                }
            }
            _fName = fName;
            foreach (char c in sName)
            {
                if (!allowedChars.Contains(c))
                {
                    throw new ArgumentException("Surname can only be letters, numbers and spaces");
                }
            }
            _sName = sName;
            if (level == "General" || level == "Manager")
            {
                _level = level;
            }
            else
            {
                throw new ArgumentException("Level must be either General or Manager");
            }
            _id = id;
        }
        public int getid()
        {
            return _id;
        }
        public override string ToString()
        {
            return $"{_id} - {_fName} - {_sName} - {_level}";
        }
    }
}
