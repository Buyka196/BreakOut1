namespace Breakout1
{
    using System;
   // using System.Threading;
    using Contracts;
  using Enums;
    using Models;
    using Models.Patterns;

    public class Engine
    {
        private const int PlaygroundWidth = 85;
        private const int PlaygroundHeight = 35;
        private const int PaddleWidth = 7;
        private const char BallSymbol = '*';

        private static int paddlePositionX = 18; 
        private static int ballPositionX = paddlePositionX + 3; 
        private static int ballPositionY = PlaygroundHeight - 2; 
        private static int previousBallPositionX = ballPositionX;
        private static int previousBallPositionY = ballPositionY;

        private static int gameSpeed = 100;

        private static Directions ballDirection = Directions.Up;
        private static IWall wallOfBricks;
        private static IFillingPattern fillingPattern;

       // public Engine(Score score)
         public Engine(Coo score)
        {
            //this.Score = score;
            this.Coo = score;
        }

       // public Score Score { get; private set; }
        public Coo Score { get; private set; }
        internal Coo Coo { get; private set; }

        public void Run()
        {
            Console.WindowWidth = PlaygroundWidth;
            Console.WindowHeight = PlaygroundHeight;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            while (true)
            {
                this.MainMenu();
            }
        }

        private void GameStart()
        {
            fillingPattern = new ZigZagPattern();
            wallOfBricks = new Wall(4, PlaygroundWidth, fillingPattern);

            DrawPaddle();
            wallOfBricks.DrawWall();
            DrawBall();
            Console.Write("\b \b");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    ChangePaddlePosition(pressedKey);
                }

                DrawPaddle();
                this.ChangeBallPosition();
                DrawBall();
                wallOfBricks.UpdateWall(previousBallPositionX, previousBallPositionY);
                
            }
        }

        private void MainMenu()
        {
            int ChoiceOption = 1;

            while (true)
            {
                if (ChoiceOption == 1)
                {   
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 14);
                Console.WriteLine("Start new game ");

                if (ChoiceOption == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 15);
                Console.WriteLine("level ");

                if (ChoiceOption == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 16);
                Console.WriteLine("Highscores ");

                if (ChoiceOption == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 17);
                Console.WriteLine("Exit");

                var cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    if (ChoiceOption + 1 <= 4)
                    {
                        ChoiceOption += 1;
                    }
                    else
                    {
                        ChoiceOption = 1;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    if (ChoiceOption - 1 >= 1)
                    {
                        ChoiceOption -= 1;
                    }
                    else
                    {
                        ChoiceOption = 4;
                    }
                }
                else if (cki.Key == ConsoleKey.Enter) 
                {
                    break;
                }
                Console.Clear();
            }

            Console.Clear();

            if (ChoiceOption == 1)
            {
                paddlePositionX = 18;
                ballPositionY = PlaygroundHeight - 2;
                ballPositionX = paddlePositionX + 3;
                ballDirection = Directions.Up;
                this.GameStart();
            }
            else if (ChoiceOption == 2)
            {
                this.Options();
            }
            else if (ChoiceOption == 3)
            {
                this.HighScoresMenue();
            }
            else if (ChoiceOption == 4)
            {
                Environment.Exit(0);
            }
        }

        private void Options()
        {
            int ChoiceOption = 1;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(35, 13);
                Console.WriteLine("Game speed: ");
                if (ChoiceOption == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                   
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 14);
                Console.WriteLine("x0.5");

                if (ChoiceOption == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                   
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                //Console.SetCursorPosition(35, 15);
                //Console.WriteLine("x1");

                if (ChoiceOption == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

             //   Console.SetCursorPosition(35, 16);
               // Console.WriteLine("x2");

                if (ChoiceOption == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                   
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(35, 17);
                Console.WriteLine("Back");

                var cki = Console.ReadKey(); 
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    if (ChoiceOption + 1 <= 4)
                    {
                        ChoiceOption += 1;
                    }
                    else
                    {
                        ChoiceOption = 1;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    if (ChoiceOption - 1 >= 1)
                    {
                        ChoiceOption -= 1;
                    }
                    else
                    {
                        ChoiceOption = 4;
                    }
                }
                else if (cki.Key == ConsoleKey.Enter) 
                {
                    break;
                }
                Console.Clear();
            }

            Console.Clear();

            if (ChoiceOption == 1)
            {
                gameSpeed = 200;
            }
            else if (ChoiceOption == 2)
            {
                gameSpeed = 100;
            }
            else if (ChoiceOption == 3)
            {
                gameSpeed = 50;
            }

            Console.Clear();
            this.MainMenu();
        }

        private void HighScoresMenue()
        {
            int ChoiceOption = 1;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;



                //  this.Score.PrintBestScores();
                this.Coo.PrintBestScores();
                if (ChoiceOption == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

              //  Console.SetCursorPosition(40, 23);
                //Console.WriteLine("Back");

                if (ChoiceOption == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                   
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                //Console.SetCursorPosition(40, 24);
                //Console.WriteLine("Exit");

                var cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.DownArrow)
                {
                    if (ChoiceOption + 1 <= 2)
                    {
                        ChoiceOption += 1;
                    }
                    else
                    {
                        ChoiceOption = 1;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    if (ChoiceOption - 1 >= 1)
                    {
                        ChoiceOption -= 1;
                    }
                    else
                    {
                        ChoiceOption = 2;
                    }
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            Console.Clear();

            if (ChoiceOption == 1)
            {
                Console.Clear();
                this.MainMenu();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void ChangeBallPosition()
        {
            switch (ballDirection)
            {
                case Directions.Up: // deesh
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionY--;
                    break;
                case Directions.UpAndLeft: // 
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionX--;
                    ballPositionY--;
                    break;
                case Directions.UpAndRight://
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionX++;
                    ballPositionY--;
                    break;
                case Directions.Down: // Down
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionY++;
                    break;
                case Directions.DownAndRight: // Down right
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionX++;
                    ballPositionY++;
                    break;
                case Directions.DownAndLeft: // Down left
                    previousBallPositionX = ballPositionX;
                    previousBallPositionY = ballPositionY;
                    ballPositionX--;
                    ballPositionY++;
                    break;
            }

            if (ballPositionY == PlaygroundHeight - 2)
            {
                if ((ballPositionX >= paddlePositionX + 2) &&
                    (ballPositionX <= paddlePositionX + 4))
                {


                    ballDirection = Directions.Up;
                }
                else if ((ballPositionX >= paddlePositionX) &&
                    (ballPositionX <= paddlePositionX + 1)) // T
                {


                    ballDirection = Directions.UpAndLeft; // 
                }
                else if ((ballPositionX >= paddlePositionX + 5) &&
                    (ballPositionX <= paddlePositionX + 6)) // 
                {


                    ballDirection = Directions.UpAndRight; // 
                }
                else
                {
                    this.Coo.SaveScore();
                    this.MainMenu();

                }
            }

            if (ballPositionY == 0) // When the ball hits the ceiling.
            {
                if (ballDirection == Directions.Up)
                {


                    ballDirection = Directions.Down; // From upward direction the ball bounces off downward.
                }
                else if (ballDirection == Directions.UpAndRight)
                {


                    ballDirection = Directions.DownAndRight; // From upward right direction the ball bounces off downward right.
                }
                else if (ballDirection == Directions.UpAndLeft)
                {


                    ballDirection = Directions.DownAndLeft; // From upward left direction the ball bounces off downward left.
                }
            }

            if (ballPositionX == 0) // When the ball hits the left wall.
            {
                if (ballDirection == Directions.UpAndLeft)
                {


                    ballDirection = Directions.UpAndRight; // From upward left direction the ball bounces off upward right.
                }
                else if (ballDirection == Directions.DownAndLeft)
                {


                    ballDirection = Directions.DownAndRight; //
                }

                if (ballPositionX == PlaygroundWidth - 1) //
                {
                    if (ballDirection == Directions.UpAndRight)
                    {


                        ballDirection = Directions.UpAndLeft; // 
                    }
                    else if (ballDirection == Directions.DownAndRight)
                    {


                        ballDirection = Directions.DownAndLeft; // 
                    }
                }

                if (ballPositionY <= wallOfBricks.Height)
                {
                    for (int i = 0; i < wallOfBricks.Height; i++)
                    {
                        for (int j = 0; j < wallOfBricks.Width; j++)
                        {
                            if (ballPositionX == wallOfBricks.FilledWall[i, j].PositionX &&
                                ballPositionY - 1 == wallOfBricks.FilledWall[i, j].PositionY &&
                                wallOfBricks.FilledWall[i, j].getVisibility())

                            {
                                wallOfBricks.FilledWall[i, j].setInvisible();



                                BallDirectionAfterWallCollision();

                                this.Coo.UpdateCurrentScore();
                            }
                        }
                    }
                }
            }
        }

        private static void BallDirectionAfterWallCollision()
        {
            if (ballDirection == Directions.Up)
            {
                ballDirection = Directions.Down;
            }
            else if (ballDirection == Directions.Down)
            {
                ballDirection = Directions.Up;
            }
            else if (ballDirection == Directions.UpAndRight)
            {
                ballDirection = Directions.DownAndRight;
            }
            else if (ballDirection == Directions.UpAndLeft)
            {
                ballDirection = Directions.DownAndLeft;
            }
            else if (ballDirection == Directions.DownAndLeft)
            {
                ballDirection = Directions.UpAndLeft;
            }
            else if (ballDirection == Directions.DownAndRight)
            {
                ballDirection = Directions.UpAndRight;
            }
        }

        private static void ChangePaddlePosition(ConsoleKeyInfo pressedKey)
        {
            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                paddlePositionX = paddlePositionX - 2;
                if (paddlePositionX < 0)
                {
                    paddlePositionX = 0;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                paddlePositionX = paddlePositionX + 2;
                if (paddlePositionX > PlaygroundWidth - PaddleWidth)
                {
                    paddlePositionX = PlaygroundWidth - PaddleWidth;
                }
            }
        }

        private static void DrawPaddle()
        {
            Console.SetCursorPosition(0, PlaygroundHeight - 2);
            Console.Write(new string(' ', PlaygroundWidth));

            for (int i = 0; i < PaddleWidth; i++)
            {
                Console.SetCursorPosition(paddlePositionX + i, PlaygroundHeight - 2);
                Console.Write('_');
            }
        }

        private static void DrawBall()
        {
            Console.SetCursorPosition(previousBallPositionX, previousBallPositionY);
            Console.Write(' ');
            Console.SetCursorPosition(ballPositionX, ballPositionY);
            Console.Write(BallSymbol);
        }
    }
}