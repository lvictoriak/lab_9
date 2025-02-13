using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Лаб_раб_9
{
    public class Car
    {
        // Закрытые поля
        private double fuelFlow;
        private double fuelVolume;
        //Статическое поле для счета элементов
        static int count = 0;
        public double FuelFlow
        {
            get 
            {
                return fuelFlow; 
            }
            set
            {
                if (value < 0)
                {
                    fuelFlow = 0;
                    throw new ArgumentException("Расход топлива не может быть отрицательным.");
                }
                else
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
                {
                    fuelVolume = 0;
                    throw new ArgumentException("Объем топлива не может быть отрицательным.");
                }
                else
                    fuelVolume = value;
            }
        }

        // Конструктор без параметров
        public Car()
        {
            FuelFlow = 0;
            FuelVolume = 0;
            count++;
        }

        // Конструктор с параметрами
        public Car(double fuelFlow, double fuelVolume)
        {
            FuelFlow = fuelFlow;
            FuelVolume = fuelVolume;
            count++;
        }

        // Конструктор копирования
        public Car(Car other)
        {
            FuelFlow = other.FuelFlow;
            FuelVolume = other.FuelVolume;
            count++;
        }

        // Метод для вычисления запаса хода
        public double CalculateRange()
        {
            if (FuelFlow == 0) 
                return 0;
            else
                return Logic.MathematicalRound(FuelVolume / FuelFlow * 100, 3);
        }

        // Статический метод для вычисления запаса хода
        public static double CalculateRangeStatic(Car car)
        {
            if (car.FuelFlow == 0) return 0;
            return Math.Round(car.FuelVolume / car.FuelFlow * 100, 3);
        }
        //Унарные операции
        public static Car operator ++(Car car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            car.FuelFlow += 0.1;
            return car;
        }
        public static Car operator --(Car car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            if (car.FuelVolume > 1) car.fuelVolume -= 1;
            else
                car.fuelVolume = 0;
            return car;
        }
        //Операции приведения типа
        public static explicit operator bool(Car car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            return car.CalculateRange() >= 100 && car.FuelVolume >= 5;
        }
        public static implicit operator double(Car car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            if (car.FuelVolume < 5) return (-1);
            return Logic.MathematicalRound((car.FuelVolume - 5) / car.FuelFlow,3);
        }
        //Бинарные операции
        public static Car operator +(Car car, double liters)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            car.FuelVolume += liters;
            return car;
        }
        public static Car operator +(double liters, Car car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            if (car.FuelVolume < liters) car.FuelVolume = 0;
            else
                car.FuelVolume -= liters;
            return car;
        }
        public static bool operator ==(Car car1, Car car2)
        {
            if (car1 is null && car2 is null) return true;
            if (car1 is null || car2 is null) return false;
            return (car1.FuelFlow == car2.FuelFlow && car1.FuelVolume == car2.FuelVolume);
        }
        public static bool operator !=(Car car1, Car car2)
        {
            return !(car1 == car2);
        }
        //Метод для сравнения двух объектов реализованного класса (для тестов)
        public override bool Equals(object obj)
        {
            if (obj is Car other)
                return this.FuelVolume == other.FuelVolume && this.FuelFlow == other.FuelFlow;
            return false;
        }
        public static int GetCount => count;
    }
}
