using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessObject
{
    public class DBContext :DbContext
    {
        public DBContext() { }

        public  DbSet<MemberObject> Members { get; set; }
        public  DbSet<OrderObject> Orders { get; set; }
        public  DbSet<OrderDetailObject> OrderDetails { get; set; }
        public  DbSet<ProductObject> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            optionsBuilder.UseSqlServer("server =(local); database = MyStockDB;uid=sa;pwd=123456;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime.Now.ToString("yy/MM/dd");

            modelBuilder.Entity<MemberObject>(entity =>
                {

                    entity.Property(e => e.City)
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    entity.Property(e => e.CompanyName)
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false);

                    entity.Property(e => e.Country)
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    entity.Property(e => e.Email)
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.Password)
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);
                });
            modelBuilder.Entity<OrderObject>(entity =>
            {
                entity.Property(e => e.Freight).HasColumnType("money");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.isOrdered).HasColumnType("bit");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnType("int");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Member");
            });

            modelBuilder.Entity<OrderDetailObject>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.OrderId })
                    .HasName("OrderDetailID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.Quantity).IsRequired().HasColumnType("int");

                entity.Property(e => e.Discount).IsRequired().HasColumnType("int");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Product");
            });

            modelBuilder.Entity<ProductObject>(entity =>
            {
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId)
                .IsRequired().HasColumnType("int");

                entity.Property(e => e.UnitInStock)
                .IsRequired().HasColumnType("int");
            });

            
        }
    }
}
