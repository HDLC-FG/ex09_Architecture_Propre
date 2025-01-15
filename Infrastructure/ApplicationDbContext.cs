using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Flights);

            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Hotels);

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Bookings)
                .WithOne()
                .HasForeignKey(b => b.HotelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
