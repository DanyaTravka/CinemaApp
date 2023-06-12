using CinemaApp.Controllers;
using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для BronTakePage.xaml
    /// </summary>
    public partial class BronTakePage : Page
    {
        HallsController hallsController = new HallsController();
        TicketsController ticketsController = new TicketsController();
        Halls currentHall = new Halls();
        Seances currentSeance = new Seances();
        static List<PlaceAndRow> tickets = new List<PlaceAndRow>(); 

        public BronTakePage()
        {
            InitializeComponent();
        }

        public BronTakePage(Seances seances)
        {
            InitializeComponent();
            if (seances != null)
            {
                currentSeance = seances;
                currentHall = hallsController.GetHallById(seances.HallId);
                NameTextBlock.Text = seances.FilmName;
                FilmInfoTextBlock.Text = seances.FilmDateAndTime + " Зал: " + currentHall.HallNumber;
                FormPage();
            }
        }

        public void FormPage()
        {
            List<Tickets> ticketsList = ticketsController.GetTicketsListBySeanceId(currentSeance.IdSeance);
            for (int i = 1; i <= currentHall.HallPlaces; i++)
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = i.ToString(),
                    Margin = new Thickness(0,0,20,0)
                };
                PlacesStackPanel.Children.Add(textBlock);
            }
            for (int i = 1; i <= currentHall.HallRows; i++)
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = i.ToString(),
                    Margin = new Thickness(0, 0, 0, 10)
                };
                RowsStackPanel.Children.Add(textBlock);
                StackPanel stackPanel = new StackPanel() { 
                Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 0, 0, 10.4)
                };
                for (int j = 1; j <= currentHall.HallPlaces; j++)
                {
                   
                    CheckBox radioButton = new CheckBox()
                    {
                        Margin = new Thickness(0, 0, 11, 0),
                        
                        Uid = i.ToString()+ ":" +j.ToString()
                    };
                    radioButton.Checked += CheckEvent;
                    radioButton.Unchecked += UnCheckEvent;
                    foreach (Tickets item in ticketsList)
                    {
                        if (item.TicketPlace == j && item.TicketRow == i)
                        {
                            radioButton.IsEnabled = false;
                        }
                    }
                    stackPanel.Children.Add(radioButton);
                }
                RyadiStackPanel.Children.Add(stackPanel);
            }
            
        }

        public void CheckEvent(object sender, EventArgs e)
        {
           CheckBox checkBox = (CheckBox)sender;
            string[] strings = checkBox.Uid.Split(':');
            PlaceAndRow placeAndRow = new PlaceAndRow()
            {
                Row = Convert.ToInt32(strings[0]),
                Place = Convert.ToInt32(strings[1])
            };
            tickets.Add(placeAndRow);
            UpdateCost();
        }

        public void UnCheckEvent(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string[] strings = checkBox.Uid.Split(':');
            PlaceAndRow placeAndRow = new PlaceAndRow()
            {
                Row = Convert.ToInt32(strings[0]),
                Place = Convert.ToInt32(strings[1])
            };
            tickets.Remove(tickets.FirstOrDefault(tickets => tickets.Row == placeAndRow.Row && tickets.Place == placeAndRow.Place));
            UpdateCost();


        }

        public void UpdateCost()
        {
            double sum = 0;
            foreach (var item in tickets)
            {
                sum += (double)currentSeance.SeanceCost;
            }
            CostTextBlock.Text = sum.ToString() + " р.";
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }


        private void BronButtonClick(object sender, RoutedEventArgs e)
        {
            if (tickets.Count < 1)
            {
                MessageBox.Show("Для бронирования выберите места", "Ошибка бронирования", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            List<Tickets> newTickets = new List<Tickets>();
            foreach (PlaceAndRow ticket in tickets) 
            {
                Tickets newTicket = new Tickets()
                {
                    TicketCost = (double)currentSeance.SeanceCost,
                    SeanceId = currentSeance.IdSeance,
                    TicketPayDate = DateTime.Now,
                    TicketRow = ticket.Row,
                    TicketPlace = ticket.Place,
                    TicketType = 2
                };
                if (!ticketsController.AddOneTicket(newTicket))
                {
                    MessageBox.Show("Не получилось добавить билет", "Ошибка бронирования", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                newTicket.IdTicket = ticketsController.GetLastAddedTicket().IdTicket;
                newTickets.Add(newTicket);
                
            }
            MessageBox.Show("Бронь оформлена", "Успешное бронирование", MessageBoxButton.OK, MessageBoxImage.Information);

            this.NavigationService.Navigate(new TicketInfoPage(newTickets));
        }
    }

    class PlaceAndRow
    {
        public int Row;
        public int Place;
    }
}
