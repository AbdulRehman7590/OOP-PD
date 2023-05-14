using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_v_4_.BL
{
    class Credentials
    {
        public int role;
        public string userName;
        public string password;
        public string contact;

        public Credentials(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public Credentials(int role, string userName, string password, string contact)
        {
            this.role = role;
            this.userName = userName;
            this.password = password;
            this.contact = contact;
        }


        public bool CheckAdmin()
        {
            bool flag = false;

            if (this.role == 1)
            {
                flag = true;
            }

            return flag;
        }













    }
}
