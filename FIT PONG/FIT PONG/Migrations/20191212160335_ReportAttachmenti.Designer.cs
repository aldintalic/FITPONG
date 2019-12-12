﻿// <auto-generated />
using System;
using FIT_PONG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FIT_PONG.Migrations
{
    [DbContext(typeof(MyDb))]
    [Migration("20191212160335_ReportAttachmenti")]
    partial class ReportAttachmenti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FIT_PONG.Models.Attachment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumUnosa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReportID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ReportID");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("FIT_PONG.Models.Bracket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.ToTable("Brackets");
                });

            modelBuilder.Entity("FIT_PONG.Models.Feed", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumModifikacije")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("FIT_PONG.Models.FeedObjava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeedID")
                        .HasColumnType("int");

                    b.Property<int>("ObjavaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FeedID");

                    b.HasIndex("ObjavaID");

                    b.ToTable("FeedsObjave");
                });

            modelBuilder.Entity("FIT_PONG.Models.Grad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.ToTable("Gradovi");
                });

            modelBuilder.Entity("FIT_PONG.Models.Igrac", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("BrojPosjetaNaProfil")
                        .HasColumnType("int");

                    b.Property<string>("JacaRuka")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("PrikaznoIme")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ProfileImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Visina")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Igraci");
                });

            modelBuilder.Entity("FIT_PONG.Models.Igrac_Utakmica", b =>
                {
                    b.Property<int>("IgracID")
                        .HasColumnType("int");

                    b.Property<int>("UtakmicaID")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("OsvojeniSetovi")
                        .HasColumnType("int");

                    b.Property<int>("PristupniElo")
                        .HasColumnType("int");

                    b.Property<int>("TipRezultataID")
                        .HasColumnType("int");

                    b.HasKey("IgracID", "UtakmicaID");

                    b.HasIndex("TipRezultataID");

                    b.HasIndex("UtakmicaID");

                    b.ToTable("IgraciUtakmice");
                });

            modelBuilder.Entity("FIT_PONG.Models.Kategorija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Kategorije");
                });

            modelBuilder.Entity("FIT_PONG.Models.Konverzacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Konverzacije");
                });

            modelBuilder.Entity("FIT_PONG.Models.Login", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("FIT_PONG.Models.Objava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumIzmjene")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Objave");
                });

            modelBuilder.Entity("FIT_PONG.Models.Permisija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("ID");

                    b.ToTable("Permisije");
                });

            modelBuilder.Entity("FIT_PONG.Models.Poruka", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("KonverzacijaID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipStatusaPorukeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KonverzacijaID");

                    b.HasIndex("TipStatusaPorukeID");

                    b.ToTable("Poruke");
                });

            modelBuilder.Entity("FIT_PONG.Models.Postovanje", b =>
                {
                    b.Property<int>("PostivalacID")
                        .HasColumnType("int");

                    b.Property<int>("PostovaniID")
                        .HasColumnType("int");

                    b.HasKey("PostivalacID", "PostovaniID");

                    b.HasIndex("PostovaniID");

                    b.ToTable("Postovanja");
                });

            modelBuilder.Entity("FIT_PONG.Models.Prijava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPrijave")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("TakmicenjeID")
                        .HasColumnType("int");

                    b.Property<bool>("isTim")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("TakmicenjeID");

                    b.ToTable("Prijave");
                });

            modelBuilder.Entity("FIT_PONG.Models.Prijava_igrac", b =>
                {
                    b.Property<int>("IgracID")
                        .HasColumnType("int");

                    b.Property<int>("PrijavaID")
                        .HasColumnType("int");

                    b.HasKey("IgracID", "PrijavaID");

                    b.HasIndex("PrijavaID");

                    b.ToTable("PrijaveIgraci");
                });

            modelBuilder.Entity("FIT_PONG.Models.Report", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("FIT_PONG.Models.Runda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BracketID")
                        .HasColumnType("int");

                    b.Property<int>("BrojRunde")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumPocetka")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("BracketID");

                    b.ToTable("Runde");
                });

            modelBuilder.Entity("FIT_PONG.Models.Sistem_Takmicenja", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.ToTable("SistemiTakmicenja");
                });

            modelBuilder.Entity("FIT_PONG.Models.Stanje_Prijave", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojBodova")
                        .HasColumnType("int");

                    b.Property<int>("BrojIzgubljenih")
                        .HasColumnType("int");

                    b.Property<int>("BrojOdigranihMeceva")
                        .HasColumnType("int");

                    b.Property<int>("BrojPobjeda")
                        .HasColumnType("int");

                    b.Property<int>("PrijavaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PrijavaID")
                        .IsUnique();

                    b.ToTable("StanjaPrijave");
                });

            modelBuilder.Entity("FIT_PONG.Models.Statistika", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AkademskaGodina")
                        .HasColumnType("int");

                    b.Property<int>("BrojOdigranihMeceva")
                        .HasColumnType("int");

                    b.Property<int>("BrojOsvojenihLiga")
                        .HasColumnType("int");

                    b.Property<int>("BrojOsvojenihTurnira")
                        .HasColumnType("int");

                    b.Property<int>("BrojSinglePobjeda")
                        .HasColumnType("int");

                    b.Property<int>("BrojTimskihPobjeda")
                        .HasColumnType("int");

                    b.Property<int>("IgracID")
                        .HasColumnType("int");

                    b.Property<int>("NajveciPobjednickiNiz")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IgracID");

                    b.ToTable("Statistike");
                });

            modelBuilder.Entity("FIT_PONG.Models.Status_Takmicenja", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("StatusiTakmicenja");
                });

            modelBuilder.Entity("FIT_PONG.Models.Status_Utakmice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("StatusiUtakmice");
                });

            modelBuilder.Entity("FIT_PONG.Models.Takmicenje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrojRundi")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumPocetka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumZavrsetka")
                        .HasColumnType("datetime2");

                    b.Property<int>("FeedID")
                        .HasColumnType("int");

                    b.Property<int>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<int>("MinimalniELO")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("RokPocetkaPrijave")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RokZavrsetkaPrijave")
                        .HasColumnType("datetime2");

                    b.Property<int>("SistemID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<int>("VrstaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FeedID");

                    b.HasIndex("KategorijaID");

                    b.HasIndex("SistemID");

                    b.HasIndex("StatusID");

                    b.HasIndex("VrstaID");

                    b.ToTable("Takmicenja");
                });

            modelBuilder.Entity("FIT_PONG.Models.TipStatusaPoruke", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("ID");

                    b.ToTable("TipoviStatusaPoruke");
                });

            modelBuilder.Entity("FIT_PONG.Models.Tip_Rezultata", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("TipoviRezultata");
                });

            modelBuilder.Entity("FIT_PONG.Models.Tip_Utakmice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("TipoviUtakmica");
                });

            modelBuilder.Entity("FIT_PONG.Models.Uloga", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("FIT_PONG.Models.UlogaPermisija", b =>
                {
                    b.Property<int>("UlogaID")
                        .HasColumnType("int");

                    b.Property<int>("PermisijaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumPostavljanja")
                        .HasColumnType("datetime2");

                    b.HasKey("UlogaID", "PermisijaID");

                    b.HasIndex("PermisijaID");

                    b.ToTable("UlogePermisije");
                });

            modelBuilder.Entity("FIT_PONG.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("LoginID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.HasIndex("GradID");

                    b.HasIndex("LoginID");

                    b.ToTable("Useri");
                });

            modelBuilder.Entity("FIT_PONG.Models.UserKonverzacija", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("KonverzacijaID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "KonverzacijaID");

                    b.HasIndex("KonverzacijaID");

                    b.ToTable("UseriKonverzacije");
                });

            modelBuilder.Entity("FIT_PONG.Models.UserUloga", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("UlogaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumDodjele")
                        .HasColumnType("datetime2");

                    b.HasKey("UserID", "UlogaID");

                    b.HasIndex("UlogaID");

                    b.ToTable("UseriUloge");
                });

            modelBuilder.Entity("FIT_PONG.Models.Utakmica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojUtakmice")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<string>("Rezultat")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("RundaID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<int>("TipUtakmiceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RundaID");

                    b.HasIndex("StatusID");

                    b.HasIndex("TipUtakmiceID");

                    b.ToTable("Utakmice");
                });

            modelBuilder.Entity("FIT_PONG.Models.Vrsta_Takmicenja", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("VrsteTakmicenja");
                });

            modelBuilder.Entity("FIT_PONG.Models.Attachment", b =>
                {
                    b.HasOne("FIT_PONG.Models.Report", null)
                        .WithMany("Prilozi")
                        .HasForeignKey("ReportID");
                });

            modelBuilder.Entity("FIT_PONG.Models.FeedObjava", b =>
                {
                    b.HasOne("FIT_PONG.Models.Feed", "Feed")
                        .WithMany()
                        .HasForeignKey("FeedID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Objava", "Objava")
                        .WithMany()
                        .HasForeignKey("ObjavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Igrac", b =>
                {
                    b.HasOne("FIT_PONG.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Igrac_Utakmica", b =>
                {
                    b.HasOne("FIT_PONG.Models.Igrac", "Igrac")
                        .WithMany()
                        .HasForeignKey("IgracID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Tip_Rezultata", "TipRezultata")
                        .WithMany()
                        .HasForeignKey("TipRezultataID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Utakmica", "Utakmica")
                        .WithMany()
                        .HasForeignKey("UtakmicaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Poruka", b =>
                {
                    b.HasOne("FIT_PONG.Models.Konverzacija", "Konverzacija")
                        .WithMany()
                        .HasForeignKey("KonverzacijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.TipStatusaPoruke", "TipStatusaPoruke")
                        .WithMany()
                        .HasForeignKey("TipStatusaPorukeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Postovanje", b =>
                {
                    b.HasOne("FIT_PONG.Models.Igrac", "Postivalac")
                        .WithMany()
                        .HasForeignKey("PostivalacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Igrac", "Postovani")
                        .WithMany()
                        .HasForeignKey("PostovaniID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Prijava", b =>
                {
                    b.HasOne("FIT_PONG.Models.Takmicenje", "Takmicenje")
                        .WithMany()
                        .HasForeignKey("TakmicenjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Prijava_igrac", b =>
                {
                    b.HasOne("FIT_PONG.Models.Igrac", "Igrac")
                        .WithMany()
                        .HasForeignKey("IgracID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Prijava", "Prijava")
                        .WithMany()
                        .HasForeignKey("PrijavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Runda", b =>
                {
                    b.HasOne("FIT_PONG.Models.Bracket", "Bracket")
                        .WithMany()
                        .HasForeignKey("BracketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Stanje_Prijave", b =>
                {
                    b.HasOne("FIT_PONG.Models.Prijava", "Prijava")
                        .WithOne("StanjePrijave")
                        .HasForeignKey("FIT_PONG.Models.Stanje_Prijave", "PrijavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Statistika", b =>
                {
                    b.HasOne("FIT_PONG.Models.Igrac", "Igrac")
                        .WithMany()
                        .HasForeignKey("IgracID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Takmicenje", b =>
                {
                    b.HasOne("FIT_PONG.Models.Feed", "Feed")
                        .WithMany()
                        .HasForeignKey("FeedID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Sistem_Takmicenja", "Sistem")
                        .WithMany()
                        .HasForeignKey("SistemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Status_Takmicenja", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Vrsta_Takmicenja", "Vrsta")
                        .WithMany()
                        .HasForeignKey("VrstaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.UlogaPermisija", b =>
                {
                    b.HasOne("FIT_PONG.Models.Permisija", "Permisija")
                        .WithMany()
                        .HasForeignKey("PermisijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Uloga", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.User", b =>
                {
                    b.HasOne("FIT_PONG.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.UserKonverzacija", b =>
                {
                    b.HasOne("FIT_PONG.Models.Konverzacija", "Konverzacija")
                        .WithMany()
                        .HasForeignKey("KonverzacijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.UserUloga", b =>
                {
                    b.HasOne("FIT_PONG.Models.Uloga", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIT_PONG.Models.Utakmica", b =>
                {
                    b.HasOne("FIT_PONG.Models.Runda", "Runda")
                        .WithMany()
                        .HasForeignKey("RundaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Status_Utakmice", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIT_PONG.Models.Tip_Utakmice", "TipUtakmice")
                        .WithMany()
                        .HasForeignKey("TipUtakmiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
