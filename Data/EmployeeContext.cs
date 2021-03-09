using DemoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            Database.Migrate();  
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<EmployeesInProject> EmployeesInProjects { get; set;}

        public DbSet<Project> Projects { get; set;}

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeesInProject>()
             .HasKey(e => new { e.EmployeeID, e.ProjectID });


             modelBuilder.Entity<EmployeesInProject>()
            .HasOne<Employee>(e => e.Employee)
            .WithMany(p => p.EmployeesInProject);

            modelBuilder.Entity<EmployeesInProject>()
            .HasOne<Project>(e => e.Project)
            .WithMany(p => p.EmployeesInProject);
        }
    }
}
