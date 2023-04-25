using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("technical")]
        public int technicalId { get; set; }
        public Technical technical { get; set; }
        [ForeignKey("problem")]
        public int problemId { get; set; }
        public Problem problem { get; set; }
        [Required]
        public double OfferSalary { get; set; }
        public DateTime Date { set; get; } = DateTime.Now;


    }
}
