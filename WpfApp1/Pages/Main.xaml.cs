using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    /// 
   
    public partial class Main : Page
    {
        MainWindow mainWindow;
        public Main(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            mainWindow.loadItem();
            load();
        }
        public void load()
        {  
            pagesListBox.Items.Clear();
            foreach (var page in mainWindow.applicationsItem)
            {
                ApplicationsItem pageControl = new ApplicationsItem();
                pageControl.DataContext = page;
                pagesListBox.Items.Add(pageControl);
            }
        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {   
            AddApplicationsItem addApplicationsItem = new AddApplicationsItem(this,mainWindow);
            addApplicationsItem.ShowDialog();
        }
    }
}
