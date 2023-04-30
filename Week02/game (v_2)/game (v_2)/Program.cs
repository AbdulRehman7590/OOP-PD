
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using EZInput;
using game__v_2_.BL;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string option;

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /* VARAIABLES */

            int score = 0, rightmove = 0, loadedArrow = 0;
            int princeHealth = 0, enemyHealth = 0, bomb = 0;
            int r2FireCount = 0;
            int arrowCount = 0, r2Steps = 0, r2Collision = 0;

            char fruit = Convert.ToChar(147);
            char heart = Convert.ToChar(3);

            bool checkBush = true;
            bool removeCharacter = false;
            bool isEnemyDead = false;
            bool r1Presence = false, r2Presence = false;
            bool gameExit = true;
            bool Move_to_stage2 = false;
            bool isFire = true;

            string r2Direction = "Down";

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /* 1-D ARRAYS */

            int[] arrowX = new int[100];
            int[] arrowY = new int[100];
            int[] r2FireX = new int[100];
            int[] r2FireY = new int[100];

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
                    RefreshingData(ref score, ref rightmove, ref loadedArrow, ref princeHealth, ref enemyHealth, ref bomb, ref r2FireCount, ref arrowCount, ref r2Steps, ref r2Collision, ref checkBush, ref removeCharacter, ref isEnemyDead, ref r2Presence, ref gameExit, ref isFire, ref axis, maze1);
                    Stage1(ref rightmove, ref score, ref fruit, ref checkBush, ref heart, ref removeCharacter, ref gameExit, ref isEnemyDead, ref princeHealth, ref enemyHealth, ref arrowCount, ref r2Presence, ref r2Steps, ref r2Direction, ref r2FireCount, ref r2Collision, ref axis, ref ARROW, r2FireX, r2FireY, arrowX, arrowY, ref Move_to_stage2, hero, maze1, enemy2, ref loadedArrow, ref isFire, ref r1Presence, ref bomb);
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

        static void Stage1(ref int rightmove, ref int score, ref char fruit, ref bool checkBush, ref char heart, ref bool removeCharacter, ref bool gameExit, ref bool isEnemyDead, ref int princehealth, ref int enemyHealth, ref int arrowCount, ref bool r2Presence, ref int r2Steps, ref string r2Direction, ref int r2FireCount, ref int r2Collision, ref Coordinates axis, ref char ARROW, int[] r2FireX, int[] r2FireY, int[] arrowX, int[] arrowY, ref bool move_to_Stage2, char[,] hero, char[,] maze1, char[,] enemy2, ref int loadedArrow, ref bool isFire, ref bool r1Presence, ref int bomb)
        {
            /* GameHeader();*/
            Console.Clear();
            PrintStage1(maze1);
            PrintHero(hero, axis, maze1);
            PrintBush();
            move_to_Stage2 = false;
            /* UpdateMoveNextStage(move_to_Stage2); */
            while (gameExit)
            {
                if (rightmove == 2)
                {
                    axis.wallX = 12;
                    axis.wallY = 1;
                    axis.wallSize = 5;
                    rightmove++;
                    WallRemove(axis, maze1);
                }

                if (rightmove == 20)
                {
                    axis.wallX = 12;
                    axis.wallY = 1;
                    axis.wallSize = 5;
                    PrintWall(axis, maze1);
                    rightmove++;
                }

                if (IsprintEnemy1(ref rightmove, r2Collision) == true)
                {
                    r2Presence = true;
                    /*UpdateEnemypresence(r1Presence, r2Presence);*/
                    PrintEnemy(enemy2, axis, maze1);
                    EnemyMove(ref r2Steps, ref r2Direction, ref axis, enemy2, maze1);

                    if (r2Steps == 5)
                    {
                        CreateEnemyFire(ref r2FireCount, axis, r2FireX, r2FireY);
                        r2Steps = 0;
                    }

                    CollisionwithEnemy(ref score, ref removeCharacter, ref isEnemyDead, ref enemyHealth, ref arrowCount, ref r2Presence, ref r2Collision, ref axis, arrowX, arrowY);
                    EnemyFireCollisions(ref princehealth, ref r2Presence, ref r2FireCount, axis, r2FireX, r2FireY);
                    CreateBombs(enemyHealth, ref bomb, r2Presence, maze1);
                }

                if (removeCharacter == true)
                {
                    EraseEnemy(enemy2, axis, maze1);
                    r2Presence = false;
                    /*updateEnemypresence(r1Presence, r2Presence);*/
                    removeCharacter = false;
                }

                if (isEnemyDead == true)
                {
                    axis.wallX = 91;
                    axis.wallY = 1;
                    axis.wallSize = 5;
                    WallRemove(axis, maze1);
                    isEnemyDead = false;
                }
                if (axis.heroX > 92)
                {
                    move_to_Stage2 = true;
                    /*UpdateMoveNextStage(move_to_Stage2);*/
                    YouWin();
                    break;
                }
                Controls(ref score, ref fruit, ref princehealth, ref axis, ref bomb, ref rightmove, isFire, ref arrowCount, ref ARROW, ref loadedArrow, ref gameExit, arrowX, arrowY, hero, maze1);
                CollisionwithBush(ref fruit, ref checkBush, ref arrowCount, arrowX, arrowY, maze1);
                MoveArrow(ref arrowCount, ref ARROW, arrowX, arrowY, maze1);
                EnemyFireMove(ref r2FireCount, ARROW, r2FireX, r2FireY, maze1);
                PrintScore(ref score);
                PrintHeroHealth(ref heart, ref gameExit, ref princehealth);
                PrintEnemyHealth(ref heart, ref enemyHealth);
                /* UpdateHealthData(princehealth, r1Health, r2Health); */
                PrintLoadedArrows(ref loadedArrow, ref ARROW);
                Reload(ref loadedArrow, ref isFire);
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

        static void Controls(ref int score, ref char fruit, ref int princehealth, ref Coordinates axis, ref int bomb, ref int rightmove, bool isFire, ref int arrowCount, ref char ARROW, ref int loadedArrow, ref bool gameExit, int[] arrowX, int[] arrowY, char[,] hero, char[,] maze)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                HeroLeft(ref score, ref fruit, ref princehealth, ref axis, hero, ref bomb, maze);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                HeroRight(ref rightmove, ref score, ref fruit, ref princehealth, ref axis, hero, ref bomb, maze);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                HeroUp(ref score, ref fruit, ref princehealth, ref axis, hero, ref bomb, maze);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                HeroDown(ref score, ref fruit, ref princehealth, ref axis, hero, ref bomb, maze);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                if (isFire == true)
                {
                    CreateArrow(ref arrowCount, axis, ref ARROW, arrowX, arrowY);
                    loadedArrow--;
                }
            }
            if (Keyboard.IsKeyPressed(Key.Escape))
            {
                gameExit = false;
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

        static void RefreshingData(ref int score, ref int rightmove, ref int loadedArrow, ref int princeHealth, ref int enemyHealth, ref int bomb, ref int r2FireCount, ref int arrowCount, ref int r2Steps, ref int r2Collision, ref bool checkBush, ref bool removeCharacter, ref bool isEnemyDead, ref bool r2Presence, ref bool gameExit, ref bool isFire, ref Coordinates axis, char[,] maze)
        {
            score = 0;
            rightmove = 0;
            loadedArrow = 9;
            princeHealth = 100;
            enemyHealth = 100;
            bomb = 0;
            r2FireCount = 0;
            arrowCount = 0;
            r2Steps = 0;
            r2Collision = 0;
            checkBush = true;
            removeCharacter = false;
            isEnemyDead = false;
            r2Presence = false;
            gameExit = true;
            isFire = true;
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

        static void MakeArrowInActive(int index, ref int arrowCount, int[] arrowX, int[] arrowY)
        {
            for (int x = index; x < arrowCount; x++)
            {
                arrowX[x] = arrowX[x + 1];
                arrowY[x] = arrowY[x + 1];
            }
            arrowCount--;
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

        static void CollisionwithBush(ref char fruit, ref bool checkBush, ref int arrowCount, int[] arrowX, int[] arrowY, char[,] maze)
        {
            for (int x = 0; x < arrowCount; x++)
            {
                if (checkBush == true)
                {
                    if (arrowX[x] == 50 && (arrowY[x] == 1 || arrowY[x] == 2 || arrowY[x] == 3))
                    {
                        RemoveBush(ref fruit, ref checkBush, maze);
                    }
                }
            }
        }

        static void CollisionwithEnemy(ref int score, ref bool removeCharacter, ref bool isEnemyDead, ref int enemyHealth, ref int arrowCount, ref bool enemyPresence, ref int enemyCollision, ref Coordinates axis, int[] arrowX, int[] arrowY)
        {
            for (int x = 0; x < arrowCount; x++)
            {
                if (enemyPresence == true)
                {
                    if ((arrowX[x] + 1 == axis.enemyX || arrowX[x] + 2 == axis.enemyX) && (arrowY[x] == axis.enemyY || arrowY[x] == axis.enemyY + 2))
                    {
                        enemyCollision++;
                        AddScore(ref score);
                        EnemyHealth(ref removeCharacter, ref enemyHealth, ref isEnemyDead);
                    }
                    if (axis.enemyX - 1 == arrowX[x] && axis.enemyY + 1 == arrowY[x])
                    {
                        enemyCollision++;
                        AddScore(ref score);
                        EnemyHealth(ref removeCharacter, ref enemyHealth, ref isEnemyDead);
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

        static void CreateArrow(ref int arrowCount, Coordinates axis, ref char ARROW, int[] arrowX, int[] arrowY)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            arrowX[arrowCount] = axis.heroX + 4;
            arrowY[arrowCount] = axis.heroY + 1;
            Console.SetCursorPosition(axis.heroX + 4, axis.heroY + 1);
            Console.Write(ARROW);
            arrowCount++;
        }

        static void MoveArrow(ref int arrowCount, ref char ARROW, int[] arrowX, int[] arrowY, char[,] maze)
        {
            for (int x = 0; x < arrowCount; x++)
            {
                char next = maze[arrowY[x], arrowX[x] + 1];
                if (next != ' ')
                {
                    EraseArrow(arrowX[x], arrowY[x], maze);
                    MakeArrowInActive(x, ref arrowCount, arrowX, arrowY);
                }
                else
                {
                    EraseArrow(arrowX[x], arrowY[x], maze);
                    arrowX[x] = arrowX[x] + 1;
                    PrintArrow(arrowX[x], arrowY[x], ARROW, maze);
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

        static void CreateEnemyFire(ref int enemyFireCount, Coordinates axis, int[] enemyFireX, int[] enemyFireY)
        {
            enemyFireX[enemyFireCount] = axis.enemyX - 1;
            enemyFireY[enemyFireCount] = axis.enemyY + 1;
            Console.SetCursorPosition(axis.enemyX - 2, axis.enemyY + 1);
            Console.Write("<");
            enemyFireCount++;
        }

        static void EnemyFireMove(ref int enemyFireCount, char ARROW, int[] enemyFireX, int[] enemyFireY, char[,] maze)
        {
            for (int x = 0; x < enemyFireCount; x++)
            {
                char next = maze[enemyFireY[x], enemyFireX[x] - 2];
                if (next == ARROW)
                {
                    EraseArrow(enemyFireX[x], enemyFireY[x], maze);
                    enemyFireX[x] = enemyFireX[x] - 1;
                    PrintArrow(enemyFireX[x], enemyFireY[x], '<', maze);
                }
                else if (next != ' ' || next == '#')
                {
                    EraseArrow(enemyFireX[x], enemyFireY[x], maze);
                    MakeArrowInActive(x, ref enemyFireCount, enemyFireX, enemyFireY);
                }
                else
                {
                    EraseArrow(enemyFireX[x], enemyFireY[x], maze);
                    enemyFireX[x] = enemyFireX[x] - 1;
                    PrintArrow(enemyFireX[x], enemyFireY[x], '<', maze);
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* ENEMIES FIRE COLLISIONS */

        static void EnemyFireCollisions(ref int princehealth, ref bool enemyPresence, ref int enemyFireCount, Coordinates axis, int[] enemyFireX, int[] enemyFireY)
        {
            for (int x = 0; x < enemyFireCount; x++)
            {
                if (enemyPresence == true)
                {
                    if ((enemyFireX[x] == axis.heroX + 5 || enemyFireX[x] == axis.heroX + 4 || enemyFireX[x] == axis.heroX + 3) && (enemyFireY[x] == axis.heroY || enemyFireY[x] == axis.heroY + 1 || enemyFireY[x] == axis.heroY + 2))
                    {
                        HeroHealth(ref princehealth);
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
