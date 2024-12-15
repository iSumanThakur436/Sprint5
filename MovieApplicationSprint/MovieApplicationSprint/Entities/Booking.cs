using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApplicationSprint.Entities
{
    public class Booking
    {
        [Key]
        public string BookingId { get; set; }

        [ForeignKey("UserNavigation")]
        public string UserId { get; set; } // Foreign Key to User table

        [ForeignKey("ShowTimeNavigation")]
        public string ShowTimeId { get; set; } // Foreign Key to ShowTime table

        public DateTime BookingDate { get; set; } // Date of booking

        public int TotalPrice { get; set; } // Total cost of booking

        public string Status { get; set; } // Example: confirmed, canceled, etc.

        // Navigation properties
        public User UserNavigation { get; set; }
        public ShowTime ShowTimeNavigation { get; set; }
    }
}
