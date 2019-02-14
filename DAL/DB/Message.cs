using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebCustomerApp.Models;

namespace WebCustomerApp.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string TextMessage { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<MessageRecipient> MessageRecipients { get; set; }

        public Message()
        {
            MessageRecipients = new List<MessageRecipient>();
        }
    }
}