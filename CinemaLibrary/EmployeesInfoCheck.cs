using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    public class EmployeesInfoCheck
    {
        public bool CheckFIOInfo(string nameInfo)
        {
            string namePatterm = @"^[А-Я][а-я]{1,20}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }
        public bool CheckAgeInfo(string nameInfo)
        {
            string namePatterm = @"^[1-9][0-9]$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }
        public bool CheckAdressInfo(string nameInfo)
        {
            string namePatterm = @"^[а-яА-Я0-9\s\.\,]{1,100}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }

        public bool CheckPhoneInfo(string nameInfo)
        {
            string namePatterm = @"^7[0-9]{10}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }
        public bool CheckSeriaInfo(string nameInfo)
        {
            string namePatterm = @"^[0-9]{4}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }

        public bool CheckNumberInfo(string nameInfo)
        {
            string namePatterm = @"^[0-9]{6}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }

        public bool CheckSalaryInfo(string nameInfo)
        {
            string namePatterm = @"^[1-9][0-9]{3,5}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }


    }
}
