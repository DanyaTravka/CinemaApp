using CinemaApp.Controllers;
using CinemaApp.Model;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        SeancesController seancesController = new SeancesController();
        FilmsController filmsController = new FilmsController();
        public MainPage()
        {
            InitializeComponent();
        }

        public void UpdateList()
        {
            if (App.currentAdmin != null)
            {
                EntryButton.Content = "Выйти";
                AdminTextBox.Text = App.currentAdmin.AdminSurname + " " + App.currentAdmin.AdminName.Substring(0,1) + ". " + App.currentAdmin.AdminPatronymic.Substring(0, 1) + ".";
                AdminPageButton.Visibility = Visibility.Visible;
            }
            else
            {
                AdminTextBox.Text = null;
                EntryButton.Content = "Войти";
                AdminPageButton.Visibility = Visibility.Collapsed;
            }
            MainListView.ItemsSource = null;
            List<Seances> seances = seancesController.GetAllSeances();
            List<Seances> filteredSeances = new List<Seances>();
            foreach (Seances item in seances)
            {
                if (NameTextBox.Text != null || NameTextBox.Text != "" || NameTextBox.Text != " ")
                {
                    if (!item.film.FilmName.ToLower().Contains(NameTextBox.Text.ToLower()))
                    {
                        continue;
                    }
                }
                if (FilmDatePicker.SelectedDate != null)
                {
                    if (FilmDatePicker.SelectedDate != item.SeanceDate)
                    {
                        continue;
                    }
                }
                filteredSeances.Add(item);
            }
            MainListView.ItemsSource = filteredSeances;
        }

        private void NameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

  
        private void FilmDatePickerSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void EntryButtonClick(object sender, RoutedEventArgs e)
        {
            App.currentAdmin = null;
            this.NavigationService.Navigate(new AuthPage());
        }



        private void AboutFilmButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            this.NavigationService.Navigate(new FilmInfoPage(filmsController.GetFilmById(seancesController.GetSeanceById(Convert.ToInt32(button.Uid)).FilmId)));
        }

      

        private void BronButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            this.NavigationService.Navigate(new BronTakePage(seancesController.GetSeanceById(Convert.ToInt32(button.Uid))));
        }

 
        private void AdminPageButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminPage());
        }
    }
}
