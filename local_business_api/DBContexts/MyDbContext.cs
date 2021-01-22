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
        public DbSet<LocalBusiness> LocalBusinesses { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables
            modelBuilder.Entity<LocalBusiness>().ToTable("LocalBusinesses");
            // Configure Primary Keys
            modelBuilder.Entity<LocalBusiness>().HasKey(x => x.Id).HasName("PK_LocalBusinesses");
            // Configure indexes
            modelBuilder.Entity<LocalBusiness>().HasIndex(x => x.Name).IsUnique().HasDatabaseName("Idx_Name");
            // Configure columns
            modelBuilder.Entity<LocalBusiness>().Property(x => x.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<LocalBusiness>().Property(x => x.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<LocalBusiness>().Property(x => x.AddressStreet).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<LocalBusiness>().Property(x => x.AddressCity).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<LocalBusiness>().Property(x => x.AddressState).HasColumnType("nvarchar(2)").IsRequired();
            modelBuilder.Entity<LocalBusiness>().Property(x => x.AddressZip).HasColumnType("nvarchar(5)").IsRequired();
            modelBuilder.Entity<LocalBusiness>().Property(x => x.PhoneNumber).HasColumnType("nvarchar(10)").IsRequired();
            // Configure relationships 
        }
    }
}
