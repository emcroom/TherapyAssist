using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TherapyAssist.Models;

namespace TherapyAssist.DAL
{
    public class TherapyAssistContext : IdentityDbContext
    {
        public TherapyAssistContext() : base("DefaultConnection")
        {
        }

        //public DbSet<Exercise> Exercises { get; set; }
        //public DbSet<ExerciseType> ExerciseTypes { get; set; }
        //public DbSet<ExerciseInterval> ExerciseIntervals { get; set; }
        //public DbSet<Equipment> Equipment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}