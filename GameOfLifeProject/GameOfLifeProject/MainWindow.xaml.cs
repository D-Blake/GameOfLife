using GameOfLifeProject.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Threading;

namespace GameOfLifeProject
{
    public delegate void CheckGridDelegate(bool alive);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //Class level variables that are needed
        Cell[,] cells;
        BackgroundWorker bw = new BackgroundWorker();
        public event PropertyChangedEventHandler PropertyChanged;
        int gridX;
        int gridY;
        private int throttle;

        //Sets it all up for running
        public MainWindow()
        {
            throttle = 100;
            GridX = 10;
            GridY = 10;
            InitializeComponent();

            xSlider.DataContext = this;
            ySlider.DataContext = this;
            XGrid.DataContext = this;
            YGrid.DataContext = this;
            throttleGrid.DataContext = this;
            throttleSlider.DataContext = this;

            bw.DoWork += new DoWorkEventHandler(BWGenerations);
            bw.WorkerSupportsCancellation = true;

            CreateGrid();

        }

        //Runs the generations as a background thread
        private void BWGenerations(object sender, DoWorkEventArgs e)
        {
            while (!bw.CancellationPending)
            {
                RunGenerations();
                Thread.Sleep(throttle);
            }
        }

        //Makes a cell swap the current Alive state
        private void BoardRectangle_Click(object sender, RoutedEventArgs e)
        {
            ((sender as Rectangle).DataContext as Cell).Alive = !(((sender as Rectangle).DataContext as Cell).Alive);
        }

        //Creates the grid with the GridX and GridY values
        private void CreateGrid()
        {
            CellConverter conv = new CellConverter();
            Cell newCell;
            Binding cellBinding = new Binding("Alive");
            cellBinding.Converter = conv;
            cellBinding.Mode = BindingMode.TwoWay;
            Rectangle newRect;
            cells = new Cell[GridX, GridY];


            for (int y = 0; y < GridY; y++)
            {
                for (int x = 0; x < GridX; x++)
                {
                    newRect = new Rectangle();
                    newCell = new Cell();

                    newRect.DataContext = newCell;
                    newRect.Fill = Brushes.Green;
                    newRect.SetBinding(Rectangle.FillProperty, cellBinding);
                    newRect.MouseDown += BoardRectangle_Click;

                    playGrid.Children.Add(newRect);

                    cells[x, y] = newCell;

                    if (x - 1 >= 0 && y - 1 >= 0 && x - 1 < GridX && y - 1 < GridY)
                    {
                        newCell.checks += cells[x - 1, y - 1].UpdateFriends;
                        cells[x - 1, y - 1].checks += newCell.UpdateFriends;
                    }
                    if (x >= 0 && y - 1 >= 0 && x < GridX && y - 1 < GridY)
                    {
                        newCell.checks += cells[x, y - 1].UpdateFriends;
                        cells[x, y - 1].checks += newCell.UpdateFriends;
                    }
                    if (x + 1 >= 0 && y - 1 >= 0 && x + 1 < GridX && y - 1 < GridY)
                    {
                        newCell.checks += cells[x + 1, y - 1].UpdateFriends;
                        cells[x + 1, y - 1].checks += newCell.UpdateFriends;
                    }
                    if (x - 1 >= 0 && y >= 0 && x - 1 < GridX && y < GridY)
                    {
                        newCell.checks += cells[x - 1, y].UpdateFriends;
                        cells[x - 1, y].checks += newCell.UpdateFriends;
                    }
                }
            }
        }

        //Property for the Grid's X value
        public int GridX
        {
            get
            {
                return gridX;
            }
            set
            {
                gridX = value;
                OnPropertyChanged(new PropertyChangedEventArgs("GridX"));
            }
        }

        //Property for the Grid's Y value
        public int GridY
        {
            get
            {
                return gridY;
            }
            set
            {
                gridY = value;
                OnPropertyChanged(new PropertyChangedEventArgs("GridY"));
            }
        }

        //Property for the Throttle value
        public int Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Throttle"));

            }
        }

        //Proptery Changed Notification
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        //Updates all cells after determining whether or not it needs to be changed
        private void RunGenerations()
        {
            for (int y = 0; y < GridY; y++)
            {
                for (int x = 0; x < GridX; x++)
                {
                    if ((!cells[x, y].Alive && cells[x, y].numOfLivingNeighbors == 3) || (cells[x, y].Alive && cells[x, y].numOfLivingNeighbors > 3) || (cells[x, y].Alive && cells[x, y].numOfLivingNeighbors < 2))
                    {
                        cells[x, y].NeedsChanged = true;
                    }
                }
            }
            for (int y = 0; y < GridY; y++)
            {
                for (int x = 0; x < GridX; x++)
                {
                    if (cells[x,y].NeedsChanged)
                    {
                        cells[x, y].Alive = !cells[x, y].Alive;
                        cells[x, y].NeedsChanged = false;
                    }
                }
            }
        }

        //Does the logic for completing a single generation
        private void OneStep()
        {
            for (int y = 0; y < GridY; y++)
            {
                for (int x = 0; x < GridX; x++)
                {
                    if ((!cells[x, y].Alive && cells[x, y].numOfLivingNeighbors == 3) || (cells[x, y].Alive && cells[x, y].numOfLivingNeighbors > 3) || (cells[x, y].Alive && cells[x, y].numOfLivingNeighbors < 2))
                    {
                        cells[x, y].NeedsChanged = true;
                    }
                }
            }
            for (int y = 0; y < GridY; y++)
            {
                for (int x = 0; x < GridX; x++)
                {
                    if (cells[x, y].NeedsChanged)
                    {
                        cells[x, y].Alive = !cells[x, y].Alive;
                        cells[x, y].NeedsChanged = false;
                    }
                }
            }
        }

        //Completes a single generation on the board
        private void OneStepButton_Click(object sender, RoutedEventArgs e)
        {
            OneStep();
        }

        //Starts the play cycle if it isn't already started
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync();
            }
        }

        //Pauses the play cycle if the cycle is running
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (bw.IsBusy)
            {
                bw.CancelAsync();
            }
        }

        //Randomly fills the array with living cells after clearing the board
        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int upperBound = (GridX * GridY) / 2;
            if (upperBound < 2)
            {
                upperBound = 3;
            }

            for(int y = 0; y < GridY; y++)
            {
                for(int x =0; x < GridX; x++)
                {
                    cells[x, y].Alive = false;
                }
            }
            for (int y = 0; y < GridY; y++)
            {
                for (int x = 0; x < GridX; x++)
                {
                    cells[x, y].numOfLivingNeighbors = 0;
                }
            }

            int numRandomCells = rand.Next(2, upperBound);
            /*--------------------------------------------------------*/
            for (int x = 0; x < numRandomCells; x++)
            {
                int newCellRandX = rand.Next(0, GridX);
                int newCellRandY = rand.Next(0, GridY);
                cells[newCellRandX, newCellRandY].Alive = true;
            }
        }

        //Starts the creation of a new Grid
        private void NewGridButton_Click(object sender, RoutedEventArgs e)
        {
            playGrid.Children.Clear();
            CreateGrid();
        }
    }
}
