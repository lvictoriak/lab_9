using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_раб_9
{
    internal class Program
    {
        static Car CreateElem(double fuelVolume = 0, double fuelFlow = 0)
        { 
            try
            {
                Car c = new Car(fuelFlow, fuelVolume);
                Console.WriteLine($"Создан элемен Car. Расход топлива: {fuelFlow} л/100км.Объем топлива: {fuelVolume} л.");
                return c;
            }
            catch (Exception ArgumentException)
            {
                Console.WriteLine(ArgumentException.Message);
                return null;
            }
            
        }

        // Вывод информации об объекте
        static void PrintInfo(Car car)
        {
            Console.WriteLine($"Расход топлива: {car.FuelFlow} л/100км");
            Console.WriteLine($"Объем топлива: {car.FuelVolume} л");
            Console.WriteLine($"Запас хода: {car.CalculateRange()} км");
        }
        static void Main(string[] args)
        {
            Console.WriteLine(); 
            
            
            
            Car c1 = CreateElem(10, 25);
            PrintInfo(c1);
            Console.WriteLine(Car.GetCount);
            
        }
    }
}
