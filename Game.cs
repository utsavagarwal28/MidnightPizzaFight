using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightPizzaFight
{
    internal class Game
    {
        //Variables
        bool isGameExited = false;
        Player player;
        Enemy enemy;

        //Functions
        public void GameLoop()
        {
            while (!isGameExited)
            {
                DisplayGameStory();
                StartMenu();
                if (!isGameExited)
                    RestartMenu();
            }
        }

        private void DisplayGameStory()
        {
            Console.Clear();
            Console.WriteLine("\n====================================");
            Console.WriteLine("           🍕 MIDNIGHT PIZZA FIGHT 🍕           ");
            Console.WriteLine("====================================");
            Console.WriteLine("\nIn a bustling pizzeria on a busy friday night...");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("You, the Dought Master, created your magnum opus -");
            Console.WriteLine("the perfect pizza🤌 Suddenly, a sneaky Crust Bandit");
            Console.WriteLine("snatches your masterouece!");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("\nFuled by passion for your craft, you give chase...");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Through winding alleys and crowded streets, you");
            Console.WriteLine("pursue the pizza pilferer. Finally, the thief is");
            Console.WriteLine("cornered in a dead-end alley. It's time to recover");
            Console.WriteLine("your stolen slice");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("                                FIGHT!                           ");

        }

        private void StartMenu()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("     Press S to Get Your Masterpiece BACK...     ");
            Console.WriteLine("     Press any other key to exit the game   ");
            Console.WriteLine("==================================================");

            ProcessStartMenuInput();
        }

        private void ProcessStartMenuInput()
        {
            string startGame = GetInput();

            if (startGame == "S")
            {
                Console.Clear();
                SpawnCharacters();
                ProcessBattleLoop();
            }
            else
            {
                ExitGame();
            }
        }

        private void SpawnCharacters()
        {
            player = new Player();
            enemy = new Enemy();
        }

        private void ProcessBattleLoop()
        {
            do
            {
                ShowBattleOptions();
                ProcessBattleInput();
            } while (AreCharacterAlive());
        }

        private void ShowBattleOptions()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("             🍕 PIZZA BATTLE OPTIONS 🍕             ");
            Console.WriteLine("==================================================");
            Console.WriteLine("  Choose your action:");
            Console.WriteLine("    [A] Attack the Crust Bandit 🥊");
            Console.WriteLine("    [H] Gulp an Espresso Shot ☕");
            Console.WriteLine("==================================================");
            Console.Write("  Your choice: ");
        }

        public void ProcessBattleInput()
        {
            string playerChoice = GetInput();
            Console.Clear();

            switch (playerChoice)
            {
                case "A":
                    PlayerAttack();
                    EnemyAttack();

                    DisplayCharacterStats();
                    break;

                case "H":
                    PlayerHeal();
                    EnemyAttack();

                    DisplayCharacterStats();
                    break;

                default:
                    InvalidInput();
                    break;
            }
        }

        public string GetInput()
        {
            string? input;
            do
            {
                input = Console.ReadLine();
            } while (input == null);
            return input.ToUpper();
        }

        private void PlayerAttack()
        {
            int totalDamage = player.CalculateTotalDamage();
            enemy.TakeDamage(totalDamage);
            player.ShowAttackDamage(totalDamage);
        }

        private void PlayerHeal()
        {
            int totalHeal = player.CalculateTotalHeal();
            player.Heal(totalHeal);
            player.ShowHeal(totalHeal);
        }

        private void EnemyAttack()
        {
            int totalDamage = enemy.CalculateTotalDamage();
            player.TakeDamage(totalDamage);
            enemy.ShowAttackDamage(totalDamage);
        }

        private void DisplayCharacterStats()
        {
            player.DisplayPlayerStats();
            enemy.DisplayEnemyStats();
        }

        private bool CheckGameOver()
        {
            if (enemy.Health <= 0 && player.Health <= 0)
            {
                ShowGameDraw();
                return true;
            }
            if (enemy.Health <= 0)
            {
                ShowGameWin();
                return true;
            }
            if (player.Health <= 0)
            {
                ShowGameLose();
                return true;
            }
            return false;
        }

        private void ShowGameDraw()
        {
            Console.Clear();
            Console.WriteLine("\n==================================================");
            Console.WriteLine("           ⚖️ THE PIZZA DEADLOCK! ⚖️              ");
            Console.WriteLine("==================================================");
            Console.WriteLine("Both warriors reached for the prize...              ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("But fate had other plans! The pizza lies ruined! 🍕💥");
            Console.WriteLine("No victor. No glory. Only crumbs remain...        ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("      A tragedy for taste buds everywhere! 😭      ");
            Console.WriteLine("    Perhaps... next time, a little less greed? 🤔   ");
            Console.WriteLine("==================================================");
        }

        private void ShowGameWin()
        {
            Console.Clear();
            Console.WriteLine("\n==================================================");
            Console.WriteLine("           🎉 PIZZA JUSTICE SERVED! 🎉              ");
            Console.WriteLine("==================================================");
            Console.WriteLine("The Dough Master has defeated the Crust Bandit!");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("The perfect pizza has been reclaimed 🍕           ");
            Console.WriteLine("The honor of Italian cuisine is restored!         ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("    Bon appétit, and thanks for playing! 👨‍🍳        ");
            Console.WriteLine("==================================================");
        }

        private void ShowGameLose()
        {
            Console.Clear();
            Console.WriteLine("\n==================================================");
            Console.WriteLine("              😭 PIZZA TRAGEDY! 😭                ");
            Console.WriteLine("==================================================");
            Console.WriteLine("The Dough Master has been outmaneuvered!           ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("The Crust Bandit escapes with your masterpiece 🏃‍♂️");
            Console.WriteLine("Your pizzeria's reputation is in shambles 📉     ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("        Thanks for your valiant effort! 🎖️         ");
            Console.WriteLine("   Perhaps it's time to switch to calzones... 🥟   ");
            Console.WriteLine("==================================================");
        }

        private void InvalidInput()
        {
            Console.WriteLine("Invalid Input! , please give a valid input");
        }

        private bool AreCharacterAlive() => player.Health > 0 && enemy.Health > 0;

        private void RestartMenu()
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("     Press R to Restart...     ");
            Console.WriteLine("     Press any other key to exit the game   ");
            Console.WriteLine("==================================================");

            ProcessRestartMenuInput();
        }

        private void ProcessRestartMenuInput()
        {
            string restartGame = GetInput();

            if (restartGame == "R")
            {
                isGameExited = false;
            }
            else
            {
                ExitGame();
            }
        }

        private void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing Midnight Pizza Fight!😄");
            isGameExited = true;
        }

    }
}
