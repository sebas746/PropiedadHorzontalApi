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

        public virtual DbSet<Administradores> Administradores { get; set; }
        public virtual DbSet<AreasComunes> AreasComunes { get; set; }
        public virtual DbSet<Contadores> Contadores { get; set; }
        public virtual DbSet<Copropiedades> Copropiedades { get; set; }
        public virtual DbSet<Copropietarios> Copropietarios { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Municipios> Municipios { get; set; }
        public virtual DbSet<Ocupantes> Ocupantes { get; set; }
        public virtual DbSet<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<TipoCopropiedades> TipoCopropiedades { get; set; }
        public virtual DbSet<TipoDocumentos> TipoDocumentos { get; set; }
        public virtual DbSet<TipoServicio> TipoServicio { get; set; }
        public virtual DbSet<TiposPropiedadesHorizontales> TiposPropiedadesHorizontales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administradores>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoAdministrador);

                entity.Property(e => e.IdDocumentoAdministrador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoAdministrador)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CelularAdministrador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAdministrador)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAdministrador)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoAdministradorNavigation)
                    .WithMany(p => p.Administradores)
                    .HasForeignKey(d => d.IdTipoDocumentoAdministrador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoDocumentos_Administradores");
            });

            modelBuilder.Entity<AreasComunes>(entity =>
            {
                entity.HasKey(e => e.IdAreaComun);

                entity.Property(e => e.IdAreaComun).ValueGeneratedNever();

                entity.Property(e => e.NitPropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAreaComun)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.NitPropiedadHorizontalNavigation)
                    .WithMany(p => p.AreasComunes)
                    .HasForeignKey(d => d.NitPropiedadHorizontal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropiedadesHorizontales_AreasComunes");
            });

            modelBuilder.Entity<Contadores>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoContador);

                entity.Property(e => e.IdDocumentoContador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoContador)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CelularContador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailContador)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreContador)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoContadorNavigation)
                    .WithMany(p => p.Contadores)
                    .HasForeignKey(d => d.IdTipoDocumentoContador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoDocumentos_Contadores");
            });

            modelBuilder.Entity<Copropiedades>(entity =>
            {
                entity.HasKey(e => e.IdCopropiedad);

                entity.Property(e => e.AreaCopropiedad).HasColumnType("decimal(8, 3)");

                entity.Property(e => e.IdDocumentoCopropietario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdDocumentoOcupante)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CoeficienteCopropiedad).HasColumnType("decimal(8, 5)");

                entity.Property(e => e.NitPropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCopropiedad)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Copropietario)
                    .WithMany(p => p.Copropiedades)
                    .HasForeignKey(d => d.IdDocumentoCopropietario)
                    .HasConstraintName("FK_Copropietarios_Copropiedades");

                entity.HasOne(d => d.Ocupante)
                    .WithMany(p => p.Copropiedades)
                    .HasForeignKey(d => d.IdDocumentoOcupante)
                    .HasConstraintName("FK_Ocupantes_Copropiedades");

                entity.HasOne(d => d.TipoCopropiedad)
                    .WithMany(p => p.Copropiedades)
                    .HasForeignKey(d => d.IdTipoCopropiedad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoCopropiedad_Copropiedades");

                entity.HasOne(d => d.PropiedadHorizontal)
                    .WithMany(p => p.Copropiedades)
                    .HasForeignKey(d => d.NitPropiedadHorizontal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropiedadesHorizontales_Copropiedades");
            });

            modelBuilder.Entity<Copropietarios>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoCopropietario)
                    .HasName("PK_Copropietario");

                entity.Property(e => e.IdDocumentoCopropietario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidosCopropietario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CelularCopropietario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailCopropietario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombresCopropietario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Copropietarios)
                    .HasForeignKey(d => d.IdTipoDocumentoCopropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TiposDocumento_Copropietarios");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.Property(e => e.IdDepartamento).ValueGeneratedNever();

                entity.Property(e => e.NombreDepartamento)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Municipios>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK_IdMunicipio");

                entity.Property(e => e.IdMunicipio).ValueGeneratedNever();

                entity.Property(e => e.NombreMunicipio)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK_Departamentos_Municipios");
            });

            modelBuilder.Entity<Ocupantes>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoOcupante);

                entity.Property(e => e.IdDocumentoOcupante)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoOcupante)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CelularOcupante)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailOcupante)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreOcupante)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoOcupanteNavigation)
                    .WithMany(p => p.Ocupantes)
                    .HasForeignKey(d => d.IdTipoDocumentoOcupante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoDocumentos_Ocupantes");
            });

            modelBuilder.Entity<PropiedadesHorizontales>(entity =>
            {
                entity.HasKey(e => e.NitPropiedadHorizontal);

                entity.Property(e => e.NitPropiedadHorizontal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AreaPrivadaConstruidaPropiedadHorizontal).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.AreaTotalCesionPropiedadHorizontal).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.AreaTotalLotePropiedadHorizontal).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.DireccionPropiedadHorizontal)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailPropiedadHorizontal)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdDocumentoAdministrador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdDocumentoContador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogoPropiedadHorizontal)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoPropiedadHorizontal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDocumentoAdministradorNavigation)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdDocumentoAdministrador)
                    .HasConstraintName("FK_PropiedadesHorizontales_Administradores");

                entity.HasOne(d => d.IdDocumentoContadorNavigation)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdDocumentoContador)
                    .HasConstraintName("FK_PropiedadesHorizontales_Contadores");

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK_Municipios_PropiedadesHorizontales");

                entity.HasOne(d => d.TipoPropiedadHorizontal)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdTipoPropiedadHorizontal)
                    .HasConstraintName("FK_PropiedadesHorizontales_TiposPropiedadesHorizontales");
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.Property(e => e.IdProveedor).ValueGeneratedNever();

                entity.Property(e => e.EmailProveedor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NitPropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProveedor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoProveedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoProveedorNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdTipoDocumentoProveedor)
                    .HasConstraintName("FK_TiposDocumento_Proveedores");

                entity.HasOne(d => d.IdTipoServicioProveedorNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdTipoServicioProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoServicio_Proveedores");

                entity.HasOne(d => d.NitPropiedadHorizontalNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.NitPropiedadHorizontal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropiedadesHorizontales_Proveedores");
            });

            modelBuilder.Entity<TipoCopropiedades>(entity =>
            {
                entity.HasKey(e => e.IdTipoCopropiedad);

                entity.Property(e => e.IdTipoCopropiedad).ValueGeneratedNever();

                entity.Property(e => e.DescripcionTipoCopropiedad)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoCopropiedad)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumentos>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PK_TipoDocumento");

                entity.Property(e => e.IdTipoDocumento).ValueGeneratedNever();

                entity.Property(e => e.DescripcionTipoDocumento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoDocumento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoServicio>(entity =>
            {
                entity.HasKey(e => e.IdTipoServicio);

                entity.Property(e => e.IdTipoServicio).ValueGeneratedNever();

                entity.Property(e => e.DescripcionTipoServicio)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoServicio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposPropiedadesHorizontales>(entity =>
            {
                entity.HasKey(e => e.IdTipoPropiedadHorizontal)
                    .HasName("PK_TipoPropiedadHorizontal");

                entity.Property(e => e.IdTipoPropiedadHorizontal).ValueGeneratedNever();

                entity.Property(e => e.DescripcionTipoPropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoPropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
