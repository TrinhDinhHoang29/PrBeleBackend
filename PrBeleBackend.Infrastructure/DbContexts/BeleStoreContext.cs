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
        
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
