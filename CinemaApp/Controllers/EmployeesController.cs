using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class EmployeesController : MainController
    {
        public List<Employees> GetEmployeesList()
        {
            return dataBase.context.Employees.ToList(); 
        }

        public Employees GetEmployeeById(int id)
        {
            return dataBase.context.Employees.FirstOrDefault(emp => emp.IdEmployee == id);
        }

        public bool DeleteEmploye(Employees films)
        {
            try
            {
                Employees curFilms = GetEmployeeById(films.IdEmployee);
                dataBase.context.Employees.Remove(curFilms);
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

        public bool AddEmploye(Employees films)
        {
            try
            {
                dataBase.context.Employees.Add(films);
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

        public bool UpdateEmploye(Employees films)
        {
            try
            {
                dataBase.context.Employees.AddOrUpdate(films);
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

        public Employees GetLastAddedEmploye()
        {
            return dataBase.context.Employees.ToList().Last();
        }
    }
}
