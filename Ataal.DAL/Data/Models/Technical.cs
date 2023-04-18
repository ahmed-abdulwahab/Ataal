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

        [Phone]
        public string? Phone { get; set; }


        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public byte []?  Photo { get; set; }// it will be in the parent class 


        
        public int? Rate { get; set; }

        
        public string? Brief { get; set; }

        

        public Offer? offer { get; set; }

       
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        public string? Address { get; set; }

        [Required]
        public ICollection<Section> Sections { get; set; }  // the sections which choosed by him to see its problems

        public ICollection<Problem>? Problems_Solved { get; set; } // the problems which solved by him
        public ICollection<Review>? Reviews { get; set; } // reviews from customers for him

        public ICollection<Report>? Reports { get; set; }// Reports from customers for him
        public ICollection<Rate>? CustomersRate { get; set; }
        public ICollection<Customer>? Blocked_Customers_Id { get; set; } //customers  who blocked by technical
     
    }
}
