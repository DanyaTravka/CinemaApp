using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Model
{
    public partial class Employees
    {
        public string EmployeeFullName
        {
            get
            {
                return EmployeeSurname + " " + EmployeeName + " " + EmployeePatronymic;
            }
        }
    }
}
