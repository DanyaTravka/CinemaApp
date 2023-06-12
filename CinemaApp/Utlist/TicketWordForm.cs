using CinemaApp.Controllers;
using CinemaApp.Model;
using Microsoft.Office.Interop.Word;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;

namespace CinemaApp.Utlist
{
    public class TicketWordForm
    {
        SeancesController seancesController = new SeancesController();
        TicketsController ticketsController = new TicketsController();
        public void FormTicket(List<Tickets> tickets)
        {
            CloseApplication();
            App.wordApplication = new Word.Application();
            Word.Document document = App.wordApplication.Documents.Open($"{Directory.GetCurrentDirectory()}\\..\\..\\Assets\\Documents\\Ticket.docx");
            Seances currentSeance = seancesController.GetSeanceById(tickets[0].SeanceId);
            document.Bookmarks["FilmName"].Range.Text = currentSeance.FilmName;
            document.Bookmarks["FilmDate"].Range.Text = currentSeance.FilmDateAndTime;
            document.Bookmarks["FilmTypeTicket"].Range.Text = tickets[0].TicketType == 1 ? "Купленный билет" : "Бронь" ;
            foreach (Tickets item in tickets)
            {
                document.Bookmarks["FilmPlaces"].Range.Text += " ряд " + item.TicketRow + ", место " + item.TicketPlace;
                document.Bookmarks["FilmNumberTickets"].Range.Text += item.IdTicket + " ";
            }
            App.wordApplication.Visible = true;
        }

        public void FormOtchet()
        {
            CloseApplication();
            App.wordApplication = new Word.Application();
            Word.Document document = App.wordApplication.Documents.Open($"{Directory.GetCurrentDirectory()}\\..\\..\\Assets\\Documents\\Otchet.docx");
            List<Seances> seances = seancesController.GetSeancesByDate(DateTime.Now);
            int sum = 0;
            foreach (Seances item in seances)
            {
                List<Tickets> tickets = ticketsController.GetTicketsListBySeanceId(item.IdSeance);
                foreach (Tickets item2 in tickets)
                {
                    sum += 1;
                }
            }
            document.Bookmarks["count"].Range.Text = sum.ToString();

            App.wordApplication.Visible = true;
        }
        public void CloseApplication()
        {
            try
            {
                if (App.wordApplication != null)
                {
                    App.wordApplication.Quit();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {

            }
        }
    }
}
