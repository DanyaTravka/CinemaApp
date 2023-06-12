using CinemaApp.Controllers;
using CinemaApp.Model;
using CinemaLibrary;
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
    /// Логика взаимодействия для AddAndRedactFilmPage.xaml
    /// </summary>
    public partial class AddAndRedactFilmPage : Page
    {
        GenresController genresController = new GenresController();
        ActorsController actorsController = new ActorsController();
        CountriesController countriesController = new CountriesController();
        AgeLimitsController ageLimitsController = new AgeLimitsController();
        FirmsController firmsController = new FirmsController();
        FilmInfoCheck filmInfoCheck = new FilmInfoCheck();
        FilmsController filmsController = new FilmsController();

        FilmsGenresController filmsGenresController = new FilmsGenresController();
        ActorsFilmsController actorsFilmsController = new ActorsFilmsController();

        Films currentFilm = null;

        List<Genres> genres = new List<Genres>();
        List<Actors> actors = new List<Actors>();
        public AddAndRedactFilmPage()
        {
            InitializeComponent();
            SetupPage();
        }

        public AddAndRedactFilmPage(Films films)
        {
            InitializeComponent();
            SetupPage();
            currentFilm = films;
            List<FilmsGeners> filmsGeners = filmsGenresController.GetFilmsGenersListByFilmId(currentFilm.IdFilm);
            foreach (FilmsGeners item in filmsGeners)
            {
                genres.Add(genresController.GetGenresById(item.GenreId));
            }
            UpdateGenresList();

            List<ActorsFilms> filmsActors = actorsFilmsController.GetActorsFilmsByFilmId(currentFilm.IdFilm);
            foreach (ActorsFilms item in filmsActors)
            {
                actors.Add(actorsController.GetActorById(item.ActorId));
            }
            UpdateActorsList();
            CountryCombo.SelectedIndex = currentFilm.CountryId - 1;
            AgeLimitCombo.SelectedIndex = currentFilm.AgeLimitId - 1;
            FirmCombo.SelectedIndex = currentFilm.FirmId - 1;
            FilmName.Text = currentFilm.FilmName;
            DurationName.Text = currentFilm.FilmDuration.Hours + ":" + currentFilm.FilmDuration.Minutes;
            Description.Text = currentFilm.FilmDescription;
        }
        public void SetupPage()
        {
            CountryCombo.ItemsSource = countriesController.GetCountriesListString();
            AgeLimitCombo.ItemsSource = ageLimitsController.GetAgeLimitsListString();
            FirmCombo.ItemsSource = firmsController.GetFirmsListString();
            ActorsCombo.ItemsSource = actorsController.GetActorsListString();
            GenresCombo.ItemsSource = genresController.GetGenresListString();
        }


        public void UpdateActorsList()
        {
            ActorsListView.ItemsSource = null;
            ActorsListView.ItemsSource = actors;
        }

        public void UpdateGenresList()
        {
            GenresListView.ItemsSource = null;
            GenresListView.ItemsSource = genres;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }


        private void AddActorButtonClick(object sender, RoutedEventArgs e)
        {
            if (ActorsCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали актера", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (actors.FirstOrDefault(ac => ac.IdActor == ActorsCombo.SelectedIndex + 1) != null)
            {
                MessageBox.Show("Данный актер уже добавлен", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            actors.Add(actorsController.GetActorById(ActorsCombo.SelectedIndex + 1));
            UpdateActorsList();
        }


        private void AddGenreButtonClick(object sender, RoutedEventArgs e)
        {
            if (GenresCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали жанр", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (genres.FirstOrDefault(ac => ac.IdGenre == GenresCombo.SelectedIndex + 1) != null)
            {
                MessageBox.Show("Данный жанр уже добавлен", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            genres.Add(genresController.GetGenresById(GenresCombo.SelectedIndex + 1));
            UpdateGenresList();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentFilm == null)
            {
                if (!ValidateFields())
                {
                    return;
                }
                Films films = new Films()
                {
                    FilmName = FilmName.Text,
                    FilmDuration = new TimeSpan(Convert.ToInt32(DurationName.Text.Split(':')[0]), Convert.ToInt32(DurationName.Text.Split(':')[1]), 0),
                    FirmId = FirmCombo.SelectedIndex + 1,
                    CountryId = CountryCombo.SelectedIndex + 1,
                    AgeLimitId = AgeLimitCombo.SelectedIndex + 1,
                    FilmDescription = Description.Text

                };
                if (!filmsController.AddFilm(films))
                {
                    MessageBox.Show("Не удалось добавить фильм", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Films lastAddedFilm = filmsController.GetLastAddedFilm();
                foreach (Genres item in genres)
                {
                    FilmsGeners filmsGeners = new FilmsGeners()
                    {
                        FilmId = lastAddedFilm.IdFilm,
                        GenreId = item.IdGenre
                    };
                    if (!filmsGenresController.AddFilmGenre(filmsGeners))
                    {
                        MessageBox.Show("Не удалось добавить связь фильмов и жанров", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                foreach (Actors item in actors)
                {
                    ActorsFilms filmsActor = new ActorsFilms()
                    {
                        FilmId = lastAddedFilm.IdFilm,
                        ActorId = item.IdActor
                    };
                    if (!actorsFilmsController.AddFilmActors(filmsActor))
                    {
                        MessageBox.Show("Не удалось добавить связь фильмов и актеров", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                MessageBox.Show("Фильм успешно добавлен", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
            else
            {
                if (!ValidateFields())
                {
                    return;
                }
                if (currentFilm.FilmName == FilmName.Text &&
                    currentFilm.FilmDuration == new TimeSpan(Convert.ToInt32(DurationName.Text.Split(':')[0]), Convert.ToInt32(DurationName.Text.Split(':')[1]), 0) &&
                    currentFilm.FirmId == FirmCombo.SelectedIndex + 1 &&
                    currentFilm.CountryId == CountryCombo.SelectedIndex + 1 &&
                    currentFilm.AgeLimitId == AgeLimitCombo.SelectedIndex + 1 &&
                    currentFilm.FilmDescription == Description.Text)
                {

                }
                else
                {
                    currentFilm.FilmName = FilmName.Text;
                    currentFilm.FilmDuration = new TimeSpan(Convert.ToInt32(DurationName.Text.Split(':')[0]), Convert.ToInt32(DurationName.Text.Split(':')[1]), 0);
                    currentFilm.FirmId = FirmCombo.SelectedIndex + 1;
                    currentFilm.CountryId = CountryCombo.SelectedIndex + 1;
                    currentFilm.AgeLimitId = AgeLimitCombo.SelectedIndex + 1;
                    currentFilm.FilmDescription = Description.Text;

                    if (!filmsController.UpdateFilm(currentFilm))
                    {
                        MessageBox.Show("Не удалось обновить фильм", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }            
                List<FilmsGeners> filmsGeners = filmsGenresController.GetFilmsGenersListByFilmId(currentFilm.IdFilm);
                foreach (FilmsGeners item in filmsGeners)
                {
                    if (genres.FirstOrDefault(genre => genre.IdGenre == item.GenreId) == null)
                    {
                        if (!filmsGenresController.DeleteFilmGenre(item))
                        {
                            MessageBox.Show("Не удалось удалить связь жанра", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }                        
                    }
                }
                foreach (Genres item in genres)
                {
                    if (filmsGeners.FirstOrDefault(fg => fg.GenreId == item.IdGenre) == null)
                    {
                        FilmsGeners filmsGenersNew = new FilmsGeners()
                        {
                            FilmId = currentFilm.IdFilm,
                            GenreId = item.IdGenre
                        };
                        if (!filmsGenresController.AddFilmGenre(filmsGenersNew))
                        {
                            MessageBox.Show("Не удалось добавить связь фильмов и жанров", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }

                List<ActorsFilms> actorsFilms = actorsFilmsController.GetActorsFilmsByFilmId(currentFilm.IdFilm);
                foreach (ActorsFilms item in actorsFilms)
                {
                    if (actors.FirstOrDefault(actor => actor.IdActor == item.ActorId) == null)
                    {
                        if (!actorsFilmsController.DeleteActorsFilms(item))
                        {
                            MessageBox.Show("Не удалось удалить связь актера", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }
                foreach (Actors item in actors)
                {
                   
                    if (actorsFilms.FirstOrDefault(fg => fg.ActorId == item.IdActor) == null)
                    {
                       
                        ActorsFilms filmsActor = new ActorsFilms()
                        {
                            FilmId = currentFilm.IdFilm,
                            ActorId = item.IdActor
                        };
                        if (!actorsFilmsController.AddFilmActors(filmsActor))
                        {
                            MessageBox.Show("Не удалось добавить связь фильмов и актеров", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }

                MessageBox.Show("Фильм успешно обновлен", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
        }

        public bool ValidateFields()
        {
            if (!filmInfoCheck.CheckNameInfo(FilmName.Text))
            {
                MessageBox.Show("Имя введено неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!filmInfoCheck.CheckDurationInfo(DurationName.Text))
            {
                MessageBox.Show("Длительность фильма введена неправильно, правильный формат 0:00", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!filmInfoCheck.CheckDescriptionInfo(Description.Text))
            {
                MessageBox.Show("Описание введено неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (CountryCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите страну фильма", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (AgeLimitCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите ограничение фильма", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (FirmCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите фирму производства фильма", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (genres.Count < 1)
            {
                MessageBox.Show("Добавьте минимум один жанр", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (actors.Count < 1)
            {
                MessageBox.Show("Добавьте минимум одного актера", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void DeleteActorClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            actors.Remove(actors.FirstOrDefault(ac => ac.IdActor == Convert.ToInt32(button.Uid)));
            UpdateActorsList();
        }

        private void DeleteGenreClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            genres.Remove(genres.FirstOrDefault(ac => ac.IdGenre == Convert.ToInt32(button.Uid)));
            UpdateGenresList();
        }
    }
}
