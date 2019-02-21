using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebCustomerApp.Models;

namespace WebCustomerApp.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Message> Messages { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public ApplicationUser()
        {
            Messages = new List<Message>();
            Phones = new List<Phone>();
        }
    }
}
