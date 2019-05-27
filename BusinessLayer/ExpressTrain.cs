using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /*Author: Stefan Hadzhiev
     * -------------------------------------------------------------------------------------------------
     * Holding information for express train not holding intermediatestops as express trains cant have them
     * ----------------------------------------------------------------------------------------------------
     * date: 06/12/2018
     */
    [Serializable]
    public class ExpressTrain : Train
    {
        [Obsolete("This property should not be used in this class", true)]
        public override void AddStop(string str)
        {
            base.AddStop(str);
        }
        [Obsolete("This property should not be used in this class", true)]
        public override bool SleeperBerth { get => base.SleeperBerth; set => base.SleeperBerth = value; }
    }
}
