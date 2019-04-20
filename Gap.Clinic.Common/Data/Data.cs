namespace Gap.Clinic.Common
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public static class Data
    {
        #region Extension Methods
        public static void Seed(this ModelBuilder modelBuilder)
        {
            DocumentType(modelBuilder);
            Patient(modelBuilder);
            User(modelBuilder);
            AppointmentType(modelBuilder);
        }
        #endregion

        #region Private Methods
        private static void DocumentType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>().HasData(
                new DocumentType { DocumentTypeId = 1, Name = "Cédula de ciudadanía" },
                new DocumentType { DocumentTypeId = 2, Name = "Tarjeta de identidad" });
        }

        private static void Patient(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    BirthDate = new DateTime(1997, 07, 07),
                    Date = DateTime.Now,
                    Document = 1234567890,
                    DocumentTypeId = 1,
                    Email = "jandru0512@gmail.com",
                    LastName = "Restrepo",
                    Name = "Andrés",
                    Status = true,
                    PatientId = 1
                });
        }

        private static void User(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    BirthDate = new DateTime(1997, 07, 07),
                    Date = DateTime.Now,
                    Email = "jandru0512@gmail.com",
                    LastName = "Restrepo",
                    Name = "Andrés",
                    Status = true,
                    Password = "123456789",
                    UserName = "jarestrepo",
                    UserId = 1
                });
        }

        private static void AppointmentType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentType>().HasData(
                new AppointmentType { AppointmentTypeId = 1, Name = "Medicina General" },
                new AppointmentType { AppointmentTypeId = 2, Name = "Odontología" },
                new AppointmentType { AppointmentTypeId = 3, Name = "Pediatría" },
                new AppointmentType { AppointmentTypeId = 4, Name = "Neurología" });
        }
        #endregion
    }
}
