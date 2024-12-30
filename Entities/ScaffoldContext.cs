using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Entities;

public partial class ScaffoldContext : DbContext
{
    public ScaffoldContext()
    {
    }

    public ScaffoldContext(DbContextOptions<ScaffoldContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=scaffold;Integrated Security = false;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Players__4A4E74A8B59801F2");

            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TeamId).HasColumnName("TeamID");

            entity.HasOne(d => d.Team).WithMany(p => p.Players)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__Players__TeamID__398D8EEE");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__123AE7B910C8BF0E");

            entity.Property(e => e.TeamId).HasColumnName("TeamID");
            entity.Property(e => e.Budget).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Eyear).HasColumnName("EYear");
            entity.Property(e => e.League)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StadiumName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TeamName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
