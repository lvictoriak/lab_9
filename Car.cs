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
            if (other == null) throw new ArgumentNullException("other");
            FuelFlow = other.FuelFlow;
            FuelVolume = other.FuelVolume;
            count++;
        }

        // Метод для вычисления запаса хода
        public double CalculateRange()
        {
            double range = 0;
            if (FuelFlow == 0) 
                range = 0;
            else
                range = Logic.MathematicalRound(FuelVolume / FuelFlow * 100, 3);
            return range;
        }

        // Статический метод для вычисления запаса хода
        public static double CalculateRangeStatic(Car car)
        {
            double range = 0;
            if (car.FuelFlow == 0) range = 0;
            range = Logic.MathematicalRound(car.FuelVolume / car.FuelFlow * 100, 3);
            return range;
        }
        //Вывод информаиции об объекте
        public string PrintInfo(Car car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            return $"Расход топлива: {car.FuelFlow} л/100км." + $" Объем топлива: {car.FuelVolume} л." + $" Запас хода: {car.CalculateRange()} км.";
        }
        //Унарные операции

        public static Car operator ++(Car car)
        {
            Car car2 = new Car();
            car2.FuelFlow = car.FuelFlow;
            car2.FuelVolume = car.FuelVolume;
            if (car is null) throw new ArgumentNullException(nameof(car));
            else
                car2.FuelFlow += 0.1;
            return car2;
        }
        public static Car operator --(Car car)
        {
            Car car2 = new Car();
            car2.FuelFlow = car.FuelFlow;
            car2.FuelVolume = car.FuelVolume;
            if (car2 is null) throw new ArgumentNullException(nameof(car2));
            if (car2.FuelVolume > 1) car2.fuelVolume -= 1;
            else
                car2.fuelVolume = 0;
            return car2;
        }
        //Операции приведения типа
        public static explicit operator bool(Car car)
        {
            if (car is null) throw new ArgumentNullException(nameof(car));
            return car.CalculateRange() >= 100 && car.FuelVolume >= 5;
        }
        public static implicit operator double(Car car)
        {
            double res = 0;
            if (car is null) throw new ArgumentNullException(nameof(car));
            if (car.FuelVolume < 5) res = -1;
            else
                res = Logic.MathematicalRound((car.FuelVolume - 5) / car.FuelFlow,3);
            return res;
        }
        //Бинарные операции
        public static Car operator +(Car car, double liters)
        {
            Car car2 = new Car();
            car2.FuelFlow = car.FuelFlow;
            car2.FuelVolume = car.FuelVolume;
            if (car2 is null) throw new ArgumentNullException(nameof(car2));
            car2.FuelVolume += liters;
            return car2;
        }
        public static Car operator +(double liters, Car car)
        {
            Car car2 = new Car();
            car2.FuelFlow = car.FuelFlow;
            car2.FuelVolume = car.FuelVolume;
            if (car2 is null) throw new ArgumentNullException(nameof(car2));
            if (car2.FuelVolume < liters) car2.FuelVolume = 0;
            else
                car2.FuelVolume -= liters;
            return car2;
        }
        public static bool operator ==(Car car1, Car car2)
        {
            bool res = false;
            if (car1 is null && car2 is null) res = true;
            if (car1 is null || car2 is null) res = false;
            else 
                res = (car1.FuelFlow == car2.FuelFlow && car1.FuelVolume == car2.FuelVolume);
            return res;
        }
        public static bool operator !=(Car car1, Car car2)
        {
            return !(car1 == car2);
        }
        //Метод для сравнения двух объектов реализованного класса (для тестов)
        public bool Equals(object obj)
        {
            bool res = false;
            if (obj is Car other)
                res = this.FuelVolume == other.FuelVolume && this.FuelFlow == other.FuelFlow;
            return res;
        }
        public static int GetCount => count;
    }
}
