using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLayer;

namespace Courswork2
{
    /// Author: Stefan Hadzhiev
    /// -----------------------------------------------------------------------------------------------------------------------
    /// new window displaying informationfor trains between 2 selected stations
    /// ------------------------------------------------------------------------------------------------------
    /// date: 06/12/2018
    public partial class Window2 : Window
    {
        public List<Train> nTrains;
        public string departure;
        public string destination;
        

        public Window2(List<Train> getTrains, string v, string v1)
        {
            InitializeComponent();
            ///getting data from main window
            nTrains = getTrains;
            departure = v;
            destination = v1;

            //looping through the trains looking for data and populating lb to display them
            foreach (var tr in nTrains)
            {
                if (tr.Departure.Equals(departure) && tr.GetListOfStops.Contains(destination))
                {
                    lbBetweenStations.Items.Add(tr);
                }
                else if (tr.Destination.Equals(destination) && tr.GetListOfStops.Contains(departure))
                {
                    lbBetweenStations.Items.Add(tr);
                }
                else if (tr.Departure.Equals(departure) && tr.Destination.Equals(destination))
                {
                    lbBetweenStations.Items.Add(tr);
                }
                else
                {
                }
            }
        }

        private void LbBetweenStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
