using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSnakeGame
{
    public enum Action
    {
        Go,
        Eat,
        Stop,
        Save,
        Retrieve
    }

    public class Snake : IDrawable
    {
        char mark = 's';

        List<Point> corpus = null;

        public Snake()  //пустой конструктор для сериализации
        {

        }

        public Snake(int StartingPointX, int StartingPointY)
        {
            corpus = new List<Point>();
            corpus.Add(new Point { x = StartingPointX, y = StartingPointY }); //узнать, как это использовать с this.x = x, this.y = y
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

        public Action Reflect(Point direction, Point foodPoint)
        {
            if (foodPoint.x == corpus[0].x + direction.x && foodPoint.y == corpus[0].y + direction.y)
            {
                corpus.Insert(0, foodPoint);
                Draw();
                return Action.Eat;
            }
            else if (Console.WindowWidth - 1 == corpus[0].x + direction.x || 
                     Console.WindowHeight - 1 == corpus[0].y + direction.y || 
                     1 == corpus[0].x + direction.x || 
                     1 == corpus[0].y + direction.y)
            {
                return Action.Stop;
            }

            for (int i = corpus.Count - 1; i > 0; i--)
            {
                corpus[i].x = corpus[i - 1].x;
                corpus[i].y = corpus[i - 1].y;
            }

            corpus[0].x = corpus[0].x + direction.x;
            corpus[0].y = corpus[0].y + direction.y;

            Draw();

            return Action.Go;
        }
    }
}
