using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Models
{
  public class Problem
    {
        [Key]
        public int Problem_ID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Description cannot exceed 20 characters")]
        public string Problem_Title { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Description cannot exceed 300 characters")]
        public string Description { get; set; }
        public string? PhotoPath1 { get; set; }
        public string? PhotoPath2 { get; set; }
        public string? PhotoPath3 { get; set; }
        public string? PhotoPath4 { get; set; }

        public bool Solved { get; set; } = false;

        [ForeignKey("Section")]
        public int Section_ID { get; set; }
        public Section Section { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;
        public int? AcceptedOfferID { get; set; }

        public bool VIP { get; set; } = false;

       public ICollection<Offer>? Offers { get; set; }

        [ForeignKey("Technical")]
        public int? Technical_ID { get; set; }            
        public Technical? Technical { get; set; }

        public ICollection<Recommendation>? Recommendations { get; set; }

        [ForeignKey("Customer")]
        public int Customer_ID { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("KeyWord")]
        public int? KeyWord_ID { get; set; }
        public KeyWords? KeyWord { get; set; }
    }
}
