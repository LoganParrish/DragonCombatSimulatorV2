using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrannyFighter2K14V2
{
    class Player
    {
        public enum AttackType { Slap = 1, Loofah, Heal}

        public string Name { get; set; }
        public int HP { get; set; }
        public int Accuracy { get; set; }
        public int Loofahs { get; set; }
        public int Healing { get; set; }
        public int SlapCount { get; set; }
        int damage = 0;
        public bool IsAlive
        {
            get
            {
                return HP > 0;
            }
        }

        public Player(string Name, int HP)
        {
            this.Loofahs = 3;
            this.Accuracy = 70;
            this.Healing = 0;
            this.SlapCount = 0;
            this.HP = HP;
        }
        public int DoAttack(Enemy Enemy)
        {

            Random rng = new Random();
            string attack = Console.ReadLine();

                

                if (attack != "1" && attack != "2" && attack != "3")
                {
                    Console.Clear();
                    Console.WriteLine("Use an actual attack, you pleb. Is Mavis' senility rubbing off on you? Mavis gets a free shot.");
                    return 0;
                }
                else
                {

                int trueAttack = int.Parse(attack);
                var Type = (AttackType)trueAttack;

                

                switch (Type)
                {

                    case AttackType.Slap:

                        if (rng.Next(0, 21) == 20)
                        {
                            Console.Clear();
                            damage = rng.Next(20, 33) * 2;
                            Console.Write("You landed a ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("*CRIT*");
                            Console.ResetColor();
                            Console.WriteLine(" and dealt " + damage + " damage!!!");
                            SlapCount++;
                            Enemy.HP -= damage;

                        }
                        else if (rng.Next(0, 21) == 10 || rng.Next(0, 21) == 15)
                        {
                            Console.Clear();
                            damage = Convert.ToInt32(rng.Next(20, 33) * 1.2);
                            Console.Write("You landed a ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("*MINI CRIT*");
                            Console.ResetColor();
                            Console.WriteLine(" and dealt " + damage + " damage!!!");
                            SlapCount++;
                            Enemy.HP -= damage;
                        }
                        else
                        {
                            if (rng.Next(0, 101) <= Accuracy)
                            {
                                damage = rng.Next(18, 33);
                                Console.Clear();
                                Console.WriteLine("You hit Mavis square on the butt and deal " + damage + " damage.");
                                SlapCount++;
                                Enemy.HP -= damage;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You prove your father right, and fail. You missed.");
                            }
                        }

                        break;
                    case AttackType.Loofah:

                        if (Loofahs > 0)
                        {
                            damage = rng.Next(1, 41);

                            Console.Clear();

                            Loofahs--;
                            Console.WriteLine("You pelt Mavis with a loofah and deal " + damage + " damage.");
                            Enemy.HP -= damage;
                        }
                        else if (Loofahs == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("You tried throwing a loofah you didn't have and Mavis gets a free shot!");
                        }

                        break;
                    case AttackType.Heal:

                        if (rng.Next(0, 21) == 15)
                        {
                            Console.Clear();
                            Console.WriteLine(@"The pill you take was actually freebase cocaine smuggled in by the Mexican Drug Cartel!
You gain an immediate 100 health boost and gain immunity to an extra pill.");
                            Healing--;
                            this.HP += 100;
                        }
                        else
                        {
                            Console.Clear();
                            Healing++;
                            damage = rng.Next(10, 41);
                            this.HP += damage;
                            Console.WriteLine("You pop some pills and heal yourself for " + damage + " health... careful not to OD.");
                        }
                        if (Healing == 5)
                        {
                            this.HP = 0;
                        }

                        //if user inputs a number that the system does not recognize
                        if (trueAttack != 1 && trueAttack != 2 && trueAttack != 3)
                        {
                            Console.Clear();
                            Console.WriteLine("You try using something you don't even have, dumb ass. Mavis gets a free shot.");
                        }

                        break;
                    default:
                        break;
                }
                return damage;
            }
        }
    }
}
