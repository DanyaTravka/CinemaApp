using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class AgeLimitsController : MainController
    {
        public AgeLimits GetAgeLimitById(int id)
        {
            return dataBase.context.AgeLimits.FirstOrDefault(age => age.IdAgeLimits == id);
        }

        public List<AgeLimits> GetAgeLimitsList()
        {
            return dataBase.context.AgeLimits.ToList();
        }

        public List<string> GetAgeLimitsListString()
        {
            List<AgeLimits> actors = GetAgeLimitsList();
            List<string> actorsString = new List<string>();
            foreach (AgeLimits item in actors)
            {
                actorsString.Add(item.AgeLimitValue);
            }
            return actorsString;
        }
    }
}
