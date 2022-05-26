using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer_DAL.Models;

namespace DataAccessLayer_DAL
{
    public class LaptopStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public LaptopStoreDbContext()
        {

        }
        public LaptopStoreDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Orders>().HasOne(b => b.Laptops)
                .WithMany(ba => ba.Orders)
                .HasForeignKey(bi => bi.LaptopId);

            /*modelBuilder.Entity<Orders>().HasOne(b => b.Customers)
                .WithMany(ba => ba.Orders)
                .HasForeignKey(bi => bi.CustomerId);*/


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BSC-PG02TQPS\\SQLEXPRESS;Database=LaptopSell;Trusted_Connection=True;MultipleActiveResultSets=true");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
