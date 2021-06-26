using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Base.Datos.Contexto.Entidades
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<GrupoRol> GrupoRols { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Trazabilidad> Trazabilidads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<GrupoRol>(entity =>
            {
                entity.ToTable("GrupoRol");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany(p => p.GrupoRols)
                    .HasForeignKey(d => d.Persona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrupoRol_Persona");

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.GrupoRols)
                    .HasForeignKey(d => d.Rol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrupoRol_Rol");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaFinal).HasColumnType("date");

                entity.Property(e => e.FechaIncial)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PrimerApellido).HasMaxLength(50);

                entity.Property(e => e.PrimerNombre).HasMaxLength(50);

                entity.Property(e => e.SegundoApellido).HasMaxLength(50);

                entity.Property(e => e.SegundoNombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo).ValueGeneratedOnAdd();

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Trazabilidad>(entity =>
            {
                entity.ToTable("Trazabilidad");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Capa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Error).IsRequired();

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.NombreMetodo)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
