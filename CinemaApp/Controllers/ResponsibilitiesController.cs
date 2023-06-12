using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class ResponsibilitiesController : MainController
    {
        public List<Responsibilities> GetResponsibilitiesList()
        {
            return dataBase.context.Responsibilities.ToList();
        }
        public List<string> GetAllResponsibilitiesString()
        {
            List<Responsibilities> actors = GetResponsibilitiesList();
            List<string> actorsString = new List<string>();
            foreach (Responsibilities item in actors)
            {
                actorsString.Add(item.ResponsibilityName);
            }
            return actorsString;
        }

        public Responsibilities GetResponsibilityById(int id)
        {
            return dataBase.context.Responsibilities.FirstOrDefault(requ => requ.IdResponsibilities == id);
        }
    }
}
