using DAL.Doman.Models.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<BreakFast> BreakFasts { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Dinner> Dinner { get; set; }
        public DbSet<Lunch> Lunch { get; set; }
        public DbSet<Soda> Sodas { get; set; }
        public DbSet<Drink> Drinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=Menu_SV_Demo;Trusted_Connection=True");
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dinner>().HasData(new Dinner { Id = Guid.NewGuid(), Discription = " ssss", Name = "dd", Created = DateTime.Now });
            modelBuilder.Entity<Lunch>().HasData(new Lunch { Id = Guid.NewGuid(), Name = "sssss", Discription = "ssss", Create = DateTime.Now });
            modelBuilder.Entity<BreakFast>().HasData(new BreakFast { Id = Guid.NewGuid(), Name = "sssss", Description = "ssss", Create = DateTime.Now });
            modelBuilder.Entity<Dessert>().HasData(new Dessert { Id = Guid.NewGuid(), Name = "sssss", Description = "ssss", Create = DateTime.Now });
            modelBuilder.Entity<Drink>().HasData(new Drink { Id = Guid.NewGuid(), Name = "sssss",Size = "10"});
            modelBuilder.Entity<Soda>().HasData(new Soda { Id = Guid.NewGuid(), Name = "sssss",Size = "10"});
        }
    }
}
