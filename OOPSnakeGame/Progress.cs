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
                BinaryFormatter BinaryInstrument = new BinaryFormatter();
                FileStream snakeStream = new FileStream("snake.txt", FileMode.Open, FileAccess.Read);
                Snake snake = BinaryInstrument.Deserialize(snakeStream) as Snake;
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
                FileStream foodStream = new FileStream("food.txt", FileMode.Open, FileAccess.Read);
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
            try
            {
                
                if (File.Exists("snake.txt"))
                {
                    File.Delete("snake.txt");
                    BinaryFormatter BinaryInstrument = new BinaryFormatter();
                    
                    BinaryInstrument.Serialize(snakeStream, snake);
                }

                if (File.Exists("food.txt"))
                {
                    File.Delete("food.txt");
                    XmlSerializer XmlInstrument = new XmlSerializer(typeof(Food));
                    
                    XmlInstrument.Serialize(foodStream, food);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                snakeStream.Close();
                foodStream.Close();
            }

        }
        
    }
}
