using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public class Player
    {
        public int Score { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public string Symbol { get; set; }

        public Point GetCoordination(Field field)
        {
            Console.WriteLine("Введите координату X");

            X = GetCorrectNumberX(field);

            Console.WriteLine("Введите координату Y");

            Y = GetCorrectNumberY(field);

            return new Point(X, Y);
        }

        private int GetCorrectNumberX(Field field)
        {
            int x;

            while (!int.TryParse(Console.ReadLine(), out x) || (x < 0 || x > field.Column - 1))
            {
                Console.WriteLine("Введите корректное значение координаты X");
            }

            return x;
        }

        private int GetCorrectNumberY(Field field)
        {
            int y;

            while (!int.TryParse(Console.ReadLine(), out y) || (y < 0 || y > field.Row - 1))
            {
                Console.WriteLine("Введите корректное значение координаты Y");
            }

            return y;
        }
    }
}
