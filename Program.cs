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
            Console.WriteLine();
        }
        static string PrintInfo1(Car car)
        {
            return $"Расход топлива: {car.FuelFlow} л/100км." + $" Объем топлива: {car.FuelVolume} л." + $" Запас хода: {car.CalculateRange()} км.";
        }
        //Вывод элементов массива
        static void PrintInfoCars(CarArray cars)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(PrintInfo1(cars[i]));
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int answer = 0; //ответ для демонстрационного меню
            bool isReadAnswer = false; //для проверки ввода ответа

          
            do
            {
                Console.WriteLine("1. First part. Demonstrate");
                Console.WriteLine("2. Second part. Demonstarte");
                Console.WriteLine("3. Third part. Demonstrate");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                do
                {
                    isReadAnswer = int.TryParse(Console.ReadLine(), out answer);
                    if (answer < 1) isReadAnswer = false;
                    if (answer > 4) isReadAnswer = false;
                    if (!isReadAnswer)
                        Console.WriteLine("Ошибка при вводе пункта меню, попробуйте снова. Выбирайте только из предложенных, от 1 до 4.");
                } while (!isReadAnswer);

                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Создание элемента типа конструктором без параметров");
                        Car car1 = new Car();
                        PrintInfo(car1);

                        Console.WriteLine("Создание элемента типа конструктором с параметрами");
                        Car car2 = CreateElem(10, 10);
                        PrintInfo(car2);

                        Console.WriteLine("Проверка создания элемента с некорректными данными");
                        Car car3 = CreateElem(-10, 10);
                        Console.WriteLine();
                        
                        Console.WriteLine("Использование конструктора копирования");
                        Car car4 = new Car(car2);
                        PrintInfo(car4);

                        Console.WriteLine("Вычисления запаса хода");
                        Car carToCalcRange = CreateElem(14, 50);
                        Console.WriteLine($"Запас хода = { carToCalcRange.CalculateRange()}");
                        Console.WriteLine();

                        Console.WriteLine("Вычиление запаса хода статической функцией");
                        Car carToCalcRangeSt = CreateElem(14, 50);
                        Console.WriteLine($"Запас хода = {Car.CalculateRangeStatic(carToCalcRangeSt)}");
                        Console.WriteLine();

                        Console.WriteLine("Вывод кол-ва созданных элементов");
                        Console.WriteLine($"Кол-во созданных элементов = {Car.GetCount}");
                        break;
                    case 2:
                        Console.WriteLine("Унарные операции");
                        Console.WriteLine("Демонстрация операции ++(увеличение расхода топлива на 0,1 л/100 км)");
                        Car car10 = CreateElem(10, 10);
                        car10 = car10++;
                        PrintInfo(car10);

                        Console.WriteLine("Демонстрация операции --(уменьшение топлива в баке на 1 л, при условии что оно не уйдет в минус");
                        Car car11 = CreateElem(10, 10);
                        car11 = car11--;
                        PrintInfo(car11);
                        Console.WriteLine();
                        
                        Console.WriteLine("Операции типа приведения");
                        Console.WriteLine("Операции bool, правда, true, если автомобиль сможет доехать до заправки (до заправки ровно 100 км), а в баке в момент заправки останется не меньше 5 л топлива, иначе – false");
                        Car car12 = new Car(10, 30);
                        Console.WriteLine("Элемент, над которым выполняет операцию");
                        PrintInfo(car12);
                        if ((bool)car12) Console.WriteLine("Сможет доехать до заправки");
                        else
                            Console.WriteLine("Не сможет доехать до заправки");
                        Console.WriteLine();

                        Console.WriteLine("Операция double, результат - количество сотен километров до заправки, чтобы в момент заправки в баке осталось ровно 5 л топлива. Если в момент расчёта в баке меньше 5 л топлива, значит результатом операции будет число\r\n-1\r\n");
                        Console.WriteLine("Элемент, над которым выполняет операцию");
                        PrintInfo(car12);
                        if ((double)car12 == -1) Console.WriteLine("Доехать до заправки авто не сможет");
                        else
                            Console.WriteLine($"До заправки сможет проехать {(double)car12} сотен километров, чтобы в момент заправки осталось 5 литров в баке");
                        Console.WriteLine();
                        
                        Console.WriteLine("Бинарные операции");
                        Console.WriteLine("+, левосторонняя операция добавления некоторого кол-ва литров топлива");
                        Console.WriteLine("Элемент, над которым выполняет операцию");
                        PrintInfo(car12);
                        Console.WriteLine("Выполняем операцию, добавим 10 л");
                        car12 = car12 + 10;
                        PrintInfo(car12);
                        Console.WriteLine();

                        Console.WriteLine("+, правосторонняя операция уменьшения расхода топлива на заданное число");
                        Console.WriteLine("Элемент, над которым выполняет операцию");
                        PrintInfo(car12);
                        Console.WriteLine("Выполняем операцию, уменьшим расход топлива на 2 л/100 км");
                        car12 = 2 + car12;
                        PrintInfo(car12);
                        Console.WriteLine();

                        Console.WriteLine("==, автомобили имеют равные возможности, если равны их атрибуты");
                        Console.WriteLine("Первый авто для сравнений");
                        PrintInfo(car11);
                        Console.WriteLine("Второй авто для сравнений");
                        PrintInfo(car12);
                        if (car11 == car12) Console.WriteLine("Автомобилии равносильны");
                        else
                            Console.WriteLine("Автомобили не равносильны");
                        Console.WriteLine();

                        Car car12Copy = new Car(car12);
                        Console.WriteLine("Первый авто для сравнений");
                        PrintInfo(car12Copy);
                        Console.WriteLine("Второй авто для сравнений");
                        PrintInfo(car12);
                        if (car12Copy == car12) Console.WriteLine("Автомобилии равносильны");
                        else
                            Console.WriteLine("Автомобили не равносильны");
                        Console.WriteLine();

                        Console.WriteLine("!=, автомобили не равносильны, если не равны их атрибуты");
                        Console.WriteLine("Первый авто для сравнений");
                        PrintInfo(car11);
                        Console.WriteLine("Второй авто для сравнений");
                        PrintInfo(car12);
                        if (car11 != car12) Console.WriteLine("Автомобилии не равносильны");
                        else
                            Console.WriteLine("Автомобили равносильны");
                        Console.WriteLine();

                        Console.WriteLine("Первый авто для сравнений");
                        PrintInfo(car12Copy);
                        Console.WriteLine("Второй авто для сравнений");
                        PrintInfo(car12);
                        if (car12Copy != car12) Console.WriteLine("Автомобилии не равносильны");
                        else
                            Console.WriteLine("Автомобили равносильны");
                        Console.WriteLine();

                        break;
                    case 3:
                        Console.WriteLine("Создание коллекции");
                        CarArray cars = new CarArray(5);
                        PrintInfoCars(cars);

                        Console.WriteLine("Копирование коллекции");
                        CarArray carsCopy = new CarArray(cars);
                        PrintInfoCars(carsCopy);

                        Console.WriteLine("Проверка работы индексатора. Вывод первого эоемеента и попытка вывода 6 в коллекции из 5 элементов");
                        try
                        {
                            PrintInfo(cars[0]);
                            PrintInfo(cars[6]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine();

                        Console.WriteLine("Нахождение автомобиля с наименьшим запасом хода");
                        PrintInfoCars(cars);
                        Car minRangeCar = cars.FindCarMinimumRange();
                        Console.WriteLine(minRangeCar);
                        Console.WriteLine();
                        break;
                }
            } while (answer < 4);
            
            
            
            Car c1 = CreateElem(10, 25);
            PrintInfo(c1);
            Console.WriteLine(Car.GetCount);
            Car car5 = CreateElem(-10, 10);

        }
    }
}
