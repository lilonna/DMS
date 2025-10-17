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

    public virtual DbSet<DesktopName> DesktopNames { get; set; }

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
            entity.HasOne(d => d.DesktopName).WithMany(p => p.Desktops).HasConstraintName("FK_Desktops_DesktopNames");

            entity.HasOne(d => d.Room).WithMany(p => p.Desktops).HasConstraintName("FK_Desktops_Rooms");

            entity.HasOne(d => d.User).WithMany(p => p.Desktops)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Desktops_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");
            entity.HasOne(d => d.Gender).WithMany(p => p.Users).HasConstraintName("FK_Users_Genders");
        });


        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Genders");
        });
        modelBuilder.Entity<DesktopName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DesktopNames");
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
