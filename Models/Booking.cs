using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Table.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int RestaurantId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Range(0, 15, ErrorMessage = "Maximum of 15 people allowed per booking")]
        public int Noofpeople { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        public int MealId { get; set; }

        public string Status { get; set; }
        //public ICollection<Meal> Meals { get; set; }
        //public ICollection<Customer> Customers { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
