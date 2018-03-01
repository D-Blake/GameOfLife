using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeProject
{
    //The cell itself
    class Cell : INotifyPropertyChanged
    {
        public Cell()
        {
            //Initialization so that the creation loop isn't as bogged down
            Alive = false;
            NeedsChanged = false;
        }

        //All required variables for the cell are stated here
        public event CheckGridDelegate checks;
        public int numOfLivingNeighbors = 0;
        private bool alive;
        public bool playGame = false;
        public event PropertyChangedEventHandler PropertyChanged;
        private bool needsChanged;

        //All properties and methods needed are created here
            //Holds whether or not the cell needs to change once that loop starts
        public bool NeedsChanged
        {
            get
            {
                return needsChanged;
            }
            set
            {
                needsChanged = value;
            }
        }
            //Holds whether or not the cell is alive and deals with notifcation
        public bool Alive
        {
            get
            {
                return alive;
            }
            set
            {
                alive = value;
                CheckBoard(alive);
                OnPropertyChanged(new PropertyChangedEventArgs("Alive"));

            }
        }
            //Notification method
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
            //Method that checks the surrounding neighbors
        public void CheckBoard(bool living)
        {
            if (checks != null)
            {
                checks(Alive);
            }
        }
            //Method that determines whether a neighbor has died or become living. 
        public void UpdateFriends(bool living)
        {
            if (living)
            {
                numOfLivingNeighbors++;
            }
            else
            {
                numOfLivingNeighbors--;
            }

        }
    }
}
