using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_02.BL
{
    class User
    {
        private string role;
        private string username;
        private string password;

        public string Role { get => role; set => role = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public User(string Username, string Password, string Role)
        {
            this.Username = Username;
            this.Password = Password;
            this.Role = Role;
        }
        public string GetUsername()
        {
            return Username;
        }
        public string GetPassword()
        {
            return Password;
        }
        public string GetRole()
        {
            return Role;
        }
        
        public bool isAdmin()
        {
            if (Role == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
