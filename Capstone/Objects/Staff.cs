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
        //private attributes so cant be edited or seen without methods for security
        private int _id;
        private string _fName;
        private string _sName;
        private string _level;
        public string fName { get { return _fName; } }
        public string sName { get { return _sName; } }
        public Staff(int id, string fName, string sName, string level)
        {
            _id = id;
            _fName = fName;
            _sName = sName;
            _level = level;

            string allowedChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm ";//list of allowed characters for the attribute
            foreach (char c in fName)
            {
                if (!allowedChars.Contains(c))//checking each character against the list to make sure it is valid
                {
                    throw new ArgumentException("First name can only be letters, numbers and spaces");//if not an error happens
                }
            }
            _fName = fName;
            foreach (char c in sName)
            {
                if (!allowedChars.Contains(c))//checking each character against the list to make sure it is valid
                {
                    throw new ArgumentException("Surname can only be letters, numbers and spaces");//if not an error happens
                }
            }
            _sName = sName;
            if (level == "General" || level == "Manager")//checking if level is a valid string
            {
                _level = level;
            }
            else
            {
                throw new ArgumentException("Level must be either General or Manager");//if not an error happens
            }
            _id = id;
        }
        /// <summary>
        /// gets the ID of employee
        /// </summary>
        /// <returns></returns>
        public int getid()
        {
            return _id;
        }
        public string getlevel()
        {
            return _level;
        }
        /// <summary>
        /// returns a string containing name, id and position of employee
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"ID number:{_id} - Name: {_fName} - {_sName} - position: {_level}";
        }
    }
}
