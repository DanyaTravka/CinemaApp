using CinemaApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Model
{
    public partial class Seances
    {
        FilmsController filmsController = new FilmsController();
        AgeLimitsController ageLimitsController = new AgeLimitsController();
        FilmsGenresController filmsGenresController = new FilmsGenresController();
        GenresController genresController = new GenresController();

        public Films film
        {
            get
            {
                return filmsController.GetFilmById(FilmId);
            }
        }
        public string FilmName { get
            {
                return film.FilmName;
            } }

        public string FilmGenresString { 
            get {
                List<FilmsGeners> filmsGeners = filmsGenresController.GetFilmsGenersListByFilmId(film.IdFilm);
                string genres = "";
                foreach (FilmsGeners item in filmsGeners)
                {
                    genres += genresController.GetGenresById(item.GenreId).GenreName + " ";
                }
                return genres;
            } }

        public string FilmDateAndTime
        {
            get
            {
                return SeanceDate.ToString("d") + " " + SeanceStartTime.ToString(@"hh\:mm"); 
            }
        }

        public string FilmAgeLimitString
        {
            get
            {
                return ageLimitsController.GetAgeLimitById(film.AgeLimitId).AgeLimitValue;
            }
        }
    }
}
