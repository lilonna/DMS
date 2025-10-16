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
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
