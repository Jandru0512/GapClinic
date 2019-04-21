﻿// <auto-generated />
using System;
using Gap.Clinic.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gap.Clinic.Persistence.Migrations
{
    [DbContext(typeof(ClinicContext))]
    [Migration("20190420234607_Appointment")]
    partial class Appointment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gap.Clinic.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentTypeId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("Date");

                    b.Property<int>("PatientId");

                    b.Property<bool>("Status");

                    b.HasKey("AppointmentId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Gap.Clinic.Models.AppointmentType", b =>
                {
                    b.Property<int>("AppointmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("AppointmentTypeId");

                    b.ToTable("AppointmentTypes");

                    b.HasData(
                        new { AppointmentTypeId = 1, Name = "Medicina General" },
                        new { AppointmentTypeId = 2, Name = "Odontología" },
                        new { AppointmentTypeId = 3, Name = "Pediatría" },
                        new { AppointmentTypeId = 4, Name = "Neurología" }
                    );
                });

            modelBuilder.Entity("Gap.Clinic.Models.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("DocumentTypeId");

                    b.ToTable("DocumentTypes");

                    b.HasData(
                        new { DocumentTypeId = 1, Name = "Cédula de ciudadanía" },
                        new { DocumentTypeId = 2, Name = "Tarjeta de identidad" }
                    );
                });

            modelBuilder.Entity("Gap.Clinic.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATETIME2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME2");

                    b.Property<int>("Document");

                    b.Property<int>("DocumentTypeId");

                    b.Property<string>("Email")
                        .HasMaxLength(320);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Status");

                    b.HasKey("PatientId");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("Patients");

                    b.HasData(
                        new { PatientId = 1, BirthDate = new DateTime(1997, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), Date = new DateTime(2019, 4, 20, 18, 46, 4, 708, DateTimeKind.Local), Document = 1234567890, DocumentTypeId = 1, Email = "jandru0512@gmail.com", LastName = "Restrepo", Name = "Andrés", Status = true }
                    );
                });

            modelBuilder.Entity("Gap.Clinic.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATETIME2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Email")
                        .HasMaxLength(320);

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserId = 1, BirthDate = new DateTime(1997, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), Date = new DateTime(2019, 4, 20, 18, 46, 4, 728, DateTimeKind.Local), Email = "jandru0512@gmail.com", LastName = "Restrepo", Name = "Andrés", Password = "123456789", Status = true, UserName = "jarestrepo" }
                    );
                });

            modelBuilder.Entity("Gap.Clinic.Models.Patient", b =>
                {
                    b.HasOne("Gap.Clinic.Models.DocumentType", "DocumentType")
                        .WithMany("Patients")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
