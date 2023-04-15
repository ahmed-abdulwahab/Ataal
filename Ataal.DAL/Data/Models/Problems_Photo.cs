using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Models
{
   public class Problems_Photo
    {
           [Key]
           public int Id { get; set; }
           [Required]
           public byte[] Photo { get; set; }

           [ForeignKey("Problem")]
           public int Problem_ID { get; set; }
          public Problem Problem { get; set; }



    }
}
