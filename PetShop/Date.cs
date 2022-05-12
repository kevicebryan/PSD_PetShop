using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Date
        //value object untuk tanggal
        //IMMUTABLE
    {
        public int day;
        public int month;
        public int year;

        public string printDate()
        {
            return ($"{day}/{month}/{year}");
        }

        public Date(int d, int m, int y)
        {
            this.day = d;
            this.month = m;
            this.year = y;  
        }
    }
}
