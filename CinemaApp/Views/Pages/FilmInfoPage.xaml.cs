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
    /// Логика взаимодействия для FilmInfoPage.xaml
    /// </summary>
    public partial class FilmInfoPage : Page
    {
        CountriesController countriesController = new CountriesController();
        FirmsController firmsController = new FirmsController();
        AgeLimitsController ageLimitsController = new AgeLimitsController();
        ActorsFilmsController actorsFilmsController = new ActorsFilmsController();
        ActorsController actorsController = new ActorsController();
        FilmsGenresController filmsGenresController = new FilmsGenresController();
        GenresController genresController = new GenresController();

        public FilmInfoPage()
        {
            InitializeComponent();
        }

        public FilmInfoPage(Films films)
        {
            InitializeComponent();
            if (films != null)
            {
                NameTextBlock.Text = films.FilmName;
                CountryTextBlock.Text = countriesController.GetCountryById(films.CountryId).CountryName;
                CompanyTextBlock.Text = firmsController.GetFirmById(films.FirmId).FirmName;
                TimeTextBlock.Text = $"{films.FilmDuration.Hours} часа {films.FilmDuration.Minutes} минут";
                DescriptionTextBlock.Text = films.FilmDescription;
                AgeTextBlock.Text = ageLimitsController.GetAgeLimitById(films.AgeLimitId).AgeLimitValue;
                List<ActorsFilms> actors =  actorsFilmsController.GetActorsFilmsByFilmId(films.IdFilm);
                foreach (ActorsFilms item in actors)
                {
                    Actors currentActor = actorsController.GetActorById(item.ActorId);
                    TextBlock textBlock = new TextBlock() { 
                    Text = currentActor.ActorName + " " + currentActor.ActorSurname,
                    Style = (Style)Resources["FilmInfoTextBlockStyle"],
                        Margin = new Thickness(0, 20, 0, 0)
                    };
                    ActorsStackPanel.Children.Add(textBlock);
                }

                List<FilmsGeners> filmsGeners = filmsGenresController.GetFilmsGenersListByFilmId(films.IdFilm);
                
                foreach (FilmsGeners item in filmsGeners)
                {
                     Genres currentGenre =  genresController.GetGenresById(item.GenreId);
                    TextBlock textBlock = new TextBlock()
                    {
                        Text = currentGenre.GenreName,                       
                        Margin = new Thickness(0,0,10,0)
                    };
                    GenresStackPanel.Children.Add(textBlock);
                }
                
            }
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
