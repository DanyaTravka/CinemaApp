using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class ResponsibilitiesEmployeesController : MainController
    {
        public List<ResponsibilitiesEmployees> GetResponsibilitiesEmployeesByEmployeeId(int id)
        {
            return dataBase.context.ResponsibilitiesEmployees.Where(af => af.EmployeeId == id).ToList();
        }

        public bool AddResponsibilitiesEmployees(ResponsibilitiesEmployees films)
        {
            try
            {
                dataBase.context.ResponsibilitiesEmployees.Add(films);
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

        public bool DeleteResponsibilitiesEmployees(ResponsibilitiesEmployees films)
        {
            try
            {
                ResponsibilitiesEmployees curFilms = GetResponsibilitiesEmployeesById(films.IdResponsibilitiesEmployees);
                dataBase.context.ResponsibilitiesEmployees.Remove(curFilms);
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

        public ResponsibilitiesEmployees GetResponsibilitiesEmployeesById(int id)
        {
            return dataBase.context.ResponsibilitiesEmployees.FirstOrDefault(fg => fg.IdResponsibilitiesEmployees == id);
        }
    }
}
