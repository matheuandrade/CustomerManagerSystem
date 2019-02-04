using CustomerManagerSystem.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CustomerManagerSystem.WEB.DAL
{
    public class CSMModelContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }

        public CSMModelContext() : base("name=CSMModelContext")
        {
            Database.SetInitializer<CSMModelContext>(new DropCreateDatabaseIfModelChanges<CSMModelContext>());
            //Database.SetInitializer<CSMModelContext>(new DropCreateDatabaseAlways<CSMModelContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}