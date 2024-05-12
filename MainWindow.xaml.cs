using JuneExam2023.Classes;
using JuneExam2023.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuneExam2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshMovieListbox();
        }

        private void lbxMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateMovieSynopsis();
        }

        private void btnBookSeats_Click(object sender, RoutedEventArgs e)
        {
            CreateBooking();
        }

        private void dpBookingDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateAvailableTickets();
        }

        #region Methods
        private void RefreshMovieListbox()
        {
            DatabaseHandler handler = new DatabaseHandler();
            List<Movie> movies = handler.FetchMovies();

            lbxMovies.ItemsSource = null;
            lbxMovies.ItemsSource = movies;
        }

        private void PopulateMovieSynopsis()
        {
            Movie selectedMovie = (Movie)lbxMovies.SelectedItem;

            if (selectedMovie != null)
            {
                tblkMovieSynopsis.Text = selectedMovie.Description;
            }
        }

        private void PopulateAvailableTickets()
        {
            Movie selectedMovie = (Movie)lbxMovies.SelectedItem;

            if (selectedMovie != null)
            {
                DatabaseHandler handler = new DatabaseHandler();
                int availableTickets = handler.GetAvailableTickets(selectedMovie.MovieID, (DateTime)dpBookingDate.SelectedDate);
                tblkAvailableSeats.Text = availableTickets.ToString();
            }
        }

        private void CreateBooking()
        {
            // Validate inputs
            Movie selectedMovie = (Movie)lbxMovies.SelectedItem;
            DateTime? date = dpBookingDate.SelectedDate;

            if ((selectedMovie != null) && (date != null) && (int.TryParse(tbxRequiredSeats.Text, out int numberOfSeats)))
            {
                DatabaseHandler handler = new DatabaseHandler();
                int availableTickets = handler.GetAvailableTickets(selectedMovie.MovieID, (DateTime)dpBookingDate.SelectedDate);

                // Check available seats vs required
                if (numberOfSeats < availableTickets)
                {
                    handler.CreateBooking((DateTime)date, numberOfSeats, selectedMovie.MovieID);

                    // Re-populate seats textblock
                    PopulateAvailableTickets();
                }
                else
                {
                    MessageBox.Show("Not enough seats available", "Error");
                }
            }
            else
            {
                MessageBox.Show("Select movie, date to book and number of seats", "Error");
            }
        }
        #endregion
    }
}
