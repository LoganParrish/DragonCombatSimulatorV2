using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrannyFighter2K14V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 55;
            Console.WindowWidth = 160;
            GrannyFighter();
            Intro();
            Game game = new Game();
            game.PlayGame();
            if (!game.Enemy.IsAlive)
            {
                AddHighScore(game.Player.SlapCount);
                DisplayHighScore();
            }
            Console.ReadKey();

        }
        static void GrannyFighter()
        {
            Console.WriteLine(@" _____ ______  ___   _   _  _   ___   __ ______ _____ _____  _   _ _____ ___________   _____  _   __ __    ___ 
|  __ \| ___ \/ _ \ | \ | || \ | \ \ / / |  ___|_   _|  __ \| | | |_   _|  ___| ___ \ / __  \| | / //  |  /   |
| |  \/| |_/ / /_\ \|  \| ||  \| |\ V /  | |_    | | | |  \/| |_| | | | | |__ | |_/ / `' / /'| |/ / `| | / /| |
| | __ |    /|  _  || . ` || . ` | \ /   |  _|   | | | | __ |  _  | | | |  __||    /    / /  |    \  | |/ /_| |
| |_\ \| |\ \| | | || |\  || |\  | | |   | |    _| |_| |_\ \| | | | | | | |___| |\ \  ./ /___| |\  \_| |\___  |
 \____/\_| \_\_| |_/\_| \_/\_| \_/ \_/   \_|    \___/ \____/\_| |_/ \_/ \____/\_| \_| \_____/\_| \_/\___/   |_/
                                                                                                               
                                                                                                               " + "\n\n");
        }
        static void Intro()
        {
            Console.WriteLine(@"Your name is Dangerous Dan. A man with a multiple personality complex and a habit of unintentionally causing self harm.
You've just managed to escape after robbing your local drug store. 75 year old Mavis Jenkins didn't stand a chance against you. 
Ha. Old people go down so easily. You're running down the street and glance over your shoulder to see none other than Mavis Jekins making a beeline toward you. 
Her walker lies upon the ground, as her amazingly toned legs sprint after you. You have a backpack full of Vicodin, a grocery basket full of shower loofahs, 
and one mean ass spanking hand. You decide that you can take her.

You stand firmly in the street. Mavis coming toward you, her perm bouncing in the wind, the smell of mothballs becoming stronger over time. 

You shut your eyes and think about how this is going to unfold.

Alright, Dan. You have...
1) A mean spanking hand that can spank Mavis for 20 - 32 damage, but you're only 70% accurate. If you're lucky, you may also land a critical hit.
2) 3 shower loofahs you can throw at her, and always hit, that do 0 - 40 damage.
3) A backpack full of Vicodin that you can use to heal yourself for 10 - 40 HP. But be careful not to overdose. I think there was something funny in one of the bottles...

Use 1, 2, and 3, respectively to attack.

Press any key to continue...
");
            Console.ReadKey();
            Console.Clear();
        }
        static void AddHighScore(int playerScore)
        {
            Console.WriteLine("\n\nAdd your name to the highscores: ");
            string playerName = Console.ReadLine();

            LoganEntities db = new LoganEntities();

            HighScore newHighScore = new HighScore();
            newHighScore.Date = DateTime.Now;
            newHighScore.Name = playerName;
            newHighScore.Game = "GrannyFighter2K14.V.2";
            newHighScore.Score = playerScore;

            db.HighScores.Add(newHighScore);

            db.SaveChanges();
        }
        static void DisplayHighScore()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================== HIGH SCORES ====================");
            Console.WriteLine("=====================================================\n\n");
            Console.ResetColor();

            LoganEntities db = new LoganEntities();
            List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "GrannyFighter2K14.V.2").OrderByDescending(x => x.Score).Take(10).ToList();

            foreach (HighScore highScore in highScoreList)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0}. {1} - Only {2} spanks to put that lady in her place - {3}", highScoreList.IndexOf(highScore) + 1, highScore.Name, highScore.Score, highScore.Date.Value.ToShortDateString());
                Console.ResetColor();
            }
        }
    }
}
