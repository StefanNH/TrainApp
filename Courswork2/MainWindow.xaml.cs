using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer;
using DataLayer;

namespace Courswork2
{
    /// Author: Stefan Hadzhiev
    /// -----------------------------------------------------------------------------------------------------------------------------------
    /// Presentation layer allowing adding of passengers and trains
    /// -----------------------------------------------------------------------------------------------------------------------------------
    /// date: 06/12/2018
    
    public partial class MainWindow : Window
    {
        protected int price = 50;
        private DateTime dtf = new DateTime();
        TrainList trains = TrainList.Instance();
        Train train;

        public MainWindow()
        {
            InitializeComponent();
            lblShowCabin.Visibility = Visibility.Hidden;
            lblShowClass.Visibility = Visibility.Hidden;

            //reconstructing trainlist from the file and populating listbox to display them
            trains.Load();
            foreach (var t in trains.GetTrains)
            {
                lbTrains.Items.Add(t);
            }
        }
        
        private void TxtTrainID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CboxTrainType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckFirstClass_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckSleeper_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CboxDeparture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CboxDestination_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CboxIntermediate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtSetTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //adding trains to the list and doign additional checks
            try
            {
                TrainFactory tFactory = new TrainFactory();
                var aTrain = tFactory.CreateTrain(cboxTrainType.SelectedItem.ToString());
                if (aTrain.GetType() == typeof(StopperTrain))
                {
                    aTrain.TrainType = "Stoping";
                }
                else if (aTrain.GetType() == typeof(SleeperTrain))
                {
                    aTrain.TrainType = "Sleeper";
                }
                else if (aTrain.GetType() == typeof(ExpressTrain))
                {
                    aTrain.TrainType = "Express";
                }
                else
                {
                    throw new ArgumentException("Undefined type");
                }
                if (txtTrainID.Text.Length == 4 && txtTrainID.Text.Any(char.IsLetter) && txtTrainID.Text.Any(char.IsDigit))
                {
                    aTrain.ID = txtTrainID.Text;
                }
                else
                {
                    throw new ArgumentException("Train ID must be 4 characters and cannot contain special characters");
                }
                if (checkFirstClass.IsChecked == true && (aTrain.GetType() == typeof(SleeperTrain) || aTrain.GetType() == typeof(ExpressTrain) || aTrain.GetType() == typeof(StopperTrain)))
                {
                    aTrain.FirstClass = true;
                }
                else if (checkFirstClass.IsChecked == false && (aTrain.GetType() == typeof(SleeperTrain) || aTrain.GetType() == typeof(ExpressTrain) || aTrain.GetType() == typeof(StopperTrain)))
                {
                    aTrain.FirstClass = false;
                }
                else
                {
                    throw new ArgumentException("Problem arised while checking first class");
                }
                if (aTrain.GetType() == typeof(SleeperTrain) && checkSleeper.IsChecked == true)
                {
                    aTrain.SleeperBerth = true;
                }
                else if (aTrain.GetType() == typeof(SleeperTrain) && checkSleeper.IsChecked == false)
                {
                    aTrain.SleeperBerth = false;
                }
                else if(aTrain.GetType() != typeof(SleeperTrain) && checkSleeper.IsChecked == false)
                {
                    aTrain.SleeperBerth = false;
                }
                else
                {
                    throw new ArgumentException("Only train type \"Sleeper\" can have sleeperberth");
                }
                if (cboxDeparture.SelectedIndex == 0 && cboxDestination.SelectedIndex == 0)
                {
                    aTrain.Departure = "Edinburgh (Waverley)";
                    aTrain.Destination = "London (Kings Cross)";
                }
                else if (cboxDeparture.SelectedIndex == 1 && cboxDestination.SelectedIndex == 1)
                {
                    aTrain.Departure = "London (Kings Cross)";
                    aTrain.Destination = "Edinburgh (Waverley)";
                }
                else
                {
                    throw new ArgumentException("If departure station is Edinburgh destination must be London and vice versa");
                }
                if (DateTime.TryParseExact(txtSetTime.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out dtf))
                {
                    aTrain.DepTime = txtSetTime.Text;
                }
                else
                {
                    throw new ArgumentException("Time must be in 24h format separeted by \":\"");
                }
                if (this.dpDepartureDay.SelectedDate != null)
                {
                    aTrain.DepartureDate = this.dpDepartureDay.Text;
                }
                else
                {
                    throw new ArgumentException("Select date");
                }
                if (aTrain.GetType() == typeof(ExpressTrain) && (chkNewcastle.IsChecked == true || chkYork.IsChecked == true || chkDarlington.IsChecked == true || chkPeterborough.IsChecked == true))
                {
                    throw new ArgumentException("Express trains cannot have intermediate stops");
                }
                else
                {
                    if (chkNewcastle.IsChecked == true)
                    {
                        aTrain.AddStop(chkNewcastle.Content.ToString());
                    }
                    if (chkYork.IsChecked == true)
                    {
                        aTrain.AddStop(chkYork.Content.ToString());
                    }
                    if (chkDarlington.IsChecked == true)
                    {
                        aTrain.AddStop(chkDarlington.Content.ToString());
                    }
                    if (chkPeterborough.IsChecked == true)
                    {
                        aTrain.AddStop(chkPeterborough.Content.ToString());
                    }
                }
                if (trains.FreeID(aTrain.ID))
                {
                    
                    trains.AddTrain(aTrain);
                    lbTrains.Items.Add(aTrain);
                    MessageBox.Show("Train added!");
                }
                else
                {
                    throw new ArgumentException("Train with that ID already exists");
                }
            }
            catch (ArgumentException ex0)
            {
                MessageBox.Show(ex0.Message);
            } 
        }

        private void LbTrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selecting train in the listbox to display First class cabins and getting add for passengers to be added to that train
            train = (Train)lbTrains.SelectedItem;
            try
            {
                if (train.FirstClass == true)
                {
                    lblShowClass.Visibility = Visibility.Visible;
                }
                else
                {
                    lblShowClass.Visibility = Visibility.Hidden;
                }
                if (train.SleeperBerth == true)
                {
                    lblShowCabin.Visibility = Visibility.Visible;
                }
                else
                {
                    lblShowCabin.Visibility = Visibility.Hidden;
                }
                if (lbTrains.SelectedItem != null)
                {
                    lblPtrainIdHolder.Content = train.ID;
                }
                
            }
            catch(ArgumentException exc1)
            {
                MessageBox.Show(exc1.Message);
            }
        }
        private void LbTrains_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            //doubleclick event to show lits of passengers in the listbox
            train = (Train)lbTrains.SelectedItem;
            
            try
            {
                if (lbTrains.SelectedItem != null) {
                    MessageBox.Show(train.DisplayPassengers);
                }
            }
            catch(ArgumentException exc2)
            {
                throw new ArgumentException(exc2.Message);
            }
        }

        private void TxtFname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtSurname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CbPassengerDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbPassengerArrival_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChkPfirstClass_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChkPassengerCabin_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TxtPcoach_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtPseat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnAddPassenger_Click(object sender, RoutedEventArgs e)
        {

            //adding passengers to train and doing additional checks
            var aPassenger = new Passenger();
            try
            {
                aPassenger.TrainID = lblPtrainIdHolder.Content.ToString();
                aPassenger.Name = txtFname.Text;
                aPassenger.Surname = txtSurname.Text;
                aPassenger.Coach = cbCoach.SelectionBoxItem.ToString();
                if (train.GetType() == typeof(SleeperTrain))
                {
                    aPassenger.Sleeper = true;
                }
                else
                {
                    aPassenger.Sleeper = false;
                }
                if (txtPseat.Text.Length == 0)
                {
                    throw new ArgumentException("Seat number should be entered");
                }
                if (int.TryParse(txtPseat.Text, out int seatNum))
                {
                    aPassenger.Seat = seatNum;
                }

                if (train.FirstClass == true && cbCoach.SelectionBoxItem.ToString().Equals("A"))
                {
                    aPassenger.FirstClass = true;
                }
                else if (train.FirstClass == true && !cbCoach.SelectionBoxItem.ToString().Equals("A"))
                {
                    aPassenger.FirstClass = false;
                }
                else if (train.FirstClass == false)
                {
                    aPassenger.FirstClass = false;
                }
                else
                {
                    throw new ArgumentException("Train or coach does not offer first class");
                }
                if (train.SleeperBerth == true && cbCoach.SelectionBoxItem.ToString().Equals("H"))
                {
                    aPassenger.Cabin = true;
                }
                else if (train.SleeperBerth == true && !cbCoach.SelectionBoxItem.ToString().Equals("H"))
                {
                    aPassenger.Cabin = false;
                }
                else if (train.SleeperBerth == false)
                {
                    aPassenger.Cabin = false;
                }
                else
                {
                    throw new ArgumentException("Train or coach does not offer sleeper berth");
                }
                
                if (train.Departure.Equals("Edinburgh (Waverley)") && train.Destination.Equals("London (Kings Cross)")
                    && cbPassengerDep.SelectedIndex < cbPassengerArrival.SelectedIndex)
                {
                    aPassenger.DepStation = cbPassengerDep.SelectionBoxItem.ToString();
                    aPassenger.ArrivalStation = cbPassengerArrival.SelectedItem.ToString();
                }
                else if (train.Destination.Equals("Edinburgh (Waverley)") && train.Departure.Equals("London (Kings Cross)")
                    && cbPassengerDep.SelectedIndex > cbPassengerArrival.SelectedIndex)
                {
                    aPassenger.DepStation = cbPassengerDep.SelectionBoxItem.ToString();
                    aPassenger.ArrivalStation = cbPassengerArrival.SelectedItem.ToString();
                }
                else
                {
                    throw new ArgumentException("Station unavailable for this train");
                }

                // calculating booking price
                if ((cbPassengerDep.SelectedItem.ToString().Equals("Edinburgh (Waverley)") &&  cbPassengerArrival.SelectedItem.ToString().Equals("London (Kings Cross)"))
                || (cbPassengerArrival.SelectedItem.Equals("Edinburgh (Waverley)") && cbPassengerDep.SelectedItem.ToString().Equals("London (Kings Cross)")))
                {
                    price = 50;
                }
                else
                {
                    price = price - 25;
                }
                if (aPassenger.FirstClass == true)
                {
                    price = price + 10;
                }
                if(aPassenger.Cabin == true)
                {
                    price = price + 20;
                }
                //messagebox with buttons 
                    switch (MessageBox.Show($"Ticket price is {price} " , "Ticket", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                    {
                        case MessageBoxResult.Yes:
                            aPassenger.Ticket = price;
                            trains.AddPassengerToTrain(aPassenger.TrainID, aPassenger);
                            MessageBox.Show("Passenger added");
                            break;

                        case MessageBoxResult.No:
                            return;


                        case MessageBoxResult.Cancel:
                            return;

                    }

               
            }
            catch (ArgumentException exc4)
            {
                MessageBox.Show(exc4.Message);
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            //save trainlist into a file when closing the app
            trains.Save();
        }

        private void BtnDateSearch_Click(object sender, RoutedEventArgs e)
        {
            // opening new window and populating it with public copy of the trainlist
            Window1 newWin = new Window1(trains.GetTrains,this.dpDepartureDay.Text);
            newWin.Show();
        }

        private void BtnTrJourneys_Click(object sender, RoutedEventArgs e)
        {
            // opening new window and populating it with public copy of the trainlist
            Window2 newWin = new Window2(trains.GetTrains, cbPassengerDep.SelectionBoxItem.ToString(), cbPassengerArrival.SelectionBoxItem.ToString());
            newWin.Show();
        }
    }
}
