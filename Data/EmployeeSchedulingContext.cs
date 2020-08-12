using System;
using EmployeeScheduling.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduling.Data
{
    public class EmployeeSchedulingContext : DbContext
    {
        public EmployeeSchedulingContext(DbContextOptions<EmployeeSchedulingContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());

            builder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Katrine",
                    LastName = "Anderson",
                    Email = "kat.and@acme.com"
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Magnus",
                    LastName = "Latif",
                    Email = "magnus_latif@acme.com"
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Andy",
                    LastName = "Smith",
                    Email = "andy-s@acme.com"
                });

            builder.Entity<Shift>().HasData(
                new Shift
                {
                    ShiftId = 1,
                    EmployeeId = 1,
                    ShiftStart = DateTime.Now.AddDays(2),
                    ShiftEnd = DateTime.Now.AddDays(2).AddHours(4)
                },
                new Shift
                {
                    ShiftId = 2,
                    EmployeeId = 1,
                    ShiftStart = DateTime.Now.AddDays(3),
                    ShiftEnd = DateTime.Now.AddDays(3).AddHours(6)
                },
                new Shift
                {
                    ShiftId = 3,
                    EmployeeId = 1,
                    ShiftStart = DateTime.Now,
                    ShiftEnd = DateTime.Now.AddHours(7)
                },
                new Shift
                {
                    ShiftId = 4,
                    EmployeeId = 2,
                    ShiftStart = DateTime.Now.AddDays(2),
                    ShiftEnd = DateTime.Now.AddDays(2).AddHours(6)
                },
                    new Shift
                    {
                        ShiftId = 5,
                        EmployeeId = 2,
                        ShiftStart = DateTime.Now.AddDays(4),
                        ShiftEnd = DateTime.Now.AddDays(4).AddHours(4)
                    },
                    new Shift
                    {
                        ShiftId = 6,
                        EmployeeId = 2,
                        ShiftStart = DateTime.Now,
                        ShiftEnd = DateTime.Now.AddHours(5)
                    },
                    new Shift
                    {
                        ShiftId = 7,
                        EmployeeId = 3,
                        ShiftStart = DateTime.Now.AddDays(1),
                        ShiftEnd = DateTime.Now.AddDays(1).AddHours(8)
                    },
                    new Shift
                    {
                        ShiftId = 8,
                        EmployeeId = 3,
                        ShiftStart = DateTime.Now.AddDays(3),
                        ShiftEnd = DateTime.Now.AddDays(3).AddHours(6)
                    },
                    new Shift
                    {
                        ShiftId = 9,
                        EmployeeId = 3,
                        ShiftStart = DateTime.Now,
                        ShiftEnd = DateTime.Now.AddHours(3)
                    }
            );
        }
    }
}
