using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrannyFighter2K14V2
{
    class Enemy
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int PoisonCount { get; set; }
        int damage = 0;
        public bool IsAlive
        {
            get
            {
                return HP > 0;
            }
        }

        public Enemy(string Name, int HP)
        {
            this.HP = HP;
            this.PoisonCount = 0;
        }
        public int DoAttack(Player Player)
        {
            Random rng = new Random();

            
            //insulin poisoning

            if (this.PoisonCount > 0)
            {
                Player.HP -= PoisonCount;
            }
           
            if (rng.Next(0, 15) == 1)
            {
                Console.WriteLine("Mavis lets her cougar advances overcome her, and touches you with her pruny hands. Your accuracy is lowered by 10%.");
                Player.Accuracy -= 10;
            }
            else if (rng.Next(0, 21) == 20)
            {
                Console.WriteLine(@"Instead of hitting you, Mavis stabs you with her insulin needle. 
You will take 5 damage every turn for each time she stabs you!");
                this.PoisonCount += 5;
            }
            //regular hit
            else if (rng.Next(0, 101) < 80)
            {
                damage = rng.Next(10, 38);
                Console.WriteLine("Mavis hits you for " + damage + " damage. She hits like a girl.");
            }
            //she misses
            else
            {
                Console.WriteLine("Mavis' cataracts sets in, and she misses you.");
            }
            Player.HP -= damage;
            return 0;
        }
        
    }
}
