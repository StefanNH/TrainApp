using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   /*Author: Stefan Hadzhiev
    * ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    * Trainfactory class using the factory pattern to return an object depeding on the needed type
    * ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    * Date: 06/12/2018
    * ------------------------------------------------------------------------------------------------------------------------------------
    * factory pattern returning different classes depending on the type needed
    */

    public class TrainFactory
    {
        public Train CreateTrain(string type)
        {
            if (type.Contains("Express"))
            {
                return new ExpressTrain();
            }
            else if (type.Contains("Sleeper"))
            {
                return new SleeperTrain();
            }
            else if (type.Contains("Stoping"))
            {
                return new StopperTrain();
            }
            else
            {
                throw new ArgumentException("Please select a type");
            }
        }
    }
}
