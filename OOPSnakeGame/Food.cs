using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSnakeGame
{
    public class Food : IDrawable
    {
        char mark = '*';
        public Point generatingPoint = new Point();

        public Food()
        {
            generatingPoint.x = new Random().Next() % 50 + 1;
            generatingPoint.y = new Random().Next() % 50 + 1;
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(generatingPoint.x, generatingPoint.y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(mark);
        }
    }
}
