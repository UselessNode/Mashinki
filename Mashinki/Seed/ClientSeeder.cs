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
    internal class ClientSeeder : Generator
    {
        public Client GenerateClient(int id)
        {
            Client client = new Client();
            client.Id = id;
            client.FirstName = RandomNameString(id,2);
            client.MiddleName = RandomNameString(id,3);
            client.LastName = RandomNameString(id, 4);
            client.Gender = RandomGender();
            client.DateOfBirth = RandomDate();
            client.DateOfRegistration = RandomDate(client.DateOfBirth.Value.Year + 18, 2023);
            return client;
        }

        public List<Client> GetClients(int amount)
        {
            ClientSeeder seeder;
            List<Client> list = new List<Client>();
            for (int i = 0; i < amount; i++)
            {
                seeder = new ClientSeeder();
                list.Add(seeder.GenerateClient(i));
            }
            return list;
        }

    }
}
