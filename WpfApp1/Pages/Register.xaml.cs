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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        MainWindow mainWindow;
        public Register(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.frame.Navigate(new Pages.Login(mainWindow));
        }

        private void OnRegin(object sender, RoutedEventArgs e)
        {
            if (login.Text.Length != 0 && password.Text.Length != 0 && password2.Text.Length != 0)
            {
                if (password.Text.Contains(password2.Text))
                {
                    try
                    {
                        ClassLibrary1.bd.Select($"insert into [User] (Login,Password,role) values ('{login.Text}','{password.Text}','{0}')");
                        mainWindow.frame.Navigate(new Pages.Main());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else MessageBox.Show("Пароли не совподают");
            }
            else MessageBox.Show("Заполните все поля");
        }
    }
}
