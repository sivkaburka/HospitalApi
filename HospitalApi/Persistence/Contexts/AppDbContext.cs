using HospitalApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Area>().ToTable("Areas");
            builder.Entity<Area>().HasKey(p => p.Id);
            builder.Entity<Area>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Area>().Property(p => p.Number).IsRequired();
            builder.Entity<Area>().HasMany(p => p.Doctors).WithOne(p => p.Area).HasForeignKey(p => p.AreaId);
            builder.Entity<Area>().HasMany(p => p.Patients).WithOne(p => p.Area).HasForeignKey(p => p.AreaId);

            builder.Entity<Area>().HasData
            (
                new Area { Id = 1, Number = 10 },
                new Area { Id = 2, Number = 11 },
                new Area { Id = 3, Number = 12 },
                new Area { Id = 4, Number = 13 }
            );

            builder.Entity<Cabinet>().ToTable("Cabinets");
            builder.Entity<Cabinet>().HasKey(p => p.Id);
            builder.Entity<Cabinet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Cabinet>().Property(p => p.Number).IsRequired();
            builder.Entity<Cabinet>().HasMany(p => p.Doctors).WithOne(p => p.Cabinet).HasForeignKey(p => p.CabinetId);

            builder.Entity<Cabinet>().HasData
            (
                new Cabinet { Id = 1, Number = 5 },
                new Cabinet { Id = 2, Number = 6 },
                new Cabinet { Id = 3, Number = 7 },
                new Cabinet { Id = 4, Number = 8 }
            );

            builder.Entity<Specialization>().ToTable("Specializations");
            builder.Entity<Specialization>().HasKey(p => p.Id);
            builder.Entity<Specialization>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Specialization>().Property(p => p.Name).IsRequired();
            builder.Entity<Specialization>().HasMany(p => p.Doctors).WithOne(p => p.Specialization).HasForeignKey(p => p.SpecializationId);

            builder.Entity<Specialization>().HasData
            (
                new Specialization { Id = 1, Name = "Хирург" },
                new Specialization { Id = 2, Name = "Терапевт" },
                new Specialization { Id = 3, Name = "Офтальмолог" },
                new Specialization { Id = 4, Name = "Стоматолог" }
            );

            builder.Entity<Patient>().ToTable("Patients");
            builder.Entity<Patient>().HasKey(p => p.Id);
            builder.Entity<Patient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Patient>().Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Patient>().Property(p => p.Patronymic).HasMaxLength(50);
            builder.Entity<Patient>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Patient>().Property(p => p.Address).IsRequired();
            builder.Entity<Patient>().Property(p => p.DateOfBirth).IsRequired();
            builder.Entity<Patient>().Property(p => p.Gender).IsRequired();
            builder.Entity<Patient>().Property(p => p.AreaId).IsRequired();

            builder.Entity<Patient>().HasData
            (
                new Patient { Id = 1, FirstName = "Александр", Patronymic = "Сергеевич", LastName = "Петров", Address = "г.Нижний новгород", DateOfBirth = new DateTime(1997, 3, 7), Gender = "Муж", AreaId = 1},
                new Patient { Id = 2, FirstName = "Иван", Patronymic = "Сергеевич", LastName = "Иванов", Address = "г.Нновгород", DateOfBirth = new DateTime(1996, 6, 8), Gender = "Муж", AreaId = 2 },
                new Patient { Id = 3, FirstName = "Василий", Patronymic = "Иванович", LastName = "Сидоров", Address = "г.Иваново", DateOfBirth = new DateTime(1995, 7, 9), Gender = "Муж", AreaId = 3 },
                new Patient { Id = 4, FirstName = "Петр", Patronymic = "Ильич", LastName = "Октябрев", Address = "г.Москва", DateOfBirth = new DateTime(1994, 8, 10), Gender = "Муж", AreaId = 4 }
            );

            builder.Entity<Doctor>().ToTable("Doctors");
            builder.Entity<Doctor>().HasKey(p => p.Id);
            builder.Entity<Doctor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Doctor>().Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Doctor>().Property(p => p.Patronymic).HasMaxLength(50);
            builder.Entity<Doctor>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Doctor>().Property(p => p.SpecializationId).IsRequired();
            builder.Entity<Doctor>().Property(p => p.CabinetId).IsRequired();

            builder.Entity<Doctor>().HasData
            (
                new Doctor { Id = 1, FirstName = "Александр", Patronymic = "Сергеевич", LastName = "Петров", CabinetId = 1, SpecializationId = 1, AreaId = 1 },
                new Doctor { Id = 2, FirstName = "Иван", Patronymic = "Сергеевич", LastName = "Иванов", CabinetId = 2, SpecializationId = 2, AreaId = 2 },
                new Doctor { Id = 3, FirstName = "Василий", Patronymic = "Иванович", LastName = "Сидоров", CabinetId = 3, SpecializationId = 3},
                new Doctor { Id = 4, FirstName = "Петр", Patronymic = "Ильич", LastName = "Октябрев", CabinetId = 4, SpecializationId = 4, AreaId = 3 }
            );

        }
    }
}
