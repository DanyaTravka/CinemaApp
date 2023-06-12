using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CinemaLibrary
{
    public class FilmInfoCheck
    { 
        public bool CheckNameInfo(string nameInfo)
        {
            string namePatterm = @"^[а-яА-Яa-zA-Z0-9\s]{1,49}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }

        public bool CheckDescriptionInfo(string nameInfo)
        {
            string namePatterm = @"^[а-яА-Яa-zA-Z0-9\s\'\.\,\-]{1,3000}$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }

        public bool CheckDurationInfo(string nameInfo)
        {
            string namePatterm = @"^[0-9]{1}\:[0-5][0-9]$";
            return Regex.IsMatch(nameInfo, namePatterm);
        }


    }
}
