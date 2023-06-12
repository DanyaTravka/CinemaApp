using CinemaApp.Controllers;
using CinemaApp.Model;
using CinemaLibrary;
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
    /// Логика взаимодействия для AddSeancePage.xaml
    /// </summary>
    public partial class AddSeancePage : Page
    {
        FilmsController filmsController = new FilmsController();
        HallsController hallsController = new HallsController();
        SeancesController seancesController = new SeancesController();
        SeancesInfoCheck seancesInfoCheck = new SeancesInfoCheck();
        public AddSeancePage()
        {
            InitializeComponent();
            SetupPage();
        }

        public void SetupPage()
        {
            FilmCombo.ItemsSource = filmsController.GetAllFilmsString();
            HallCombo.ItemsSource = hallsController.GetAllHallsString();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (!seancesInfoCheck.CheckCostInfo(CostTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели цену", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!seancesInfoCheck.CheckTimeInfo(TimeTextBox.Text))
            {
                MessageBox.Show("Вы неправильно ввели время", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (HallCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали зал", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (FilmCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали фильм", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (DateStartDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Вы не выбрали дату", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (DateStartDatePicker.SelectedDate.Value.Day  > DateTime.Now.Day + 10)
            {
                MessageBox.Show("Дата введена неверно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (DateStartDatePicker.SelectedDate.Value < DateTime.Now)
            {
                MessageBox.Show("Дата введена неверно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Seances seances = new Seances()
            {
                SeanceDate = (DateTime)DateStartDatePicker.SelectedDate,
                FilmId = filmsController.GetFilmByName((string)FilmCombo.SelectedValue).IdFilm,
                HallId = HallCombo.SelectedIndex + 1,
                SeanceStartTime = new TimeSpan( Convert.ToInt32(TimeTextBox.Text.Split(':')[0]), Convert.ToInt32(TimeTextBox.Text.Split(':')[1]), 0),
                SeanceCost = Convert.ToInt32(CostTextBox.Text)

            };
            if (!seancesController.AddSeance(seances))
            {
                MessageBox.Show("Не получилось добавить сеанс", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            MessageBox.Show("Сеанс успешно добавлен", "Успешно добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
            this.NavigationService.GoBack();

        }
    }
}
