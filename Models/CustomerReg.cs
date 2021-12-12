using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Table.Models
{
    public class CustomerReg : DbContext
    {
        public CustomerReg(DbContextOptions<CustomerReg> options) : base(options)
        {

        }
        public DbSet<Customer> CustomerRegistration { get; set; }
    }
    
}
