using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Customer_ID { get; set; }
        [Required]
        [ForeignKey("Technical")]
        public int Technical_ID { get; set; }

        public Technical Technical { get; set; }

        [ForeignKey("problem")]
        public int Problem_ID { get; set; }

        public Problem problem { get; set; }

   
    }
}
