using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DMS.Models;

public partial class DMSContext : DbContext
{
    public DMSContext()
    {
    }

    public DMSContext(DbContextOptions<DMSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Desktop> Desktops { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DMSConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Desktop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Desktops");
            entity.HasOne(d => d.Room).WithMany(p => p.Desktops)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Desktops_Rooms");

            entity.HasOne(d => d.User).WithMany(p => p.Desktops)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Desktops_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");
            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Genders");
        });

        // Genders
        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Genders");
        });

        // Rooms
        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Rooms");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
