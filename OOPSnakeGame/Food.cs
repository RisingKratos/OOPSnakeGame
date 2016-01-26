using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSnakeGame
{
    public class Food : IChangable
    {
        char mark = '*';

        public Point generatingPoint = new Point();

        public Food()   //уже пустой конструктор
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

        public void Clear()
        {
            Console.SetCursorPosition(generatingPoint.x, generatingPoint.y);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(' ');
        }

    }

}
