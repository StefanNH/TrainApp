using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BusinessLayer;

namespace DataLayer
{
    /* Author: Stefan Hadzhiev
     * -----------------------------------------------------------------------------------------------------------
     * container class meant to save list of train classes
     * Method AddTrain() adding new train to the list
     * Method FreeID() checking if train with that ID already exist within the lsit
     * Method AddPassengersToTrain() adding passenger to a train that is already in the list
     * Method Save() saving TrainList to a file
     * Method Load() reconstructing TrainList from file
     * --------------------------------------------------------------------------------------
     * Date: 06/12/2018
     * -----------------------------------------------------------------------------------------------------------
     * Using singleton pattern to ensure only 1 instance of the list and file exist throughout the programme
     */

    [Serializable]
    public class TrainList
    {
        private static TrainList _trainList;
        private List<Train> _trains = new List<Train>();
        private BinaryFormatter _formatter;

        //filename for the saved DATA change this if needed
        private const string SAVED_DATA = "savings.txt";

        //initializing instance of the class if there isn't one already
        public static TrainList Instance()
        {
            if (_trainList == null)
            {
                _trainList = new TrainList();
            }

            return _trainList;
        }

        //private constructor
        private TrainList()
        {
            this._trains = new List<Train>();
            this._formatter = new BinaryFormatter();
        }

        public void Save()
        {
            try
            {
                // Create a FileStream that will write data to file.
                FileStream writerFileStream =
                    new FileStream(SAVED_DATA, FileMode.Create, FileAccess.Write);
                // save the trainList to a file
                this._formatter.Serialize(writerFileStream, this._trains);

                // Close the writerFileStream when done.
                writerFileStream.Close();
            }
            catch (ArgumentException exc0)
            {
                Console.WriteLine("Unable to save data", exc0.Message);
            }
        } 

        public void Load()
        {

            //checks if data is already saved
            if (File.Exists(SAVED_DATA))
            {

                try
                {
                    // Create a FileStream will gain read access to the data file.
                    FileStream readerFileStream = new FileStream(SAVED_DATA,
                        FileMode.Open, FileAccess.Read);
                    // Reconstruct from file.
                    this._trains = (List<Train>)
                        this._formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when done
                    readerFileStream.Close();

                }
                catch (ArgumentException exc1)
                {
                    Console.WriteLine("Problem reading the file occured", exc1.Message);
                }

            }

        }

        //Add train if train with the same ID doesnt exist in it already
        public void AddTrain(Train newTrain)
        {
            if (this.FreeID(newTrain.ID))
            {
                _trains.Add(newTrain);
            }
        }

        //check if Train with that ID exists in the list
        public bool FreeID(string trainID)
        {
            foreach (Train t in _trains)
            {
                if (t.ID.Equals(trainID))
                {
                    return false;
                }
            }
            return true;
        }

        //adding passengers to train
        public void AddPassengerToTrain(string id, Passenger newPassenger)
        {
            foreach (var t in _trains)
            {
                if (t.ID.Equals(id))
                {
                    t.AddPassenger(newPassenger);
                }
            }
        }

        //returning public list with trains
        public List<Train> GetTrains
        {
            get
            {
                List<Train> res = new List<Train>();
                foreach (var v in _trains)
                {
                    res.Add(v);
                }
                return res;
            }
        }
    }
}
