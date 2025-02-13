using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Лаб_раб_9
{
    public class CarArray
    {
        static Random random = new Random();
        Car[]cars; //одномерный массив элементов типа Car
        static int count = 0;

        public int Length
        {
            get => cars.Length;
        }

        //Конструктор без параметров
        public CarArray()
        {
            cars = new Car[0];
            count++;
        }
        //Конструктор с параметрами, заполняющий элементы случайными значениями
        public CarArray(int length)
        {
            cars = new Car[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                cars[i] = new Car(random.Next(5, 20), random.Next(10, 70));
            }
            count++;
        }
        //Конструктор копирования, позволяющий создать копию коллекции, которая передается в конструктор как параметр, д.б. реализовано глубокое копирование
        public CarArray(CarArray other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            cars =  new Car[other.cars.Length];
            for (int i = 0; i < other.cars.Length; i++)
            {
                cars[i] = new Car(other.cars[i]);
            }

            count++;
        }
        //Метод для просмотра элементов массива
        public void PrintInfoCars()
        {
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
        //Посчет кол-ва созданных объектов и коллекций
        public static int GetCount => count;
    }
}
