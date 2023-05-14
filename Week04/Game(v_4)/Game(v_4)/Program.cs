using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using EZInput;
using Game_v_4_.BL;

namespace Game_v_4_
{
    class Program
    {
        static void Main(string[] args)
        {
            string option;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /* Hero */
            char head = Convert.ToChar(1);
            char body = Convert.ToChar(178);
            char ARROW = Convert.ToChar(26);
            char[,] hero = new char[3, 5]
            {
                {' ', head, ' ', ' ', ' '},
                {'<', body, '-', 'D', ARROW},
                {'/', ' ', '\\', ' ', ' '}
            };

            /* Enemy 3 */
            char face2 = Convert.ToChar(2);
            char body2 = Convert.ToChar(219);
            char[,] enemy2 = new char[3, 5]
            {
                {' ', ' ', ' ', face2, ' '},
                {'<', '(', '-', body2, '>'},
                {' ', ' ', '/', ' ', '\\'}
            };

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /* Hero and Enemy Data */

            HeroData hero_Data = new HeroData();
            EnemyData enemy_Data = new EnemyData();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /* MAZES */
            char[,] maze1 = new char[22, 108];

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /* WORKING */

            LoadingPage();
            while (true)
            {
                GameHeader();
                Console.WriteLine(" ");
                Menu();
                option = Console.ReadLine();

                if (option == "1")
                {

                }

                else if (option == "2")
                {
                    RefreshingData(ref hero_Data, ref enemy_Data);
                    LoadMaze(maze1);
                    Stage1(ref hero_Data, ref enemy_Data, ref ARROW, hero, maze1, enemy2);
                }

                else if (option == "3")
                {
                    Story();
                }

                else if (option == "4")
                {
                    Instruction();
                }

                else if (option == "5")
                {
                    break;
                }

                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Enter Valid Number !");
                    Halt();
                }

            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* STAGES */

        static void Stage1(ref HeroData hData, ref EnemyData eData, ref char ARROW, char[,] hero, char[,] maze1, char[,] enemy2)
        {
            /* GameHeader();*/
            Console.Clear();
            PrintStage1(maze1);
            PrintHero(hero, hData, maze1);
            PrintBush();
            /* UpdateMoveNextStage(move_to_Stage2); */
            while (hData.gameExit)
            {
                if (hData.rightSteps == 2)
                {
                    hData.AddRightStep();
                    hData.wallX = 12;
                    hData.wallY = 8;
                    hData.wallSize = 5;
                    WallRemove(hData, maze1);
                }

                if (hData.rightSteps == 20)
                {
                    hData.AddRightStep();
                    hData.wallX = 12;
                    hData.wallY = 8;
                    hData.wallSize = 5;
                    PrintWall(hData, maze1);
                }

                if (IsprintEnemy1(ref hData.rightSteps, eData.enemyCollision) == true)
                {
                    eData.enemyPresence = true;
                    /*UpdateEnemypresence(r1Presence, r2Presence);*/
                    PrintEnemy(enemy2, eData, maze1);
                    EnemyMove(ref eData, enemy2, maze1);

                    if (eData.enemySteps == 5)
                    {
                        CreateEnemyFire(eData);
                        eData.enemySteps = 0;
                    }

                    CollisionwithEnemy(ref hData, ref eData);
                    EnemyFireCollisions(hData, eData);
                    CreateBombs(ref hData.bomb, eData, maze1);
                }

                if (eData.removeCharacter == true)
                {
                    EraseEnemy(enemy2, eData, maze1);
                    eData.enemyPresence = false;
                    /*updateEnemypresence(r1Presence, r2Presence);*/
                    eData.removeCharacter = false;
                }

                if (eData.isEnemyDead == true)
                {
                    hData.wallX = 91;
                    hData.wallY = 8;
                    hData.wallSize = 5;
                    WallRemove(hData, maze1);
                    eData.isEnemyDead = false;
                }
                if (hData.heroX > 92)
                {
                    /*UpdateMoveNextStage(move_to_Stage2);*/
                    YouWin();
                    break;
                }
                Controls(ref hData, ref ARROW, hero, maze1);
                CollisionwithBush(hData, maze1);
                MoveArrow(ref ARROW, hData, maze1);
                EnemyFireMove(ARROW, eData, maze1);
                PrintScore(ref hData.score);
                PrintHeroHealth(ref hData.heart, ref hData.gameExit, ref hData.princeHealth);
                PrintEnemyHealth(ref hData.heart, ref eData.enemyHealth);
                /*UpdateHealthData(princehealth, r1Health, r2Health);*/
                PrintLoadedArrows(ref hData.loadedArrow, ref ARROW);
                hData.Reload();
                Thread.Sleep(100);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* GENERAL FUNCTIONS */

        static void Menu()
        {
            Console.WriteLine("1. Resume Game");
            Console.WriteLine("2. New Game");
            Console.WriteLine("3. Story of Game");
            Console.WriteLine("4. Controls");
            Console.WriteLine("5. Exit");
            Console.WriteLine(" ");
            Console.Write("Select Option : ");
        }

        static void Halt()
        {
            Console.WriteLine(" ");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        static void LoadingPage()
        {
            GameHeader();
            HeaderPic();
            /*char load = Convert.ToChar(219);*/
            /*int asciiCode = 219;
            char character = Encoding.ASCII.GetChars(new byte[] { (byte)asciiCode })[0];*/
            char load = (char)(254);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(108, 15);
            Console.WriteLine("Loading...");
            Console.SetCursorPosition(108, 17);
            for (int x = 0; x < 200; x = x + 10)
            {
                Console.Write(load);
                Thread.Sleep(200);
            }
            Console.SetCursorPosition(108, 19);
            Console.Write("Press any digit key to continue...");
            Console.ReadKey();
        }

        static void GameHeader()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(7, 0);
            Console.WriteLine("   _____                .__                   __________        .__                                  ");
            Console.SetCursorPosition(7, 1);
            Console.WriteLine("  /  _  \\_______   ____ |  |__   ___________  \\______   \\_______|__| ____   ____  ____            ");
            Console.SetCursorPosition(7, 2);
            Console.WriteLine(" /  /_\\  \\_  __ \\_/ ___\\|  |  \\_/ __ \\_  __ \\  |     ___/\\_  __ \\  |/    \\_/ ___\\/ __ \\  ");
            Console.SetCursorPosition(7, 3);
            Console.WriteLine("/    |    \\  | \\/\\  \\___|   Y  \\  ___/|  | \\/  |    |     |  | \\/  |   |  \\  \\__\\  ___/    ");
            Console.SetCursorPosition(7, 4);
            Console.WriteLine("\\____|__  /__|    \\___  >___|  /\\___  >__|     |____|     |__|  |__|___|  /\\___  >___  >         ");
            Console.SetCursorPosition(7, 5);
            Console.WriteLine("        \\/            \\/     \\/     \\/                                  \\/     \\/    \\/       ");
            Console.SetCursorPosition(7, 6);
            Console.WriteLine(" ");
            Console.SetCursorPosition(7, 7);
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        static void HeaderPic()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                     :*%%%#########@@@@@@####@@@:.-.                                     ");
            Console.WriteLine("                         *                     :=#@@@@*-                  :=+*-          ");
            Console.WriteLine("                         *                             :+%@@@#=.      .:%@@@%%.          ");
            Console.WriteLine("                         *                                 .=*@@@#=    .-*+@*.           ");
            Console.WriteLine("                         =.                                    -#@@@+=*-                 ");
            Console.WriteLine("                         -:                                     .+%**@***:               ");
            Console.WriteLine("                          +                                  .+*: *@@@@@@@+              ");
            Console.WriteLine("                          +                               :*=  .+@@@@@@*+@@#             ");
            Console.WriteLine("                          =.                           =*=  :=#@@@@@@%-  +@@#            ");
            Console.WriteLine("                      -+#%%%#@@@@@@%@@@%%#-        .+*:  .#@@@@@@@@@=     *@@#           ");
            Console.WriteLine("                   :*@@@@@@@@@@@@@@@@@*=:        :*+.  +@@@@@@@@@#.        %@@=          ");
            Console.WriteLine("                 -%@@@@@@@@@@@@@@@@#-         :*=  .=#@@@@@@@@@@-          .@@@.         ");
            Console.WriteLine("                +@@@@@@@@@@@@@@@@-.       =*-    *#@@@@@@@@@@*              +@@*         ");
            Console.WriteLine("            -*@%#@@@@@@@@@@@@@@@@@+   -*=   :=*%@@@@@@@@@@@*                 .@@+        ");
            Console.WriteLine("          =%%=-. .#@@@@@@@@@@@@@@@@==*==*@@@@@@@@@@@@@@**                     #@*        ");
            Console.WriteLine("        :%@+      :@@@@@@@@@@@@@%*#@*#@@@@@@@@@@@@@#+@*.                      =@%        ");
            Console.WriteLine("       =@*.       =@@@@@@@@@@@%*#@@@@@@@@@@@@@@@@@#:*.                        :@%        ");
            Console.WriteLine("      +@-        :@@@@@@@@@@@**=@@@@@@@@@@@@@@@@@@:                           .@%        ");
            Console.WriteLine("           :+%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*::::                           %%         ");
            Console.WriteLine("        .=#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*    :::-:                     .@=         ");
            Console.WriteLine("      .#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@.        :---.                *@          ");
            Console.WriteLine("    *@@@@@@@@@@@@@@@%*=+%@@%@@@@@@@@@@@@@@@@@@%#=            :----.         *%           ");
            Console.WriteLine("   .#@@@@@@@@@@@@@#-       :*@@@@@@@@@@@@@@@@@@@%                    :---: .@+           ");
        }

        static void Controls(ref HeroData hData, ref char ARROW, char[,] hero, char[,] maze)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                HeroLeft(ref hData, hero, maze);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                HeroRight(ref hData, hero, maze);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                HeroUp(ref hData, hero, maze);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                HeroDown(ref hData, hero, maze);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                if (hData.isFire == true)
                {
                    CreateArrow(hData, ref ARROW);
                    hData.loadedArrow--;
                }
            }
            if (Keyboard.IsKeyPressed(Key.Escape))
            {
                hData.gameExit = false;
            }
        }

        static void Instruction()
        {
            GameHeader();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine("  Move UP  .............  Up arrow key ");
            Console.WriteLine("  Move Down ............  Down arrow key ");
            Console.WriteLine("  Move Right ...........  Right arrow key ");
            Console.WriteLine("  Move Left ............  Left arrow key ");
            Console.WriteLine("  Firing   .............  SpaceBar ");
            Console.WriteLine("  Exit Game ............  Escape key ");
            Halt();
        }

        static void Story()
        {
            GameHeader();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            TextAnimation("          In a kingdom long ago, there lived a Prince skilled in archery named Alexander. One day, the kingdom was invaded by an army of evil creatures lead by Lady Night and Lord shadow.");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            TextAnimation("          Prince found himself facing a daunting task - he was the only one left to defend the kingdom. So, he gathered information about the enemy and comes to know that the Lady Night has known some magic and the Lord Shadow is always with its twin bodyguards named as Blade and Devi. ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            TextAnimation("          Despite the overwhelming odds, Prince refused to back down. With his bow and arrow, he stood tall and prepared for battle. As the enemy charged towards him, Prince calmly took aim and let fly his arrows, taking down one enemy after another.");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            TextAnimation("          With every arrow he loosed, Prince grew more confident in his abilities. His movements became fluid and graceful, and soon he was dodging incoming attacks with ease. The battle continued for hours, but Prince refused to give up. Finally, the Lord Shadow fell before his arrows. The kingdom was saved, and Prince emerged victorious, hailed as a hero by the people.");
            Console.WriteLine(" ");
            Halt();
        }

        static void TextAnimation(string a)
        {
            bool isPrintStory = true;
            for (int x = 0; a.Length != x; x++)
            {
                if (Keyboard.IsKeyPressed(Key.Shift))
                {
                    isPrintStory = false;
                }
                if (isPrintStory == true)
                {
                    Thread.Sleep(10);
                    Console.Write(a[x]);
                }
                else
                {
                    Console.Write(a[x]);
                }
            }
        }

        static void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(15, 16);
            Console.WriteLine("    ______                                ___                                 ");
            Console.SetCursorPosition(15, 17);
            Console.WriteLine("  .' ___  |                             .'   `.                               ");
            Console.SetCursorPosition(15, 18);
            Console.WriteLine(" / .'   \\_|  ,--.   _ .--..--.  .---.  /  .-.  \\ _   __  .---.  _ .--.      ");
            Console.SetCursorPosition(15, 19);
            Console.WriteLine(" | |   ____ `'_\\ : [ `.-. .-. |/ /__\\\\ | |   | |[ \\ [  ]/ /__\\[ `/'`\\]   ");
            Console.SetCursorPosition(15, 20);
            Console.WriteLine(" \\ `.___]  |// | |, | | | | | || \\__., \\  `-'  / \\ \\/ / | \\__., | |     ");
            Console.SetCursorPosition(15, 21);
            Console.WriteLine("  `._____.' \\'-;__/[___||__||__]'.__.'  `.___.'   \\__/   '.__.'[___]        ");
            Console.SetCursorPosition(15, 23);
            Console.Write("Press any digit key to continue...");
            Console.Read();
        }

        static void YouWin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(15, 16);
            Console.WriteLine(" ____  ____                 ____      ____  _                   ");
            Console.SetCursorPosition(15, 17);
            Console.WriteLine("|_  _||_  _|               |_  _|    |_  _|(_)                  ");
            Console.SetCursorPosition(15, 18);
            Console.WriteLine("  \\ \\  / / .--.   __   _     \\ \\  /\\  / /  __   _ .--.     ");
            Console.SetCursorPosition(15, 19);
            Console.WriteLine("   \\ \\/ // .'`\\ \\[  | | |     \\ \\/  \\/ /  [  | [ `.-. |  ");
            Console.SetCursorPosition(15, 20);
            Console.WriteLine("   _|  |_| \\__. | | \\_/ |,     \\  /\\  /    | |  | | | |     ");
            Console.SetCursorPosition(15, 21);
            Console.WriteLine("  |______|'.__.'  '.__.'_/      \\/  \\/    [___][___||__]      ");
            Console.SetCursorPosition(15, 23);
            Console.Write("Press any digit key to continue...");
            Console.ReadKey();
            Credits();
        }

        static void Credits()
        {
            GameHeader();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(46, 10);
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(55, 12);
            Console.WriteLine("    Credits      ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(55, 14);
            Console.WriteLine("  Game  Designer ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(55, 16);
            Console.WriteLine("   Abdul Rehman  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(55, 19);
            Console.WriteLine("  Story  Writing ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(55, 21);
            Console.WriteLine("   Abdul Rehman  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(55, 24);
            Console.WriteLine("Special Thanks to");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(55, 26);
            Console.WriteLine("   Anas  Mustafa ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(55, 27);
            Console.WriteLine("    Wali Ahmad   ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(55, 28);
            Console.WriteLine("   Abdul  Sabur   ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(46, 30);
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 32);
            Console.WriteLine("Press any key(+ Enter) to continue..");
            Console.Read();
        }

        static void RefreshingData(ref HeroData hData, ref EnemyData eData)
        {
            hData.heroY = 9;
            hData.heroX = 3;
            hData.score = 0;
            hData.rightSteps = 0;
            hData.loadedArrow = 9;
            hData.princeHealth = 100;
            hData.checkBush = true;
            hData.gameExit = true;
            hData.isFire = true;
            hData.bomb = 0;

            eData.enemyX = 80;
            eData.enemyY = 8;
            eData.enemyHealth = 100;
            eData.enemySteps = 0;
            eData.enemyCollision = 0;
            eData.removeCharacter = false;
            eData.isEnemyDead = false;
            eData.enemyPresence = false;
            eData.enemyDirection = "Down";
        }

        static void PrintStage1(char[,] maze1)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            /* Console.SetCursorPosition(0, 15);*/
            for (int x = 0; x < maze1.GetLength(0); x++)
            {
                for (int y = 0; y < maze1.GetLength(1); y++)
                {
                    Console.Write(maze1[x, y]);
                }
                Console.WriteLine(" ");
                Thread.Sleep(10);
            }
        }

        static void PrintArrow(int x, int y, char arrow, char[,] maze)
        {
            maze[y, x] = arrow;
            Console.SetCursorPosition(x, y);
            Console.Write(arrow);
        }

        static void EraseArrow(int x, int y, char[,] maze)
        {
            maze[y, x] = ' ';
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        static void PrintBush()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(50, 4);
            Console.WriteLine("(________)");
            Console.SetCursorPosition(50, 5);
            Console.WriteLine(" (______)");
            Console.SetCursorPosition(50, 6);
            Console.WriteLine("  (____)");
        }

        static void PrintWall(HeroData hData, char[,] maze)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int x = 0; x < hData.wallSize; x++)
            {
                Console.SetCursorPosition(hData.wallX, hData.wallY + x);
                maze[(hData.wallY + x), hData.wallX] = '#';
                Console.WriteLine("#");
                Thread.Sleep(20);
            }
        }

        static void RemoveBush(char fruit, ref bool checkBush, char[,] maze)
        {
            Console.SetCursorPosition(50, 4);
            Console.WriteLine("          ");
            Console.SetCursorPosition(50, 5);
            Console.WriteLine("         ");
            Console.SetCursorPosition(50, 6);
            Console.WriteLine("        ");
            Console.SetCursorPosition(53, 6);
            maze[6, 53] = fruit;
            Console.WriteLine(fruit);
            checkBush = false;
        }

        static void WallRemove(HeroData hData, char[,] maze)
        {
            for (int x = 0; x < hData.wallSize; x++)
            {
                Console.SetCursorPosition(hData.wallX, hData.wallY + x);
                maze[(hData.wallY + x), hData.wallX] = ' ';
                Console.WriteLine(" ");
                Thread.Sleep(20);
            }
        }

        static void PrintLoadedArrows(ref int loadedArrow, ref char Arrow)
        {
            Console.SetCursorPosition(84, 25);
            Console.Write("Arrows : " + Arrow + " X " + loadedArrow);
        }

        static void CreateBombs(ref int bomb, EnemyData eData, char[,] maze)
        {
            if ((eData.enemyHealth <= 60 && bomb < 4) && eData.enemyPresence == true)
            {
                Random rnd = new Random();
                int min = 0;
                int max = 100;
                int x, y;
                x = 14 + rnd.Next(min, max) % 60;
                y = 4 + rnd.Next(min, max) % 14;
                maze[y, x] = '0';
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("0");
                bomb++;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* SCORING SYSTEM */

        static void PrintScore(ref int score)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(35, 25);
            Console.WriteLine("Score : " + score);
            /* UpdateScoreData(score); */
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* HEALTH MECHANISM */


        static void PrintHeroHealth(ref char heart, ref bool gameExit, ref int princehealth)
        {
            Console.SetCursorPosition(5, 25);
            if (princehealth <= 0)
            {
                gameExit = false;
                princehealth = 0;
                Console.WriteLine("Prince : " + princehealth + " " + heart + " ");
                GameOver();
            }
            else
            {
                Console.WriteLine("Prince : " + princehealth + " " + heart + " ");
            }
        }

        static void PrintEnemyHealth(ref char heart, ref int enemyHealth)
        {
            if (enemyHealth < 0)
            {
                enemyHealth = 0;
            }
            Console.SetCursorPosition(60, 25);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enemy : " + enemyHealth + " " + heart + " ");
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* PRINTING HERO AND ENEMIES */

        static void PrintHero(char[,] hero, HeroData hData, char[,] maze)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int x = 0; x < hero.GetLength(0); x++)
            {
                Console.SetCursorPosition(hData.heroX, hData.heroY + x);
                for (int y = 0; y < hero.GetLength(1); y++)
                {
                    maze[(hData.heroY + x), (hData.heroX + y)] = hero[x, y];
                    Console.Write(hero[x, y]);
                }
            }
        }

        static void PrintEnemy(char[,] enemy, EnemyData eData, char[,] maze)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int x = 0; x < enemy.GetLength(0); x++)
            {
                Console.SetCursorPosition(eData.enemyX, eData.enemyY + x);
                for (int y = 0; y < enemy.GetLength(1); y++)
                {
                    maze[(eData.enemyY + x), (eData.enemyX + y)] = enemy[x, y];
                    Console.Write(enemy[x, y]);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* ERASING HERO AND ENEMIES */

        static void EraseHero(char[,] hero, HeroData hData, char[,] maze)
        {
            for (int x = 0; x < hero.GetLength(0); x++)
            {
                Console.SetCursorPosition(hData.heroX, hData.heroY + x);
                for (int y = 0; y < hero.GetLength(1); y++)
                {
                    maze[(hData.heroY + x), (hData.heroX + y)] = ' ';
                    Console.Write(" ");
                }
            }
        }

        static void EraseEnemy(char[,] enemy, EnemyData eData, char[,] maze)
        {
            for (int i = 0; i < enemy.GetLength(0); i++)
            {
                Console.SetCursorPosition(eData.enemyX, eData.enemyY + i);
                for (int j = 0; j < enemy.GetLength(1); j++)
                {
                    maze[(eData.enemyY + i), (eData.enemyX + j)] = ' ';
                    Console.Write("  ");
                }
            }
        }

        static bool IsprintEnemy1(ref int rightmove, int enemyCollision)
        {
            if (rightmove == 25 && enemyCollision < 10)
            {
                return true;
            }
            return false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* HERO FIRE COLLISION */

        static void CollisionwithBush(HeroData hData, char[,] maze)
        {
            foreach (var x in hData.arrows)
            {
                if (hData.checkBush == true)
                {
                    if (x.fireX == 50 && (x.fireY == 4 || x.fireY == 5 || x.fireY == 6))
                    {
                        RemoveBush(hData.fruit, ref hData.checkBush, maze);
                    }
                }
            }
        }

        static void CollisionwithEnemy(ref HeroData hData, ref EnemyData eData)
        {
            foreach (var x in hData.arrows)
            {
                if (eData.enemyPresence == true)
                {
                    if ((x.fireX + 1 == eData.enemyX || x.fireX + 2 == eData.enemyX) && (x.fireY == eData.enemyY || x.fireY == eData.enemyY + 2))
                    {
                        eData.AddEnemyCollisions();
                        hData.AddScore(5);
                        eData.EnemyHealth();
                    }
                    if (eData.enemyX - 1 == x.fireX && eData.enemyY + 1 == x.fireY)
                    {
                        eData.AddEnemyCollisions();
                        hData.AddScore(5);
                        eData.EnemyHealth();
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* HERO MOVEMENT */

        static void HeroUp(ref HeroData hData, char[,] hero, char[,] maze)
        {
            char next1 = maze[hData.heroY - 1, hData.heroX];
            char next2 = maze[hData.heroY - 1, (hData.heroX + 1)];
            char next3 = maze[hData.heroY - 1, (hData.heroX + 2)];
            char next4 = maze[hData.heroY - 1, (hData.heroX + 3)];
            char next5 = maze[hData.heroY - 1, (hData.heroX + 4)];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' && next5 == ' ')
            {
                EraseHero(hero, hData, maze);
                hData.heroY--;
                PrintHero(hero, hData, maze);
            }
            else if (next1 == hData.fruit || next2 == hData.fruit || next3 == hData.fruit || next4 == hData.fruit || next5 == hData.fruit)
            {
                EraseHero(hero, hData, maze);
                hData.heroY--;
                PrintHero(hero, hData, maze);
                hData.AddScore(3);
                hData.RecoverHealth();
            }
            else if (next1 == '<' || next2 == '<' || next3 == '<' || next4 == '<' || next5 == '<')
            {
                EraseHero(hero, hData, maze);
                hData.heroY--;
                PrintHero(hero, hData, maze);
            }
            else if (next1 == '0' || next2 == '0' || next3 == '0' || next4 == '0' || next5 == '0')
            {
                EraseHero(hero, hData, maze);
                hData.heroY--;
                PrintHero(hero, hData, maze);
                hData.HeroHealth(20);
                hData.bomb--;
            }
            /*UpdateHeroCoordinate(heroX, heroY);*/
        }

        static void HeroDown(ref HeroData hData, char[,] hero, char[,] maze)
        {
            char next1 = maze[hData.heroY + 3, hData.heroX];
            char next2 = maze[hData.heroY + 3, hData.heroX + 1];
            char next3 = maze[hData.heroY + 3, hData.heroX + 2];
            char next4 = maze[hData.heroY + 3, hData.heroX + 3];
            char next5 = maze[hData.heroY + 3, hData.heroX + 4];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' && next5 == ' ')
            {
                EraseHero(hero, hData, maze);
                hData.heroY++;
                PrintHero(hero, hData, maze);
            }
            else if (next1 == hData.fruit || next2 == hData.fruit || next3 == hData.fruit || next4 == hData.fruit || next5 == hData.fruit)
            {
                EraseHero(hero, hData, maze);
                hData.heroY++;
                PrintHero(hero, hData, maze);
                hData.AddScore(3);
                hData.RecoverHealth();
            }
            else if (next1 == '<' || next2 == '<' || next3 == '<' || next4 == '<' || next5 == '<')
            {
                EraseHero(hero, hData, maze);
                hData.heroY++;
                PrintHero(hero, hData, maze);
            }
            else if (next1 == '0' || next2 == '0' || next3 == '0' || next4 == '0' || next5 == '0')
            {
                EraseHero(hero, hData, maze);
                hData.heroY++;
                PrintHero(hero, hData, maze);
                hData.HeroHealth(20);
                hData.bomb--;
            }
            /*UpdateHeroCoordinate(heroX, heroY);*/
        }

        static void HeroRight(ref HeroData hData, char[,] hero, char[,] maze)
        {
            char next1 = maze[hData.heroY, (hData.heroX + 5)];
            char next2 = maze[hData.heroY, (hData.heroX + 5)];
            char next3 = maze[hData.heroY, (hData.heroX + 5)];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                EraseHero(hero, hData, maze);
                hData.heroX++;
                PrintHero(hero, hData, maze);
            }
            else if (next1 == hData.fruit || next2 == hData.fruit || next3 == hData.fruit)
            {
                EraseHero(hero, hData, maze);
                hData.heroX++;
                PrintHero(hero, hData, maze);
                hData.AddScore(3);
                hData.RecoverHealth();
            }
            else if (next1 == '<' || next2 == '<' || next3 == '<')
            {
                EraseHero(hero, hData, maze);
                hData.heroX++;
                PrintHero(hero, hData, maze);
            }
            else if (next1 == '0' || next2 == '0' || next3 == '0')
            {
                EraseHero(hero, hData, maze);
                hData.heroX++;
                PrintHero(hero, hData, maze);
                hData.HeroHealth(20);
                hData.bomb--;
            }
            hData.AddRightStep();
            /*updateSteps(rightmove);*/
            /*UpdateHeroCoordinate(heroX, heroY);*/
        }

        static void HeroLeft(ref HeroData hData, char[,] hero, char[,] maze)
        {
            char next1 = maze[hData.heroY, hData.heroX - 1];
            char next2 = maze[hData.heroY + 1, hData.heroX - 1];
            char next3 = maze[hData.heroY + 2, hData.heroX - 1];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                EraseHero(hero, hData, maze);
                hData.heroX--;
                PrintHero(hero, hData, maze);
            }
            else if (next1 == hData.fruit || next2 == hData.fruit || next3 == hData.fruit)
            {
                EraseHero(hero, hData, maze);
                hData.heroX--;
                PrintHero(hero, hData, maze);
                hData.AddScore(3);
                hData.RecoverHealth();
            }
            else if (next1 == '<' || next2 == '<' || next3 == '<')
            {
                EraseHero(hero, hData, maze);
                hData.heroX--;
                PrintHero(hero, hData, maze);
            }
            else if (next1 == '0' || next2 == '0' || next3 == '0')
            {
                EraseHero(hero, hData, maze);
                hData.heroX--;
                PrintHero(hero, hData, maze);
                hData.HeroHealth(20);
                hData.bomb--;
            }
            /*UpdateHeroCoordinate(heroX, heroY);*/
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* HERO FIRING MECHANISM */

        static void CreateArrow(HeroData hData, ref char ARROW)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            int xPos = hData.heroX + 4;
            int yPos = hData.heroY + 1;

            hData.AddinFireList(xPos, yPos);

            Console.SetCursorPosition(hData.heroX + 4, hData.heroY + 1);
            Console.Write(ARROW);
        }

        static void MoveArrow(ref char ARROW, HeroData hData, char[,] maze)
        {
            for (int x = 0; x < hData.arrows.Count; x++)
            {
                char next = maze[hData.arrows[x].fireY, hData.arrows[x].fireX + 1];
                if (next != ' ')
                {
                    EraseArrow(hData.arrows[x].fireX, hData.arrows[x].fireY, maze);
                    hData.RemovefromFireList(x);
                }
                else
                {
                    EraseArrow(hData.arrows[x].fireX, hData.arrows[x].fireY, maze);
                    hData.arrows[x].fireX += 1;
                    PrintArrow(hData.arrows[x].fireX, hData.arrows[x].fireY, ARROW, maze);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* ENEMIES MOVEMENT */

        static void EnemyMove(ref EnemyData eData, char[,] enemy, char[,] maze)
        {
            if (eData.enemyDirection == "Up")
            {
                char next = maze[eData.enemyY - 1, eData.enemyX];
                if (next == ' ')
                {
                    eData.AddEnemySteps();
                    EraseEnemy(enemy, eData, maze);
                    eData.enemyY--;
                    PrintEnemy(enemy, eData, maze);

                }
                else if (next == '#' || next == '_')
                {
                    eData.enemyDirection = "Down";
                }
            }
            else if (eData.enemyDirection == "Down")
            {
                char next = maze[eData.enemyY + 3, eData.enemyX];
                if (next == ' ')
                {
                    eData.AddEnemySteps();
                    EraseEnemy(enemy, eData, maze);
                    eData.enemyY++;
                    PrintEnemy(enemy, eData, maze);
                }
                else if (next == '#' || next == '_')
                {
                    eData.enemyDirection = "Up";
                }
            }
            /*UpdateR1Coordinate(enemyX, enemyY);*/
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* ENEMIES FIRING MECHANISM */

        static void CreateEnemyFire(EnemyData eData)
        {
            int xPos = eData.enemyX - 1;
            int yPos = eData.enemyY + 1;

            eData.AddinFireList(xPos, yPos);

            Console.SetCursorPosition(eData.enemyX - 2, eData.enemyY + 1);
            Console.Write("<");
        }

        static void EnemyFireMove(char ARROW, EnemyData eData, char[,] maze)
        {
            for (int x = 0; x < eData.bullets.Count; x++)
            {
                char next = maze[eData.bullets[x].fireY, eData.bullets[x].fireX - 2];
                if (next == ARROW)
                {
                    EraseArrow(eData.bullets[x].fireX, eData.bullets[x].fireY, maze);
                    eData.bullets[x].fireX -= 1;
                    PrintArrow(eData.bullets[x].fireX, eData.bullets[x].fireY, '<', maze);
                }
                else if (next != ' ' || next == '#')
                {
                    EraseArrow(eData.bullets[x].fireX, eData.bullets[x].fireY, maze);
                    eData.RemovefromFireList(x);
                }
                else
                {
                    EraseArrow(eData.bullets[x].fireX, eData.bullets[x].fireY, maze);
                    eData.bullets[x].fireX -= 1;
                    PrintArrow(eData.bullets[x].fireX, eData.bullets[x].fireY, '<', maze);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* ENEMIES FIRE COLLISIONS */

        static void EnemyFireCollisions(HeroData hData, EnemyData eData)
        {
            foreach (var x in eData.bullets)
            {
                if (eData.enemyPresence == true)
                {
                    if ((x.fireX == hData.heroX + 5 || x.fireX == hData.heroX + 4 || x.fireX == hData.heroX + 3) && (x.fireY == hData.heroY || x.fireY == hData.heroY + 1 || x.fireY == hData.heroY + 2))
                    {
                        hData.HeroHealth(10);
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* Loading maze  */
        static void LoadMaze(char[,] maze)
        {
            if (File.Exists("maze.txt"))
            {
                int row = 0;
                StreamReader file = new StreamReader("maze.txt");
                string record;
                while (!file.EndOfStream)
                {
                    record = file.ReadLine();

                    for (int x = 0; x < record.Length; x++)
                    {
                        maze[row, x] = record[x];
                    }
                    row++;
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Unable to load file");
            }
        }
    
    
    }
}
