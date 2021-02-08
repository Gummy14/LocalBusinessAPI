using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DBContexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessHours> BusinessHours { get; set; }
        public DbSet<DayOfTheWeek> DaysOfTheWeek { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables
            modelBuilder.Entity<Business>().ToTable("Businesses");
            modelBuilder.Entity<BusinessHours>().ToTable("BusinessHours");
            modelBuilder.Entity<DayOfTheWeek>().ToTable("DaysOfTheWeek");
            // Configure Primary Keys
            modelBuilder.Entity<Business>().HasKey(x => x.Id).HasName("PK_Businesses");
            modelBuilder.Entity<BusinessHours>().HasKey(x => x.Id).HasName("PK_BusinessHours");
            // Configure indexes
            modelBuilder.Entity<DayOfTheWeek>().HasIndex(x => x.Weekday).IsUnique().HasDatabaseName("Idx_Weekday");
            // Configure columns
            modelBuilder.Entity<Business>().Property(x => x.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Business>().Property(x => x.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Business>().Property(x => x.AddressStreet).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Business>().Property(x => x.AddressCity).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Business>().Property(x => x.AddressState).HasColumnType("nvarchar(2)").IsRequired();
            modelBuilder.Entity<Business>().Property(x => x.AddressZip).HasColumnType("nvarchar(5)").IsRequired();
            modelBuilder.Entity<Business>().Property(x => x.AddressCountry).HasColumnType("nvarchar(10)").IsRequired();
            modelBuilder.Entity<Business>().Property(x => x.PhoneNumber).HasColumnType("nvarchar(15)").IsRequired();

            modelBuilder.Entity<BusinessHours>().Property(x => x.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<BusinessHours>().Property(x => x.BusinessId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<BusinessHours>().Property(x => x.DayOfTheWeek).HasColumnType("int").IsRequired();
            modelBuilder.Entity<BusinessHours>().Property(x => x.OpeningTime).HasColumnType("datetime");
            modelBuilder.Entity<BusinessHours>().Property(x => x.ClosingTime).HasColumnType("datetime");

            modelBuilder.Entity<DayOfTheWeek>().Property(x => x.Id).HasColumnType("int").IsRequired();
            modelBuilder.Entity<DayOfTheWeek>().Property(x => x.Weekday).HasColumnType("nvarchar(10)").IsRequired();
            modelBuilder.Entity<DayOfTheWeek>().HasData(
                new DayOfTheWeek { Id = 1, Weekday = "Sunday" }, 
                new DayOfTheWeek { Id = 2, Weekday = "Monday" },
                new DayOfTheWeek { Id = 3, Weekday = "Tuesday" },
                new DayOfTheWeek { Id = 4, Weekday = "Wednesday" },
                new DayOfTheWeek { Id = 5, Weekday = "Thursday" },
                new DayOfTheWeek { Id = 6, Weekday = "Friday" },
                new DayOfTheWeek { Id = 7, Weekday = "Saturday" }
                );
            // Configure relationships 
            modelBuilder.Entity<BusinessHours>().HasOne<Business>().WithMany().HasForeignKey(p => p.BusinessId).IsRequired();
        }
    }
}
