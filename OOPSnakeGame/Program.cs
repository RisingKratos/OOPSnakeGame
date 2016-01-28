using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSnakeGame
{
    interface IChangable
    {
        void Draw();
        void Clear();
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(50, 50);

            Progress progress = new Progress();

            //Snake snake = progress.SnakeRetriever();
            Snake snake = new Snake(Console.WindowHeight / 2, Console.WindowWidth / 2);

            //Food food = progress.FoodRetriever();
            Food food = new Food();

            ConsoleKeyInfo command;

            Point direction = new Point();

            while (true)
            {
                command = Console.ReadKey();

                Action action = Action.Default;

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
                        progress.ProgressSaver(snake,food);
                        action = Action.Save;
                        //сохранить
                        break;
                    case ConsoleKey.R:
                        action = Action.Retrieve;
                        //восстановить
                        break;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        break;
                }

                    action = snake.Reflect(direction, food.generatingPoint);

                switch (action)
                {
                    case Action.Go:
                        break;
                    case Action.Eat:
                        food = new Food();
                        break;
                    case Action.Stop:
                        Console.SetCursorPosition(Console.WindowHeight / 2, Console.WindowWidth / 2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Game Is Over!!!");
                        break;
                    case Action.Save:
                        action = Action.Default;
                        break;
                    case Action.Default:
                        break;
                    case Action.Retrieve:
                        break;
                    default: break;
                }

            }
            //петля закончилась
        }
    }
}
