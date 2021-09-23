﻿// <auto-generated />
using System;
using ForbExpress.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ForbExpress.Migrations
{
    [DbContext(typeof(ForbDbContext))]
    [Migration("20210911143303_IftsAsStringMigration")]
    partial class IftsAsStringMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ForbExpress.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("ConclusionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ContractNumber")
                        .HasColumnType("text");

                    b.Property<int>("ContractState")
                        .HasColumnType("integer");

                    b.Property<bool>("DocumentsStorage")
                        .HasColumnType("boolean");

                    b.Property<string>("Ifts")
                        .HasColumnType("text");

                    b.Property<bool>("IsReturnableCopy")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LeaseEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LeaseStartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LeaseTerm")
                        .HasColumnType("integer");

                    b.Property<int>("LesseeId")
                        .HasColumnType("integer");

                    b.Property<int>("MailContractId")
                        .HasColumnType("integer");

                    b.Property<bool>("MonthlyActs")
                        .HasColumnType("boolean");

                    b.Property<bool>("Paid")
                        .HasColumnType("boolean");

                    b.Property<int>("PartnerId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Penalty")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Price1")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Price2")
                        .HasColumnType("numeric");

                    b.Property<int>("RegistrationType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LesseeId");

                    b.HasIndex("MailContractId");

                    b.HasIndex("PartnerId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("ForbExpress.Models.Lessee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bank")
                        .HasColumnType("text");

                    b.Property<string>("Bic")
                        .HasColumnType("text");

                    b.Property<string>("CheckingAccount")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Kpp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Ogrn")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.ToTable("Lessee");
                });

            modelBuilder.Entity("ForbExpress.Models.MailContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("ConclusionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ControlDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("HasProxy")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LeaseBeginDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LeaseEndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LeaseTerm")
                        .HasColumnType("integer");

                    b.Property<string>("MailContractNumber")
                        .HasColumnType("text");

                    b.Property<decimal>("Price1")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Price2")
                        .HasColumnType("numeric");

                    b.Property<string>("Responsible")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MailContracts");
                });

            modelBuilder.Entity("ForbExpress.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("ForbExpress.Models.Contract", b =>
                {
                    b.HasOne("ForbExpress.Models.Lessee", "Lessee")
                        .WithMany()
                        .HasForeignKey("LesseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForbExpress.Models.MailContract", "Mail")
                        .WithMany()
                        .HasForeignKey("MailContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForbExpress.Models.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lessee");

                    b.Navigation("Mail");

                    b.Navigation("Partner");
                });
#pragma warning restore 612, 618
        }
    }
}
