using CinemaApp.Controllers;
using CinemaApp.Model;
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
    /// Логика взаимодействия для SeancesPage.xaml
    /// </summary>
    public partial class SeancesPage : Page
    {
        SeancesController seancesController = new SeancesController();
        TicketsController ticketsController = new TicketsController();
        public SeancesPage()
        {
            InitializeComponent();
        }

        private void AddNewSeanceClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddSeancePage());
        }

        public void UpdateList()
        {
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = seancesController.GetAllSeances();

        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void DeleteSeanceButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
           
            var result = MessageBox.Show("Вы уверены, что хотите удалить сеанс?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Seances seanceToDelete = seancesController.GetSeanceById(Convert.ToInt32(button.Uid));            
                    List<Tickets> tickets = ticketsController.GetTicketsListBySeanceId(seanceToDelete.IdSeance);
                    foreach (Tickets item2 in tickets)
                    {
                        if (!ticketsController.DeleteTicket(item2))
                        {
                            MessageBox.Show("Не удалось удалить билет", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    if (!seancesController.DeleteSeance(seanceToDelete))
                    {
                        MessageBox.Show("Не удалось удалить сеанс", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
       
                MessageBox.Show("Сеанс удален", "Успешное удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateList();
            }
        }
    }
}
