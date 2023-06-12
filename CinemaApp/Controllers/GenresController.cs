using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class GenresController : MainController
    {
        public Genres GetGenresById(int id)
        {
            return dataBase.context.Genres.FirstOrDefault(g => g.IdGenre == id);
        }

        public List<Genres> GetGenresList()
        {
            return dataBase.context.Genres.ToList();
        }

        public List<string> GetGenresListString()
        {
            List<Genres> actors = GetGenresList();
            List<string> actorsString = new List<string>();
            foreach (Genres item in actors)
            {
                actorsString.Add(item.GenreName);
            }
            return actorsString;
        }
    }
}
