using CinemaLibraryTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibraryTests.Controllers
{
    public class SeancesController : MainController
    {
        public List<Seances> GetAllSeances()
        {
            return dataBase.context.Seances.ToList();
        }

        public List<Seances> GetSeancesByDate(DateTime dateTime)
        {
            return dataBase.context.Seances.Where(seans => seans.SeanceDate == dateTime).ToList();
        }
        public Seances GetSeanceById(int id)
        {
            return dataBase.context.Seances.FirstOrDefault(sen => sen.IdSeance == id);
        }

        public List<Seances> GetSeancesListByFilmId(int id)
        {
            return dataBase.context.Seances.Where(sen => sen.FilmId == id).ToList();
        }

        public bool DeleteSeance(Seances seance)
        {
            try
            {
                Seances curSeance = GetSeanceById(seance.IdSeance);
                dataBase.context.Seances.Remove(curSeance);
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

        public bool AddSeance(Seances seance)
        {
            try
            {
                
                dataBase.context.Seances.Add(seance);
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

    }
}
