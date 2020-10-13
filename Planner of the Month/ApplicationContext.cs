using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Planner_of_the_Month
{
    // Для взаимодействия с базой данных - контекст данных
    public class ApplicationContext: DbContext
    {
        // Набор объектов, которые хранятся в базе данных
        public DbSet<Task> Tasks { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        // Установка параметров подключения
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PlannerOfTheMonth;Trusted_connection=True;");
        }
    }
}
