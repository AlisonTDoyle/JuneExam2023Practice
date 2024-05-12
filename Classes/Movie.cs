using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JuneExam2023.Classes
{
    public class Movie
    {
        // Properties
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string Cast { get; set; }
        public virtual List<Booking> Bookings { get; set; }

        // Constructors
        public Movie() 
        {
            // Tells computer to set aside memory for list
            Bookings = new List<Booking>();
        }

        // Methods
        public override string ToString()
        {
            return Title;
        }
    }

    // Create Database
    public class MovieData : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public MovieData(string database) : base(database)
        {
        }

        public MovieData() : this("OODExam_AlisonDoyle")
        {
        }
    }
}

