using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class User
    {
        private string name { get; set; }
        private string phone  {get; set; }
        private string email  {get; set; }
        private string password { get; set; }

        public string Name { get { return name; } set { name = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Email { get { return email; } set { email = value; } }    
        public string Password { get { return password; } set { password = value; } }   

        public User(string name, string phone, string email, string password)
        {
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.password = password;
        }

        public string printUser()
        {
            return ($"{name} / {phone} / {email}");
        }
    }
}
