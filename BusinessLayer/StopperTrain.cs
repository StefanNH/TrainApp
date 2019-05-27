using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /*Author: Stefan Hadzhiev
     * ---------------------------------------------------------------------------------------------------
     * Manipulating data for trains making sleeperberth property obsolete cannot be added to stopper type trains
     * ---------------------------------------------------------------------------------------------------------
     * date: 06/12/2018
     */
    [Serializable]
    public class StopperTrain : Train
    {
        [Obsolete("This property has been deprecated and should no longer be used.", true)]
        public override bool SleeperBerth { get => base.SleeperBerth; set => base.SleeperBerth = value; }
    }
}
