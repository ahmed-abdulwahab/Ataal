using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Models
{
   public class Review
    {
        [Key]
        public int ID { get; set; }

        [Required]
     
        [ForeignKey("Customer")]
        public int Customer_ID { get; set; }

        public Customer Customer { get; set; }
   
        [Required]
   
        [ForeignKey("Technical")]
        public int Technical_ID { get; set; }

        public Technical Technical { get; set; }
   
        [Required] 
        public string  Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }


        [ForeignKey("Report")]
        public int? Report_ID { get; set; }

        public Report? Report { get; set; }



    }
}
