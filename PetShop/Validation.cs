using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Validation
    {
        public bool ValidPrice(int price)
        {
            if (price <= 0) return false;
            return true; 
        }

        public bool ValidPhone(String phone)
        {
            if(phone.Length < 10 || phone.Length > 12) return false;
            return true;
        }

        public bool ValidEmail(String email)
        {
            if(!email.Contains("@"))return false;
            if (email.StartsWith("@")) return false;
            return true;   
        }

        public bool ValidPassword(String password)
        {
            if(password.Length < 7) return false;  
            return true;
        }

        public bool ValidRange(int start, int end, int input)
        {
            if(input < start || input > end) return false;
            return true;
        }
    }
}
