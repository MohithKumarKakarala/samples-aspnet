using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using okta_aspnet_mvc_example.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace okta_aspnet_mvc_example.Models
{
    public class InstructionEntities: DbContext
    {
        public InstructionEntities() : base("InstructionEntities")
        {
        }
        public DbSet<Instruction> Instructions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instruction>().ToTable("Instruction");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}