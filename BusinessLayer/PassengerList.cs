using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    [Serializable]
    public class PassengerList
    {
        /*Author: Stefan Hadzhiev
         * --------------------------------------------------------------------------------------------------------------------------------
         * container class meant to hold list of passengers
         * Method: AddPassenger() adding passenger objects to the list
         * Method: FreeSeat() checking if coach and seat are taken
         * -----------------------------------------------------
         * date: 06/12/2018
         */
        private List<Passenger> _passengers = new List<Passenger>();

        //adding passenger objects to the list if seat and coach arent already taken
        public void AddPassenger(Passenger newPassenger)
        {
            if (this.FreeSeat(newPassenger))
            {
                _passengers.Add(newPassenger);
            }
            else
            {
                throw new ArgumentException("Passenger already in the list");
            }
        }

        // finding a passenger if needed
        public Passenger Find(char coach, int seat)
        {
            foreach (Passenger p in _passengers)
            {
                if (coach.Equals(p.Coach) && seat == p.Seat)
                {
                    return p;
                }
            }
            return null;
        }

        //removing passenger from the list
        public void DelPassenger(char coach, int seat)
        {
            Passenger p = this.Find(coach,seat);
            if (p != null)
            {
                _passengers.Remove(p);
            }

        }

        //Checking if passenger is already in the list
        public bool FreeSeat(Passenger p)
        {
            foreach (Passenger rp in _passengers)
            {
                if (rp.Coach.Equals(p.Coach) && rp.Seat == p.Seat)
                {
                    return false;
                }
            }
            return true;
        }
        
        //returning list of passengers
        public List<Passenger> GetPassengers
        {
            get
            {
                List<Passenger> res = new List<Passenger>();
                foreach (var v in _passengers)
                {
                    res.Add(v);
                }
                return res;
            }
        }

        //returing list of strings containing passenger details
        public List<string> strPsngers
        {
            get
            {
                List<string> s = new List<string>();
                foreach (var v in _passengers)
                {
                    s.Add(v.ToString());
                }
                return s;
            }
        }

        // returning string containing passenger details separated by \n
        public string strPassengers
        {
            get
            {
                var s = String.Join("\n", this.strPsngers);
                return s;
            }
        }
    }
    
}
