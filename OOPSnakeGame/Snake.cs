using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSnakeGame
{
    public class Snake : IDrawable
    {
        char mark = 's';
        List<Point> corpus = null;
        public Snake(int X, int Y)
        {
            corpus = new List<Point>();
            corpus.Add(new Point { x = X, y = Y }); //узнать, как это использовать с this.x = x, this.y = y
            Draw();
        }

        public void Draw()
        {
            foreach (Point point in corpus)
            {
                Console.SetCursorPosition(point.x, point.y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(mark);
            }
        }

        public void Clear()
        {
            foreach (Point point in corpus)
            {
                Console.SetCursorPosition(point.x, point.y);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(' ');
            }
        }

    }
}
