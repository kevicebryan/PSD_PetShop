using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class ShopSystem
    {
        List <User> users = new List<User>();
        List<Dog> dogs = new List<Dog>();
        List<Item>items = new List<Item>();

        public ShopSystem()
        {
            // to add dummy Data to the system
            init();
        }

        public void mainMenu()
        {
            int choice = -1;
            while(choice != 4)
            {
                printMainMenu();
                Console.WriteLine(">>");
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1) manageDogs();
                if(choice == 2) manageItems();
                if(choice == 3) manageUsers();
            }
        }
        void printMainMenu()
        {
            Console.WriteLine("PSD Pet Shop");
            Console.WriteLine("1. Manage Dogs");
            Console.WriteLine("2. Manage Items");
            Console.WriteLine("3. Manage Users");
            Console.WriteLine("4. Exit");
        }

        void manageDogs()
        {
            Console.WriteLine("Manage Dogs");
            Console.WriteLine("1. View Dogs");
            Console.WriteLine("2. Add New Dog");
            Console.WriteLine("3. Remove Dog");
            Console.WriteLine("4. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) viewDogs();
            if (choice == 2) addDog();
            if (choice == 3) removeDog();
        }

        void manageUsers()
        {
            Console.WriteLine("Manage Users");
            Console.WriteLine("1. View Users");
            Console.WriteLine("2. Ban User");
            Console.WriteLine("3. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) viewUsers();
            if (choice == 2) banUser();
        }

        void manageItems()
        {
            Console.WriteLine("Manage Items");
            Console.WriteLine("1. View Items");
            Console.WriteLine("2. Add New Item");
            Console.WriteLine("3. Remove Item");
            Console.WriteLine("4. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) viewItems();
            if (choice == 2) addItem();
            if (choice == 3) removeItem();
        }

        public string generateDogID()
        {
            Random randomNumber = new Random();
            int a = randomNumber.Next(10);
            int b = randomNumber.Next(10);
            int c = randomNumber.Next(10);
            String id = ($"D{a}{b}{c}");

            while (!isUniqueDogID(id))
            {
                 a = randomNumber.Next(10);
                 b = randomNumber.Next(10);
                 c = randomNumber.Next(10);
                 id = ($"D{a}{b}{c}");
            }
            return id;
        }
        public string generateItemID()
        {
            Random randomNumber = new Random();
            int a = randomNumber.Next(10);
            int b = randomNumber.Next(10);
            int c = randomNumber.Next(10);
            String id = ($"I{a}{b}{c}");

            while (!isUniqueItemID(id))
            {
                a = randomNumber.Next(10);
                b = randomNumber.Next(10);
                c = randomNumber.Next(10);
                id = ($"I{a}{b}{c}");
            }
            return id;
        }
        Boolean isUniqueDogID(string id)
        {
            for(int i = 0; i < dogs.Count; i++)
            {
                if (id == dogs[i].Id) return false;
            }
            return true;
        }
        Boolean isUniqueItemID(string id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (id == items[i].Id) return false;
            }
            return true;
        }

        // Manage Dogs

        void viewDogs()
        {
            for(int i = 0; i < dogs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dogs[i].printDog()}");
            }
        }

        void addDog()
        {
            string id = generateDogID();
            Console.Write("Input Dog Name: ");
            string name = Console.ReadLine();
            Console.Write("Input Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Birth Date [1-31]: ");
            int day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Birth Month [1-12]: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Birth Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Date birthDate = new Date(day, month, year);
            Console.Write($"Description of {name}: ");
            string desc = Console.ReadLine();

            Dog newDog = new Dog(id, name, birthDate, price, desc);
            dogs.Add(newDog);
            Console.WriteLine($"Succefully added {name}, its ID is {id}");
        }

        void removeDog()
        {
            viewDogs();
            int idx = -1;
            while (!!validDogIndex(idx))
            {
                Console.WriteLine($"Remove Dog dog at number [1 - {dogs.Count}]:");
                idx = Convert.ToInt32(Console.ReadLine());
            }
            Dog removedDog = dogs.ElementAt(idx - 1);
            Console.WriteLine($"Succesfully removed #{removedDog.Id}");
            dogs.RemoveAt(idx - 1);

        }
        
        
        // Manage Items
        void viewItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].printItem()}");
            }
        }

        void addItem()
        {
            string id = generateItemID();
            Console.Write("Input Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Input Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            Item newItem = new Item(id, name, price, stock);
            items.Add(newItem);
            Console.WriteLine($"Succefully added {name}, item ID is {id}");
        }

        void removeItem()
        {
            viewItems();
            int idx = -1;
            while (!!validItemIndex(idx))
            {
                Console.WriteLine($"Remove Dog dog at number [1 - {items.Count}]:");
                idx = Convert.ToInt32(Console.ReadLine());
            }
            Item removedItems = items.ElementAt(idx - 1);
            Console.WriteLine($"Succesfully removed #{removedItems.Id}");
            items.RemoveAt(idx - 1);

        }
        
        
        // Manage Users
        void viewUsers()
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].printUser()}");
            }
        }

        void banUser()
        {
            viewUsers();
            int idx = -1;
            while (!!validItemIndex(idx))
            {
                Console.WriteLine($"Remove Dog dog at number [1 - {items.Count}]:");
                idx = Convert.ToInt32(Console.ReadLine());
            }
            User removedUser = users.ElementAt(idx - 1);
            Console.WriteLine($"Succesfully removed {removedUser.Email}");
            users.RemoveAt(idx - 1);
        }

        Boolean validDogIndex(int choice)
        {
            choice--;

            if(choice < 0) return false;
            if (choice > dogs.Count - 1) return false;
            return true;
        }
        Boolean validUserIndex(int choice)
        {
            choice--;

            if (choice < 0) return false;
            if (choice > users.Count - 1) return false;
            return true;
        }
        Boolean validItemIndex(int choice)
        {
            choice--;

            if (choice < 0) return false;
            if (choice > items.Count - 1) return false;
            return true;
        }

        void init()
        {
            // Dummy Users
            users.Add(new User("Kevin", "0812345676", "kevin@gmail.com", "password"));
            users.Add(new User("Ryanto", "0855555644", "ryanto@gmail.com", "password"));
            users.Add(new User("Wendy", "08333456222", "wendy@gmail.com", "password"));

            // Dummy Dogs
            dogs.Add(new Dog("D001", "Fury", new Date(1, 1, 2010), 1000000, "a furry black pitbull"));
            dogs.Add(new Dog("D002", "Stanny", new Date(2, 15, 2019), 1500000, "a tiny chihuahua"));
            dogs.Add(new Dog("D003", "Billy", new Date(4, 18, 2020), 2500000, "a giant bulldog"));
            //Dummy Items
            items.Add(new Item("I001", "Dog Plushie", 50000, 50));
            items.Add(new Item("I002", "Dog Leash", 75000, 120));
            items.Add(new Item("I003", "Dog Dragon Costume", 125000, 10));

        }
    }
}
