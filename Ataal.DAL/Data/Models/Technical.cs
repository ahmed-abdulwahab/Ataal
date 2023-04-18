using Ataal.DAL.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Data.Models
{
    public class Technical 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Frist Name cannot exceed 20 characters")]

        public string Frist_Name { get; set; } = string.Empty;

        [Required]
        [StringLength(20, ErrorMessage = "Last Name cannot exceed 20 characters")]

        public string Last_Name { get; set; } = string.Empty;


        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public byte []?  Photo { get; set; }         // it will be in the parent class 


        [Required]
        public int Rate { get; set; } = 0;

        public string? Brief { get; set; }
        public int NotificationCounter { get; set; } = 0;
        public Offer? offer { get; set; }


        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public ICollection<Section> Sections { get; set; }  // the sections which choosed by him to see its problems
        public ICollection<Recommendation>? Recommendations { get; set; }
        public ICollection<Problem>? Problems_Solved { get; set; } // the problems which solved by him
        public ICollection<Review>? Reviews { get; set; } // reviews from customers for him
        public ICollection<Rate>? CustomersRate { get; set; }

        public ICollection<Report>? Reports { get; set; }// Reports from customers for him
             
        public ICollection<Customer>? Blocked_Customers_Id { get; set; } //customers  who blocked by technical
     
    }
}
