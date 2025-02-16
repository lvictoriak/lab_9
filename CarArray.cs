using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        //Конструктор с параметрами, заполняющийся ручным вводом
        public CarArray(int length, double[] flows, double[] volumes)
        {
            cars = new Car[length];
            for (int i = 0; i < length; i++)
            {
                cars[i] = new Car(flows[i], volumes[i]);
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
        //Вывод информации
        public string PrintInfo(CarArray cars)
        {
            string res = "";
            if (cars == null) res = "Массив пустой";
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i]  == null) res += $"Элемент {i+1} отсутствует. \n";
                res += cars[i].PrintInfo(cars[i]) + "\n";
            }
            return res;
        }
        //Индексатор
        public Car this[int index]
        {
            get
            {
                if (index < 0 || index >= cars.Length)
                    throw new IndexOutOfRangeException("Индекс вне допустимого диапазона.");
                return cars[index];
            }
            set
            {
                if (index < 0 || index >= cars.Length)
                    throw new IndexOutOfRangeException("Индекс вне допустимого диапазона.");
                cars[index] = value;
            }
        }
        //Подсчет кол-ва созданных объектов и коллекций
        public static int GetCount => count;
    }
}
