using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class RequirementsController : MainController
    {
        public List<Requirements> GetRequirementsList()
        {
            return dataBase.context.Requirements.ToList();
        }
        public List<string> GetAllRequirementsString()
        {
            List<Requirements> actors = GetRequirementsList();
            List<string> actorsString = new List<string>();
            foreach (Requirements item in actors)
            {
                actorsString.Add(item.RequirementName);
            }
            return actorsString;
        }

        public Requirements GetRequirementById(int id)
        {
            return dataBase.context.Requirements.FirstOrDefault(requ => requ.IdRequirements == id);
        }
    }
}
