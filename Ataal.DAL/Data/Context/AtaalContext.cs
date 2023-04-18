using Ataal.DAL.Data.Identity;
using Ataal.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using Section = Ataal.DAL.Data.Models.Section;

namespace Ataal.DAL.Data.Context
{
    public class AtaalContext : IdentityDbContext<AppUser>
    {

        public DbSet<Rate> Rates => Set<Rate>();
        public DbSet<KeyWords> KeyWords => Set<KeyWords>();
        public DbSet<Problem> Problems => Set<Problem>();
        public DbSet<Offer>Offers=> Set<Offer>();
        public DbSet<Recommendation> Recommendations => Set<Recommendation>();

        public DbSet<Report> Reports => Set<Report>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Section> Sections => Set<Section>();
        public DbSet<Technical> Technicals => Set<Technical>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Admin> Admins => Set<Admin>();

        public AtaalContext(DbContextOptions<AtaalContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Problem>()
            .HasOne(c => c.Section)
            .WithMany(p => p.Problems)
            .OnDelete(DeleteBehavior.ClientCascade);
        }
    }

}









    
