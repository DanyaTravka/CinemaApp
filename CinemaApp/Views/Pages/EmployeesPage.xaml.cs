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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        EmployeesController employeesController = new EmployeesController();
        ResponsibilitiesEmployeesController responsibilitiesEmployeesController = new ResponsibilitiesEmployeesController();
        RequirementsEmployeesController requirementsEmployeesController = new RequirementsEmployeesController();
        public EmployeesPage()
        {
            InitializeComponent();
        }

        public void UpdateList()
        {
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = employeesController.GetEmployeesList();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void AddNewEmployeeClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddOrUpdateEmployeePage());
        }

        private void ReductEmployeeClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            this.NavigationService.Navigate(new AddOrUpdateEmployeePage(employeesController.GetEmployeeById(Convert.ToInt32(button.Uid))));
        }

        private void DeleteEmployeeButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Employees employee = employeesController.GetEmployeeById(Convert.ToInt32(button.Uid));
            var result = MessageBox.Show("Вы уверены, что хотите удалить работника?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                List<ResponsibilitiesEmployees> responsibilitiesEmployees = responsibilitiesEmployeesController.GetResponsibilitiesEmployeesByEmployeeId(employee.IdEmployee);
                foreach (ResponsibilitiesEmployees item in responsibilitiesEmployees)
                {
                    if (!responsibilitiesEmployeesController.DeleteResponsibilitiesEmployees(item))
                    {
                        MessageBox.Show("Не удалось удалить связь обязанности", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                List<RequirementsEmployees> requirementsEmployees = requirementsEmployeesController.GetRequirementsEmployeesByEmployeeId(employee.IdEmployee);
                foreach (RequirementsEmployees item in requirementsEmployees)
                {
                    if (!requirementsEmployeesController.DeleteRequirementsEmployees(item))
                    {
                        MessageBox.Show("Не удалось удалить связь требования", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                if (!employeesController.DeleteEmploye(employee))
                {
                    MessageBox.Show("Не удалось удалить работника", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Работник успешно удален", "Успешное удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateList();
            }
        }
    }
}
