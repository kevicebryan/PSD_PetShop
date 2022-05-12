using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Item
    {
        private string id {get; set;}

        public string Id
        {
            get { return id;}
            set { id = value;}
        }
        private string name { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int price { get; set; }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        private int stock { get; set; }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public Item(string id, string name, int price, int stock)
        {
                this.id = id;
                this.name = name;
                this.price = price;
                this.stock = stock;
        }
        public string printItem()
        {
            return ($"{id} / {name} / Rp {price} / {stock}x");
        }
    }
}
