using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.DbContexts
{
    public class BeleStoreContext : DbContext
    {
        public BeleStoreContext(DbContextOptions<BeleStoreContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductAttributeType> productAttributeTypes { get; set; }
        public DbSet<AttributeType> attributeTypes { get; set; }
        public DbSet<AttributeValue> attributeValues { get; set; }
        public DbSet<Variant> variants { get; set; }
        public DbSet<VariantAttributeValue> variantAttributeValues { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Permission> permissions { get; set; } 
        public DbSet<Role> roles { get; set; }
        public DbSet<RolePermission> rolePermissions { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<AddressCustomer> addressCustomers { get; set; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductAttributeType>().ToTable("ProductAttributeType");
            modelBuilder.Entity<AttributeType>().ToTable("AttributeType");
            modelBuilder.Entity<AttributeValue>().ToTable("AttributeValue");
            modelBuilder.Entity<Variant>().ToTable("Variant");
            modelBuilder.Entity<VariantAttributeValue>().ToTable("VariantAttributeValue");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Permission>().ToTable("Permission");
            modelBuilder.Entity<RolePermission>().ToTable("RolePermission");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<AddressCustomer>().ToTable("AddressCustomer");


            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)          // Product có 1 Category
            .WithMany(c => c.Products)        // Category có nhiều Product
            .HasForeignKey(p => p.CategoryId); // Sử dụng CategoryId làm Foreign Key

            modelBuilder.Entity<AttributeType>()
                .HasMany(a => a.AttributeValues)
                .WithOne(b=> b.AttributeType)
                .HasForeignKey(a =>a.AttributeTypeId);
            modelBuilder.Entity<ProductAttributeType>()
                .HasKey(v => new {v.ProductId,v.AttributeTypeId});
            modelBuilder.Entity<ProductAttributeType>()
                .HasOne(a => a.Product)
                .WithMany(p => p.ProductAttributeTypes)
                .HasForeignKey(p=>p.ProductId);
            modelBuilder.Entity<ProductAttributeType>()
                .HasOne(a => a.AttributeType)
                .WithMany(p => p.ProductAttributeTypes)
                .HasForeignKey(p => p.AttributeTypeId);
            modelBuilder.Entity<VariantAttributeValue>()
                .HasKey(v => new {v.VariantId,v.AttributeValueId});
            modelBuilder.Entity<VariantAttributeValue>()
                .HasOne(p => p.Variant)
                .WithMany(p => p.VariantAttributeValues)
                .HasForeignKey(p => p.VariantId);
            modelBuilder.Entity<VariantAttributeValue>()
                .HasOne(p => p.AttributeValue)
                .WithMany(p => p.VariantAttributeValues)
                .HasForeignKey(p => p.AttributeValueId);
            modelBuilder.Entity<Variant>()
                .HasOne(v=>v.Product)
                .WithMany(p=>p.Variants)
                .HasForeignKey(p=>p.ProductId);

            //role
            modelBuilder.Entity<Role>()
                .HasMany(r => r.RolePermissions)
                .WithOne(p => p.Role)
                .HasForeignKey(p => p.RoleId);
            //permission
            modelBuilder.Entity<Permission>()
               .HasMany(r => r.RolePermissions)
               .WithOne(p => p.Permission)
               .HasForeignKey(p => p.PermissionId);
            //rolePermission
            modelBuilder.Entity<RolePermission>()
            .HasKey(r => new { r.PermissionId, r.RoleId});
            //Account
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId);
            //Customer
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.AddressCustomers)
                .WithOne(a => a.Customer)
                .HasForeignKey(c => c.CustomerId);

        }
    }
}
