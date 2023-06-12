using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaApp.Controllers
{
    public class ActorsController : MainController
    {
        public List<Actors> GetActorsList()
        {
            return dataBase.context.Actors.ToList();
        }

        public List<string> GetActorsListString()
        {
            List<Actors> actors = GetActorsList();
            List<string> actorsString = new List<string>();
            foreach (Actors item in actors)
            {
                actorsString.Add(item.ActorName + " "+ item.ActorSurname);
            }
            return actorsString;
        }
        public Actors GetActorById(int id)
        {
            return dataBase.context.Actors.FirstOrDefault(ac => ac.IdActor == id);
        }
    }
}
