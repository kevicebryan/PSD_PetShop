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
        private Date birthDate { get; }
        private int price { get; set; }
       
        // Make new Class for Description
        private string description { get; set; }

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

        public Date BirthDate
        {
            get { return birthDate; }
        }

        public int  Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int getAge()
        {
            int birthYear = this.birthDate.year;
            int age = 2022 - birthYear;
        return age;
        }

        public Dog(string id, string name, Date birthDate, int price, string description)
        {
            this.id = id;
            this.name = name;
            this.birthDate = birthDate;
            this.price = price;
            this.description = description;
        }

        public String printDog()
        {
            return ($"{this.id} / {this.name} / { this.birthDate.printDate()} / Rp {this.price}" +
                $"${this.description}");
        }
    }


}
