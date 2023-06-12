using CinemaApp.Controllers;
using CinemaApp.Model;
using CinemaApp.Utlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для TicketInfoPage.xaml
    /// </summary>
    public partial class TicketInfoPage : Page
    {
        SeancesController seancesController = new SeancesController();
        Seances seances = new Seances();
        List<Tickets> ticketsListCurrent = new List<Tickets>();
        public TicketInfoPage()
        {
            InitializeComponent();
        }

        public TicketInfoPage(List<Tickets> ticketsList)
        {
            ticketsListCurrent = ticketsList;
            InitializeComponent();
            SetupPageOnce(ticketsList[0]);
            foreach (Tickets item in ticketsList)
            {
                SetupPage(item);
            }
        }

        public void SetupPage(Tickets tickets)
        {
            PlacesTextBlock.Text += " Ряд " + tickets.TicketRow + ", Место " + tickets.TicketPlace;
            NumbersTextBlock.Text += tickets.IdTicket + " ";
        }

        public void SetupPageOnce(Tickets tickets)
        {
            seances = seancesController.GetSeanceById(tickets.SeanceId);
            NameTextBlock.Text += seances.FilmName;
            DateTextBlock.Text += seances.FilmDateAndTime;
            if (tickets.TicketType == 1)
            {
                TypeTextBlock.Text += "Купленный билет";
            }
            else
            {
                TypeTextBlock.Text += "Бронь";
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

  
        private void WordButtonClick(object sender, RoutedEventArgs e)
        {
            TicketWordForm ticketWordForm = new TicketWordForm();
            ticketWordForm.FormTicket(ticketsListCurrent);
        }
    }
}
