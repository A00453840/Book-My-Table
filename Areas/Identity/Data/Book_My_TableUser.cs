using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Book_My_Table.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Book_My_TableUser class
    public class Book_My_TableUser : IdentityUser
    {
        [PersonalData]
        [RegularExpression("^[A-Z]*[a-zA-Z\\s]*$", ErrorMessage = "Please enter a valid Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [RegularExpression("^[A-Z]*[a-zA-Z\\s]*$", ErrorMessage = "Please enter a valid Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
    }
}
