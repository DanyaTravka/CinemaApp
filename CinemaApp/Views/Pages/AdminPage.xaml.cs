using CinemaApp.Utlist;
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

namespace CinemaApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

  
        private void CreateOtchetButtonClick(object sender, RoutedEventArgs e)
        {
            TicketWordForm ticketWordForm = new TicketWordForm();
            ticketWordForm.FormOtchet();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }



        private void FilmButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FilmsPage());
        }

        private void SeancesButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SeancesPage());
        }


        private void EmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EmployeesPage());

        }
    }
}
