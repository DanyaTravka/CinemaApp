using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class PostsController : MainController
    {
        public List<Posts> GetPostList()
        {
            return dataBase.context.Posts.ToList();
        }
        public List<string> GetAllPostsString()
        {
            List<Posts> actors = GetPostList();
            List<string> actorsString = new List<string>();
            foreach (Posts item in actors)
            {
                actorsString.Add(item.PostName);
            }
            return actorsString;
        }
    }
}
