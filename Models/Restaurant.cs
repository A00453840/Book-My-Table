using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Table.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        //  public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Display(Name = "Opening Time")]
        [DataType(DataType.Time)]
        public DateTime OpeningTime { get; set; }

        [Display(Name = "Closing Time")]
        [DataType(DataType.Time)]
        public DateTime ClosingTime { get; set; }
       // public virtual Meal Meal { get; set; }
        //public virtual Booking Booking { get; set; }
       // public virtual TableDb TableDb { get; set; }
    }
}
