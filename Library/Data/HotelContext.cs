using Microsoft.EntityFrameworkCore;

using Library.Models;

namespace Library.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=dat154.hvl.no; Port=1443; Database=dat154;UserId=dat154_rw;Password=dat154_rw; Integrated Security = true;");

    }
}