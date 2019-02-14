using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCustomerApp.Models
{
    public class MessageRecipient
    {
        [Key]
        public int IdMesRec { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime Period { get; set; }

        public int MessageId { get; set; }
        [ForeignKey("MessageId")]
        public Message Message { get; set; }
        public int PhoneId { get; set; }
        [ForeignKey("PhoneId")]
        public Phone Phone { get; set; }
    }
}