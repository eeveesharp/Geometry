using System;

namespace Geometry
{
    public class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();

            Player firstPlayer = new Player();

            Player secondPlayer = new Player();

            int attempts = GetAttempts();

            Game game = new Game(field, firstPlayer, secondPlayer,attempts);

            field.SetField();

            field.GetField();

            int i = 0;

            while (i < attempts)
            {
                game.GetMoveFirstPlayer();

                game.GetMoveSecondPlayer();
            }
        }

        static int GetAttempts()
        {
            Console.WriteLine("Введите количество ходов");

            int number;

            while (!int.TryParse(Console.ReadLine(),out number) || number < 20)
            {
                Console.WriteLine("error");
            }

            return number;
        }
    }
}
