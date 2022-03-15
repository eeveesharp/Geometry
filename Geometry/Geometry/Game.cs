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

        public Game(Field field, Player firstPlayer, Player secondPlayer)
        {
            this.Field = field;

            this.FirstPlayer = firstPlayer;

            this.SecondPlayer = secondPlayer;

            firstPlayer.Symbol = "*";

            secondPlayer.Symbol = "#";
        }

        public void Start()
        {
            int temp = 0;

            SetAttempts();

            Field.SetField();

            Field.GetField();

            ShowPoint();

            while (temp <= FirstPlayer.Attempts)
            {              
                GetMoveFirstPlayer();

                GetMoveSecondPlayer();

                temp++;
            }

            GetWinner();
        }

        private void SetAttempts()
        {
            Console.WriteLine("Введите количество ходов");

            int number;

            while (!int.TryParse(Console.ReadLine(), out number) || number < 20)
            {
                Console.WriteLine("Error.Количество ходов должно быть не меньше 20");
            }

            FirstPlayer.Attempts = number;

            SecondPlayer.Attempts = number;

            Console.Clear();
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
                for (int j = 0; j <= column; j++)
                {
                    Field.PlayField[y + i, x + j] = FirstPlayer.Symbol;
                }
            }

            FirstPlayer.Score += (row + 1) * (column + 1);

            FirstPlayer.Attempts--;

            Console.Clear();

            Field.GetField();

            ShowPoint();
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
                for (int j = 0; j <= column; j++)
                {
                    Field.PlayField[y + i, x + j] = SecondPlayer.Symbol;
                }
            }

            SecondPlayer.Score += (row + 1) * (column + 1);

            SecondPlayer.Attempts--;

            Console.Clear();

            Field.GetField();

            ShowPoint();
        }

        private int GetRandomNumberForFigure()
        {
            return random.Next(0, 5);
        }

        public void ShowPoint()
        {
            Console.WriteLine($"\t\t\t|Player_1({FirstPlayer.Symbol})|{FirstPlayer.Score}:{SecondPlayer.Score}|Player_2({SecondPlayer.Symbol})|");

            Console.WriteLine($"\t\t\t|Осталось ходов у Player_1|:{FirstPlayer.Attempts}");

            Console.WriteLine($"\t\t\t|Осталось ходов у Player_2({SecondPlayer.Symbol})|:{SecondPlayer.Attempts}");
        }

        private void GetWinner()
        {
            if (FirstPlayer.Score > SecondPlayer.Score)
            {
                Console.WriteLine("Победитель Player_1");
            }
            else if (FirstPlayer.Score < SecondPlayer.Score)
            {
                Console.WriteLine("Победитель Player_2");
            }
            else
            {
                Console.WriteLine("Ничья");
            }
        }
    }
}
