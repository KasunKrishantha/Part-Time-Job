using PartTimeJob.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PartTimeJob.DAL
{
    public class PartTimeContext : DbContext
    {
        public PartTimeContext() : base("PartTimeContext")
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApply> JobApplies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PostApproval> PostApprovals { get; set; }
        public DbSet<PostView> PostViews { get; set; }
        public DbSet<YourTrip> YourTrips { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}