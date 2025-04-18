using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightPizzaFight
{
    internal class Enemy
    {
        // Variables
        private int health = 150;
        private int attackDamage = 15;
        private int maxHealth = 150;

        public int Health
        {

            get
            {
                return health;
            }

            // Property
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
        public Enemy()
        {
            SpawnEnemy();
        }

        // Functions
        private void SpawnEnemy()
        {
            Console.WriteLine("===================================");
            Console.WriteLine(" 🦹 CRUST BANDIT: NEMESIS OF ITALIAN CUISINE 🦹 ");
            Console.WriteLine("===================================");
            Console.WriteLine("\nYou'll never catch me, flour face!\n");
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
            Console.WriteLine("Crust Bandit's attack dealt " + totalDamage + " damage! 🥊");
            Console.WriteLine("--------------------------------------------");
        }

        public void DisplayEnemyStats()
        {
            Console.WriteLine("\n---------------------------------------------------");
            Console.WriteLine("              CRUST BANDIT'S STATS                ");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Health: " + Health + "/" + maxHealth);
            Console.WriteLine("Crust Bandit: " + attackDamage);
            Console.WriteLine("Crust Bandit Boost 🌪️: 5 to 15");
        }
    }
}
