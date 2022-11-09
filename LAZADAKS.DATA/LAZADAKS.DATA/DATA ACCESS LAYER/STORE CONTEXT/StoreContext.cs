using LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.STORE_CONTEXT
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public virtual DbSet<User> Users
        {
            get;
            set;
        }

        public virtual DbSet<Customer> Customers
        {
            get;
            set;
        }

        public virtual DbSet<ItemCategory> ItemCategories
        {
            get;
            set;
        }

        public virtual DbSet<Product> Products
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DevConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }


    }
}
