using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PropiedadHorizontal.Data.data.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(nullable: false),
                    NombreDepartamento = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "TipoCopropiedades",
                columns: table => new
                {
                    IdTipoCopropiedad = table.Column<int>(nullable: false),
                    NombreTipoCopropiedad = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    DescripcionTipoCopropiedad = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCopropiedades", x => x.IdTipoCopropiedad);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    IdTipoDocumento = table.Column<int>(nullable: false),
                    NombreTipoDocumento = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    DescripcionTipoDocumento = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.IdTipoDocumento);
                });

            migrationBuilder.CreateTable(
                name: "TiposAgrupamiento",
                columns: table => new
                {
                    TipoAgrupamiento = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TiposAgr__1FF98F66F1FD5B4B", x => x.TipoAgrupamiento);
                });

            migrationBuilder.CreateTable(
                name: "TiposCuentasBancarias",
                columns: table => new
                {
                    IdTipoCuentaBancaria = table.Column<int>(nullable: false),
                    NombreTipoCuentaBancaria = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    DescripcionTipoCuentaBancaria = table.Column<string>(unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCuentaBancaria", x => x.IdTipoCuentaBancaria);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                columns: table => new
                {
                    IdTipoServicio = table.Column<int>(nullable: false),
                    NombreTipoServicio = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    DescripcionTipoServicio = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicio", x => x.IdTipoServicio);
                });

            migrationBuilder.CreateTable(
                name: "TiposPropiedadesHorizontales",
                columns: table => new
                {
                    IdTipoPropiedadHorizontal = table.Column<int>(nullable: false),
                    NombreTipoPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    DescripcionTipoPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPropiedadHorizontal", x => x.IdTipoPropiedadHorizontal);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    IdMunicipio = table.Column<long>(nullable: false),
                    NombreMunicipio = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    IdDepartamento = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdMunicipio", x => x.IdMunicipio);
                    table.ForeignKey(
                        name: "FK_Departamentos_Municipios",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamentos",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    IdDocumentoAdministrador = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IdTipoDocumentoAdministrador = table.Column<int>(nullable: false),
                    NombreAdministrador = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ApellidoAdministrador = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    CelularAdministrador = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    EmailAdministrador = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.IdDocumentoAdministrador);
                    table.ForeignKey(
                        name: "FK_TipoDocumentos_Administradores",
                        column: x => x.IdTipoDocumentoAdministrador,
                        principalTable: "TipoDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contadores",
                columns: table => new
                {
                    IdDocumentoContador = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IdTipoDocumentoContador = table.Column<int>(nullable: false),
                    NombreContador = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ApellidoContador = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    CelularContador = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    EmailContador = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contadores", x => x.IdDocumentoContador);
                    table.ForeignKey(
                        name: "FK_TipoDocumentos_Contadores",
                        column: x => x.IdTipoDocumentoContador,
                        principalTable: "TipoDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Copropietarios",
                columns: table => new
                {
                    IdDocumentoCopropietario = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IdTipoDocumentoCopropietario = table.Column<int>(nullable: false),
                    NombresCopropietario = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ApellidosCopropietario = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    CelularCopropietario = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    EmailCopropietario = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    GeneroCopropietario = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    FechaNacimientoCopropietario = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copropietario", x => x.IdDocumentoCopropietario);
                    table.ForeignKey(
                        name: "FK_TiposDocumento_Copropietarios",
                        column: x => x.IdTipoDocumentoCopropietario,
                        principalTable: "TipoDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Residentes",
                columns: table => new
                {
                    IdDocumentoResidente = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IdTipoDocumentoResidente = table.Column<int>(nullable: false),
                    NombresResidente = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ApellidosResidente = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    CelularResidente = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    EmailResidente = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    GeneroResidente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residente", x => x.IdDocumentoResidente);
                    table.ForeignKey(
                        name: "FK_TipoDocumentos_Residente",
                        column: x => x.IdTipoDocumentoResidente,
                        principalTable: "TipoDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropiedadesHorizontales",
                columns: table => new
                {
                    NitPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    NombrePropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    DireccionPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    TelefonoPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    EmailPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    LogoPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IdMunicipio = table.Column<long>(nullable: true),
                    IdTipoPropiedadHorizontal = table.Column<int>(nullable: true),
                    IdDocumentoAdministrador = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IdDocumentoContador = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AreaTotalLotePropiedadHorizontal = table.Column<decimal>(type: "decimal(10, 3)", nullable: true),
                    AreaPrivadaConstruidaPropiedadHorizontal = table.Column<decimal>(type: "decimal(10, 3)", nullable: true),
                    AreaTotalCesionPropiedadHorizontal = table.Column<decimal>(type: "decimal(10, 3)", nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    NombreBancoPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IdTipoCuentaPropiedadHorizontal = table.Column<int>(nullable: true),
                    NumeroCuentaPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropiedadesHorizontales", x => x.NitPropiedadHorizontal);
                    table.ForeignKey(
                        name: "FK_PropiedadesHorizontales_Administradores",
                        column: x => x.IdDocumentoAdministrador,
                        principalTable: "Administradores",
                        principalColumn: "IdDocumentoAdministrador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropiedadesHorizontales_Contadores",
                        column: x => x.IdDocumentoContador,
                        principalTable: "Contadores",
                        principalColumn: "IdDocumentoContador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Municipios_PropiedadesHorizontales",
                        column: x => x.IdMunicipio,
                        principalTable: "Municipios",
                        principalColumn: "IdMunicipio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropiedadesHorizontales_TiposCuentasBancarias",
                        column: x => x.IdTipoCuentaPropiedadHorizontal,
                        principalTable: "TiposCuentasBancarias",
                        principalColumn: "IdTipoCuentaBancaria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropiedadesHorizontales_TiposPropiedadesHorizontales",
                        column: x => x.IdTipoPropiedadHorizontal,
                        principalTable: "TiposPropiedadesHorizontales",
                        principalColumn: "IdTipoPropiedadHorizontal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AreasComunes",
                columns: table => new
                {
                    IdAreaComun = table.Column<int>(nullable: false),
                    NombreAreaComun = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    NitPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasComunes", x => x.IdAreaComun);
                    table.ForeignKey(
                        name: "FK_PropiedadesHorizontales_AreasComunes",
                        column: x => x.NitPropiedadHorizontal,
                        principalTable: "PropiedadesHorizontales",
                        principalColumn: "NitPropiedadHorizontal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Copropiedades",
                columns: table => new
                {
                    IdCopropiedad = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCopropiedad = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CoeficienteCopropiedad = table.Column<decimal>(type: "decimal(8, 5)", nullable: false),
                    AreaCopropiedad = table.Column<decimal>(type: "decimal(8, 3)", nullable: false),
                    NitPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IdDocumentoCopropietario = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IdTipoCopropiedad = table.Column<int>(nullable: false),
                    IdDocumentoResidente = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CuotaAdministracionCopropiedad = table.Column<decimal>(type: "decimal(11, 2)", nullable: true),
                    CodigoParqueaderoCopropiedad = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    EsResidenteCopropietario = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copropiedades", x => x.IdCopropiedad);
                    table.ForeignKey(
                        name: "FK_Copropietarios_Copropiedades",
                        column: x => x.IdDocumentoCopropietario,
                        principalTable: "Copropietarios",
                        principalColumn: "IdDocumentoCopropietario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Residentes_Copropiedades",
                        column: x => x.IdDocumentoResidente,
                        principalTable: "Residentes",
                        principalColumn: "IdDocumentoResidente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCopropiedad_Copropiedades",
                        column: x => x.IdTipoCopropiedad,
                        principalTable: "TipoCopropiedades",
                        principalColumn: "IdTipoCopropiedad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropiedadesHorizontales_Copropiedades",
                        column: x => x.NitPropiedadHorizontal,
                        principalTable: "PropiedadesHorizontales",
                        principalColumn: "NitPropiedadHorizontal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(nullable: false),
                    NombreProveedor = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    TelefonoProveedor = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    EmailProveedor = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IdTipoServicioProveedor = table.Column<int>(nullable: false),
                    NitPropiedadHorizontal = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IdTipoDocumentoProveedor = table.Column<int>(nullable: true),
                    NombreBancoProveedor = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IdTipoCuentaProveedor = table.Column<int>(nullable: true),
                    NumeroCuentaProveedor = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IdProveedor);
                    table.ForeignKey(
                        name: "FK_TipoCuentaBancaria_Proveedores",
                        column: x => x.IdTipoCuentaProveedor,
                        principalTable: "TiposCuentasBancarias",
                        principalColumn: "IdTipoCuentaBancaria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TiposDocumento_Proveedores",
                        column: x => x.IdTipoDocumentoProveedor,
                        principalTable: "TipoDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoServicio_Proveedores",
                        column: x => x.IdTipoServicioProveedor,
                        principalTable: "TipoServicio",
                        principalColumn: "IdTipoServicio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropiedadesHorizontales_Proveedores",
                        column: x => x.NitPropiedadHorizontal,
                        principalTable: "PropiedadesHorizontales",
                        principalColumn: "NitPropiedadHorizontal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_IdTipoDocumentoAdministrador",
                table: "Administradores",
                column: "IdTipoDocumentoAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_AreasComunes_NitPropiedadHorizontal",
                table: "AreasComunes",
                column: "NitPropiedadHorizontal");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contadores_IdTipoDocumentoContador",
                table: "Contadores",
                column: "IdTipoDocumentoContador");

            migrationBuilder.CreateIndex(
                name: "IX_Copropiedades_IdDocumentoCopropietario",
                table: "Copropiedades",
                column: "IdDocumentoCopropietario");

            migrationBuilder.CreateIndex(
                name: "IX_Copropiedades_IdDocumentoResidente",
                table: "Copropiedades",
                column: "IdDocumentoResidente");

            migrationBuilder.CreateIndex(
                name: "IX_Copropiedades_IdTipoCopropiedad",
                table: "Copropiedades",
                column: "IdTipoCopropiedad");

            migrationBuilder.CreateIndex(
                name: "IX_Copropiedades_NitPropiedadHorizontal",
                table: "Copropiedades",
                column: "NitPropiedadHorizontal");

            migrationBuilder.CreateIndex(
                name: "IX_Copropietarios_IdTipoDocumentoCopropietario",
                table: "Copropietarios",
                column: "IdTipoDocumentoCopropietario");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_IdDepartamento",
                table: "Municipios",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PropiedadesHorizontales_IdDocumentoAdministrador",
                table: "PropiedadesHorizontales",
                column: "IdDocumentoAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_PropiedadesHorizontales_IdDocumentoContador",
                table: "PropiedadesHorizontales",
                column: "IdDocumentoContador");

            migrationBuilder.CreateIndex(
                name: "IX_PropiedadesHorizontales_IdMunicipio",
                table: "PropiedadesHorizontales",
                column: "IdMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_PropiedadesHorizontales_IdTipoCuentaPropiedadHorizontal",
                table: "PropiedadesHorizontales",
                column: "IdTipoCuentaPropiedadHorizontal");

            migrationBuilder.CreateIndex(
                name: "IX_PropiedadesHorizontales_IdTipoPropiedadHorizontal",
                table: "PropiedadesHorizontales",
                column: "IdTipoPropiedadHorizontal");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_IdTipoCuentaProveedor",
                table: "Proveedores",
                column: "IdTipoCuentaProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_IdTipoDocumentoProveedor",
                table: "Proveedores",
                column: "IdTipoDocumentoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_IdTipoServicioProveedor",
                table: "Proveedores",
                column: "IdTipoServicioProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_NitPropiedadHorizontal",
                table: "Proveedores",
                column: "NitPropiedadHorizontal");

            migrationBuilder.CreateIndex(
                name: "IX_Residentes_IdTipoDocumentoResidente",
                table: "Residentes",
                column: "IdTipoDocumentoResidente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreasComunes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Copropiedades");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "TiposAgrupamiento");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Copropietarios");

            migrationBuilder.DropTable(
                name: "Residentes");

            migrationBuilder.DropTable(
                name: "TipoCopropiedades");

            migrationBuilder.DropTable(
                name: "TipoServicio");

            migrationBuilder.DropTable(
                name: "PropiedadesHorizontales");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Contadores");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "TiposCuentasBancarias");

            migrationBuilder.DropTable(
                name: "TiposPropiedadesHorizontales");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
