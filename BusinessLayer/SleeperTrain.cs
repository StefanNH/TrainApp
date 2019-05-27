using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /*Author: Stefan Hadzhiev
     * --------------------------------------------------------------------------------
     * sleeper class overriding the DepTime assuring no sleeper train can be added before 21:00
     * -----------------------------------------------------------------------------------------
     * date: 06/12/2018
     */
    [Serializable]
    public class SleeperTrain : Train
    {
        private string _time;
        
        public override string DepTime
        {
            get
            {
                return _time;
            }
            set
            {
                if (DateTime.TryParseExact(value, "HH:mm", null, System.Globalization.DateTimeStyles.None, out dt) && dt.Hour >= 21)
                {
                    _time = value;
                }
                else
                {
                    throw new ArgumentException("Sleeper trains are expected to depart later than 21:00");
                }

            }
        }

    }
}
