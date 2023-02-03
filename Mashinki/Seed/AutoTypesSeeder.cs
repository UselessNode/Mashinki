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
    public class AutoTypesSeeder : Generator
    {
        public AutoTypes GenerateAutoType(int id)
        {
            AutoTypes type = new AutoTypes();
            type.Id = id;
            type.TypeName = RandomNameString(3);
            return type;
        }

        public List<AutoTypes> GetAutoTypes(int amount)
        {
            AutoTypesSeeder seeder;
            List<AutoTypes> list = new List<AutoTypes>();
            for (int i = 0; i < amount; i++)
            {
                seeder = new AutoTypesSeeder();
                list.Add(seeder.GenerateAutoType(i));
            }
            return list;
        }

        public List<AutoTypes> GetAutoTypes(List<Auto> autos)
        {
            List<AutoTypes> list = new List<AutoTypes>(autos.Count);
            foreach (var item in autos)
            {
                list.Add(item.AutoTypes);
            }
            return list;
        }

    }
}
