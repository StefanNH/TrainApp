using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    [Serializable]
    public class Passenger
    {
        /*author: Stefan Hadzhiev
         * ------------------------------------------------------------------------------------------
         * class to allow manipulation of passenger details
         * ------------------------------------------------------------------------------------------
         * date: 06/12/2018
         */
        private string _name;
        private string _surname;
        private string _trainID;
        private string _coach;
        private int _seat;
        private int _ticket;
        private string _departureStation;
        private string _arrivalStation;
        private bool _firstClass;
        private bool _sleeper;
        private bool _cabin;

        //setting and getting first name property
        public string Name
        {
            set
            {
                //validating it contains only letters
                if (value.Any(char.IsLetter))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("Name fields cannot contain numbers or special characters");
                }
            }
            get
            {
                return _name;
            }
        }

        //setters and getters for _surname checking if the value consits of letters only
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value.Any(char.IsLetter))
                {
                    _surname = value;
                }
                else
                {
                    throw new ArgumentException("Name fields cannot contain numbers or special characters");
                }
            }
        }

        //setters and getters for the _trainId property
        public string TrainID
        {
            set
            {
                _trainID = value;
            }
            get
            {
                return _trainID;
            }
        }

        //set and get for couch property
        public string Coach
        {
            set
            {
                //validating the coaches are from A-H
                if (value.Contains("A") || value.Contains("B") || value.Contains("C") || value.Contains("D") || value.Contains("E") || value.Contains("F") || value.Contains("G") || value.Contains("H"))
                {
                    _coach = value;
                }
                else
                {
                    throw new ArgumentException("Coaches are from A-H");
                }
            }
            get
            {
                return _coach;
            }
        }
        
        //set and get for seat property
        public int Seat
        {
            set
            {
                //validating that the value is between 1 and 60
                if (value >= 1 && value <= 60)
                {
                    _seat = value;
                }
                else
                {
                    throw new ArgumentException("Value must be between 1 and 60");
                }
            }
            get
            {
                return _seat;
            }
        }

        //set and get for _departureStation
        public string DepStation
        {
            set
            {
                _departureStation = value;
            }
            get
            {
                return _departureStation;
            }
        }

        //set and get for _arrivalStation
        public string ArrivalStation
        {
            get
            {
                return _arrivalStation;
            }
            set
            {
                _arrivalStation = value;
            }
        }

        //set and get for _firstClass
        public bool FirstClass
        {
            get
            {
                return _firstClass;
            }
            set
            {
                _firstClass = value;
            }
        }

        //set and get for _cabin
        public bool Cabin
        {
            get
            {
                return _cabin;
            }
            set
            {
                _cabin = value;
            }
        }

        //set and get for _sleeper
        public bool Sleeper
        {
            get
            {
                return _sleeper;
            }
            set
            {
                _sleeper = value;
            }
        }

        //set and get for _ticket
        public int Ticket
        {
            get
            {
                return _ticket;
            }
            set
            {
                _ticket = value;
            }
        }

        public override string ToString()
        {
            return "Name: " + Name + " " + Surname + ", Coach: " + Coach + ", Seat N: " + Seat;
        }
    }
}
