using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Models
{
    public class Section
    {
        
            [Key]
            public int Section_ID { get; set; }

            [Required]
            [StringLength(20, ErrorMessage = "Section_Name cannot exceed 20 characters")]   
            public string Section_Name { get; set; }
            [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
            public string Description { get; set; }

            public byte[]? Photo { get; set; }

         public ICollection<Problem>? Problems { get; set; }
         public ICollection<Technical>? Technicals { get; set; }  // all of technical in this section 
         public ICollection<KeyWords>? KeyWords { get; set; }

    }
}
