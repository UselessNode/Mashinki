using Mashinki.EF;
using Mashinki.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Security.Cryptography;

namespace Mashinki.Seed
{
    public class Generator
    {
        RandomGenerator random = new RandomGenerator();
        public int autoTypesAmount  = 1;
        public int autoAmount       = 1;
        public int clientAmount     = 1;
        public int purchaseAmount   = 1;

        public string[] consonants =
        {
            "b", "c", "d", "f", "g", "h", "j", "k",
            "l", "m", "l", "n", "p", "q", "r", "s",
            "sh", "zh", "t", "v", "w", "x"
        };
        public string[] vowels = 
        { 
            "a", "e", "i", "o", "u", "ae", "y" 
        };

        public string RandomNameString(int Maxlenght = 2)
        {
            string Name = "";
            Name += consonants[random.Next(consonants.Length)].ToUpper();
            Name += vowels[random.Next(vowels.Length)];
            for (int i = 0; i < Maxlenght; i++)
            {
                Name += consonants[random.Next(consonants.Length)];
                Name += vowels[random.Next(vowels.Length)];
            }
            return Name;
        }

        public string RandomNameString(Random random, int Maxlenght = 2)
        {
            string Name = "";
            Name += consonants[random.Next(consonants.Length)].ToUpper();
            Name += vowels[random.Next(vowels.Length)];
            for (int i = 0; i < Maxlenght; i++)
            {
                Name += consonants[random.Next(consonants.Length)];
                Name += vowels[random.Next(vowels.Length)];
            }
            return Name;
        }

        public string RandomNameString(int seed, int Maxlenght = 2)
        {
            //Random random = new Random();
            string Name = "";
            Name += consonants[random.Next(consonants.Length)].ToUpper();
            Name += vowels[random.Next(vowels.Length)];
            for (int i = 0; i < Maxlenght; i++)
            {
                Name += consonants[random.Next(consonants.Length)];
                Name += vowels[random.Next(vowels.Length)];
            }
            return Name;
        }

        public DateTime RandomDate(int minYear = 1900, int maxYear = 2000)
        {
            //Random random = new Random();
            int year = random.Next(minYear, maxYear);
            int month = random.Next(1, 12);
            int day = random.Next(1, DateTime.DaysInMonth(year, month));
            return new DateTime(year, month, day);
        }

        public string RandomGender()
        {
            string gender = "М";
            if (new Random().Next() % 2 == 0)
                gender = "Ж";
            return gender;
        }
    }
}
