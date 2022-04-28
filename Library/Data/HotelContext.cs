using Microsoft.EntityFrameworkCore;

using Library.Models;

namespace Library.Data
{
    public class HotelContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<Todo> Todos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server = dat154.hvl.no, 1443; Database=dat154_2022_42;User=dat154_rw;Password=dat154_rw;");

    }
}