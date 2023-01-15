using ArtsofteDbModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtsofteDbModel.Context
{
    public class ArtsofteDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public ArtsofteDbContext(DbContextOptions<ArtsofteDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
