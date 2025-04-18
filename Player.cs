using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightPizzaFight
{
    internal class Player
    {
        // variables
        private int health = 100;
        private int maxHealth = 100;
        private int attackDamage = 20;
        private int healingCapacity = 15;

        // Property
        public int Health
        {

            get
            {
                return health;
            }

            private set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > maxHealth)
                {
                    health = maxHealth;
                }
                else
                {
                    health = value;
                }
            }

        }

        // Default Constructor
        public Player()
        {
            SpawnPlayer();
        }

        // Functions
        private void SpawnPlayer()
        {
            Console.WriteLine("===================================");
            Console.WriteLine(" 🍕 DOUGH MASTER: GUARDIAN OF THE GOLDEN CRUST 🍕 ");
            Console.WriteLine("===================================");
            Console.WriteLine("\nDough Master: That scoundrel won't escape with my creation!\n");

        }

        private int generateRandomNumberInRange(int min, int max)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(min, max + 1);
            return randomNumber;
        }

        public int CalculateTotalDamage()
        {
            int additionalDamage = generateRandomNumberInRange(5, 15);
            int totalDamage = attackDamage + additionalDamage;

            return totalDamage;
        }

        public void TakeDamage(int damageRecieved) => Health -= damageRecieved;

        public void ShowAttackDamage(int totalDamage)
        {
            Console.WriteLine("             🍕 PIZZA BATTLE 🍕                   ");
            Console.WriteLine("============================================");
            Console.WriteLine("Dough Master's attack dealt " + totalDamage + " damage! 🥊");
            Console.WriteLine("--------------------------------------------");
        }

        public int CalculateTotalHeal()
        {
            int additionalHeal = generateRandomNumberInRange(10, 20);
            int totalHeal = healingCapacity + additionalHeal;

            return totalHeal;
        }

        public void Heal(int healAmount) => Health += healAmount;

        public void ShowHeal(int healAmount)
        {
            if (Health >= maxHealth)
            {
                Console.WriteLine("             🍕 PIZZA BATTLE 🍕                   ");
                Console.WriteLine("============================================");
                Console.WriteLine("     Dough Master is bursting with energy! 🚀    ");
                Console.WriteLine("--------------------------------------------");
            }
            else
            {
                Console.WriteLine("             🍕 PIZZA BATTLE 🍕                   ");
                Console.WriteLine("============================================");
                Console.WriteLine("Dough Master's heal restored " + healAmount + " hp! ☕");
                Console.WriteLine("--------------------------------------------");
            }
        }

        public void DisplayPlayerStats()
        {
            Console.WriteLine("\n---------------------------------------------------");
            Console.WriteLine("              DOUGH MASTER'S STATS                ");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Health: " + Health + "/" + maxHealth);
            Console.WriteLine("Dough Slapper: " + attackDamage);
            Console.WriteLine("Espresso Shot ☕: " + healingCapacity);
            Console.WriteLine("Dough Slapper Boost 🌪️: 5 to 15");
            Console.WriteLine("Espresso Shot Boost ☕: 10 to 20");
        }

    }
}
