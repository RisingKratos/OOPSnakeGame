using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSnakeGame
{
    interface IDrawable
    {
        void Draw();
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(50, 50);

            Snake snake = new Snake(25, 25);

            Food food = new Food();

            ConsoleKeyInfo command;

            Point direction = new Point();

            while (true)
            {
                command = Console.ReadKey();

                switch (command.Key)
                {
                    case ConsoleKey.UpArrow:
                        direction.x = 0;
                        direction.y = -1;
                        break;
                    case ConsoleKey.RightArrow:
                        direction.x = 1;
                        direction.y = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        direction.x = 0;
                        direction.y = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction.x = -1;
                        direction.y = 0;
                        break;
                    case ConsoleKey.S:
                        //сохранить
                        break;
                    case ConsoleKey.R:
                        //восстановить
                        break;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        break;
                }

                Action action = snake.Reflect(direction,food.generatingPoint);
                
            }
            //петля закончилась
        }
    }
}
