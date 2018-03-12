using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;

namespace RealEstate.Data
{
    public class RealEstateContext: DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(user => user.Login).IsUnique();
            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();
        }


    }
}
