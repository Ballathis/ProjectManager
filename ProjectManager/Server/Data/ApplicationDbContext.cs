using Microsoft.EntityFrameworkCore;
using ProjectManager.Server.Data.Entities;
using System;

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
        public DbSet<DocumentationCounter> DocumentationsCounter { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Documentation>()
                .HasIndex(p => new { p.IdDesignObject, p.IdMark, p.Number })
                .IsUnique(true);
            modelBuilder.Entity<DocumentationCounter>()
                .HasIndex(p => p.IdDesignObject)
                .IsUnique(true);
        }
    }
}
