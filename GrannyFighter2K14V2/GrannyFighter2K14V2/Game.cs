using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrannyFighter2K14V2
{
    class Game
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }

        public Game()
        {
            this.Player = Player;
            this.Enemy = Enemy;
        }

        public void DisplayCombatInfo()
        {
            //Player HUD showing current accuracy, poison damage per turn, and HP.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n\n\n\n____________________________________________________________________________________________");
            Console.ResetColor();
            Console.Write("Health Meter : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Player.HP);
            Console.ResetColor();
            Console.Write(" / 100" + "                                          " + "Boss Health : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Enemy.HP);
            Console.ResetColor();
            Console.WriteLine( " / 150");
            Console.Write("                             Current mainhand accuracy : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Player.Accuracy + "%");
            Console.ResetColor();
            Console.Write("                                  Loofahs remaining : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Player.Loofahs);
            Console.ResetColor();

            //handy conditional counter if you're poisoned
            if (Enemy.PoisonCount > 0)
            {
                Console.WriteLine("              \n               ================ Poison Damage Per Turn: " + Enemy.PoisonCount + "================");
            }
            
        }
        public void PlayGame()
        {
            this.Enemy = new Enemy("Mavis", 150);
            this.Player = new Player("Dan", 100);

            while (this.Player.IsAlive && this.Enemy.IsAlive)
            {

                DisplayCombatInfo();
                this.Player.DoAttack(Enemy);
                this.Enemy.DoAttack(Player);


                if (!this.Player.IsAlive && !this.Enemy.IsAlive)
                {
                    Console.WriteLine("Even though you both managed to kill eachother, there has been no major loss to society and neither of you will be remembered.");
                }
                if (!this.Player.IsAlive && this.Player.Healing == 5)
                {
                    
                    Console.Clear();
                    Console.WriteLine("You overdosed!");
                    GameOver();
        
                }
                else if (!this.Player.IsAlive)
                {
                    Console.Clear();
                    Console.WriteLine("An old lady just beat your sorry behind.");
                    GameOver();
                    Console.ReadKey();
                }
                if (!this.Enemy.IsAlive)
                {
                    Console.Clear();
                    Console.WriteLine("Awesome job. You beat up a senior citizen.");
                    Console.WriteLine("\n\n");
                    Console.WriteLine(@" _____ _                 _           __                   _             _             _ 
|_   _| |               | |         / _|                 | |           (_)           | |
  | | | |__   __ _ _ __ | | _____  | |_ ___  _ __   _ __ | | __ _ _   _ _ _ __   __ _| |
  | | | '_ \ / _` | '_ \| |/ / __| |  _/ _ \| '__| | '_ \| |/ _` | | | | | '_ \ / _` | |
  | | | | | | (_| | | | |   <\__ \ | || (_) | |    | |_) | | (_| | |_| | | | | | (_| |_|
  \_/ |_| |_|\__,_|_| |_|_|\_\___/ |_| \___/|_|    | .__/|_|\__,_|\__, |_|_| |_|\__, (_)
                                                   | |             __/ |         __/ |  
                                                   |_|            |___/         |___/   ");

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
        
                }


            }
        }
        public void GameOver()
        {
            Console.WriteLine(@" _____   ___  ___  ___ _____   _____  _   _ ___________ 
|  __ \ / _ \ |  \/  ||  ___| |  _  || | | |  ___| ___ \
| |  \// /_\ \| .  . || |__   | | | || | | | |__ | |_/ /
| | __ |  _  || |\/| ||  __|  | | | || | | |  __||    / 
| |_\ \| | | || |  | || |___  \ \_/ /\ \_/ / |___| |\ \ 
 \____/\_| |_/\_|  |_/\____/   \___/  \___/\____/\_| \_|
                                                        
                                                        ");
            Console.WriteLine("\n\n");
            Console.WriteLine(@" _____ _                 _           __                   _             _             _ 
|_   _| |               | |         / _|                 | |           (_)           | |
  | | | |__   __ _ _ __ | | _____  | |_ ___  _ __   _ __ | | __ _ _   _ _ _ __   __ _| |
  | | | '_ \ / _` | '_ \| |/ / __| |  _/ _ \| '__| | '_ \| |/ _` | | | | | '_ \ / _` | |
  | | | | | | (_| | | | |   <\__ \ | || (_) | |    | |_) | | (_| | |_| | | | | | (_| |_|
  \_/ |_| |_|\__,_|_| |_|_|\_\___/ |_| \___/|_|    | .__/|_|\__,_|\__, |_|_| |_|\__, (_)
                                                   | |             __/ |         __/ |  
                                                   |_|            |___/         |___/   ");
        }
        
    }
}
