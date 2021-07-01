using Microsoft.EntityFrameworkCore;
using Migrations.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migrations.Web.Models.MigrationsDB
{
    public class MigrationsContext : DbContext
    {

        public MigrationsContext() { }

        public MigrationsContext(DbContextOptions<MigrationsContext> options ) : base(options)
        {

        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Customer>(e =>
            {
                e.ToTable("Customer");

                e.Property(e => e.FirstName)
                    .HasMaxLength(50);
            });

            model.Entity<Order>(e =>
            {
                e.ToTable("Order");

                e.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsRequired();

                e.HasOne(e => e.Customer)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.CustomerID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");
            });

            model.Entity<Blog>(e =>
            {
                e.ToTable("Blog");

                e.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsRequired();
            });
        }
    }
}
