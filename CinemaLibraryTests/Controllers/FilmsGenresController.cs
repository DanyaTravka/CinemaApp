using CinemaLibraryTests.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibraryTests.Controllers
{
    public class FilmsGenresController : MainController
    {
        public List<FilmsGeners> GetFilmsGenersListByFilmId(int id)  
        { 
            return dataBase.context.FilmsGeners.Where(fg => fg.FilmId == id).ToList();
        }

        public bool AddFilmGenre(FilmsGeners films)
        {
            try
            {
                dataBase.context.FilmsGeners.Add(films);
                if (dataBase.context.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteFilmGenre(FilmsGeners films)
        {
            try
            {
                FilmsGeners curFilms = GetFilmGenreById(films.FilmsGenresId);
                dataBase.context.FilmsGeners.Remove(curFilms);
                if (dataBase.context.SaveChanges() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public FilmsGeners GetFilmGenreById(int id)
        {
            return dataBase.context.FilmsGeners.FirstOrDefault(fg => fg.FilmsGenresId == id);
        }
    }
}
