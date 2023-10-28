﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal.Data;

#nullable disable

namespace ProyectoFinal.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProyectoFinal.Models.Aguinaldo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CUI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DiasLaborados")
                        .HasColumnType("real");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<float>("PromedioSalario")
                        .HasColumnType("real");

                    b.Property<float>("TotalAguinaldo")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Aguinaldo");
                });

            modelBuilder.Entity("ProyectoFinal.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AntecedentesPenales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AntecedentesPoliciacos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CUI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diplomas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fotografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdDireccion")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.Property<string>("Titulos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("idPuestos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDireccion");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("idPuestos");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ProyectoFinal.Models.Asistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("EsEntrada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<double?>("HorasExtras")
                        .HasColumnType("float");

                    b.Property<double?>("HorasTrabajadas")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioAsistenciaId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAsistenciaId");

                    b.ToTable("Asistencias");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Bono14", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Bono14Total")
                        .HasColumnType("real");

                    b.Property<string>("CUI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DiasLaborados")
                        .HasColumnType("real");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<float?>("PromedioComisiones")
                        .HasColumnType("real");

                    b.Property<float>("PromedioSalario")
                        .HasColumnType("real");

                    b.Property<float?>("SalarioAdicionalComisiones")
                        .HasColumnType("real");

                    b.Property<float?>("TotalComisiones")
                        .HasColumnType("real");

                    b.Property<float>("TotalSalarios")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Bono14");
                });

            modelBuilder.Entity("ProyectoFinal.Models.CuotaPatronal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CUI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<float>("IGSS")
                        .HasColumnType("real");

                    b.Property<float>("IRTRA")
                        .HasColumnType("real");

                    b.Property<float>("Sueldo")
                        .HasColumnType("real");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CuotaPatronal");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("ProyectoFinal.Models.DepartamentoGt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tabla_Departamentos");
                });

            modelBuilder.Entity("ProyectoFinal.Models.DireccionGt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idMunicipios")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idMunicipios");

                    b.ToTable("Tabla_Direcciones");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Indemnizacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CUI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Comisiones")
                        .HasColumnType("real");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<float?>("HorasExtras")
                        .HasColumnType("real");

                    b.Property<float>("Promedio")
                        .HasColumnType("real");

                    b.Property<float>("PromedioSalarios")
                        .HasColumnType("real");

                    b.Property<float>("SubTotal")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Indemnizacion");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Mensaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Mensajes");
                });

            modelBuilder.Entity("ProyectoFinal.Models.MunicipioGt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idDepartamentos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idDepartamentos");

                    b.ToTable("Tabla_Municipios");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Nomina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AguinaldoNomina")
                        .HasColumnType("int");

                    b.Property<float>("Anticipo")
                        .HasColumnType("real");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Bonificaciones")
                        .HasColumnType("real");

                    b.Property<int?>("Bono14Nomina")
                        .HasColumnType("int");

                    b.Property<string>("CUI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Comisiones")
                        .HasColumnType("real");

                    b.Property<int?>("CuotaPatronalNomina")
                        .HasColumnType("int");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNomina")
                        .HasColumnType("datetime2");

                    b.Property<float?>("HorasExtras")
                        .HasColumnType("real");

                    b.Property<float>("HorasLaboradas")
                        .HasColumnType("real");

                    b.Property<float?>("ISR")
                        .HasColumnType("real");

                    b.Property<float?>("IgssUsuario")
                        .HasColumnType("real");

                    b.Property<int?>("Indemnizacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("PrecioHoraExtra")
                        .HasColumnType("real");

                    b.Property<float?>("Prestamo")
                        .HasColumnType("real");

                    b.Property<float?>("Produccion")
                        .HasColumnType("real");

                    b.Property<string>("PuestoS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salario")
                        .HasColumnType("real");

                    b.Property<float>("TotalDescuentos")
                        .HasColumnType("real");

                    b.Property<float>("TotalDevengado")
                        .HasColumnType("real");

                    b.Property<float>("TotalLiquido")
                        .HasColumnType("real");

                    b.Property<string>("UsuarioNomina")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UsuarioPuesto")
                        .HasColumnType("int");

                    b.Property<int?>("VacacionesNomina")
                        .HasColumnType("int");

                    b.Property<float?>("Ventas")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AguinaldoNomina");

                    b.HasIndex("Bono14Nomina");

                    b.HasIndex("CuotaPatronalNomina");

                    b.HasIndex("Indemnizacion");

                    b.HasIndex("UsuarioNomina");

                    b.HasIndex("UsuarioPuesto");

                    b.HasIndex("VacacionesNomina");

                    b.ToTable("Nomina");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("Existencia")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Puesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salario")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("Puesto");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Vacaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CUI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Comisiones")
                        .HasColumnType("real");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<float?>("HorasExtras")
                        .HasColumnType("real");

                    b.Property<float?>("Resultado")
                        .HasColumnType("real");

                    b.Property<float>("Sueldos")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Vacaciones");
                });

            modelBuilder.Entity("ProyectoFinal.Models.VentaProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("idProducto")
                        .HasColumnType("int");

                    b.Property<int?>("idVenta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idProducto");

                    b.HasIndex("idVenta");

                    b.ToTable("VentaProducto");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Ventas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Pago")
                        .HasColumnType("int");

                    b.Property<string>("idUsuario")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("idUsuario");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProyectoFinal.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProyectoFinal.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProyectoFinal.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinal.Models.AppUser", b =>
                {
                    b.HasOne("ProyectoFinal.Models.DireccionGt", "Direcciones")
                        .WithMany()
                        .HasForeignKey("IdDireccion");

                    b.HasOne("ProyectoFinal.Models.Puesto", "IdPuesto")
                        .WithMany()
                        .HasForeignKey("idPuestos");

                    b.Navigation("Direcciones");

                    b.Navigation("IdPuesto");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Asistencia", b =>
                {
                    b.HasOne("ProyectoFinal.Models.AppUser", "UsuarioAsistencia")
                        .WithMany("Asistencias")
                        .HasForeignKey("UsuarioAsistenciaId");

                    b.Navigation("UsuarioAsistencia");
                });

            modelBuilder.Entity("ProyectoFinal.Models.DireccionGt", b =>
                {
                    b.HasOne("ProyectoFinal.Models.MunicipioGt", "MunicipioGt")
                        .WithMany()
                        .HasForeignKey("idMunicipios");

                    b.Navigation("MunicipioGt");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Mensaje", b =>
                {
                    b.HasOne("ProyectoFinal.Models.AppUser", "Appuser")
                        .WithMany("Mensajes")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appuser");
                });

            modelBuilder.Entity("ProyectoFinal.Models.MunicipioGt", b =>
                {
                    b.HasOne("ProyectoFinal.Models.DepartamentoGt", "DepartamentoGt")
                        .WithMany()
                        .HasForeignKey("idDepartamentos");

                    b.Navigation("DepartamentoGt");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Nomina", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Aguinaldo", "Aguinaldo")
                        .WithMany("Nomina")
                        .HasForeignKey("AguinaldoNomina");

                    b.HasOne("ProyectoFinal.Models.Bono14", "Bono14")
                        .WithMany("Nomina")
                        .HasForeignKey("Bono14Nomina");

                    b.HasOne("ProyectoFinal.Models.CuotaPatronal", "CuotaPAtronal")
                        .WithMany("Nomina")
                        .HasForeignKey("CuotaPatronalNomina");

                    b.HasOne("ProyectoFinal.Models.Indemnizacion", "Indemnizaciones")
                        .WithMany("Nomina")
                        .HasForeignKey("Indemnizacion");

                    b.HasOne("ProyectoFinal.Models.AppUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioNomina");

                    b.HasOne("ProyectoFinal.Models.Puesto", "Puesto")
                        .WithMany()
                        .HasForeignKey("UsuarioPuesto");

                    b.HasOne("ProyectoFinal.Models.Vacaciones", "Vacaciones")
                        .WithMany("Nomina")
                        .HasForeignKey("VacacionesNomina");

                    b.Navigation("Aguinaldo");

                    b.Navigation("Bono14");

                    b.Navigation("CuotaPAtronal");

                    b.Navigation("Indemnizaciones");

                    b.Navigation("Puesto");

                    b.Navigation("Usuario");

                    b.Navigation("Vacaciones");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Puesto", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("IdDepartamento");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("ProyectoFinal.Models.VentaProducto", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("idProducto");

                    b.HasOne("ProyectoFinal.Models.Ventas", "Venta")
                        .WithMany("ProductosEnVenta")
                        .HasForeignKey("idVenta");

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Ventas", b =>
                {
                    b.HasOne("ProyectoFinal.Models.AppUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Aguinaldo", b =>
                {
                    b.Navigation("Nomina");
                });

            modelBuilder.Entity("ProyectoFinal.Models.AppUser", b =>
                {
                    b.Navigation("Asistencias");

                    b.Navigation("Mensajes");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Bono14", b =>
                {
                    b.Navigation("Nomina");
                });

            modelBuilder.Entity("ProyectoFinal.Models.CuotaPatronal", b =>
                {
                    b.Navigation("Nomina");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Indemnizacion", b =>
                {
                    b.Navigation("Nomina");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Vacaciones", b =>
                {
                    b.Navigation("Nomina");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Ventas", b =>
                {
                    b.Navigation("ProductosEnVenta");
                });
#pragma warning restore 612, 618
        }
    }
}
