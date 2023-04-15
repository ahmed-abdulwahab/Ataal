using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Models
{
     public  enum Causes { 
  
       Harassment_or_bullying,
        Hate_speech_or_discrimination,
        Inappropriate_content,
        Impersonation_or_fake_accounts,
        Spam_or_unwanted_Review


    };
   public class Report
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
    
        [ForeignKey("Review")]
        public int Review_ID { get; set; }
 
        public Review Review { get; set; }
        /// <summary>
   
        public Causes Causes { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_Date { get; set; }


    }
}
