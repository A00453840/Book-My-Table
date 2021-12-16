using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Book_My_Table.Controllers.BookingsController;

namespace Book_My_Table.Models
{
    public class Booking
    {
        [Key]
        [Display(Name = "Booking Id")]
        public int BookingId { get; set; }

        [Display(Name = "Restaurant Id")]
        public int RestaurantId { get; set; }
        public string CustomerId { get; set; }

        [Required]
        [RegularExpression("^[A-Z]*[a-zA-Z\\s]*$", ErrorMessage = "Please enter a valid Name")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [DateValidate(ErrorMessage = "Invalid date (Cannot be past date)")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Time (HH:mm am/pm)")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Display(Name = "Number of Guests")]
        [Range(1, 10, ErrorMessage = "Minimum of 1 and maximum of 10 guests allowed per booking")]
        public int Noofpeople { get; set; }

        [Display(Name = "Contact Number")]
        [Required]
        [RegularExpression("^(\\+1(\\s){0,1})?\\(?\\d{3}\\)?[\\s.-]?\\d{3}[\\s.-]?\\d{4}$", ErrorMessage = "Please enter a valid phone number")]
        //[DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        public int MealId { get; set; }

        public string Status { get; set; }
        //public ICollection<Meal> Meals { get; set; }
        //public ICollection<Customer> Customers { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
