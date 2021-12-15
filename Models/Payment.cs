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
        
        [DataType(DataType.Currency)]
        public float Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        public string PaymentType { get; set; }
    }
}
