using System;
using System.Collections.Generic;
using System.Data;
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
using System.Collections.ObjectModel;

namespace Planner_of_the_Month
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Task> GetData()
        {
            ObservableCollection<Task> taskdata = null; ;
            using (ApplicationContext db = new ApplicationContext())
            {
                taskdata = new ObservableCollection<Task>(db.Tasks.ToList());
            }

            return taskdata;
        }
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Task> taskdata = GetData();
            TasksView.DataContext = taskdata;
        }

        /*private void TasksView_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var Task = new Task
                {
                    Name = "Администрирование и поддержка пользователей \"1С:УПП\"",
                    Category = CategoryTask.АСУП,
                    Executors = "Скрябина М.В.",
                    MonthlyType = true
                };

                db.Tasks.Add(Task);
                db.SaveChanges();

                var tasks = db.Tasks.ToList();
                TasksView.ItemsSource = tasks;
            }
        }*/

        private void TasksView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var editTask = new EditTask();
            editTask.Owner = this;
            editTask.Show();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            var find = TasksView.SelectedIndex;
            if (find != -1)
            {

                TasksView.Items.Remove(TasksView.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Необходимо выбрать хотя бы одну строку!");
            }
        }
    }
}
