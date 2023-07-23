using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Problem_02.BL;

namespace Problem_02.DL
{
    class UserDL
    {
        private static List<User> users = new List<User>();

        public static List<User> Users { get => users; set => users = value; }

        public static void AddUserToList(User U)
        {
            Users.Add(U);
        }

        public static User UserSignIn(User U)
        {
            foreach (var user in Users)
            {
                if (user.GetUsername() == U.GetUsername() && user.GetPassword() == U.GetPassword())
                {
                    return user;
                }
            }
            return null;
        }
        
    }
}
