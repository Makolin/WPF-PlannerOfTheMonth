using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace Planner_of_the_Month
{
    enum CategoryTask
    {
        КТПП,
        АСУП
    }

    // Таблица для заполнения списка задач
    class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryTask Category { get; set; }
        public List<string> Executors { get; set; }
        public DateTime PlanComplitionDate { get; set; }
        public DateTime RealComplitionDate { get; set; }

        /*public Tasks (string Name, CategoryTask Category, List<string> Executors)
        {
            this.Name = Name;
            this.Category = Category;
            this.Executors = Executors;
            this.PlanComplitionDate = DateTime.Now;
            this.RealComplitionDate = DateTime.Now;
        }*/
    }
    class TasksContext : DbContext
    {
        public TasksContext() : base("DbConnection")
        {

        }
        public DbSet<Tasks> Tasks { get; set; }
    }

}
