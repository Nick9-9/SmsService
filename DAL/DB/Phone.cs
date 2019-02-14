using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebCustomerApp.Models
{
    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneRecepient { get; set; }
        
        public ICollection<MessageRecipient> MessageRecipients { get; set; }
        public ICollection<AdditInform> AdditInforms { get; set; }


        public Phone()
        {
            MessageRecipients = new List<MessageRecipient>();
            AdditInforms = new List<AdditInform>();
        }

    }
}