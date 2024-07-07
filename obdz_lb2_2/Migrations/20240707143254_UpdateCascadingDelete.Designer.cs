﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using obdz_lb2_2;

#nullable disable

namespace obdz_lb2_2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240707143254_UpdateCascadingDelete")]
    partial class UpdateCascadingDelete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("obdz_lb2_2.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("INTERVAL DAY(8) TO SECOND(7)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Screen", b =>
                {
                    b.Property<int>("ScreenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScreenId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<int>("TheaterId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ScreenId");

                    b.HasIndex("TheaterId");

                    b.ToTable("Screens");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Showtime", b =>
                {
                    b.Property<int>("ShowtimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowtimeId"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("MovieId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ScreenId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ShowtimeId");

                    b.HasIndex("MovieId");

                    b.HasIndex("ScreenId");

                    b.ToTable("Showtimes");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Theater", b =>
                {
                    b.Property<int>("TheaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TheaterId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.HasKey("TheaterId");

                    b.ToTable("Theaters");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<int>("ShowtimeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ViewerId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("TicketId");

                    b.HasIndex("ShowtimeId");

                    b.HasIndex("ViewerId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Viewer", b =>
                {
                    b.Property<int>("ViewerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ViewerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.HasKey("ViewerId");

                    b.ToTable("Viewers");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Screen", b =>
                {
                    b.HasOne("obdz_lb2_2.Models.Theater", "Theater")
                        .WithMany("Screens")
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Showtime", b =>
                {
                    b.HasOne("obdz_lb2_2.Models.Movie", "Movie")
                        .WithMany("Showtimes")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("obdz_lb2_2.Models.Screen", "Screen")
                        .WithMany("Showtimes")
                        .HasForeignKey("ScreenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Screen");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Ticket", b =>
                {
                    b.HasOne("obdz_lb2_2.Models.Showtime", "Showtime")
                        .WithMany("Tickets")
                        .HasForeignKey("ShowtimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("obdz_lb2_2.Models.Viewer", "Viewer")
                        .WithMany("Tickets")
                        .HasForeignKey("ViewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Showtime");

                    b.Navigation("Viewer");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Movie", b =>
                {
                    b.Navigation("Showtimes");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Screen", b =>
                {
                    b.Navigation("Showtimes");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Showtime", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Theater", b =>
                {
                    b.Navigation("Screens");
                });

            modelBuilder.Entity("obdz_lb2_2.Models.Viewer", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
