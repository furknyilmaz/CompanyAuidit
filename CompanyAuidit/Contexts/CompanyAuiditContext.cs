using CompanyAuidit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CompanyAuidit.Contexts
{
    public class CompanyAuiditContext : DbContext
    {
        public CompanyAuiditContext(DbContextOptions<CompanyAuiditContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserItem> UserItems { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
