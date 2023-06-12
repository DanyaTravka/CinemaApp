using CinemaApp.Views.Pages;
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

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
        }



        private void MainFrameNavigated(object sender, NavigationEventArgs e)
        {
            var currentPage = e.Content;
            if (currentPage is MainPage)
            {
                MainPage page = (MainPage)currentPage;
                page.UpdateList();
            }
            if (currentPage is FilmsPage)
            {
                FilmsPage page = (FilmsPage)currentPage;
                page.UpdateFilmList();
            }
            if (currentPage is SeancesPage)
            {
                SeancesPage page = (SeancesPage)currentPage;
                page.UpdateList();
            }
            if (currentPage is EmployeesPage)
            {
                EmployeesPage page = (EmployeesPage)currentPage;
                page.UpdateList();
            }

        }

   

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (App.wordApplication != null)
                {
                    App.wordApplication.Quit();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {

            }
        }
    }
}
