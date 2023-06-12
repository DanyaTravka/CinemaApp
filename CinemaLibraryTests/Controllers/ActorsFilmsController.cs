
using CinemaLibraryTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibraryTests.Controllers
{
    public class ActorsFilmsController : MainController
    {
        public List<ActorsFilms> GetActorsFilmsByFilmId(int id)
        {
            return dataBase.context.ActorsFilms.Where(af => af.FilmId == id).ToList();
        }

        public bool AddFilmActors(ActorsFilms films)
        {
            try
            {
                dataBase.context.ActorsFilms.Add(films);
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

        public bool DeleteActorsFilms(ActorsFilms films)
        {
            try
            {
                ActorsFilms curFilms = GetActorsFilmsById(films.IdActorsFilms);
                dataBase.context.ActorsFilms.Remove(curFilms);
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

        public ActorsFilms GetActorsFilmsById(int id)
        {
            return dataBase.context.ActorsFilms.FirstOrDefault(fg => fg.IdActorsFilms == id);
        }
    }
}
