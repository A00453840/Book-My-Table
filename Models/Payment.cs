using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Table.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int BookingId { get; set; }
        public string CustomerId { get; set; }

        [Range(10, 1000,
         ErrorMessage = "Enter an amount between 20$ - 50$")]
        [Required]
        [DataType(DataType.Currency)]
        public float Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        public string PaymentType { get; set; }
    }
}
