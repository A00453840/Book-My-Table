using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_My_Table.Models;

namespace Book_My_Table.Models
{
    public class CustomerReg : DbContext
    {
        public CustomerReg(DbContextOptions<CustomerReg> options) : base(options)
        {

        }
        public DbSet<Customer> CustomerRegistration { get; set; }
        public DbSet<Book_My_Table.Models.Booking> Booking { get; set; }
        public DbSet<Book_My_Table.Models.Restaurant> Restaurant { get; set; }
        public DbSet<Book_My_Table.Models.Payment> Payment { get; set; }
        public DbSet<Book_My_Table.Models.SavedCard> SavedCard { get; set; }
    }
    
}
