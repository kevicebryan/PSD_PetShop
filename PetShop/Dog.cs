using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Dog
    {
        private string id { get; set; }
        private string name { get; set; }

        private Date date { get; set; }
        private int price { get; set; }
       
        // Make new Class for Description
        private Description description { get; set; }

        public Dog(string id, string name, Date date, int price, Description description)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.price = price;
            this.description = description;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Date Date
        {
            get { return date; }
        }

        public int  Price
        {
            get { return price; }
            set { price = value; }
        }

        public Description Description
        {
            get { return description; }
            set { description = value; }
        }
        public int getAge()
        {
            int birthYear = this.date.Year;
            int age = 2022 - birthYear;
        return age;
        }


        public String printDog()
        {
            return ($"{this.id} / {this.name} / { this.date.printDate()} / Rp {this.price} / " +
                $"{this.description.printDesc()}");
        }
    }


}
