using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLayer
{

    [Serializable]
    public class Train
    {
        /*Author: Stefan Hadzhiev
         * -----------------------------------------------------------------------------------
         * class holding and manipulating data about trains
         * -----------------------------------------------------------------------------------
         * Date: 06/12/2018
         */

        protected DateTime dt;
        private string _trainID;
        private string _departure;
        private string _destination;
        private string _trainType;
        private string _depTime;
        private string _depDate;
        private bool _sleeperBerth;
        private bool _firstClass;
        private PassengerList _passengers = new PassengerList();
        private List<string> _intermediates = new List<string>();

        //Public setter and getter for the ID property
        public string ID
        {
            set
            {
                //Setting validation for the value only numbers letters and no longer than 4 symbols

                if (value.Length == 4 && value.Any(char.IsDigit) && value.Any(char.IsLetter))
                {
                    _trainID = value.ToUpper();
                }
                else
                {
                    throw new ArgumentException("ID must be 4 symbols with no special characters");
                }

            }
            get
            {
                return _trainID;
            }
        }

        //Setters and getters for departure station
        public string Departure
        {
            set
            {
                //validating that its either Edinburgh Waverley or London Kings Cross
                if (value.Contains("Edinburgh (Waverley)") || value.Contains("London (Kings Cross)"))
                {
                    _departure = value;
                }
                else
                {
                    throw new ArgumentException("Departure station must be Edinburgh (Waverley) or London (Kings Cross)");
                }
            }
            get
            {
                return _departure;
            }
        }

        //setters and getters for destination
        public string Destination
        {
            set
            {
                //validating if departure station is Edinburgh arival must be  London and vice versa 
                if (value.Contains("London"))
                {
                    _destination = value;
                }
                else if (value.Contains("Edinburgh"))
                {
                    _destination = value;
                }
                else
                {
                    throw new ArgumentException("Select valid destination");
                }
            }
            get
            {
                return _destination;
            }
        }

        //set and get for the Type property
        public string TrainType
        {
            set
            {

                //validation its one of the 3 types "Express", "Stoping" or "Sleeper"
                if (value.Contains("Express") || value.Contains("Stoping") || value.Contains("Sleeper"))
                {
                    _trainType = value;
                }
                else
                {
                    throw new ArgumentException("Undefined type");
                }

            }
            get
            {
                return _trainType;
            }
        }

        //set and get for time property
        public virtual string DepTime
        {
            set
            {
                if (DateTime.TryParseExact(value, "HH:mm", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    _depTime = value;
                }
                else
                {
                    throw new ArgumentException("Enter valid time");
                }
            }
            get
            {
                return _depTime;
            }
        }

        //Set and get for departure day
        public string DepartureDate
        {
            set
            {
                if (DateTime.TryParseExact(value, "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    _depDate = value;
                }
                else
                {
                    throw new ArgumentException("Please enter valid date");
                }
            }
            get
            {
                return _depDate;
            }
        }

        //Set and get for sleeper berth property
        public virtual bool SleeperBerth
        {
            set
            {
                _sleeperBerth = value;
            }
            get
            {
                return _sleeperBerth;
            }
        }

        //set and get for the fist class property
        public virtual bool FirstClass
        {
            set
            {
                _firstClass = value;
            }
            get
            {
                return _firstClass;
            }
        }
        //Method to add stops to the list
        public virtual void AddStop(string str)
        {
            if (str.Contains("Newcastle") || str.Contains("York") || str.Contains("Darlington") || str.Contains("Peterborough"))
            {
                _intermediates.Add(str);
            }
        }

        //Get to retrieve the list as a single comma separated string
        public virtual string GetStops
        {
            get
            {
                var s = String.Join(",", _intermediates);
                return s;
            }
        }

        //Get to retrieve list of strings containing intermediate stops
        public virtual List<string> GetListOfStops
        {
            get
            {
                List<string> res = new List<string>();
                foreach (var v in _intermediates)
                {
                    res.Add(v);
                }
                return res;
            }
        }
        //Method adding passengers to the passenger list porperty
        public void AddPassenger(Passenger newPassenger)
        {
            if (this.ID.Equals(newPassenger.TrainID))
            {
                _passengers.AddPassenger(newPassenger);
            }
            else
            {
                throw new ArgumentException("passenger id does not match train id");
            }
        }

        //get to retrieve list of passengers
        public List<Passenger> GetPassengersList
        {
            get
            {
                List<Passenger> res = new List<Passenger>();
                {
                    foreach (var v in this._passengers.GetPassengers)
                    {
                        res.Add(v);
                    }
                    return res;
                }
            } 
        }

        //returning string containing  passengers details
        public string DisplayPassengers
        {

            get
            {
                return this._passengers.strPassengers;
            }
            
        }

        public override string ToString()
        {
            return $"ID: {ID} Departure: {Departure} Destination: {Destination} Departure time: {DepTime} date: {DepartureDate} Type: {TrainType}  Intermediate stops: {GetStops}";
        }
    }
}

