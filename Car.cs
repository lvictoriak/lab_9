using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_раб_9
{
    internal class Car
    {
        // Закрытые поля
        private double fuelFlow;
        private double fuelVolume;
        public double FuelFlow
        {
            get 
            {
                return fuelFlow; 
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Расход топлива не может быть отрицательным.");
                fuelFlow = value;
            }
        }

        public double FuelVolume
        {
            get 
            { 
                return fuelVolume; 
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Объем топлива не может быть отрицательным.");
                fuelVolume = value;
            }
        }

        // Конструктор без параметров
        public Car()
        {
            FuelFlow = 0;
            FuelVolume = 0;
        }

        // Конструктор с параметрами
        public Car(double fuelFlow, double fuelVolume)
        {
            FuelFlow = fuelFlow;
            FuelVolume = fuelVolume;
        }

        // Конструктор копирования
        public Car(Car other)
        {
            FuelFlow = other.FuelFlow;
            FuelVolume = other.FuelVolume;
        }

        // Метод для вычисления запаса хода
        public double CalculateRange()
        {
            if (FuelFlow == 0) 
                return 0;
            else
                return Math.Round(FuelVolume / FuelFlow * 100, 3);
        }

        // Статический метод для вычисления запаса хода
        public static double CalculateRangeStatic(Car car)
        {
            if (car.FuelFlow == 0) return 0;
            return Math.Round(car.FuelVolume / car.FuelFlow * 100, 3);
        }

        // Вывод информации об объекте
        public void PrintInfo()
        {
            Console.WriteLine($"Расход топлива: {FuelFlow} л/100км");
            Console.WriteLine($"Объем топлива: {FuelVolume} л");
            Console.WriteLine($"Запас хода: {CalculateRange()} км");
        }
    }
}
