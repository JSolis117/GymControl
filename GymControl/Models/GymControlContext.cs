using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GymControl.Models;

public partial class GymControlContext : DbContext
{
    public GymControlContext()
    {
    }

    public GymControlContext(DbContextOptions<GymControlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Rutina> Rutinas { get; set; }

    public virtual DbSet<Subscripcione> Subscripciones { get; set; }

    public virtual DbSet<SubscripcionesCombo> SubscripcionesCombos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plane>(entity =>
        {
            entity.HasKey(e => e.Idplan).HasName("PK__Planes__8DBD72BA26B5F85A");

            entity.Property(e => e.Idplan).HasColumnName("IDPlan");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.NombrePlan).HasMaxLength(50);
            entity.Property(e => e.PrecioMensual).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("PK__Roles__A681ACB6E97D89DC");

            entity.Property(e => e.Idrol).HasColumnName("IDRol");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.NombreRol).HasMaxLength(50);
        });

        modelBuilder.Entity<Rutina>(entity =>
        {
            entity.HasKey(e => e.Idrutina).HasName("PK__Rutinas__C9ED4567C24AA078");

            entity.Property(e => e.Idrutina).HasColumnName("IDRutina");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.NombreRutina).HasMaxLength(100);

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Rutinas)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Rutinas__IDUsuar__5BE2A6F2");
        });

        modelBuilder.Entity<Subscripcione>(entity =>
        {
            entity.HasKey(e => e.Idsubscripcion).HasName("PK__Subscrip__60EFB26F33057892");

            entity.Property(e => e.Idsubscripcion).HasColumnName("IDSubscripcion");
            entity.Property(e => e.EstadoPago).HasMaxLength(20);
            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.Idplan).HasColumnName("IDPlan");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdplanNavigation).WithMany(p => p.Subscripciones)
                .HasForeignKey(d => d.Idplan)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Subscripc__IDPla__571DF1D5");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Subscripciones)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Subscripc__IDUsu__5629CD9C");
        });

        modelBuilder.Entity<SubscripcionesCombo>(entity =>
        {
            entity.HasKey(e => e.IdsubscripcionCombo).HasName("PK__Subscrip__7D45BF70F2E1B693");

            entity.Property(e => e.IdsubscripcionCombo).HasColumnName("IDSubscripcionCombo");
            entity.Property(e => e.DescuentoAplicado).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Idsubscripcion).HasColumnName("IDSubscripcion");

            entity.HasOne(d => d.IdsubscripcionNavigation).WithMany(p => p.SubscripcionesCombos)
                .HasForeignKey(d => d.Idsubscripcion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Subscripc__IDSub__5EBF139D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuarios__52311169BE8F9611");

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Contrasena).HasMaxLength(100);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.EstadoSubscripcion).HasMaxLength(20);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Idrol).HasColumnName("IDRol");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrol)
                .HasConstraintName("FK__Usuarios__IDRol__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
