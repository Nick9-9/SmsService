using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.MessageViewModels
{
   public class MessageListViewModel
    {
        [Required]
        [Display(Name = "Recepient phone number")]
        [RegularExpression(@"^\+[0-9]{12}$", ErrorMessage = "Invalid phone number")]
        public List<string> PhoneRecepient { get; set; }

        [Required]
        [Display(Name = "Text message")]
        public string TextMessage { get; set; }
        public MessageListViewModel(string textMessage, List<string> phoneRecepient)
        {
            PhoneRecepient = phoneRecepient;
            TextMessage = textMessage;
        }
    }
}
