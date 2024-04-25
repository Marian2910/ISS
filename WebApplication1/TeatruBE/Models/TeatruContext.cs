using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TeatruBE.Models;

public partial class TeatruContext : DbContext
{
    public TeatruContext()
    {
    }

    public TeatruContext(DbContextOptions<TeatruContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Loc> Locs { get; set; }

    public virtual DbSet<Rezervare> Rezervares { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Spectacol> Spectacols { get; set; }

    public virtual DbSet<TipLoc> TipLocs { get; set; }

    public virtual DbSet<Utilizator> Utilizators { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Teatru;User Id=SA;Password=MyPassword123#;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loc>(entity =>
        {
            entity.HasKey(e => e.LocId).HasName("PK__Loc__7931970B811A5D18");

            entity.ToTable("Loc");

            entity.Property(e => e.LocId)
                .ValueGeneratedNever()
                .HasColumnName("locId");
            entity.Property(e => e.SpectacolId).HasColumnName("spectacolId");
            entity.Property(e => e.Stare)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("stare");
            entity.Property(e => e.TipLocId).HasColumnName("tipLocId");

            entity.HasOne(d => d.Spectacol).WithMany(p => p.Locs)
                .HasForeignKey(d => d.SpectacolId)
                .HasConstraintName("FK__Loc__spectacolId__3B75D760");

            entity.HasOne(d => d.TipLoc).WithMany(p => p.Locs)
                .HasForeignKey(d => d.TipLocId)
                .HasConstraintName("FK__Loc__tipLocId__3C69FB99");
        });

        modelBuilder.Entity<Rezervare>(entity =>
        {
            entity.HasKey(e => e.RezervareId).HasName("PK__Rezervar__2F762A9FE62D65BF");

            entity.ToTable("Rezervare");

            entity.Property(e => e.RezervareId)
                .ValueGeneratedNever()
                .HasColumnName("rezervareId");
            entity.Property(e => e.SpectacolId).HasColumnName("spectacolId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Spectacol).WithMany(p => p.Rezervares)
                .HasForeignKey(d => d.SpectacolId)
                .HasConstraintName("FK__Rezervare__spect__4222D4EF");

            entity.HasOne(d => d.User).WithMany(p => p.Rezervares)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Rezervare__userI__412EB0B6");

            entity.HasMany(d => d.Locs).WithMany(p => p.Rezervares)
                .UsingEntity<Dictionary<string, object>>(
                    "RezervareLoc",
                    r => r.HasOne<Loc>().WithMany()
                        .HasForeignKey("LocId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Rezervare__locId__45F365D3"),
                    l => l.HasOne<Rezervare>().WithMany()
                        .HasForeignKey("RezervareId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Rezervare__rezer__44FF419A"),
                    j =>
                    {
                        j.HasKey("RezervareId", "LocId").HasName("PK__Rezervar__88E533EF4269BFA8");
                        j.ToTable("RezervareLoc");
                        j.IndexerProperty<int>("RezervareId").HasColumnName("rezervareId");
                        j.IndexerProperty<int>("LocId").HasColumnName("locId");
                    });
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.SalaId).HasName("PK__Sala__F876175230C99CAD");

            entity.ToTable("Sala");

            entity.Property(e => e.SalaId)
                .ValueGeneratedNever()
                .HasColumnName("salaId");
            entity.Property(e => e.NumarLocuri).HasColumnName("numarLocuri");
            entity.Property(e => e.Nume)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nume");
        });

        modelBuilder.Entity<Spectacol>(entity =>
        {
            entity.HasKey(e => e.SpectacolId).HasName("PK__Spectaco__AEDEDF89ECDCDF2B");

            entity.ToTable("Spectacol");

            entity.Property(e => e.SpectacolId)
                .ValueGeneratedNever()
                .HasColumnName("spectacolId");
            entity.Property(e => e.Data)
                .HasColumnType("date")
                .HasColumnName("data");
            entity.Property(e => e.NumarLocuri).HasColumnName("numarLocuri");
            entity.Property(e => e.Nume)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nume");
            entity.Property(e => e.Ora).HasColumnName("ora");
        });

        modelBuilder.Entity<TipLoc>(entity =>
        {
            entity.HasKey(e => e.TipLocId).HasName("PK__TipLoc__28CD8E28CDCE5183");

            entity.ToTable("TipLoc");

            entity.Property(e => e.TipLocId)
                .ValueGeneratedNever()
                .HasColumnName("tipLocId");
            entity.Property(e => e.Nume)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nume");
            entity.Property(e => e.Pret)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("pret");
        });

        modelBuilder.Entity<Utilizator>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Utilizat__CB9A1CFF7B51165F");

            entity.ToTable("Utilizator");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nume)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nume");
            entity.Property(e => e.Parola)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("parola");
            entity.Property(e => e.Prenume)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("prenume");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
