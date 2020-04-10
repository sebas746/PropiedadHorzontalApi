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
        public virtual DbSet<Arrendatarios> Arrendatarios { get; set; }
        public virtual DbSet<Copropiedades> Copropiedades { get; set; }
        public virtual DbSet<Copropietarios> Copropietarios { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Municipios> Municipios { get; set; }
        public virtual DbSet<PropiedadesHorizontales> PropiedadesHorizontales { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<TipoCopropiedad> TipoCopropiedad { get; set; }
        public virtual DbSet<TipoDocumentos> TipoDocumentos { get; set; }
        public virtual DbSet<TipoPropiedadHorizontal> TipoPropiedadHorizontal { get; set; }
        public virtual DbSet<TipoServicio> TipoServicio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administradores>(entity =>
            {
                entity.HasKey(e => e.IdDocumento)
                    .HasName("PK__Administ__E52073476492559A");

                entity.Property(e => e.IdDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Administradores)
                    .HasForeignKey(d => d.IdTipoDocumento)
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

            modelBuilder.Entity<Arrendatarios>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoArrendatario)
                    .HasName("PK__Arrendat__55E5C997ED4BAB48");

                entity.Property(e => e.IdDocumentoArrendatario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Arrendatarios)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoDocumentos_Arrendatarios");
            });

            modelBuilder.Entity<Copropiedades>(entity =>
            {
                entity.HasKey(e => e.IdCopropiedad);

                entity.Property(e => e.Area).HasColumnType("decimal(8, 3)");

                entity.Property(e => e.IdDocumentoArrendatario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdDocumentoCopropietario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Indice).HasColumnType("decimal(8, 5)");

                entity.Property(e => e.NitPropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCopropiedad)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Arrendatario)
                    .WithMany(p => p.Copropiedades)
                    .HasForeignKey(d => d.IdDocumentoArrendatario)
                    .HasConstraintName("FK_Arrendatarios_Copropiedades");

                entity.HasOne(d => d.Copropietario)
                    .WithMany(p => p.Copropiedades)
                    .HasForeignKey(d => d.IdDocumentoCopropietario)
                    .HasConstraintName("FK_Copropietarios_Copropiedades");

                entity.HasOne(d => d.TipoCopropiedad)
                    .WithMany(p => p.Copropiedades)
                    .HasForeignKey(d => d.IdTipoCopropiedad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoCopropiedad_Copropiedades");

                entity.HasOne(d => d.PropiedadHorizontal)
                    .WithMany(p => p.Copropiedades)
                    .HasForeignKey(d => d.NitPropiedadHorizontal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropiedadHorizontal_Copropiedades");
            });

            modelBuilder.Entity<Copropietarios>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoCopropietario)
                    .HasName("PK__Copropie__150685C474CEF61B");

                entity.Property(e => e.IdDocumentoCopropietario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Copropietarios)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TiposDocumento_Copropietarios");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__787A433DBA0F36E7");

                entity.Property(e => e.IdDepartamento).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Municipios>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK__Municipi__6100597851A3089C");

                entity.Property(e => e.IdMunicipio).ValueGeneratedNever();

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
                entity.HasKey(e => e.NitPropiedadHorizontal);

                entity.Property(e => e.NitPropiedadHorizontal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdDocumentoAdministrador)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Administrador)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdDocumentoAdministrador)
                    .HasConstraintName("FK_PropiedadesHorizontales_Administradores");

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK_Municipios_PropHorizontal");

                entity.HasOne(d => d.TipoPropiedadHorizontal)
                    .WithMany(p => p.PropiedadesHorizontales)
                    .HasForeignKey(d => d.IdTipoPropiedadHorizontal)
                    .HasConstraintName("FK_PropiedadesHorizontales_TipoPropiedadHorizontal");
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__E8B631AF77A7203B");

                entity.Property(e => e.IdProveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NitPropiedadHorizontal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FK_TiposDocumento_Proveedores");

                entity.HasOne(d => d.IdTipoServicioNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdTipoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoServicio_Proveedores");

                entity.HasOne(d => d.NitPropiedadHorizontalNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.NitPropiedadHorizontal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropiedadesHorizontales_Proveedores");
            });

            modelBuilder.Entity<TipoCopropiedad>(entity =>
            {
                entity.HasKey(e => e.IdTipoCopropiedad)
                    .HasName("PK__TipoCopr__BB62A14D75200F0E");

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
                    .HasName("PK__TipoDocu__3AB3332F8CB4F74C");

                entity.Property(e => e.IdTipoDocumento).ValueGeneratedNever();

                entity.Property(e => e.Descripción)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPropiedadHorizontal>(entity =>
            {
                entity.HasKey(e => e.IdTipoPropiedadHorizontal)
                    .HasName("PK__TipoProp__69A9CD78FDFD0680");

                entity.Property(e => e.IdTipoPropiedadHorizontal).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoServicio>(entity =>
            {
                entity.HasKey(e => e.IdTipoServicio)
                    .HasName("PK__TipoServ__E29B3EA7FE6A86C9");

                entity.Property(e => e.IdTipoServicio).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreServicio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
