using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.MessageViewModels
{
   public class MessageViewModel
    {
        [Required]
        [Display(Name = "Recepient phone number")]
        [RegularExpression(@"^\+[0-9]{12}$", ErrorMessage = "Invalid phone number")]
        public string PhoneRecepient { get; set; }
        public string Name { get; set; }

        [Required]
        [Display(Name = "Text message")]
        public string TextMessage { get; set; }

    }
}
