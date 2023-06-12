using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class HallsController : MainController
    {
        public Halls GetHallById(int id)
        {
            return dataBase.context.Halls.FirstOrDefault(hall => hall.IdHall == id);
        }

        public List<Halls> GetHallsList()
        {
            return dataBase.context.Halls.ToList();
        }

        public List<string> GetAllHallsString()
        {
            List<Halls> actors = GetHallsList();
            List<string> actorsString = new List<string>();
            foreach (Halls item in actors)
            {
                actorsString.Add(item.HallNumber.ToString());
            }
            return actorsString;
        }
    }
}
