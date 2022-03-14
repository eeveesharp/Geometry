using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public class Game
    {
        private readonly Random random = new Random();

        public Field Field { get; set; }

        public Player FirstPlayer { get; set; }

        public Player SecondPlayer { get; set; }

        public int Attempts { get; private set; }

        public Game(Field field, Player firstPlayer, Player secondPlayer,int attempts)
        {
            this.Field = field;

            this.FirstPlayer = firstPlayer;

            this.SecondPlayer = secondPlayer;

            this.Attempts = attempts;

            firstPlayer.Symbol = "*";

            secondPlayer.Symbol = "#";
        }

        public Point GetPointFromPlayer(Player player)
        {
            Point point;

            point = player.GetCoordination(Field);

            return point;
        }

        public void GetMoveFirstPlayer()
        {
            Console.WriteLine("Ход первого игрока");

            Console.WriteLine(new string('-', 30));

            Point point = GetPointFromPlayer(FirstPlayer);

            int x = point.X;

            int y = point.Y;

            int row = GetRandomNumberForFigure();

            int column = GetRandomNumberForFigure();

            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Field.PlayField[y + i, x + j] = FirstPlayer.Symbol;
                }
            }          

            Console.Clear();

            Field.GetField();
        }

        public void GetMoveSecondPlayer()
        {
            Console.WriteLine("Ход второго игрока");

            Console.WriteLine(new string('-', 30));

            Point point = GetPointFromPlayer(FirstPlayer);

            int x = point.X;

            int y = point.Y;

            int row = GetRandomNumberForFigure();

            int column = GetRandomNumberForFigure();

            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Field.PlayField[y + i, x + j] = SecondPlayer.Symbol;
                }
            }
            //FirstPlayer.Score += row * column;
            Console.Clear();

            Field.GetField();
        }

        private int GetRandomNumberForFigure() 
        {            
            return random.Next(0, 5);
        }
    }
}
