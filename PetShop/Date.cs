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
        private int day { get; }
        private int month { get; }
        private int year { get; }

        public int Day { get { return day; } }
        public int Month { get { return month; } }
        public int Year { get { return year; } }

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;  
        }
        

        public string printDate()
        {
            return ($"{day}/{month}/{year}");
        }


        

    }
}
