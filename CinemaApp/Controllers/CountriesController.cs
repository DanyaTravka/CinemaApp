using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class CountriesController : MainController
    {
        public Countries GetCountryById(int id)
        {
            return dataBase.context.Countries.FirstOrDefault(con => con.IdCountry == id);
        }

        public List<Countries> GetCountriesList()
        {
            return dataBase.context.Countries.ToList();
        }

        public List<string> GetCountriesListString()
        {
            List<Countries> actors = GetCountriesList();
            List<string> actorsString = new List<string>();
            foreach (Countries item in actors)
            {
                actorsString.Add(item.CountryName);
            }
            return actorsString;
        }
    }
}
