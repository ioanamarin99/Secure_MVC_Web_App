using ISM_Y1_Marin_Ioana_Web_Cloud_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.employees.Any())
            {
                context.employees.AddRange(
                new Employee
                {
                    EmployeeName = "Marian",
                    EmployeeAge = 28,
                    EmployeeWage = 12000.00m,
                },
                new Employee
                {
                    EmployeeName = "Serban",
                    EmployeeAge = 23,
                    EmployeeWage = 4500m,
                },
                 new Employee
                 {
                     EmployeeName = "Johnny",
                     EmployeeAge = 25,
                     EmployeeWage = 6800m,
                 },
                  new Employee
                  {
                      EmployeeName = "Maria",
                      EmployeeAge = 30,
                      EmployeeWage = 22000m,
                  }
                );

                context.SaveChanges();
            }

            if (!context.jobs.Any())
            {
                context.jobs.AddRange(
                    new Job
                    {
                        JobName = "Project Manager",
                        WeeklyHours = 40,
                        EmployeeId = 2
                    },
                    new Job
                    {
                        JobName = "Integration Software Engineer",
                        WeeklyHours = 40,
                        EmployeeId = 3
                    },
                    new Job
                    {
                        JobName = "Junior Software Developer",
                        WeeklyHours = 40,
                        EmployeeId = 4
                    },
                    new Job
                    {
                        JobName = "Trainer",
                        WeeklyHours = 20,
                        EmployeeId = 4
                    }
                    );
                context.SaveChanges();
            }

        }
    }
}
