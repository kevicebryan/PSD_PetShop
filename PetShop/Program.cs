using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopSystem shopSystem = new ShopSystem();
            shopSystem.preMenu();

        }
    }
}

