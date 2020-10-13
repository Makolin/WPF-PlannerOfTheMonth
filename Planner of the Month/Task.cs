using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Planner_of_the_Month
{
    public enum CategoryTask
    {
        КТПП,
        АСУП
    }

    // Таблица для заполнения списка задач
    public class Task
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool MonthlyType { get; set; }
        [Required]
        public CategoryTask Category { get; set; }
        [Required]
        public string Executors { get; set; }
        public DateTime PlanComplitionDate { get; set; }
        public DateTime RealComplitionDate { get; set; }
        public string Note { get; set; }
    }
}
