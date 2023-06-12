using CinemaLibraryTests.Controllers;
using CinemaLibraryTests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CinemaLibraryTests.IntegrationTests
{
    [TestClass]
    public class EmployeesControllerTests
    {
        EmployeesController employeesController = new EmployeesController();
        [TestMethod]
        public void AddEmploye_AddNewEmployee_ReturnTrue()
        {
            Employees employees = new Employees()
            {
                EmployeeName = "a",
                EmployeeSurname = "a",
                EmployeePatronymic = "a",
                EmployeeAge = 13,
                GenderId = 1,
                EmployeeAdress = "a",
                EmployeePhone = "a",
                EmployeePassportSeria = "a",
                EmployeePassportNumber = "a",
                PostId = 1,
                EmployeeSalary = 1
            };
            Assert.IsTrue(employeesController.AddEmploye(employees));
        }

        [TestMethod]
        public void UpdateEmploye_UpdateNewEmployee_ReturnTrue()
        {
            Employees employees = employeesController.GetLastAddedEmploye();
            employees.EmployeeName = "f";
            Assert.IsTrue(employeesController.UpdateEmploye(employees));
        }

        [TestMethod]
        public void DeleteEmployee_DeleteNewEmployee_ReturnTrue()
        {
            Employees employees = employeesController.GetLastAddedEmploye();

            Assert.IsTrue(employeesController.DeleteEmploye(employees));
        }
    }
}
