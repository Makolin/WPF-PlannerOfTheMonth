using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planner_of_the_Month
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //using (TasksContext db = new TasksContext())
            //{
            //    List<Tasks> FullList = (from item in db.Tasks
            //                            select item).ToList();
            //    if (FullList.Count() != 0)
            //    {
            //        TasksView.ItemsSource = FullList;
            //    }
            //    else
            //    {
            //        MessageBox.Show("База данных пуста, необходимо внести значения!");
            //    }
                
            //}
            InitializeComponent();
        }

        private void TasksView_Loaded(object sender, RoutedEventArgs e)
        {
            using (TasksContext db = new TasksContext())
            {
                var Task = new Tasks
                {
                    Name = "Администрирование и поддежка пользователей \"1С:УПП\"",
                    Category = CategoryTask.АСУП,
                    Executors = new List<string> { "Скрябина М.В." },
                    PlanComplitionDate = DateTime.Now,
                    RealComplitionDate = DateTime.Now
                };
                db.Tasks.Add(Task);
                db.SaveChanges();

                var currentTask = (from task in db.Tasks
                                  orderby task.Name
                                  select task).ToList();
                TasksView.ItemsSource = currentTask.ToList();
            }
            //var Task = new Tasks("Администрирование и поддежка пользователей \"1С:УПП\"", CategoryTask.АСУП, new List<string> { "Скрябина М.В." });
            //List<Tasks> Result = new List<Tasks> { };
            //Result.Add(Task);
            //TasksView.ItemsSource = Result;
        }
    }
}
