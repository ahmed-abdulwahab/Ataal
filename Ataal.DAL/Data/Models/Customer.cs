﻿using Ataal.DAL.Data.Identity;
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
      public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Frist_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        [Phone]
        public string? Phone { get; set; }



        public byte[]? Photo { get; set; }

        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        public string? Address { get; set; }

        public ICollection<Technical>? Blocked_Technicals_Id { get; set; }  //technicals who blocked by customer

        public ICollection<Problem>? Problems { get; set; } // users problems

      

    }
}
