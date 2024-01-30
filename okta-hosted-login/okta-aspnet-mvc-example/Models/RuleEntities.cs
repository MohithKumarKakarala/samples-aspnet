using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using okta_aspnet_mvc_example.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace okta_aspnet_mvc_example.Models
{
    public class RuleEntities: DbContext
    {
        public RuleEntities() : base("RuleEntities")
        {
        }
        public DbSet<Rule> Rules { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rule>().ToTable("Rule");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}