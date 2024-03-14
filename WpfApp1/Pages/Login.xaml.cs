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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MainWindow mainWindow;
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
           
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.frame.Navigate(new Pages.Register(mainWindow));
        }

        private void OnLogin(object sender, RoutedEventArgs e)
        {
            if (login.Text.Length != 0 && password.Text.Length != 0)
            {
                try
                {
                    ClassLibrary1.bd.Select($"select * from [User] where Login='{login.Text}' and Password='{password.Text}'");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    mainWindow.frame.Navigate(new Pages.Main());
                }

            }
            else MessageBox.Show("Заполните все поля");
        }
    }
}
