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
    /// Логика взаимодействия для FilmsPage.xaml
    /// </summary>
    public partial class FilmsPage : Page
    {
        FilmsController filmsController = new FilmsController();

        SeancesController seancesController = new SeancesController();
        TicketsController ticketsController = new TicketsController();
        FilmsGenresController filmsGenresController = new FilmsGenresController();
        ActorsFilmsController actorsFilmsController = new ActorsFilmsController();

        public FilmsPage()
        {
            InitializeComponent();

        }

        public void UpdateFilmList()
        {
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = filmsController.GetAllFilms();

        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void AddNewFilmClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddAndRedactFilmPage());
        }



        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Films filmToDelete = filmsController.GetFilmById(Convert.ToInt32(button.Uid));
            var result = MessageBox.Show("Вы уверены, что хотите удалить фильм?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                List<ActorsFilms> actorsFilms = actorsFilmsController.GetActorsFilmsByFilmId(filmToDelete.IdFilm);
                foreach (ActorsFilms item in actorsFilms)
                {
                    if (!actorsFilmsController.DeleteActorsFilms(item))
                    {
                        MessageBox.Show("Не удалось удалить связь актеров", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                List<FilmsGeners> genresFilms = filmsGenresController.GetFilmsGenersListByFilmId(filmToDelete.IdFilm);
                foreach (FilmsGeners item in genresFilms)
                {
                    if (!filmsGenresController.DeleteFilmGenre(item))
                    {
                        MessageBox.Show("Не удалось удалить связь жанров", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                List<Seances> seances = seancesController.GetSeancesListByFilmId(filmToDelete.IdFilm);
                foreach (Seances item in seances)
                {
                    List<Tickets> tickets = ticketsController.GetTicketsListBySeanceId(item.IdSeance);
                    foreach (Tickets item2 in tickets)
                    {
                        if (!ticketsController.DeleteTicket(item2))
                        {
                            MessageBox.Show("Не удалось удалить билет", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    if (!seancesController.DeleteSeance(item))
                    {
                        MessageBox.Show("Не удалось удалить сеанс", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                if (!filmsController.DeleteFilm(filmToDelete))
                {
                    MessageBox.Show("Не удалось удалить фильм", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Фильм и все его сеансы удалены", "Успешное удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateFilmList();
            }
        }

        private void RedactButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Films filmToRedact = filmsController.GetFilmById(Convert.ToInt32(button.Uid));
            this.NavigationService.Navigate(new AddAndRedactFilmPage(filmToRedact));
        }
    }
}
