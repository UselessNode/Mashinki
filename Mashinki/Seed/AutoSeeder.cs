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
    internal class AutoSeeder : Generator
    {
        public Auto GenerateAuto(int id)
        {
            RandomGenerator random= new RandomGenerator();
            Auto auto = new Auto();
            auto.Id = id;
            auto.Name = RandomNameString(10);
            auto.AutoTypes = new AutoTypesSeeder().GenerateAutoType(id);
            auto.Clarence = random.Next(100, 180);
            auto.Cost = random.Next(100_000, 2_020_000);
            auto.EnginePower = random.Next(70, 200);
            auto.EngineVolume = (double)random.Next(1, 10) / 10d;
            return auto;
        }

        public List<Auto> GetAutos(int amount)
        {
            AutoSeeder seeder;
            List<Auto> list = new List<Auto>();
            for (int i = 0; i < amount; i++)
            {
                seeder = new AutoSeeder();
                list.Add(seeder.GenerateAuto(i));
            }
            return list;
        }

    }
}
