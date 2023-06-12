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
    /// Логика взаимодействия для AddOrUpdateEmployeePage.xaml
    /// </summary>
    public partial class AddOrUpdateEmployeePage : Page
    {
        EmployeesInfoCheck employeesInfoCheck = new EmployeesInfoCheck();
        PostsController postsController = new PostsController();
        GendersController gendersController = new GendersController();
        RequirementsController requirementsController = new RequirementsController();
        ResponsibilitiesController responsibilitiesController = new ResponsibilitiesController();

        RequirementsEmployeesController requirementsEmployeesController = new RequirementsEmployeesController();
        ResponsibilitiesEmployeesController responsibilitiesEmployeesController = new ResponsibilitiesEmployeesController();

        List<Requirements> requirements = new List<Requirements>();

        List<Responsibilities> responsibilities = new List<Responsibilities>();
        EmployeesController employeesController = new EmployeesController();
        Employees currentEmployee = null;
        public AddOrUpdateEmployeePage()
        {
           
            InitializeComponent();
            SetupPage();
        }

        public AddOrUpdateEmployeePage(Employees employees)
        {
            InitializeComponent();
            SetupPage();
            currentEmployee = employees;
            Name.Text = currentEmployee.EmployeeName;
            Surname.Text = currentEmployee.EmployeeSurname;
            Patronymic.Text = currentEmployee.EmployeePatronymic;
            Age.Text = currentEmployee.EmployeeAge.ToString();
            GenderCombo.SelectedIndex = currentEmployee.GenderId - 1;
            Adress.Text = currentEmployee.EmployeeAdress;
            Phone.Text = currentEmployee.EmployeePhone;
            Seria.Text = currentEmployee.EmployeePassportSeria;
            Number.Text = currentEmployee.EmployeePassportNumber;
            PostCombo.SelectedIndex = currentEmployee.PostId -1 ;
            Salary.Text = currentEmployee.EmployeeSalary.ToString();
            List<RequirementsEmployees> requirementsEmployees = requirementsEmployeesController.GetRequirementsEmployeesByEmployeeId(currentEmployee.IdEmployee);
            foreach (RequirementsEmployees item in requirementsEmployees)
            {
                requirements.Add(requirementsController.GetRequirementById(item.RequirementId));
            }
            UpdateRequirements();
            List<ResponsibilitiesEmployees> responsibilitiesEmployees = responsibilitiesEmployeesController.GetResponsibilitiesEmployeesByEmployeeId(currentEmployee.IdEmployee);
            foreach (ResponsibilitiesEmployees item in responsibilitiesEmployees)
            {
                responsibilities.Add(responsibilitiesController.GetResponsibilityById(item.ResponsibilityId));
            }
            UpdateResponsibilities();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        public void SetupPage()
        {
            RequerementsCombo.ItemsSource = requirementsController.GetAllRequirementsString();
            ResponsibilitiesCombo.ItemsSource = responsibilitiesController.GetAllResponsibilitiesString();
            GenderCombo.ItemsSource = gendersController.GetAllHallsString();
            PostCombo.ItemsSource = postsController.GetAllPostsString();
        }


        public void UpdateRequirements()
        {
            RequerementsListView.ItemsSource = null;
            RequerementsListView.ItemsSource = requirements;
        }

        public void UpdateResponsibilities()
        {
            ResponsibiliriesListView.ItemsSource = null;
            ResponsibiliriesListView.ItemsSource = responsibilities;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentEmployee == null)
            {
                if (!ValidateFields())
                {
                    return;
                }
                Employees employees = new Employees() { 
                    EmployeeName = Name.Text,
                    EmployeeSurname = Surname.Text,
                    EmployeePatronymic = Patronymic.Text,
                    EmployeeAge = Convert.ToInt32(Age.Text),
                    GenderId = GenderCombo.SelectedIndex + 1,
                    EmployeeAdress = Adress.Text,
                    EmployeePhone = Phone.Text,
                    EmployeePassportSeria = Seria.Text,
                    EmployeePassportNumber = Number.Text,
                    PostId = PostCombo.SelectedIndex + 1,
                    EmployeeSalary = Convert.ToInt32(Salary.Text)
                };
                if (!employeesController.AddEmploye(employees))
                {
                    MessageBox.Show("Не получилось добавить работника", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Employees lastAddedEmployee = employeesController.GetLastAddedEmploye();
                foreach (Requirements item in requirements)
                {
                    RequirementsEmployees requirementsEmployees = new RequirementsEmployees()
                    {
                        RequirementId = item.IdRequirements,
                        EmployeeId = lastAddedEmployee.IdEmployee
                    };
                    if (!requirementsEmployeesController.AddRequirementsEmployees(requirementsEmployees))
                    {
                        MessageBox.Show("Не удалось добавить связь требования и работника", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                foreach (Responsibilities item in responsibilities)
                {
                    ResponsibilitiesEmployees requirementsEmployees = new ResponsibilitiesEmployees()
                    {
                        ResponsibilityId = item.IdResponsibilities,
                        EmployeeId = lastAddedEmployee.IdEmployee
                    };
                    if (!responsibilitiesEmployeesController.AddResponsibilitiesEmployees(requirementsEmployees))
                    {
                        MessageBox.Show("Не удалось добавить связь обязанности и работника", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                MessageBox.Show("Работник успешно добавлен", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
            else
            {
                if (!ValidateFields())
                {
                    return;
                }
                if (currentEmployee.EmployeeName == Name.Text &&
                     currentEmployee.EmployeeSurname == Surname.Text &&
                     currentEmployee.EmployeePatronymic == Patronymic.Text &&
                     currentEmployee.EmployeeAge == Convert.ToInt32(Age.Text) &&
                     currentEmployee.GenderId == GenderCombo.SelectedIndex + 1 &&
                     currentEmployee.EmployeeAdress == Adress.Text &&
                     currentEmployee.EmployeePhone == Phone.Text &&
                     currentEmployee.EmployeePassportSeria == Seria.Text &&
                     currentEmployee.EmployeePassportNumber == Number.Text &&
                     currentEmployee.PostId == PostCombo.SelectedIndex + 1 &&
                     currentEmployee.EmployeeSalary == Convert.ToInt32(Salary.Text)
                     )
                {

                }
                else
                {
                    currentEmployee.EmployeeName = Name.Text;
                    currentEmployee.EmployeeSurname = Surname.Text;
                    currentEmployee.EmployeePatronymic = Patronymic.Text;
                    currentEmployee.EmployeeAge = Convert.ToInt32(Age.Text);
                    currentEmployee.GenderId = GenderCombo.SelectedIndex + 1;
                    currentEmployee.EmployeeAdress = Adress.Text;
                    currentEmployee.EmployeePhone = Phone.Text;
                    currentEmployee.EmployeePassportSeria = Seria.Text;
                    currentEmployee.EmployeePassportNumber = Number.Text;
                    currentEmployee.PostId = PostCombo.SelectedIndex + 1;
                    currentEmployee.EmployeeSalary = Convert.ToInt32(Salary.Text);
                    if (!employeesController.UpdateEmploye(currentEmployee))
                    {
                        MessageBox.Show("Не удалось обновить работника", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                List<RequirementsEmployees> requirementsEmployees = requirementsEmployeesController.GetRequirementsEmployeesByEmployeeId(currentEmployee.IdEmployee);
                foreach (RequirementsEmployees item in requirementsEmployees)
                {
                    if (requirements.FirstOrDefault(genre => genre.IdRequirements == item.RequirementId) == null)
                    {
                        if (!requirementsEmployeesController.DeleteRequirementsEmployees(item))
                        {
                            MessageBox.Show("Не удалось удалить связь требования", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }
                foreach (Requirements item in requirements)
                {
                    if (requirementsEmployees.FirstOrDefault(fg => fg.RequirementId == item.IdRequirements) == null)
                    {
                        RequirementsEmployees requirementsEmployeesNew = new RequirementsEmployees()
                        {
                            RequirementId = item.IdRequirements,
                            EmployeeId = currentEmployee.IdEmployee
                        };
                        if (!requirementsEmployeesController.AddRequirementsEmployees(requirementsEmployeesNew))
                        {
                            MessageBox.Show("Не удалось добавить связь требования и работника", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }

                List<ResponsibilitiesEmployees> responsibilitiesEmployees = responsibilitiesEmployeesController.GetResponsibilitiesEmployeesByEmployeeId(currentEmployee.IdEmployee);
                foreach (ResponsibilitiesEmployees item in responsibilitiesEmployees)
                {
                    if (responsibilities.FirstOrDefault(genre => genre.IdResponsibilities == item.ResponsibilityId) == null)
                    {
                        if (!responsibilitiesEmployeesController.DeleteResponsibilitiesEmployees(item))
                        {
                            MessageBox.Show("Не удалось удалить связь обязанности", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }
                foreach (Responsibilities item in responsibilities)
                {
                    if (responsibilitiesEmployees.FirstOrDefault(fg => fg.ResponsibilityId == item.IdResponsibilities) == null)
                    {
                        ResponsibilitiesEmployees requirementsEmployeesNew = new ResponsibilitiesEmployees()
                        {
                            ResponsibilityId = item.IdResponsibilities,
                            EmployeeId = currentEmployee.IdEmployee
                        };
                        if (!responsibilitiesEmployeesController.AddResponsibilitiesEmployees(requirementsEmployeesNew))
                        {
                            MessageBox.Show("Не удалось добавить связь обязанности и работника", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }

                MessageBox.Show("Работник успешно обновлен", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();
            }
        }

        public bool ValidateFields()
        {
            if (!employeesInfoCheck.CheckFIOInfo(Name.Text))
            {
                MessageBox.Show("Имя введено неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!employeesInfoCheck.CheckFIOInfo(Surname.Text))
            {
                MessageBox.Show("Фамилия введена неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!employeesInfoCheck.CheckFIOInfo(Patronymic.Text))
            {
                MessageBox.Show("Отчество введено неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!employeesInfoCheck.CheckAgeInfo(Age.Text))
            {
                MessageBox.Show("Возраст введен неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (GenderCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите пол", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (PostCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите должность", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!employeesInfoCheck.CheckAdressInfo(Adress.Text))
            {
                MessageBox.Show("Адрес введен неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!employeesInfoCheck.CheckPhoneInfo(Phone.Text))
            {
                MessageBox.Show("Телефон введен неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!employeesInfoCheck.CheckSeriaInfo(Seria.Text))
            {
                MessageBox.Show("Серия паспорта введена неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!employeesInfoCheck.CheckNumberInfo(Number.Text))
            {
                MessageBox.Show("Номер паспорта введен неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!employeesInfoCheck.CheckSalaryInfo(Salary.Text))
            {
                MessageBox.Show("Зарплата введена неправильно", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (requirements.Count < 1)
            {
                MessageBox.Show("Выберите минимум одно требование", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (responsibilities.Count < 1)
            {
                MessageBox.Show("Выберите минимум одну обязанность", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void DeleteResponsibilityClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            responsibilities.Remove(responsibilities.FirstOrDefault(ac => ac.IdResponsibilities == Convert.ToInt32(button.Uid)));     
            UpdateResponsibilities();
        }

        private void DeleteRequrementsClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            requirements.Remove(requirements.FirstOrDefault(ac => ac.IdRequirements == Convert.ToInt32(button.Uid)));
            UpdateRequirements();
        }

        private void AddRequerementButtonClick(object sender, RoutedEventArgs e)
        {
            if (RequerementsCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали требование", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (requirements.FirstOrDefault(ac => ac.IdRequirements == RequerementsCombo.SelectedIndex + 1) != null)
            {
                MessageBox.Show("Данное требование уже добавлено", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            requirements.Add(requirementsController.GetRequirementById(RequerementsCombo.SelectedIndex + 1));
            UpdateRequirements();
        }

        private void AddResponsibilityButtonClick(object sender, RoutedEventArgs e)
        {
            if (ResponsibilitiesCombo.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали обязанность", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (responsibilities.FirstOrDefault(ac => ac.IdResponsibilities == ResponsibilitiesCombo.SelectedIndex + 1) != null)
            {
                MessageBox.Show("Данная обязанность уже добавлена", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            responsibilities.Add(responsibilitiesController.GetResponsibilityById(ResponsibilitiesCombo.SelectedIndex + 1));
            UpdateResponsibilities();
        }
    }
}
