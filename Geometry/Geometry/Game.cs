using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            SetAttempts();

            Field.SetField();

            Field.GetField();

            ShowPoint();

            int temp = FirstPlayer.Attempts;

            while (temp > 0)
            {
                GetMoveFirstPlayer();

                GetMoveSecondPlayer();

                temp--;
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

            do
            {
                point = player.GetCoordination(Field);

                if (IsPointFill(point))
                {
                    Console.WriteLine("Error.Координата занята");
                }
            } while (IsPointFill(point));

            return point;
        }

        public void GetMoveFirstPlayer()
        {
            Console.WriteLine("Ход первого игрока");

            Console.WriteLine(new string('-', 30));

            int row = GetRandomNumberForFigure();

            int column = GetRandomNumberForFigure();

            if (!isMove(row, column))
            {
                Console.WriteLine("Переброс...(Это может занять несколько секунд)");

                Thread.Sleep(6000);

                row = GetRandomNumberForFigure();

                column = GetRandomNumberForFigure();

                if (!isMove(row, column))
                {
                    Console.WriteLine("Неудачно!!!");

                    Thread.Sleep(6000);

                    FirstPlayer.Attempts--;

                    Console.Clear();

                    Field.GetField();

                    ShowPoint();

                    return;
                }
            }
            if (isMove(row, column))
            {
                Point point = GetPointFromPlayer(FirstPlayer);

                while (!IsChecked(point.X, point.Y, row, column))
                {
                    point = GetPointFromPlayer(FirstPlayer);

                    row = GetRandomNumberForFigure();

                    column = GetRandomNumberForFigure();
                }

                GetFigureOnField(FirstPlayer, point.X, point.Y, row, column);

                FirstPlayer.Score += (row + 1) * (column + 1);

                FirstPlayer.Attempts--;

                Console.Clear();

                Field.GetField();

                ShowPoint();
            }
        }

        public void GetMoveSecondPlayer()
        {
            Console.WriteLine("Ход второго игрока");

            Console.WriteLine(new string('-', 30));

            int row = GetRandomNumberForFigure();

            int column = GetRandomNumberForFigure();

            if (!isMove(row, column))
            {
                Console.WriteLine("Переброс...(Это может занять несколько секунд)");

                Thread.Sleep(6000);

                row = GetRandomNumberForFigure();

                column = GetRandomNumberForFigure();

                if (!isMove(row, column))
                {
                    Console.WriteLine("Неудачно!!!");

                    Thread.Sleep(6000);

                    SecondPlayer.Attempts--;

                    Console.Clear();

                    Field.GetField();

                    ShowPoint();

                    return;
                }
            }
            if (isMove(row, column))
            {
                Point point = GetPointFromPlayer(SecondPlayer);

                while (!IsChecked(point.X, point.Y, row, column))
                {
                    point = GetPointFromPlayer(SecondPlayer);

                    row = GetRandomNumberForFigure();

                    column = GetRandomNumberForFigure();
                }

                GetFigureOnField(SecondPlayer, point.X, point.Y, row, column);

                SecondPlayer.Score += (row + 1) * (column + 1);

                SecondPlayer.Attempts--;

                Console.Clear();

                Field.GetField();

                ShowPoint();
            }
        }

        private int GetRandomNumberForFigure()
        {
            return random.Next(0, 5);
        }

        public void ShowPoint()
        {
            Console.WriteLine($"\t\t\t|Player_1({FirstPlayer.Symbol})|{FirstPlayer.Score}:{SecondPlayer.Score}|Player_2({SecondPlayer.Symbol})|");

            Console.WriteLine($"\t\t\t|Осталось ходов у Player_1|:{FirstPlayer.Attempts}");

            Console.WriteLine($"\t\t\t|Осталось ходов у Player_2|:{SecondPlayer.Attempts}");
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

        private bool IsPointFill(Point point)
        {
            bool isPointFill = false;

            if (Field.PlayField[point.Y, point.X] == "*" || Field.PlayField[point.Y, point.X] == "#")
            {
                isPointFill = true;
            }

            return isPointFill;
        }

        private void GetFigureOnField(Player player, int x, int y, int row, int column)
        {
            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j <= column; j++)
                {
                    Field.PlayField[y + i, x + j] = player.Symbol;
                }
            }
        }

        private bool IsChecked(int x, int y, int row, int column)
        {
            try
            {
                int temp = 0;

                for (int i = 0; i <= row; i++)
                {
                    for (int j = 0; j <= column; j++)
                    {
                        if (Field.PlayField[y + i, x + j] == "-")
                        {
                            temp++;
                        }
                    }
                }

                if (temp < (row + 1) * (column + 1))
                {
                    Console.WriteLine("Error.Фигура не влазит либо залазит на другую.Выберите другую координату");

                    return false;
                }

                return true;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Фигура выходит за пределы поля");

                return false;
            }
        }

        private bool isMove(int row, int column)
        {
            int temp = 0;

            for (int i = 0; i < Field.Row; i++)
            {
                for (int j = 0; j < Field.Column; j++)
                {
                    if (Field.PlayField[i, j] == "-")
                    {
                        temp = GetSquare(i,j,row, column);

                        if (temp >= (row + 1) * (column + 1))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private int GetSquare(int x,int y,int row, int column)
        {
            int temp = 0;

            try
            {
                for (int i = 0; i <= row; i++)
                {
                    for (int j = 0; j <= column; j++)
                    {
                        if (Field.PlayField[i + x, j + y] == "-")
                        {
                            temp++;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }          

            return temp;
        }
    }
}
