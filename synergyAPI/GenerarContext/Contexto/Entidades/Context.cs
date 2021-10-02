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

        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<GrupoRol> GrupoRols { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<PersonaEmpresa> PersonaEmpresas { get; set; }
        public virtual DbSet<PersonaSede> PersonaSedes { get; set; }
        public virtual DbSet<RegistroTarjetum> RegistroTarjeta { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Sede> Sedes { get; set; }
        public virtual DbSet<Trazabilidad> Trazabilidads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QEFA977\\SQLEXPRESS;Initial Catalog=synergy;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicial)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaReIntegro).HasColumnType("datetime");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.PaisNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.Pais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_Empresa_Pais");
            });

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

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CelularPersona)
                    .IsRequired()
                    .HasMaxLength(50);

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

            modelBuilder.Entity<PersonaEmpresa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PersonaEmpresa");

                entity.HasOne(d => d.EmpresaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Empresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaEmpresa_Empresa");

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Persona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaEmpresa_Persona");
            });

            modelBuilder.Entity<PersonaSede>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PersonaSede");

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Persona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaSede_Persona");

                entity.HasOne(d => d.SedeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Sede)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaSede_Sede");
            });

            modelBuilder.Entity<RegistroTarjetum>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AnoVigenciaTarjeta)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.CodigoCvv)
                    .IsRequired()
                    .HasColumnName("CodigoCVV");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MesVigenciaTarjeta)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.NombreTitular)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumeroTarjeta)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.EmpresaNavigation)
                    .WithMany(p => p.RegistroTarjeta)
                    .HasForeignKey(d => d.Empresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistroTarjeta_Empresa");
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

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.ToTable("Sede");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ColorBox)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicial)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.EmpresaNavigation)
                    .WithMany(p => p.Sedes)
                    .HasForeignKey(d => d.Empresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_Empresa");

                entity.HasOne(d => d.PaisNavigation)
                    .WithMany(p => p.Sedes)
                    .HasForeignKey(d => d.Pais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_Sede_Pais");
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
