using Microsoft.EntityFrameworkCore;
using PGMate.Models;

namespace PGMate.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CleaningTask> CleaningTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity properties, constraints, and relationships if needed
            modelBuilder.Entity<CleaningTask>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RoomNumber).IsRequired().HasMaxLength(10);
                entity.Property(e => e.AssignedTo).IsRequired().HasMaxLength(50);
                entity.Property(e => e.TaskType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ScheduledTime).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
            });
        }
    }
}
