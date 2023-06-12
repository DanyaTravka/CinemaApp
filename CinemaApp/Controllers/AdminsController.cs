using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class AdminsController : MainController
    {
        public Admins GetAdminByLoginAndPassword(string login, string password)
        {
            return dataBase.context.Admins.FirstOrDefault(adm => adm.AdminLogin == login && adm.AdminPassword == password);
        }
    }
}
