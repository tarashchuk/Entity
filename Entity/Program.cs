using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
               /* User user1 = new User { Login = "login1", Password = "pass1234" };
                User user2 = new User { Login = "login2", Password = "5678word2" };
                db.Users.AddRange(new List<User> { user1, user2 });
                db.SaveChanges();
                UserProfile profile1 = new UserProfile { Id = user1.Id, Age = 22, Name = "Tom" };
                UserProfile profile2 = new UserProfile { Id = user2.Id, Age = 27, Name = "Alice" };
                db.UserProfiles.AddRange(new List<UserProfile> { profile1, profile2 });
                db.SaveChanges();*/


                foreach (User user in db.Users.Include("Profile").ToList())
                    Console.WriteLine("Name: {0}  Age: {1}  Login: {2}  Password: {3}",
                            user.Profile.Name, user.Profile.Age, user.Login, user.Password);
            }
            Console.ReadKey();
        }

    }
}
