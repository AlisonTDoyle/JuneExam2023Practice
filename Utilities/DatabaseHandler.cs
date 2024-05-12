using JuneExam2023.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuneExam2023.Utilities
{
    internal class DatabaseHandler
    {
        MovieData db = new MovieData();

        public List<Movie> FetchMovies()
        {
            var query = from movie in db.Movies
                        select movie;

            return query.ToList();
        }

        public int GetAvailableTickets(int movieId, DateTime date)
        {
            var query = from booking in db.Bookings
                        where (booking.Movie.MovieID == movieId) && (booking.BookingDate == date)
                        select booking;

            List<Booking> bookings = query.ToList();
            int ticketsBooked = 0;

            for (int i = 0; i < bookings.Count; i++)
            {
                ticketsBooked += bookings[i].NumberOfTickets;
            }

            int availableTickets = 100 - ticketsBooked;

            return availableTickets;
        }

        public void CreateBooking(DateTime bookingDate, int numberOfTickets, int movieId)
        {
            // Fetch movie
            var query = (from movie in db.Movies
                        where movie.MovieID == movieId
                        select movie).FirstOrDefault();

            // Create booking
            Booking newBooking = new Booking() { BookingDate  = bookingDate, NumberOfTickets = numberOfTickets, Movie = (Movie)query};
            
            // Add booking to database
            db.Bookings.Add(newBooking);
            db.SaveChanges();
        }
    }
}
