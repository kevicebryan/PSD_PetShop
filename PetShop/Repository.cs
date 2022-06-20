using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetShop
{
    class Repository
        // Class for reading/writing from/to Database in this case the local JSON file.
    {
        public static List<User>  readUsers(String fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            List<User> list = JsonSerializer.Deserialize<List<User>>(jsonString);
            return list;
        }
        public static List<Dog> readDogs(String fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            List<Dog> list = JsonSerializer.Deserialize<List<Dog>>(jsonString);
            return list;
        }
        public static List<Item> readItems(String fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            List<Item> list = JsonSerializer.Deserialize<List<Item>>(jsonString);
            return list;
        }

        public static void writeData(List<User> users, List<Dog> dogs, List<Item>items)
        {
            string usersJSON = JsonSerializer.Serialize(users);
            string dogsJSON = JsonSerializer.Serialize(dogs);
            string itemsJSON = JsonSerializer.Serialize(items);

            File.WriteAllText("users.json", usersJSON);
            File.WriteAllText("dogs.json", dogsJSON);
            File.WriteAllText("items.json", itemsJSON);
        }

        // for logs (PurchaseEvents)
        public static List<PurchaseEvent> readPurchases(String fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            List<PurchaseEvent> list = JsonSerializer.Deserialize<List<PurchaseEvent>>(jsonString);
            return list;
        }

        public static void writePurchaseEvent(List<PurchaseEvent> purchases) { 
            string purchaseEventJSON = JsonSerializer.Serialize(purchases);
            File.WriteAllText("purchaseEvents.json", purchaseEventJSON);
        }

    }
}
