using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuneExam2023.Classes
{
    public class Booking
    {
        // Properties
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfTickets { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
