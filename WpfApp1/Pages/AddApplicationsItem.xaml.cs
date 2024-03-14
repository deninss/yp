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
        public AddApplicationsItem()
        {
            InitializeComponent();
        }

        private void OnAddItem(object sender, RoutedEventArgs e)
        {
            if (Equipment.Text.Length != 0 && TypeOfFault.Text.Length != 0 && DescriptionOfTheProblem.Text.Length != 0)
            {
                try
                {
                    DataTable result = ClassLibrary1.bd.Select($"insert into [Applications] (DateOfAddition,Equipment,TypeOfFault,DescriptionOfTheProblem,Client,Status) values ('{DateTime.Now}','{Equipment.Text}','{TypeOfFault.Text}','{DescriptionOfTheProblem.Text}','{Users.id}','{"в ожидании"}')");
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
