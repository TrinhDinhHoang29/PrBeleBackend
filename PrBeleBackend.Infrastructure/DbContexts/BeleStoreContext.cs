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
        public DbSet<Setting> settings { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Discount> discounts { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<ProductTag> productTags { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<ProductOrder> productOrders { get; set; }
        public DbSet<Rate> rates { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<ProductCart> productCarts { get; set; }
        public DbSet<Keyword> keywords { get; set; }
        public DbSet<ProductKeyword> productKeywords { get; set; }
        public DbSet<WishList> wishList { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<BlogContent> blogContents { get; set; }



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
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Setting>().ToTable("Setting");
            modelBuilder.Entity<Discount>().ToTable("Discount");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<ProductTag>().ToTable("ProductTag");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<ProductOrder>().ToTable("ProductOrder");
            modelBuilder.Entity<Rate>().ToTable("Rate");
            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<ProductCart>().ToTable("ProductCart");
            modelBuilder.Entity<Keyword>().ToTable("Keyword");
            modelBuilder.Entity<ProductKeyword>().ToTable("ProductKeyword");
            modelBuilder.Entity<WishList>().ToTable("WishList");
            modelBuilder.Entity<Blog>().ToTable("Blog");
            modelBuilder.Entity<BlogContent>().ToTable("BlogContent");

            //blog start
            modelBuilder.Entity<BlogContent>()
                .HasOne(bc => bc.Blog)
                .WithMany(bc => bc.Contents)
                .HasForeignKey(bc => bc.BlogId);
            //blog end

            //product customer start
            modelBuilder.Entity<Product>()
                .HasMany(p => p.WishList)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.WishList)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<WishList>()
                .HasKey(pk => new { pk.ProductId, pk.CustomerId });
            //product customer end

            //product keyword start
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductKeywords)
                .WithOne(pt => pt.Product)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<Keyword>()
                .HasMany(key => key.ProductKeywords)
                .WithOne(key => key.Keyword)
                .HasForeignKey(key => key.KeywordId);

            modelBuilder.Entity<ProductKeyword>()
                .HasKey(pk => new { pk.ProductId, pk.KeywordId });

            modelBuilder.Entity<Keyword>()
                .HasIndex(key => key.Key);
            //product keyword end

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
            //Discount
            modelBuilder.Entity<Discount>()
                .HasMany(d => d.products)
                .WithOne(p => p.Discount)
                .HasForeignKey(p => p.DiscountId);
            //Tag
            modelBuilder.Entity<Tag>()
                .HasMany(t => t.productTags)
                .WithOne(pt=>pt.Tag)
                .HasForeignKey(t => t.TagId);
            modelBuilder.Entity<ProductTag>()
                .HasKey(pt => new {pt.TagId,pt.ProductId});
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductTags)
                .WithOne(pt => pt.Product)
                .HasForeignKey(pt => pt.ProductId);
            //Order 
            modelBuilder.Entity<ProductOrder>()
            .HasKey(pt => new { pt.VariantId, pt.OrderId });
            modelBuilder.Entity<Order>()
                .HasMany(p => p.ProductOrders)
                .WithOne(po => po.Order)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Variant>()
                .HasMany(v => v.ProductOrders)
                .WithOne(p => p.Variant)
                .HasForeignKey(v => v.VariantId);
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.UserId);
            //rate
            modelBuilder.Entity<Rate>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Rates)
                .HasForeignKey(r => r.ProductId);
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Rates)
                .WithOne(r => r.Account)
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Customer>()
              .HasMany(a => a.Rates)
              .WithOne(r => r.Customer)
              .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Rate>()
                .Ignore(r => r.RateReference);
            //cart
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithOne(c => c.Cart)
                .HasForeignKey<Cart>(c => c.UserId);
            modelBuilder.Entity<ProductCart>()
                .HasKey(c => new {c.VariantId,c.CartId});
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.ProductCarts)
                .WithOne(c => c.Cart)
                .HasForeignKey(c => c.CartId);
            modelBuilder.Entity<Variant>()
               .HasMany(c => c.ProductCarts)
               .WithOne(c => c.Variant)
               .HasForeignKey(c => c.VariantId);
  




        }
    }
}
