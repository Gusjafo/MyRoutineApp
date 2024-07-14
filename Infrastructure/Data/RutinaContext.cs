using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class RutinaContext(DbContextOptions<RutinaContext> options) : DbContext(options)
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Period>(entity =>
            {
                entity.ToTable(nameof(Period));
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable(nameof(Session));
                entity.HasOne(d => d.Period)
                      .WithMany(p => p.Sessions)
                      .HasForeignKey(d => d.PeriodID);
            });
        }
    }
}
