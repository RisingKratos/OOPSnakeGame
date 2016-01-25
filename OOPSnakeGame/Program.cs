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

        }
    }
}
