using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class FirmsController : MainController
    {
        public Firms GetFirmById(int id)
        {
            return dataBase.context.Firms.FirstOrDefault(firm => firm.IdFirm == id);
        }

        

        public List<Firms> GetFirmsList()
        {
            return dataBase.context.Firms.ToList();
        }

        public List<string> GetFirmsListString()
        {
            List<Firms> actors = GetFirmsList();
            List<string> actorsString = new List<string>();
            foreach (Firms item in actors)
            {
                actorsString.Add(item.FirmName);
            }
            return actorsString;
        }
    }
}
