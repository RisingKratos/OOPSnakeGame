using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOPSnakeGame
{
    public class Progress
    {
        public Snake SnakeRetriever()    //как вернуть несколько объектов или ссылаться на объекты из главной функции
        {
            if (File.Exists("snake.txt"))
            {
                XmlSerializer XmlInstrument = new XmlSerializer(typeof(Snake));
                FileStream snakeStream = new FileStream("snake.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                Snake snake = XmlInstrument.Deserialize(snakeStream) as Snake;
                snakeStream.Close();
                return snake;
            }

            return new Snake(25, 25);

        }

        public Food FoodRetriever()
        {
            if (File.Exists("food.txt"))
            {
                XmlSerializer XmlInstrument = new XmlSerializer(typeof(Food));
                FileStream foodStream = new FileStream("food.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                Food food = XmlInstrument.Deserialize(foodStream) as Food;
                foodStream.Close();
                return food;
            }

            return new Food();
        }

        public void ProgressSaver(Snake snake, Food food)
        {
            FileStream snakeStream = new FileStream("snake.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream foodStream = new FileStream("food.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            XmlSerializer XmlInstrument = new XmlSerializer(typeof(Snake));

            Console.Write(snake.ToString());

            XmlInstrument.Serialize(snakeStream, snake);

            snakeStream.Close();

            XmlInstrument = new XmlSerializer(typeof(Food));

            XmlInstrument.Serialize(foodStream, food);

            foodStream.Close();

        }

    }
}
