using Microsoft.EntityFrameworkCore;
using PropiedadHorizontal.Data.Models;

namespace PropiedadHorizontal.Data.Context
{
    public partial class ApplicationDbContext : DbContext, IBaseContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administradores> Administradores { get; set; }
        public virtual DbSet<AreasComunes> AreasComunes { get; set; }
        public virtual DbSet<Contadores> Contadores { get; set; }
        public virtual DbSet<Copropiedades> Copropiedades { get; set; }
        public virtual DbSet<Copropietarios> Copropietarios { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<ItemsComunes> ItemsComunes { get; set; }
        public virtual DbSet<Municipios> Municipios { get; set; }
        public virtual DbSet<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Residentes> Residentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

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

                entity.Property(e => e.CodigoTipoDocumentoAdministrador)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAdministrador)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAdministrador)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
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

                entity.Property(e => e.CodigoTipoDocumentoContador)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmailContador)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreContador)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Copropiedades>(entity =>
            {
                entity.HasKey(e => e.IdCopropiedad);

                entity.Property(e => e.AreaCopropiedad).HasColumnType("decimal(8, 3)");

                entity.Property(e => e.CodigoParqueaderoCopropiedad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTipoCopropiedad)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CoeficienteCopropiedad).HasColumnType("decimal(8, 5)");

                entity.Property(e => e.CuotaAdministracionCopropiedad).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.IdDocumentoCopropietario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdDocumentoResidente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.Residente)
                    .WithMany(p => p.Copropiedades)
                    .HasForeignKey(d => d.IdDocumentoResidente)
                    .HasConstraintName("FK_Residentes_Copropiedades");

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

                entity.Property(e => e.CodigoTipoDocumentoCopropietario)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmailCopropietario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimientoCopropietario).HasColumnType("date");

                entity.Property(e => e.GeneroCopropietario)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NombresCopropietario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
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

            modelBuilder.Entity<ItemsComunes>(entity =>
            {
                entity.HasKey(e => e.CodigoItem)
                    .HasName("PK_ItemsComunes");

                entity.Property(e => e.CodigoItem)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoAgrupador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionItem)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreItem)
                    .IsRequired()
                    .HasMaxLength(50)
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

            modelBuilder.Entity<PropiedadesHorizontales>(entity =>
            {
                entity.HasKey(e => e.NitPropiedadHorizontal);

                entity.Property(e => e.NitPropiedadHorizontal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AreaPrivadaConstruidaPropiedadHorizontal).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.AreaTotalCesionPropiedadHorizontal).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.AreaTotalLotePropiedadHorizontal).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.CodigoTipoCuentaPropiedadHorizontal)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTipoPropiedadHorizontal)
                    .HasMaxLength(15)
                    .IsUnicode(false);

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

                entity.Property(e => e.NombreBancoPropiedadHorizontal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCuentaPropiedadHorizontal)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoPropiedadHorizontal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdDocumentoAdministrador)
                    .HasConstraintName("FK_PropiedadesHorizontales_Administradores");

                entity.HasOne(d => d.Contador)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdDocumentoContador)
                    .HasConstraintName("FK_PropiedadesHorizontales_Contadores");

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK_Municipios_PropiedadesHorizontales");
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.Property(e => e.IdProveedor).ValueGeneratedNever();

                entity.Property(e => e.CodigoTipoCuentaProveedor)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTipoDocumentoProveedor)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTipoPersonaTributaria)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTipoServicioProveedor)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmailProveedor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NitPropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreBancoProveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProveedor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCuentaProveedor)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RutProveedor)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoProveedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.NitPropiedadHorizontalNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.NitPropiedadHorizontal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropiedadesHorizontales_Proveedores");
            });

            modelBuilder.Entity<Residentes>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoResidente)
                    .HasName("PK_Residente");

                entity.Property(e => e.IdDocumentoResidente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidosResidente)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CelularResidente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTipoDocumentoResidente)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmailResidente)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeneroResidente)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NombresResidente)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
