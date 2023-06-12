using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Model
{
    public partial class Actors
    {
        public string ActorsFullName { get {
                return ActorName + " " + ActorSurname;
            } }
    }
}
