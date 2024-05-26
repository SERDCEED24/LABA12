using CarsLibrary;
using System.Collections.Immutable;
namespace _12_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание коллекций разных типов
            MyCollection<Car> carCollection = new MyCollection<Car>();
            MyCollection<PassengerCar> passengerCarCollection = new MyCollection<PassengerCar>(5);
            MyCollection<SUV> suvCollection = new MyCollection<SUV>(3);
            MyCollection<Truck> truckCollection = new MyCollection<Truck>();

            // Демонстрация добавления элементов
            Console.WriteLine("Добавление элементов в коллекцию Car:");
            for (int i = 0; i < 5; i++)
            {
                Car car = new Car();
                car.RandomInit();
                carCollection.Add(car);
                Console.WriteLine(car);
            }

            Console.WriteLine("\nДобавление элементов в коллекцию Truck:");
            for (int i = 0; i < 3; i++)
            {
                Truck truck = new Truck();
                truck.RandomInit();
                truckCollection.Add(truck);
                Console.WriteLine(truck);
            }

            // Демонстрация метода Contains
            Console.WriteLine("\nПроверка наличия элемента в коллекции Car:");
            Car checkCar = carCollection.ToArray()[0];
            if (checkCar != null)
            {
                Console.WriteLine($"Содержит ли коллекция {checkCar}? {carCollection.Contains(checkCar)}");
            }

            // Демонстрация метода Remove
            Console.WriteLine("\nУдаление элемента из коллекции Car:");
            if (checkCar != null)
            {
                Console.WriteLine($"Удаление {checkCar}");
                carCollection.Remove(checkCar);
            }

            // Демонстрация метода CopyTo
            Console.WriteLine("\nКопирование элементов коллекции Truck в массив:");
            Truck[] truckArray = new Truck[truckCollection.Count];
            truckCollection.CopyTo(truckArray, 0);
            foreach (Truck truck in truckArray)
            {
                Console.WriteLine(truck);
            }

            // Демонстрация метода Clear
            Console.WriteLine("\nОчистка коллекции Car:");
            carCollection.Clear();
            Console.WriteLine($"Количество элементов в коллекции Car после очистки: {carCollection.Count}");

            // Демонстрация перебора коллекции с использованием foreach
            Console.WriteLine("\nПеребор коллекции PassengerCar с использованием foreach:");
            foreach (PassengerCar passengerCar in passengerCarCollection)
            {
                Console.WriteLine(passengerCar);
            }

            Console.WriteLine("\nПеребор коллекции SUV с использованием foreach:");
            foreach (SUV suv in suvCollection)
            {
                Console.WriteLine(suv);
            }
        }
    }
}
