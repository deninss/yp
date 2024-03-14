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
using WpfApp1.Classes;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Applications> applicationsItem = new List<Applications>();
        public MainWindow()
        {
            InitializeComponent();
            this.frame.Navigate(new Pages.Login(this));
        }
        public void loadItem()
        {
            try
            {
                applicationsItem.Clear();
                DataTable item = ClassLibrary1.bd.Select($"select * from [Applications]");

                foreach (DataRow row in item.Rows)
                {
                    Classes.Applications applications = new Classes.Applications
                    {
                        id = "Номер заявки: " + Convert.ToInt32(row["ApplicationNumber"]),
                        DateOfAddition = "Дата добавления: " + Convert.ToDateTime(row["DateOfAddition"]),
                        Equipment = "Оборудование: " + row["Equipment"].ToString(),
                        TypeOfFault = " Тип неисправности: " + row["TypeOfFault"].ToString(),
                        DescriptionOfTheProblem = "Описание проблемы: " + row["DescriptionOfTheProblem"].ToString(),
                        Client = "Клиент: " + row["Client"].ToString(),
                        Status = "Статус: " + row["Status"].ToString(),
                    };
                    applicationsItem.Add(applications);
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
