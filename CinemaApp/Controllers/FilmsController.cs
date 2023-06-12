using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class FilmsController : MainController
    {
        public Films GetFilmById(int id)
        {
            return dataBase.context.Films.FirstOrDefault(film => film.IdFilm == id);
        }

        public List<Films> GetAllFilms()
        {
            return dataBase.context.Films.ToList();
        }

        public Films GetFilmByName(string name)
        {
            return dataBase.context.Films.FirstOrDefault(film => film.FilmName == name);
        }


        public List<string> GetAllFilmsString()
        {
            List<Films> actors = GetAllFilms();
            List<string> actorsString = new List<string>();
            foreach (Films item in actors)
            {
                actorsString.Add(item.FilmName);
            }
            return actorsString;
        }
        public bool DeleteFilm(Films films)
        {
            try
            {
                Films curFilms = GetFilmById(films.IdFilm);
                dataBase.context.Films.Remove(curFilms);
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

        public bool AddFilm(Films films)
        {
            try
            {        
                dataBase.context.Films.Add(films);
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

        public bool UpdateFilm(Films films)
        {
            try
            {
                dataBase.context.Films.AddOrUpdate(films);
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

        public Films GetLastAddedFilm()
        {
            return dataBase.context.Films.ToList().Last();
        }
    }
}
