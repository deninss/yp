using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Classes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddApplicationsItem.xaml
    /// </summary>
    public partial class AddApplicationsItem : Window
    {
        Classes.Users users = new Classes.Users();
        MainWindow mainWindow;
        Main main;
        public AddApplicationsItem(Main main, MainWindow mainWindow)
        {
            InitializeComponent();
            this.main = main;
            this.mainWindow = mainWindow;
        }

        private void OnAddItem(object sender, RoutedEventArgs e)
        {
            if (Equipment.Text.Length != 0 && TypeOfFault.Text.Length != 0 && DescriptionOfTheProblem.Text.Length != 0)
            {
                try
                {
                    DateTime date = DateTime.Now;
                    Random rand = new Random();
                   
                    const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    Random random = new Random();
                    string token = new string(Enumerable.Repeat(allowedChars, 6)
                      .Select(s => s[random.Next(s.Length)]).ToArray());
                    DataTable result = ClassLibrary1.bd.Select($"insert into [Applications] (ApplicationNumber,DateOfAddition,Equipment,TypeOfFault,DescriptionOfTheProblem,Client,Status) values ('{token}','{date}','{Equipment.Text}','{TypeOfFault.Text}','{DescriptionOfTheProblem.Text}','{Users.user}','{"в ожидании"}')");
                    Classes.Applications applications = new Classes.Applications
                    {
                        id = "Номер заявки: "+ token,
                        DateOfAddition = "Дата добавления: " +date,
                        Equipment = "Оборудование: "+ Equipment.Text,
                        TypeOfFault = " Тип неисправности: "+ TypeOfFault.Text,
                        DescriptionOfTheProblem = "Описание проблемы: "+ DescriptionOfTheProblem.Text,
                        Client = "Клиент: " + Users.user,
                        Status = "Статус: в ожидании",
                    };
                    mainWindow.applicationsItem.Add(applications);
                    main.load();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Заполните все поля");
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            this.Close();            
        }
    }
}
