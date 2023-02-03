using Mashinki.EF;
using Mashinki.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mashinki.Seeding
{
    internal class PurchaseSeeder : Generator
    {
        public Purchase GeneratePurchase(int id, Auto auto, Client client)
        {
            Random random = new Random();
            Purchase purchase = new Purchase();
            purchase.Id = id;
            purchase.Auto = auto;
            purchase.AutoId = auto.Id;
            purchase.Client = client;
            purchase.ClientId = client.Id;
            purchase.DateOfPurchase = RandomDate(2000, 2023);
            return purchase;
        }

        public List<Purchase> GetPurchases(List<Auto> autos, List<Client> clients, int amount)
        {
            PurchaseSeeder seeder;
            List<Purchase> list = new List<Purchase>();
            for (int i = 0; i < amount; i++)
            {
                seeder = new PurchaseSeeder();
                list.Add(seeder.GeneratePurchase(i, autos[i], clients[i]));
            }
            return list;
        }

    }
}
