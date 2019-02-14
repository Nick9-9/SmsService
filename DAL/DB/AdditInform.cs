using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCustomerApp.Models
{
    public class AdditInform
    {
        [Key]
        public int AditInfId { get; set; }
        public string AditionInform { get; set; }

        public int PhoneId { get; set; }
        [ForeignKey("PhoneId")]
        public Phone Phone { get; set; }


    }
}