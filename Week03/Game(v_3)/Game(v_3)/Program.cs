using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EZInput;
using Game_v_3_.BL;

namespace Game_v_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            string option;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /* VARAIABLES */

            char fruit = Convert.ToChar(147);
            char heart = Convert.ToChar(3);

            Variables var = new Variables();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
             
            /* Lists */ 

            List<HeroFires> arrows = new List<HeroFires>();
            List<EnemyFires> bullets = new List<EnemyFires>();

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

            /* COORDINATES */

            Coordinates axis = new Coordinates();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /* MAZES */
            char[,] maze1 = new char[14, 107]
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };

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
                    RefreshingData(ref var, ref axis, maze1);
                    Stage1(ref fruit, ref var, ref heart, ref axis, ref ARROW, bullets, arrows, hero, maze1, enemy2);
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

        static void Stage1(ref char fruit, ref Variables var, ref char heart, ref Coordinates axis, ref char ARROW, List<EnemyFires> bullets, List<HeroFires> arrows, char[,] hero, char[,] maze1, char[,] enemy2)
        {
            /* GameHeader();*/
            Console.Clear();
            PrintStage1(maze1);
            PrintHero(hero, axis, maze1);
            PrintBush();
            /* UpdateMoveNextStage(move_to_Stage2); */
            while (var.gameExit)
            {
                if (var.rightmove == 2)
                {
                    axis.wallX = 12;
                    axis.wallY = 1;
                    axis.wallSize = 5;
                    var.rightmove++;
                    WallRemove(axis, maze1);
                }

                if (var.rightmove == 20)
                {
                    axis.wallX = 12;
                    axis.wallY = 1;
                    axis.wallSize = 5;
                    PrintWall(axis, maze1);
                    var.rightmove++;
                }

                if (IsprintEnemy1(ref var.rightmove, var.enemyCollision) == true)
                {
                    var.enemyPresence = true;
                    /*UpdateEnemypresence(r1Presence, r2Presence);*/
                    PrintEnemy(enemy2, axis, maze1);
                    EnemyMove(ref var.enemySteps, ref var.enemyDirection, ref axis, enemy2, maze1);

                    if (var.enemySteps == 5)
                    {
                        CreateEnemyFire(axis, bullets);
                        var.enemySteps = 0;
                    }

                    CollisionwithEnemy(ref var, ref axis, arrows);
                    EnemyFireCollisions(ref var.princeHealth, ref var.enemyPresence, axis, bullets);
                    CreateBombs(var.enemyHealth, ref var.bomb, var.enemyPresence, maze1);
                }

                if (var.removeCharacter == true)
                {
                    EraseEnemy(enemy2, axis, maze1);
                    var.enemyPresence = false;
                    /*updateEnemypresence(r1Presence, r2Presence);*/
                    var.removeCharacter = false;
                }

                if (var.isEnemyDead == true)
                {
                    axis.wallX = 91;
                    axis.wallY = 1;
                    axis.wallSize = 5;
                    WallRemove(axis, maze1);
                    var.isEnemyDead = false;
                }
                if (axis.heroX > 92)
                {
                    /*UpdateMoveNextStage(move_to_Stage2);*/
                    YouWin();
                    break;
                }
                Controls(ref var, ref fruit, ref axis, ref ARROW, arrows, hero, maze1);
                CollisionwithBush(ref fruit, ref var.checkBush, arrows, maze1);
                MoveArrow(ref ARROW, arrows, maze1);
                EnemyFireMove(ARROW, bullets, maze1);
                PrintScore(ref var.score);
                PrintHeroHealth(ref heart, ref var.gameExit, ref var.princeHealth);
                PrintEnemyHealth(ref heart, ref var.enemyHealth);
                /* UpdateHealthData(princehealth, r1Health, r2Health); */
                PrintLoadedArrows(ref var.loadedArrow, ref ARROW);
                Reload(ref var.loadedArrow, ref var.isFire);
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

        static void Controls(ref Variables var, ref char fruit, ref Coordinates axis, ref char ARROW, List<HeroFires> arrows, char[,] hero, char[,] maze)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                HeroLeft(ref var.score, ref fruit, ref var.princeHealth, ref axis, hero, ref var.bomb, maze);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                HeroRight(ref var.rightmove, ref var.score, ref fruit, ref var.princeHealth, ref axis, hero, ref var.bomb, maze);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                HeroUp(ref var.score, ref fruit, ref var.princeHealth, ref axis, hero, ref var.bomb, maze);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                HeroDown(ref var.score, ref fruit, ref var.princeHealth, ref axis, hero, ref var.bomb, maze);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                if (var.isFire == true)
                {
                    CreateArrow(axis, ref ARROW, arrows);
                    var.loadedArrow--;
                }
            }
            if (Keyboard.IsKeyPressed(Key.Escape))
            {
                var.gameExit = false;
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

        static void RefreshingData(ref Variables var, ref Coordinates axis, char[,] maze)
        {
            var.score = 0;
            var.rightmove = 0;
            var.loadedArrow = 9;
            var.princeHealth = 100;
            var.enemyHealth = 100;
            var.bomb = 0;
            var.enemySteps = 0;
            var.enemyCollision = 0;
            var.checkBush = true;
            var.removeCharacter = false;
            var.isEnemyDead = false;
            var.enemyPresence = false;
            var.gameExit = true;
            var.isFire = true;
            var.enemyDirection = "Down";

            axis.heroX = 3;
            axis.heroY = 2;
            axis.enemyX = 80;
            axis.enemyY = 2;

            maze = new char[14, 107]
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };
        }

        static void PrintStage1(char[,] maze1)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            /* Console.SetCursorPosition(0, 15);*/
            for (int x = 0; x < 14; x++)
            {
                for (int y = 0; y < 107; y++)
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
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("(________)");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine(" (______)");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("  (____)");
        }

        static void PrintWall(Coordinates axis, char[,] maze)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int x = 0; x < axis.wallSize; x++)
            {
                Console.SetCursorPosition(axis.wallX, axis.wallY + x);
                maze[(axis.wallY + x), axis.wallX] = '#';
                Console.WriteLine("#");
                Thread.Sleep(20);
            }
        }

        static void RemoveBush(ref char fruit, ref bool checkBush, char[,] maze)
        {
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("          ");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("         ");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("        ");
            Console.SetCursorPosition(53, 3);
            maze[3, 53] = fruit;
            Console.WriteLine(fruit);
            checkBush = false;
        }

        static void WallRemove(Coordinates axis, char[,] maze)
        {
            for (int x = 0; x < axis.wallSize; x++)
            {
                Console.SetCursorPosition(axis.wallX, axis.wallY + x);
                maze[(axis.wallY + x), axis.wallX] = ' ';
                Console.WriteLine(" ");
                Thread.Sleep(20);
            }
        }

        static void PrintLoadedArrows(ref int loadedArrow, ref char Arrow)
        {
            Console.SetCursorPosition(84, 15);
            Console.Write("Arrows : " + Arrow + " X " + loadedArrow);
        }

        static void Reload(ref int loadedArrow, ref bool isFire)
        {
            if (loadedArrow <= 0)
            {
                isFire = false;
            }
            if (isFire == false)
            {
                loadedArrow++;
            }
            if (loadedArrow == 9)
            {
                isFire = true;
            }
        }

        static void CreateBombs(int enemyHealth, ref int bomb, bool enemyPresence, char[,] maze)
        {
            if ((enemyHealth < 60 && bomb < 4) && enemyPresence == true)
            {
                Random rnd = new Random();
                int min = 0;
                int max = 100;
                int x, y;
                x = 14 + rnd.Next(min, max) % 60;
                y = 1 + rnd.Next(min, max) % 10;
                maze[y, x] = '0';
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("0");
                bomb++;
            }
        }

        static void BombDamage(ref int princehealth)
        {
            princehealth = princehealth - 20;
            if (princehealth < 0)
            {
                princehealth = 0;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* SCORING SYSTEM */

        static void PrintScore(ref int score)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(35, 15);
            Console.WriteLine("Score : " + score);
            /* UpdateScoreData(score); */
        }

        static void AddScore(ref int score)
        {
            score = score + 5;
        }

        static void FruitScore(ref int score)
        {
            score = score + 3;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* HEALTH MECHANISM */

        static void HeroHealth(ref int princehealth)
        {
            princehealth = princehealth - 10;
        }

        static void FruitrecoverHealth(ref int princehealth)
        {
            princehealth = princehealth + 40;
            if (princehealth > 100)
            {
                princehealth = 100;
            }
        }

        static void EnemyHealth(ref bool removeCharacter, ref int enemyHealth, ref bool isEnemyDead)
        {
            enemyHealth = enemyHealth - 10;
            if (enemyHealth == 0)
            {
                isEnemyDead = true;
                removeCharacter = true;
            }
        }

        static void PrintHeroHealth(ref char heart, ref bool gameExit, ref int princehealth)
        {
            if (princehealth <= 0)
            {
                gameExit = false;
                princehealth = 0;
                Console.SetCursorPosition(5, 15);
                Console.WriteLine("Prince : " + princehealth + " " + heart + " ");
                GameOver();
            }
            else
            {
                Console.SetCursorPosition(5, 15);
                Console.WriteLine("Prince : " + princehealth + " " + heart + " ");
            }
        }

        static void PrintEnemyHealth(ref char heart, ref int enemyHealth)
        {
            if (enemyHealth < 0)
            {
                enemyHealth = 0;
            }
            Console.SetCursorPosition(60, 15);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enemy : " + enemyHealth + " " + heart + " ");
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* PRINTING HERO AND ENEMIES */

        static void PrintHero(char[,] hero, Coordinates axis, char[,] maze)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int x = 0; x < hero.GetLength(0); x++)
            {
                Console.SetCursorPosition(axis.heroX, axis.heroY + x);
                for (int y = 0; y < hero.GetLength(1); y++)
                {
                    maze[(axis.heroY + x), (axis.heroX + y)] = hero[x, y];
                    Console.Write(hero[x, y]);
                }
            }
        }

        static void PrintEnemy(char[,] enemy, Coordinates axis, char[,] maze)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int x = 0; x < enemy.GetLength(0); x++)
            {
                Console.SetCursorPosition(axis.enemyX, axis.enemyY + x);
                for (int y = 0; y < enemy.GetLength(1); y++)
                {
                    maze[(axis.enemyY + x), (axis.enemyX + y)] = enemy[x, y];
                    Console.Write(enemy[x, y]);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* ERASING HERO AND ENEMIES */

        static void EraseHero(char[,] hero, Coordinates axis, char[,] maze)
        {
            for (int x = 0; x < hero.GetLength(0); x++)
            {
                Console.SetCursorPosition(axis.heroX, axis.heroY + x);
                for (int y = 0; y < hero.GetLength(1); y++)
                {
                    maze[(axis.heroY + x), (axis.heroX + y)] = ' ';
                    Console.Write(" ");
                }
            }
        }

        static void EraseEnemy(char[,] enemy, Coordinates axis, char[,] maze)
        {
            for (int i = 0; i < enemy.GetLength(0); i++)
            {
                Console.SetCursorPosition(axis.enemyX, axis.enemyY + i);
                for (int j = 0; j < enemy.GetLength(1); j++)
                {
                    maze[(axis.enemyY + i), (axis.enemyX + j)] = ' ';
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

        static void CollisionwithBush(ref char fruit, ref bool checkBush, List<HeroFires> arrows, char[,] maze)
        {
            for (int x = 0; x < arrows.Count; x++)
            {
                if (checkBush == true)
                {
                    if (arrows[x].fireX == 50 && (arrows[x].fireY == 1 || arrows[x].fireY == 2 || arrows[x].fireY == 3))
                    {
                        RemoveBush(ref fruit, ref checkBush, maze);
                    }
                }
            }
        }

        static void CollisionwithEnemy(ref Variables var, ref Coordinates axis, List<HeroFires> arrows)
        {
            for (int x = 0; x < arrows.Count; x++)
            {
                if (var.enemyPresence == true)
                {
                    if ((arrows[x].fireX + 1 == axis.enemyX || arrows[x].fireX + 2 == axis.enemyX) && (arrows[x].fireY == axis.enemyY || arrows[x].fireY == axis.enemyY + 2))
                    {
                        var.enemyCollision++;
                        AddScore(ref var.score);
                        EnemyHealth(ref var.removeCharacter, ref var.enemyHealth, ref var.isEnemyDead);
                    }
                    if (axis.enemyX - 1 == arrows[x].fireX && axis.enemyY + 1 == arrows[x].fireY)
                    {
                        var.enemyCollision++;
                        AddScore(ref var.score);
                        EnemyHealth(ref var.removeCharacter, ref var.enemyHealth, ref var.isEnemyDead);
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* HERO MOVEMENT */

        static void HeroUp(ref int score, ref char fruit, ref int princehealth, ref Coordinates axis, char[,] hero, ref int bomb, char[,] maze)
        {
            char next1 = maze[axis.heroY - 1, axis.heroX];
            char next2 = maze[axis.heroY - 1, (axis.heroX + 1)];
            char next3 = maze[axis.heroY - 1, (axis.heroX + 2)];
            char next4 = maze[axis.heroY - 1, (axis.heroX + 3)];
            char next5 = maze[axis.heroY - 1, (axis.heroX + 4)];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' && next5 == ' ')
            {
                EraseHero(hero, axis, maze);
                axis.heroY--;
                PrintHero(hero, axis, maze);
            }
            else if (next1 == fruit || next2 == fruit || next3 == fruit || next4 == fruit || next5 == fruit)
            {
                EraseHero(hero, axis, maze);
                axis.heroY--;
                PrintHero(hero, axis, maze);
                FruitScore(ref score);
                FruitrecoverHealth(ref princehealth);
            }
            else if (next1 == '<' || next2 == '<' || next3 == '<' || next4 == '<' || next5 == '<')
            {
                EraseHero(hero, axis, maze);
                axis.heroY--;
                PrintHero(hero, axis, maze);
            }
            else if (next1 == '0' || next2 == '0' || next3 == '0' || next4 == '0' || next5 == '0')
            {
                EraseHero(hero, axis, maze);
                axis.heroY--;
                PrintHero(hero, axis, maze);
                BombDamage(ref princehealth);
                bomb--;
            }
            /*UpdateHeroCoordinate(heroX, heroY);*/
        }

        static void HeroDown(ref int score, ref char fruit, ref int princehealth, ref Coordinates axis, char[,] hero, ref int bomb, char[,] maze)
        {
            char next1 = maze[axis.heroY + 3, axis.heroX];
            char next2 = maze[axis.heroY + 3, axis.heroX + 1];
            char next3 = maze[axis.heroY + 3, axis.heroX + 2];
            char next4 = maze[axis.heroY + 3, axis.heroX + 3];
            char next5 = maze[axis.heroY + 3, axis.heroX + 4];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' && next5 == ' ')
            {
                EraseHero(hero, axis, maze);
                axis.heroY++;
                PrintHero(hero, axis, maze);
            }
            else if (next1 == fruit || next2 == fruit || next3 == fruit || next4 == fruit || next5 == fruit)
            {
                EraseHero(hero, axis, maze);
                axis.heroY++;
                PrintHero(hero, axis, maze);
                FruitScore(ref score);
                FruitrecoverHealth(ref princehealth);
            }
            else if (next1 == '<' || next2 == '<' || next3 == '<' || next4 == '<' || next5 == '<')
            {
                EraseHero(hero, axis, maze);
                axis.heroY++;
                PrintHero(hero, axis, maze);
            }
            else if (next1 == '0' || next2 == '0' || next3 == '0' || next4 == '0' || next5 == '0')
            {
                EraseHero(hero, axis, maze);
                axis.heroY++;
                PrintHero(hero, axis, maze);
                BombDamage(ref princehealth);
                bomb--;
            }
            /*UpdateHeroCoordinate(heroX, heroY);*/
        }

        static void HeroRight(ref int rightmove, ref int score, ref char fruit, ref int princehealth, ref Coordinates axis, char[,] hero, ref int bomb, char[,] maze)
        {
            char next1 = maze[axis.heroY, (axis.heroX + 5)];
            char next2 = maze[axis.heroY, (axis.heroX + 5)];
            char next3 = maze[axis.heroY, (axis.heroX + 5)];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                EraseHero(hero, axis, maze);
                axis.heroX++;
                PrintHero(hero, axis, maze);
            }
            else if (next1 == fruit || next2 == fruit || next3 == fruit)
            {
                EraseHero(hero, axis, maze);
                axis.heroX++;
                PrintHero(hero, axis, maze);
                FruitScore(ref score);
                FruitrecoverHealth(ref princehealth);
            }
            else if (next1 == '<' || next2 == '<' || next3 == '<')
            {
                EraseHero(hero, axis, maze);
                axis.heroX++;
                PrintHero(hero, axis, maze);
            }
            else if (next1 == '0' || next2 == '0' || next3 == '0')
            {
                EraseHero(hero, axis, maze);
                axis.heroX++;
                PrintHero(hero, axis, maze);
                BombDamage(ref princehealth);
                bomb--;
            }
            rightmove++;
            if (rightmove >= 25)
            {
                rightmove = 25;
            }
            /*updateSteps(rightmove);*/
            /*UpdateHeroCoordinate(heroX, heroY);*/
        }

        static void HeroLeft(ref int score, ref char fruit, ref int princehealth, ref Coordinates axis, char[,] hero, ref int bomb, char[,] maze)
        {
            char next1 = maze[axis.heroY, axis.heroX - 1];
            char next2 = maze[axis.heroY + 1, axis.heroX - 1];
            char next3 = maze[axis.heroY + 2, axis.heroX - 1];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                EraseHero(hero, axis, maze);
                axis.heroX--;
                PrintHero(hero, axis, maze);
            }
            else if (next1 == fruit || next2 == fruit || next3 == fruit)
            {
                EraseHero(hero, axis, maze);
                axis.heroX--;
                PrintHero(hero, axis, maze);
                FruitScore(ref score);
                FruitrecoverHealth(ref princehealth);
            }
            else if (next1 == '<' || next2 == '<' || next3 == '<')
            {
                EraseHero(hero, axis, maze);
                axis.heroX--;
                PrintHero(hero, axis, maze);
            }
            else if (next1 == '0' || next2 == '0' || next3 == '0')
            {
                EraseHero(hero, axis, maze);
                axis.heroX--;
                PrintHero(hero, axis, maze);
                BombDamage(ref princehealth);
                bomb--;
            }
            /*UpdateHeroCoordinate(heroX, heroY);*/
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* HERO FIRING MECHANISM */

        static void CreateArrow(Coordinates axis, ref char ARROW, List<HeroFires> arrows)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            int xPos = axis.heroX + 4;
            int yPos = axis.heroY + 1;

            HeroFires data = new HeroFires(xPos, yPos);
            arrows.Add(data);
            
            Console.SetCursorPosition(axis.heroX + 4, axis.heroY + 1);
            Console.Write(ARROW);            
        }

        static void MoveArrow(ref char ARROW, List<HeroFires> arrows, char[,] maze)
        {
            for (int x = 0; x < arrows.Count; x++)
            {
                char next = maze[arrows[x].fireY, arrows[x].fireX + 1];
                if (next != ' ')
                {
                    EraseArrow(arrows[x].fireX, arrows[x].fireY, maze);
                    arrows.RemoveAt(x);
                }
                else
                {
                    EraseArrow(arrows[x].fireX, arrows[x].fireY, maze);
                    arrows[x].fireX = arrows[x].fireX + 1;
                    PrintArrow(arrows[x].fireX, arrows[x].fireY, ARROW, maze);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* ENEMIES MOVEMENT */

        static void EnemyMove(ref int enemySteps, ref string enemyDirection, ref Coordinates axis, char[,] enemy, char[,] maze)
        {
            if (enemyDirection == "Up")
            {
                char next = maze[axis.enemyY - 1, axis.enemyX];
                if (next == ' ')
                {
                    enemySteps++;
                    EraseEnemy(enemy, axis, maze);
                    axis.enemyY--;
                    PrintEnemy(enemy, axis, maze);

                }
                else if (next == '#' || next == '_')
                {
                    enemyDirection = "Down";
                }
            }
            else if (enemyDirection == "Down")
            {
                char next = maze[axis.enemyY + 3, axis.enemyX];
                if (next == ' ')
                {
                    enemySteps++;
                    EraseEnemy(enemy, axis, maze);
                    axis.enemyY++;
                    PrintEnemy(enemy, axis, maze);
                }
                else if (next == '#' || next == '_')
                {
                    enemyDirection = "Up";
                }
            }
            /*UpdateR1Coordinate(enemyX, enemyY);*/
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* ENEMIES FIRING MECHANISM */

        static void CreateEnemyFire(Coordinates axis, List<EnemyFires> bullets)
        {
            int xPos = axis.enemyX - 1;
            int yPos = axis.enemyY + 1;

            EnemyFires data = new EnemyFires(xPos, yPos);
            bullets.Add(data);

            Console.SetCursorPosition(axis.enemyX - 2, axis.enemyY + 1);
            Console.Write("<");
        }

        static void EnemyFireMove(char ARROW, List<EnemyFires> bullets, char[,] maze)
        {
            for (int x = 0; x < bullets.Count; x++)
            {
                char next = maze[bullets[x].fireY, bullets[x].fireX - 2];
                if (next == ARROW)
                {
                    EraseArrow(bullets[x].fireX, bullets[x].fireY, maze);
                    bullets[x].fireX = bullets[x].fireX - 1;
                    PrintArrow(bullets[x].fireX, bullets[x].fireY, '<', maze);
                }
                else if (next != ' ' || next == '#')
                {
                    EraseArrow(bullets[x].fireX, bullets[x].fireY, maze);
                    bullets.RemoveAt(x);
                }
                else
                {
                    EraseArrow(bullets[x].fireX, bullets[x].fireY, maze);
                    bullets[x].fireX = bullets[x].fireX - 1;
                    PrintArrow(bullets[x].fireX, bullets[x].fireY, '<', maze);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* ENEMIES FIRE COLLISIONS */

        static void EnemyFireCollisions(ref int princehealth, ref bool enemyPresence, Coordinates axis, List<EnemyFires> bullets)
        {
            for (int x = 0; x < bullets.Count; x++)
            {
                if (enemyPresence == true)
                {
                    if ((bullets[x].fireX == axis.heroX + 5 || bullets[x].fireX == axis.heroX + 4 || bullets[x].fireX == axis.heroX + 3) && (bullets[x].fireY == axis.heroY || bullets[x].fireY == axis.heroY + 1 || bullets[x].fireY == axis.heroY + 2))
                    {
                        HeroHealth(ref princehealth);
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
