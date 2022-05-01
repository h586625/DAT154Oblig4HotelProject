using System;
using System.Collections.Generic;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Data
{
    public partial class dat154_2022_42Context : DbContext
    {
        public dat154_2022_42Context()
        {
        }

        public dat154_2022_42Context(DbContextOptions<dat154_2022_42Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Todo> Todos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = dat154.hvl.no, 1443; Database=dat154_2022_42;User=dat154_rw;Password=dat154_rw;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckedIn).HasColumnName("checked_in");

                entity.Property(e => e.CheckedOut).HasColumnName("checked_out");

                entity.Property(e => e.DateEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("date_end");

                entity.Property(e => e.DateStart)
                    .HasColumnType("datetime")
                    .HasColumnName("date_start");

                entity.Property(e => e.Roomnr).HasColumnName("roomnr");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.RoomnrNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Roomnr)
                    .HasConstraintName("FK__Reservati__roomn__5070F446");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__Reservati__useri__5535A963");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Roomnr)
                    .HasName("PK__Room__6CC4F246CB88DE5F");

                entity.Property(e => e.Roomnr)
                    .ValueGeneratedNever()
                    .HasColumnName("roomnr");

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.Beds).HasColumnName("beds");

                entity.Property(e => e.InOrder).HasColumnName("in_order");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Size).HasColumnName("size");
            });

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cleaned).HasColumnName("cleaned");

                entity.Property(e => e.Maintained).HasColumnName("maintained");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.Roomid).HasColumnName("roomid");

                entity.Property(e => e.Serviced).HasColumnName("serviced");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Todos)
                    .HasForeignKey(d => d.Roomid)
                    .HasConstraintName("FK__Todos__roomid__5812160E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__tmp_ms_x__AB6E61640D04B4EC")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
