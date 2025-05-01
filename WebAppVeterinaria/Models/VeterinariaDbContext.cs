using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppVeterinaria.Models;

public partial class VeterinariaDbContext : DbContext
{
    public VeterinariaDbContext()
    {
    }

    public VeterinariaDbContext(DbContextOptions<VeterinariaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CitaMedica> CitaMedica { get; set; }

    public virtual DbSet<Mascota> Mascota { get; set; }

    public virtual DbSet<Medico> Medico { get; set; }

    public virtual DbSet<Veterinaria> Veterinaria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ASPIRE_3;Database=BD_Veterinaria;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CitaMedica>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__CitaMedi__3213E83FBBAFDD95");

            entity.Property(e => e.Diagnostico).HasMaxLength(100);
            entity.Property(e => e.FechaCita).HasColumnType("datetime");
            entity.Property(e => e.Formula).HasMaxLength(50);
            entity.Property(e => e.Sintomas).HasMaxLength(50);

            entity.HasOne(d => d.Mascota).WithMany(p => p.CitaMedica)
                .HasForeignKey(d => d.MascotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CitaMedic__Masco__4222D4EF");

            entity.HasOne(d => d.Medico).WithMany(p => p.CitaMedica)
                .HasForeignKey(d => d.MedicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CitaMedic__Medic__412EB0B6");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Mascota__3213E83FA1A9C5B7");

            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.Especie).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(20);
            entity.Property(e => e.Propietario).HasMaxLength(50);
            entity.Property(e => e.Raza).HasMaxLength(20);
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Medico__3213E83FA579B379");

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Cedula).HasMaxLength(15);
            entity.Property(e => e.Ciudad).HasMaxLength(30);
            entity.Property(e => e.Departamento).HasMaxLength(30);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Genero).HasMaxLength(1);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Pais).HasMaxLength(30);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Veterinaria>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Veterina__3213E83FE7715784");

            entity.Property(e => e.Direccion).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Nit).HasMaxLength(15);
            entity.Property(e => e.RazonSocial).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
