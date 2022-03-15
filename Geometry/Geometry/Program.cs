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

            Game game = new Game(field, firstPlayer, secondPlayer);

            game.Start();
        }
    }
}
