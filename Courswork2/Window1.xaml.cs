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
    ///Author: Stefan Hadzhiev
    ///----------------------------------------------------------------------------------
    ///new window displaying information about trains leaving at selected date
    ///----------------------------------------------------------------------------------
    ///date: 06/12/2018
    public partial class Window1 : Window
    {
        public string passedDate;
        public List<Train> paassedTrains; 

        public Window1(List<Train> getTrains, string text)
        {
            InitializeComponent();
            // getting data from main window
            passedDate = text;
            paassedTrains = getTrains;
            //looping through each train and adding them if the date is equal to the selected
            foreach (var v in paassedTrains)
            {
                if (v.DepartureDate.Equals(passedDate))
                    lbDataSearch.Items.Add(v);
            }
        }

        private void LbDataSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
