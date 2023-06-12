using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class RequirementsEmployeesController : MainController
    {
        public List<RequirementsEmployees> GetRequirementsEmployeesByEmployeeId(int id)
        {
            return dataBase.context.RequirementsEmployees.Where(af => af.EmployeeId == id).ToList();
        }

        public bool AddRequirementsEmployees(RequirementsEmployees films)
        {
            try
            {
                dataBase.context.RequirementsEmployees.Add(films);
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

        public bool DeleteRequirementsEmployees(RequirementsEmployees films)
        {
            try
            {
                RequirementsEmployees curFilms = GetRequirementsEmployeesById(films.IdRequirementsEmployees);
                dataBase.context.RequirementsEmployees.Remove(curFilms);
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

        public RequirementsEmployees GetRequirementsEmployeesById(int id)
        {
            return dataBase.context.RequirementsEmployees.FirstOrDefault(fg => fg.IdRequirementsEmployees == id);
        }
    }
}
