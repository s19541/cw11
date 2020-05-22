using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Models
{
    public class DoctorsDbContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DoctorsDbContext()
        {

        }
        public DoctorsDbContext(DbContextOptions options)
        :base(options){

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>((builder) =>
            {
                builder.HasKey(a => a.IdDoctor);
                builder.Property(a => a.IdDoctor).ValueGeneratedOnAdd();
                builder.Property(a => a.FirstName).IsRequired();
                builder.Property(a => a.LastName).IsRequired();

                builder.HasMany(a => a.Prescriptions).WithOne(a => a.Doctor).HasForeignKey(a => a.IdDoctor).IsRequired();
                var dictStudies = new List<Doctor>();
                dictStudies.Add(new Doctor { IdDoctor = 1,FirstName = "Marek",LastName = "Markowski",Email = "MMarkowski@gmail.com" });
                dictStudies.Add(new Doctor { IdDoctor = 2,FirstName = "Zbigniew", LastName = "Medyk", Email = "ZMedyk@gmail.com" });

                modelBuilder.Entity<Doctor>()
                            .HasData(dictStudies);
            });
            modelBuilder.Entity<Prescription>((builder) =>
            {
                builder.HasKey(a => a.IdPrescription);
                builder.Property(a => a.IdPrescription).ValueGeneratedOnAdd();
                builder.HasMany(a => a.PrescriptionsMedicaments).WithOne(a => a.Prescription).HasForeignKey(a => a.IdPrescription).IsRequired();
                var dictStudies = new List<Prescription>();
                dictStudies.Add(new Prescription { IdPrescription = 1 , Date = DateTime.Now,DueDate = new DateTime(2020,6,21),IdDoctor=1,IdPatient=1 });
                dictStudies.Add(new Prescription { IdPrescription = 2 , Date = DateTime.Now, DueDate = new DateTime(2020,8,4), IdDoctor = 2, IdPatient = 2 });
                dictStudies.Add(new Prescription { IdPrescription = 3 , Date = DateTime.Now, DueDate = new DateTime(2020,7,2), IdDoctor = 2, IdPatient = 3 });


                modelBuilder.Entity<Prescription>()
                            .HasData(dictStudies);
            });
            modelBuilder.Entity<Patient>((builder) =>
            {
                builder.HasKey(a => a.IdPatient);
                builder.Property(a => a.IdPatient).ValueGeneratedOnAdd();
                builder.Property(a => a.FirstName).IsRequired();
                builder.Property(a => a.LastName).IsRequired();

                builder.HasMany(a => a.Prescriptions).WithOne(a => a.Patient).HasForeignKey(a => a.IdPatient).IsRequired();
                var dictStudies = new List<Patient>();
                dictStudies.Add(new Patient { IdPatient = 1 , FirstName = "Marcin", LastName = "Krasuski", BirthDate = new DateTime(1997, 12, 25) });
                dictStudies.Add(new Patient { IdPatient = 2 , FirstName = "Lukasz", LastName = "Zygmunciak", BirthDate = new DateTime(1993,10,12) });
                dictStudies.Add(new Patient { IdPatient = 3 , FirstName = "Pawel", LastName = "Szabla", BirthDate = new DateTime(1996,4,2) });


                modelBuilder.Entity<Patient>()
                            .HasData(dictStudies);
            });
            modelBuilder.Entity<Medicament>((builder) =>
            {
                builder.HasKey(a => a.IdMedicament);
                builder.Property(a => a.IdMedicament).ValueGeneratedOnAdd();
                builder.HasMany(a => a.PrescriptionsMedicaments).WithOne(a => a.Medicament).HasForeignKey(a => a.IdMedicament).IsRequired();

                var dictStudies = new List<Medicament>();
                dictStudies.Add(new Medicament { IdMedicament = 1 , Name = "Ibuprom", Description = "lek", Type = "tabletka" });
                dictStudies.Add(new Medicament { IdMedicament = 2 , Name = "SuperLek", Description = "fajny lek", Type = "syrop" });


                modelBuilder.Entity<Medicament>()
                            .HasData(dictStudies);
            });
            modelBuilder.Entity<Prescription_Medicament>((builder) =>
            {
                builder.HasKey(a => a.IdPrescription);
                builder.HasKey(a => a.IdMedicament);

                var dictStudies = new List<Prescription_Medicament>();
                dictStudies.Add(new Prescription_Medicament { IdMedicament=1,IdPrescription=1,Dose=2 });
                dictStudies.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 6 });


                modelBuilder.Entity<Prescription_Medicament>()
                            .HasData(dictStudies);

            });
        }

    }
}
