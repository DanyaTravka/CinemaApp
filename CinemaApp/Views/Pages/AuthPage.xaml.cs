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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        AdminsController adminsController = new AdminsController();
        public AuthPage()
        {
            InitializeComponent();
        }


        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void EntryButtonClick(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "" || LoginTextBox.Text == null || LoginTextBox.Text == " " || PasswordPasswordBox.Password == "" 
                || PasswordPasswordBox.Password == null || PasswordPasswordBox.Password == " ")
            {
                MessageBox.Show("Введите логин и пароль", "Неправильный ввод", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Admins admins = adminsController.GetAdminByLoginAndPassword(LoginTextBox.Text, PasswordPasswordBox.Password);
            if (admins == null)
            {
                MessageBox.Show("Пользователь не найден", "Не найдено", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            App.currentAdmin = admins;
            this.NavigationService.Navigate(new MainPage());

        }
    }
}
