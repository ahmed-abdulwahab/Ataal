using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ataal.DAL.CustomValidation.CustomerValidation;

namespace Ataal.DAL.Data.Models
{
    public class Rate
    {
        [Key]
        public int RateId { get; set; }

        [ForeignKey("Customer")]
        public int Customer_ID { get; set; }

        public Customer Customer { get; set; }

        [Required]

        [ForeignKey("Technical")]
        public int Technical_ID { get; set; }

        public Technical Technical { get; set; }

        [Max_Rate(5)]
        public int Rate_Value { get; set; }
    }
}
