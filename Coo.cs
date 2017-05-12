using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout1
{

    class Coo
    {
       // DrawPaddle();
        //wallOfBricks.DrawWall();

        private int points;
        private static readonly int previousBallPositionY;
        private static int previousBallPositionX;
        private static int ballPositionX;
        private static int ballPositionY;

        public object CurrentGamer { get; private set; }
        public static string BallSymbol { get; private set; }

        public void SaveScore()
        {
            Console.Clear();
            Console.WriteLine("Game Over!"); // The ball did not land on the paddle.
            Console.WriteLine("Your score: {0}", this.points);
            //CurrentGamer.GamerPoints = points;
            Console.Write("Enter you name to save the score: ");
          //  CurrentGamer.GamerName = Console.ReadLine();
            Console.Clear();
            this.SaveTopResult();
            this.points = 0;
        }

        private void SaveTopResult()
        {
            throw new NotImplementedException();
        }

        internal void PrintBestScores()
        {
            throw new NotImplementedException();
        }

        internal void UpdateCurrentScore()
        {
            throw new NotImplementedException();
        }

        /* private void SaveTopResult()
         {
             throw new NotImplementedException();
         }

         public void UpdateCurrentScore()
         {
             this.points++;
         }
         /*private static void DrawBall()
         {
             Console.SetCursorPosition(previousBallPositionX, previousBallPositionY);
             Console.Write(' ');
             Console.SetCursorPosition(ballPositionX, ballPositionY);
             Console.Write(BallSymbol);
         }*/

    }
}
