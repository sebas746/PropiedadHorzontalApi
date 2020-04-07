using Microsoft.EntityFrameworkCore;
using PropiedadHorizontal.Data.Models;

namespace PropiedadHorizontal.Data.Context
{
    public partial class PropiedadHorizontalContext : DbContext, IBaseContext
    {
        public PropiedadHorizontalContext()
        {
        }

        public PropiedadHorizontalContext(DbContextOptions<PropiedadHorizontalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Municipios> Municipios { get; set; }
        public virtual DbSet<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__787A433D57B3B15B");

                entity.Property(e => e.IdDepartamento).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Municipios>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK__Municipi__61005978DD14B2EE");

                entity.Property(e => e.IdMunicipio).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdDepartamento).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK_Departamentos_Municipios");
            });

            modelBuilder.Entity<PropiedadesHorizontales>(entity =>
            {
                entity.HasKey(e => e.Nit)
                    .HasName("PK__Propieda__C7D1D6DB0F151262");

                entity.Property(e => e.Nit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdMunicipio).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Logo).HasColumnType("varchar(200)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK_Municipios_PropHorizontal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
