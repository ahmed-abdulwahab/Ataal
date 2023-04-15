using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Models
{
     public class KeyWords
    {
        [Key]
        public int KeyWord_ID { get; set; }

        [Required]
        public string KeyWord_Name { get; set; }

        [ForeignKey("Section")]
        public int Section_ID { get; set; }
        public Section Section { get; set; }

        public ICollection<Problem>? Problems{ get; set; }
    }
}
