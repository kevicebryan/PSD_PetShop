using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetShop
{
    class ShopSystem
    {
        List <User> users = new List<User>();
        List<Dog> dogs = new List<Dog>();
        List<Item>items = new List<Item>();

        Validation validator = new Validation();
        public ShopSystem()
        {
            // to add dummy Data to the system
            init();


        }

        public void preMenu()
        {
            int choice = -1;
            while (choice != 3)
            {
                printPreMenu();
                Console.WriteLine(">>");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1) login();
                if (choice == 2) register();
            }
            // convert list of obj to JSON
            string usersJSON = JsonSerializer.Serialize(users);
            string dogsJSON = JsonSerializer.Serialize(dogs);
            string itemsJSON = JsonSerializer.Serialize(items);

            File.WriteAllText("users.json", usersJSON);
            File.WriteAllText("dogs.json", dogsJSON);
            File.WriteAllText("items.json", itemsJSON);
        }

        public void printPreMenu()
        {
            Console.WriteLine("PSD Pet Shop");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
        }

        public void customerMenu(Customer customer)
        {
            int choice = -1;
            while (choice != 5)
            {
                printCustomerMenu();
                Console.WriteLine(">>");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1) customer.viewDogs(dogs);
                if (choice == 2) customer.buyDog(dogs);
                if (choice == 3) customer.viewItems(items);
                if (choice == 4) customer.buyItem(items);
            }
        }

        public void printCustomerMenu()
        {
            Console.WriteLine("PSD Pet Shop");
            Console.WriteLine("1. View Dogs");
            Console.WriteLine("2. Buy a dog");
            Console.WriteLine("3. View Items");
            Console.WriteLine("4. Buy item");
            Console.WriteLine("5. Exit");
        }

        public void adminMenu(Admin admin)
        {
            int choice = -1;
            while(choice != 4)
            {
                printAdminMenu();
                Console.WriteLine(">>");
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1) admin.manageDogs(dogs);
                if(choice == 2) admin.manageItems(items);
                if(choice == 3) admin.manageUsers(users);
            }
        }

        public void printAdminMenu()
        {
            Console.WriteLine("PSD Pet Shop");
            Console.WriteLine("1. Manage Dogs");
            Console.WriteLine("2. Manage Items");
            Console.WriteLine("3. Manage Users");
            Console.WriteLine("4. Exit");
        }

        public void login()
        {
            string email;  string password;

            do
            {
                do
                {
                    Console.Write("Your email: ");
                    email = Console.ReadLine();
                } while (!validator.ValidEmail(email));

                do
                {
                    Console.Write("Password: ");
                    password = Console.ReadLine();
                } while (!validator.ValidPassword(password));

                if(validUser(email, password) == null)
                {
                    Console.WriteLine("Invalid credentials, please fill data again!");
                }

            } while (validUser(email, password) == null);


            Console.WriteLine("Login Success!");
            if (email.Equals("admin@admin"))
            {
                User currUser = validUser(email, password);
                Admin currAdmin = new Admin(currUser.Name, currUser.Phone, currUser.Email, currUser.Password);
                adminMenu(currAdmin);
            }
            else{
                User currUser = validUser(email, password);
                Customer currCustomer = new Customer(currUser.Name, currUser.Phone, currUser.Email, currUser.Password);
                customerMenu(currCustomer);
            };
        }

        public User validUser(string email, string password)
        {
            for(int i = 0; i < users.Count; i++)
            {
                if(users[i].Email.Equals(email))
                {
                    if (users[i].Password.Equals(password)) return users[i];
                }
            }
            return null;
        }

        public void register()
        {
            string name; string phone; string email; string password;
            Console.Write("Your name: ");
            name = Console.ReadLine();
            do
            {
                Console.Write("Your email: ");
                email = Console.ReadLine();
            } while (!validator.ValidEmail(email));

            do
            {
                Console.Write("Your phone number: ");
                phone = Console.ReadLine();
            } while (!validator.ValidPhone(phone));

            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine();
            } while (!validator.ValidPassword(password));

            User newUser = new User(name, phone, email, password);
            users.Add(newUser);
            Console.WriteLine("Succesfully Registered!");
            Console.WriteLine("You can now login!");
        }


        // ID Generators
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


        // Validating Index
        public Boolean validDogIndex(int choice)
        {
            choice--;
            if (!validator.ValidRange(0, dogs.Count - 1, choice)) return false;
            return true;
        }
        public Boolean validUserIndex(int choice)
        {
            choice--;
            if (!validator.ValidRange(0, users.Count - 1, choice)) return false;
            return true;
        }
        public Boolean validItemIndex(int choice)
        {
            choice--;
            if (!validator.ValidRange(0, items.Count - 1, choice)) return false;
            return true;
        }

        public void init()
        {
            
            string usersFileName = "users.json";
            string itemsFileName = "items.json";
            string dogsFileName = "dogs.json";


            string usersJSONString = File.ReadAllText(usersFileName);
            string itemsJSONString = File.ReadAllText(itemsFileName);
            string dogsJSONString = File.ReadAllText(dogsFileName);

            users = JsonSerializer.Deserialize<List<User>>(usersJSONString);
            items = JsonSerializer.Deserialize<List<Item>>(itemsJSONString);
            dogs = JsonSerializer.Deserialize <List<Dog>>(dogsJSONString);

            /*

            // Dummy Users
            users.Add(new User("Kevin", "0812345676", "kevin@gmail.com", "password"));
            users.Add(new User("Ryanto", "0855555644", "ryanto@gmail.com", "password"));
            users.Add(new User("Wendy", "08333456222", "wendy@gmail.com", "password"));
            users.Add(new User("admin", "081234567890", "admin@admin", "admin123"));

            // Dummy Dogs
            dogs.Add(new Dog("D001", "Fury", new Date(1, 1, 2010), 1000000, new Description("black", "...", 4.5, "Poodle" )));
            dogs.Add(new Dog("D002", "Stanny", new Date(2, 15, 2019), 1500000, new Description("brown", "...", 2.5, "Labrador")));
            dogs.Add(new Dog("D003", "Billy", new Date(4, 18, 2020), 2500000, new Description("white", "...", 3.0, "Golden Retriever")));
            //Dummy Items
            items.Add(new Item("I001", "Dog Plushie", 50000, 50));
            items.Add(new Item("I002", "Dog Leash", 75000, 120));
            items.Add(new Item("I003", "Dog Dragon Costume", 125000, 10));

            */




        }
    }
}
