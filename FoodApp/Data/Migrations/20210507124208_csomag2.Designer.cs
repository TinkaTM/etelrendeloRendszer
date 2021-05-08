﻿// <auto-generated />
using System;
using FoodApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210507124208_csomag2")]
    partial class csomag2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodApp.Models.Csomag", b =>
                {
                    b.Property<int>("CsomagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EtteremID")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("RendelesID")
                        .HasColumnType("int");

                    b.Property<int>("RendelesStatID")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CsomagID");

                    b.HasIndex("EtteremID");

                    b.HasIndex("RendelesID");

                    b.HasIndex("RendelesStatID");

                    b.HasIndex("UserId");

                    b.ToTable("Csomags");
                });

            modelBuilder.Entity("FoodApp.Models.Etlap", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Allergen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ar")
                        .HasColumnType("int");

                    b.Property<string>("Kategoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Leiras")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nev")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Etlap");
                });

            modelBuilder.Entity("FoodApp.Models.EtteremCim", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EtteremNev")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Iranyitoszam")
                        .HasColumnType("int");

                    b.Property<DateTime>("Nyitas")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Varos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Zaras")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("EtteremCim");
                });

            modelBuilder.Entity("FoodApp.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("FoodApp.Models.FutarAdat", b =>
                {
                    b.Property<int>("FutarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Jarmu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keresztnev")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Kezdes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Telefonszam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Varos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Vegzes")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vezeteknev")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FutarId");

                    b.HasIndex("UserId");

                    b.ToTable("FutarAdat");
                });

            modelBuilder.Entity("FoodApp.Models.KocsiItem", b =>
                {
                    b.Property<int>("KocsiItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Darab")
                        .HasColumnType("int");

                    b.Property<int?>("EtelID")
                        .HasColumnType("int");

                    b.Property<int>("EtteremCimId")
                        .HasColumnType("int");

                    b.Property<string>("KocsiId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KocsiItemId");

                    b.HasIndex("EtelID");

                    b.HasIndex("EtteremCimId");

                    b.ToTable("KocsiItem");
                });

            modelBuilder.Entity("FoodApp.Models.Rendeles", b =>
                {
                    b.Property<int>("RendelesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Iranyitoszam")
                        .HasColumnType("int");

                    b.Property<string>("KeresztNev")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RendelesIdo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Telefonszam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCookie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Varos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VezetekNev")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RendelesId");

                    b.HasIndex("UserId");

                    b.ToTable("Rendeles");
                });

            modelBuilder.Entity("FoodApp.Models.RendelesDetail", b =>
                {
                    b.Property<int>("RendelesDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CsomagID")
                        .HasColumnType("int");

                    b.Property<int>("Darab")
                        .HasColumnType("int");

                    b.Property<int>("EtlapId")
                        .HasColumnType("int");

                    b.Property<int>("EtteremCimId")
                        .HasColumnType("int");

                    b.Property<int>("RendelesId")
                        .HasColumnType("int");

                    b.HasKey("RendelesDetailId");

                    b.HasIndex("CsomagID");

                    b.HasIndex("EtlapId");

                    b.HasIndex("EtteremCimId");

                    b.HasIndex("RendelesId");

                    b.ToTable("RendelesDetail");
                });

            modelBuilder.Entity("FoodApp.Models.RendelesStatus", b =>
                {
                    b.Property<int>("RendelesStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CompletionTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EtteremId")
                        .HasColumnType("int");

                    b.Property<int?>("FutarId")
                        .HasColumnType("int");

                    b.Property<int>("RenStatus")
                        .HasColumnType("int");

                    b.Property<int>("RendelesId")
                        .HasColumnType("int");

                    b.HasKey("RendelesStatusId");

                    b.HasIndex("EtteremId");

                    b.HasIndex("FutarId");

                    b.HasIndex("RendelesId");

                    b.ToTable("rendelesStatuse");
                });

            modelBuilder.Entity("FoodApp.Models.VendegCim", b =>
                {
                    b.Property<int>("VendegCimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Iranyitoszam")
                        .HasColumnType("int");

                    b.Property<string>("KeresztNev")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefonszam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Varos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VezetekNev")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendegCimId");

                    b.HasIndex("UserId");

                    b.ToTable("VendegCim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FoodApp.Models.Csomag", b =>
                {
                    b.HasOne("FoodApp.Models.EtteremCim", "Etterem")
                        .WithMany()
                        .HasForeignKey("EtteremID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodApp.Models.Rendeles", "Rendeles")
                        .WithMany()
                        .HasForeignKey("RendelesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodApp.Models.RendelesStatus", "RendelesStat")
                        .WithMany()
                        .HasForeignKey("RendelesStatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FoodApp.Models.Etlap", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FoodApp.Models.EtteremCim", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FoodApp.Models.FutarAdat", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FoodApp.Models.KocsiItem", b =>
                {
                    b.HasOne("FoodApp.Models.Etlap", "Etel")
                        .WithMany()
                        .HasForeignKey("EtelID");

                    b.HasOne("FoodApp.Models.EtteremCim", "EtteremCim")
                        .WithMany()
                        .HasForeignKey("EtteremCimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodApp.Models.Rendeles", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FoodApp.Models.RendelesDetail", b =>
                {
                    b.HasOne("FoodApp.Models.Csomag", null)
                        .WithMany("RendelesLine")
                        .HasForeignKey("CsomagID");

                    b.HasOne("FoodApp.Models.Etlap", "Etlap")
                        .WithMany()
                        .HasForeignKey("EtlapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodApp.Models.EtteremCim", "EtteremCim")
                        .WithMany()
                        .HasForeignKey("EtteremCimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodApp.Models.Rendeles", "Rendeles")
                        .WithMany("RendelesLine")
                        .HasForeignKey("RendelesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodApp.Models.RendelesStatus", b =>
                {
                    b.HasOne("FoodApp.Models.EtteremCim", "Etterem")
                        .WithMany()
                        .HasForeignKey("EtteremId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodApp.Models.FutarAdat", "Futar")
                        .WithMany()
                        .HasForeignKey("FutarId");

                    b.HasOne("FoodApp.Models.Rendeles", "Rendeles")
                        .WithMany()
                        .HasForeignKey("RendelesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodApp.Models.VendegCim", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
