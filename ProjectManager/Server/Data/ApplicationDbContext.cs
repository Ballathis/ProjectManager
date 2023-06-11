using Microsoft.EntityFrameworkCore;
using ProjectManager.Server.Data.Entities;

namespace ProjectManager.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DesignObject> DesignObjects { get; set; }
        public DbSet<Documentation> Documentations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
