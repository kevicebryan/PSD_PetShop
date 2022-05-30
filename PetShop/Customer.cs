using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Customer : User
    {
        ShopSystem ss = new ShopSystem();
        public Customer(string name, string phone, string email, string password) : base(name, phone, email, password)
        {
        }

        public void buyDog(List <Dog> dogs)
        {
            base.viewDogs(dogs);
            int idx = -1;
            while (!ss.validDogIndex(idx))
            {
                Console.WriteLine($"Buy Dog dog at number [1 - {dogs.Count}]:");
                idx = Convert.ToInt32(Console.ReadLine());
            }
            Dog removedDog = dogs.ElementAt(idx - 1);
            Console.WriteLine($"Succesfully bought #{removedDog.Id}");
            dogs.RemoveAt(idx - 1);

        }
        public void buyItem(List <Item> items)
        {
            base.viewItems(items);
            int idx = -1;
            while (ss.validItemIndex(idx))
            {
                Console.WriteLine($"Buy Item number [1 - {items.Count}]:");
                idx = Convert.ToInt32(Console.ReadLine());
            }
            Item removedItems = items.ElementAt(idx - 1);
            if (removedItems.Stock != 0)
            {
                Console.WriteLine($"Succesfully bought #{removedItems.Id}");
                items.RemoveAt(idx - 1);
            }
            else
            {
                Console.WriteLine("Item out of stock!");
            }
        }
    }
}
