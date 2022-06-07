using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Admin : User
    {
        ShopSystem ss = new ShopSystem();
        Validation validator = new Validation();
        public Admin(string name, string phone, string email, string password) : base(name, phone, email, password)
        {
        }

        public void manageDogs(List <Dog> dogs)
        {
            Console.WriteLine("Manage Dogs");
            Console.WriteLine("1. View Dogs");
            Console.WriteLine("2. Add New Dog");
            Console.WriteLine("3. Remove Dog");
            Console.WriteLine("4. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) base.viewDogs(dogs);
            if (choice == 2) addDog(dogs);
            if (choice == 3) removeDog(dogs);
        }

        public void manageUsers(List <User> users)
        {
            Console.WriteLine("Manage Users");
            Console.WriteLine("1. View Users");
            Console.WriteLine("2. Ban User");
            Console.WriteLine("3. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) viewUsers(users);
            if (choice == 2) banUser(users);
        }

        public void manageItems(List <Item> items)
        {
            Console.WriteLine("Manage Items");
            Console.WriteLine("1. View Items");
            Console.WriteLine("2. Add New Item");
            Console.WriteLine("3. Remove Item");
            Console.WriteLine("4. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) base.viewItems(items);
            if (choice == 2) addItem(items);
            if (choice == 3) removeItem(items);
        }


        // Manage Item
        public void addItem(List <Item> items)
        {
            string id; int price; int stock;
            id = ss.generateItemID();
            Console.Write("Input Item Name: ");
            string name = Console.ReadLine();

            do
            {
                Console.Write("Input Price: ");
                price = Convert.ToInt32(Console.ReadLine());
            } while (!validator.ValidPrice(price));

            Console.Write("Input Stock: ");
            stock = Convert.ToInt32(Console.ReadLine());

            Item newItem = new Item(id, name, price, stock);
            items.Add(newItem);
            Console.WriteLine($"Succefully added {name}, item ID is {id}");
        }

        public void removeItem(List <Item> items)
        {
            base.viewItems(items);
            int idx = -1;
            while (!ss.validItemIndex(idx))
            {
                Console.WriteLine($"Remove Item at number [1 - {items.Count}]:");
                idx = Convert.ToInt32(Console.ReadLine());
            }
            Item removedItems = items.ElementAt(idx - 1);
            Console.WriteLine($"Succesfully removed #{removedItems.Id}");
            items.RemoveAt(idx - 1);
        }

        // Manage Dogs
        public void addDog( List <Dog> dogs)
        {
            string id = ss.generateDogID();
            Console.Write("Input Dog Name: ");
            string name = Console.ReadLine();
            int price;
            do
            {
                Console.Write("Input Price: ");
                price = Convert.ToInt32(Console.ReadLine());
            } while (!validator.ValidPrice(price));

            Console.Write("Input Birth Date [1-31]: ");
            int day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Birth Month [1-12]: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Birth Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Date birthDate = new Date(day, month, year);
            Console.Write($"Color of {name}: ");
            string color = Console.ReadLine();
            Console.Write($"Image Source of {name}: ");
            string photo = Console.ReadLine();
            Console.Write($"Weight of {name}: ");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.Write($"Species of {name}: ");
            string species = Console.ReadLine();

            Dog newDog = new Dog(id, name, birthDate, price, new Description(color, photo, weight, species));
            dogs.Add(newDog);
            Console.WriteLine($"Succefully added {name}, its ID is {id}");
        }

        public void removeDog(List <Dog> dogs)
        {
            base.viewDogs(dogs);
            int idx = -1;
            do
            {
                Console.WriteLine($"Remove Dog dog at number [1 - {dogs.Count}]:");
                idx = Convert.ToInt32(Console.ReadLine());
            } while (!ss.validDogIndex(idx));

            Dog removedDog = dogs.ElementAt(idx - 1);
            Console.WriteLine($"Succesfully removed #{removedDog.Id}");
            dogs.RemoveAt(idx - 1);

        }

        // Manage User
        public void viewUsers(List <User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].printUser()}");
            }
        }

        public void banUser(List <User> users)
        {
            viewUsers(users);
            int idx = -1;
            while (!ss.validUserIndex(idx))
            {
                Console.WriteLine($"Remove User number [1 - {users.Count}]:");
                idx = Convert.ToInt32(Console.ReadLine());
            }
            User removedUser = users.ElementAt(idx - 1);
            Console.WriteLine($"Succesfully removed {removedUser.Email}");
            users.RemoveAt(idx - 1);
        }

    }
}
