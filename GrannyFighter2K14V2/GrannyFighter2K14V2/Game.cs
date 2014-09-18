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
            Console.WriteLine("\n\n\n\n\n____________________________________________________________________________________________");
            Console.WriteLine("Health Meter : " + Player.HP + " / 100" + "                                          " + "Boss Health : " + Enemy.HP + " / 150");
            Console.WriteLine("                             Current mainhand accuracy : " + Player.Accuracy + "%");
            Console.WriteLine("                                  Loofahs remaining : " + Player.Loofahs);

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

                
                if (!this.Player.IsAlive)
                {
                    Console.Clear();
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
                if (!this.Enemy.IsAlive)
                {
                    Console.Clear();
                    Console.WriteLine("You won. K.");
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
        
    }
}
