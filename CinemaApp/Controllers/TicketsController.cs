using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class TicketsController : MainController
    {
        public List<Tickets> GetTicketsListBySeanceId(int id) {
            return dataBase.context.Tickets.Where(ticket => ticket.SeanceId == id).ToList();
        }

        public bool AddOneTicket(Tickets ticket)
        {
            try
            {
                dataBase.context.Tickets.Add(ticket);
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

        public Tickets GetLastAddedTicket()
        {
            return dataBase.context.Tickets.ToList().Last();
        }

        public Tickets GetTicketById(int id)
        {
            return dataBase.context.Tickets.FirstOrDefault(ticket => ticket.IdTicket == id);
        }

        public bool DeleteTicket(Tickets ticket)
        {
            try
            {
                Tickets curTicket = GetTicketById(ticket.IdTicket);
                dataBase.context.Tickets.Remove(curTicket);
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
