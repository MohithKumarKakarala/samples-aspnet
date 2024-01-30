using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using okta_aspnet_mvc_example.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace okta_aspnet_mvc_example.Models
{
    public class PolicyEntities: DbContext
    {
        public PolicyEntities() : base("PolicyEntities")
        {
        }
        public DbSet<Policy> Policies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>().ToTable("Policy");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}