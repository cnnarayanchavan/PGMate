using Microsoft.EntityFrameworkCore;
using PGMate.Models;

namespace PGMate.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<PGMember> PGMembers { get; set; }
        public DbSet<CleaningTask> CleaningTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Room → PGMember : 1:N
            modelBuilder.Entity<Room>()
                .HasMany(r => r.PGMembers)
                .WithOne(p => p.Room)
                .HasForeignKey(p => p.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
            

            // PGMember → CleaningTask : 1:N
            modelBuilder.Entity<PGMember>()
                .HasMany(p => p.CleaningTasks)
                .WithOne(c => c.PGMember)
                .HasForeignKey(c => c.PGMemberId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
