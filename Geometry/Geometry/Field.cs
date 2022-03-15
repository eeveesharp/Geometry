using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public class Field
    {
        public string[,] PlayField { get; private set; }

        public int Row { get; private set; }

        public int Column { get; private set; }

        public void SetField()
        {
            Console.WriteLine("Введите количество строк");

            Row = GetCorrectNumberRow();

            Console.WriteLine("Введите количество столбцов");

            Column = GetCorrectNumberColumn();

            PlayField = new string[Row, Column];

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    PlayField[i, j] = "-";
                }
            }
        }

        public void GetField()
        {
            Console.Write("  |");

            for (int i = 0; i < Column; i++)
            {
                Console.Write("{0,-4}",i);
            }

            Console.WriteLine();

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {                  
                    if (j == 0)
                    {
                        if (i < 10)
                        {
                            Console.Write($" {i}|");
                        }
                        else
                        {
                            Console.Write($"{i}|");
                        }
                    }

                    Console.Write("{0,-4}",PlayField[i, j]);
                }

                Console.WriteLine();
            }

            Console.SetWindowSize((int)(Column * 4.15), (int)(Row * 1.4));
        }

        private int GetCorrectNumberRow()
        {
            int row;

            while (!int.TryParse(Console.ReadLine(), out row) || row < 20)
            {
                Console.WriteLine("Error.Количество строк должно быть не меньше 20");
            }

            Console.Clear();

            return row;
        }

        private int GetCorrectNumberColumn()
        {
            int column;

            while (!int.TryParse(Console.ReadLine(), out column) || column < 30)
            {
                Console.WriteLine("Error.Количество столбцов должно быть не меньше 30");
            }

            Console.Clear();

            return column;
        }
    }
}
