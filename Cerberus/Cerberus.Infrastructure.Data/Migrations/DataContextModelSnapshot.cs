﻿// <auto-generated />
using Cerberus.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cerberus.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Cerberus.Domain.Models.Machine.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MAC")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OS")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("VictimID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VictimID");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("Cerberus.Domain.Models.Machine.ComputerFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ComputerID")
                        .HasColumnType("int");

                    b.Property<string>("Json")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("ComputerID");

                    b.ToTable("ComputerFile");
                });

            modelBuilder.Entity("Cerberus.Domain.Models.Machine.ComputerScript", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ComputerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("ComputerScript");
                });

            modelBuilder.Entity("Cerberus.Domain.Models.Person.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ProfilePhoto")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Cerberus.Domain.Models.Person.Victim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Victim");
                });

            modelBuilder.Entity("Cerberus.Domain.Models.Machine.Computer", b =>
                {
                    b.HasOne("Cerberus.Domain.Models.Person.Victim", "Victim")
                        .WithMany()
                        .HasForeignKey("VictimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Victim");
                });

            modelBuilder.Entity("Cerberus.Domain.Models.Machine.ComputerFile", b =>
                {
                    b.HasOne("Cerberus.Domain.Models.Machine.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computer");
                });

            modelBuilder.Entity("Cerberus.Domain.Models.Machine.ComputerScript", b =>
                {
                    b.HasOne("Cerberus.Domain.Models.Machine.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computer");
                });
#pragma warning restore 612, 618
        }
    }
}
