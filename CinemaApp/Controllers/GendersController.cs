using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaApp.Controllers
{
    public class GendersController : MainController
    {
        public List<Genders> GetGendersList()
        {
            return dataBase.context.Genders.ToList();   
        }
        public List<string> GetAllHallsString()
        {
            List<Genders> actors = GetGendersList();
            List<string> actorsString = new List<string>();
            foreach (Genders item in actors)
            {
                actorsString.Add(item.GenderName);
            }
            return actorsString;
        }
    }
}
