using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using DataLayer;

namespace TrainsUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            Train t = new Train();
            t.ID = "1A15";
            t.SleeperBerth = false;
            t.FirstClass = false;
            t.TrainType = "Express";
            t.Departure = "Edinburgh (Waverley)";
            t.Destination = "London Kings Cross";
            t.DepartureDate = "11/11/2018";
            t.DepTime = "21:11";
            t.AddStop("York");
                Passenger p = new Passenger();
                p.TrainID = "1A15";
                p.Name = "Qsen";
                p.Coach = "H";
                p.Seat = 34;
                t.AddPassenger(p);
            Assert.IsNotNull(t, "Value is null");
            Assert.IsNotNull(t.GetPassengersList, "Value is null");
            Assert.AreEqual(t.GetStops, "York");
        }
    }
}
