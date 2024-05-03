using CarsLibrary;

namespace _12_2
{
    internal class Program
    {
        static MyHashTable<Car> GenerateHashTable()
        {
            Console.WriteLine("Введите кол-во элементов в таблице:");
            int size = VHS.Input("Ошибка! Введите целое неотрицательное число!", 0);
            MyHashTable<Car> table = new MyHashTable<Car>(size);
            for (int i = 0; i < size; i++)
            {
                Car tempCar = new Car();
                tempCar.RandomInit();
                table.AddItem(tempCar);
            }
            Console.WriteLine("\nТаблица сгенерирована.");
            return table;
        }
        static MyHashTable<Car> AddElement(MyHashTable<Car> table)
        {
            Car carToAdd = new Car();
            carToAdd.RandomInit();
            table.AddItem(carToAdd);
            Console.WriteLine("Элемент успешно добавлен в таблицу.");
            return table;
        }
        static MyHashTable<Car> DeleteElementByData(MyHashTable<Car> table)
        {
            if (table.Count == 0)
            {
                Console.WriteLine("Таблица пустая!");
            }
            else
            {
                Car carForDeletion = new Car();
                carForDeletion.Init();
                if (table.RemoveData(carForDeletion))
                {
                    Console.WriteLine("\nЭлемент был удалён из таблицы.");
                }
                else
                {
                    Console.WriteLine("\nЭлемент не содержится в таблице!");
                }
            }
            return table;
        }
        static void Search(MyHashTable<Car> table)
        {
            if (table.Count == 0)
            {
                Console.WriteLine("Таблица пустая!");
            }
            else
            {
                Car carToSearch = new Car();
                carToSearch.Init();
                int index = table.FindItem(carToSearch);
                if (index == -1)
                {
                    Console.WriteLine("\nЭлемент не был найден в таблице.");
                }
                else
                {
                    Console.WriteLine($"\nЭлемент был найден в таблице и находится на {index + 1} позиции.");
                }
            }
        }
        static void Main(string[] args)
        {
            string Menu = "\nВыберите действие с хеш-таблицей:\n" +
                         "1. Сформировать таблицу.\n" +
                         "2. Распечатать таблицу.\n" +
                         "3. Добавить элемент в таблицу.\n" +
                         "4. Удалить элемент из таблицы.\n" +
                         "5. Найти элемент в таблице.\n" +
                         "6. Вывести на экран Capacity и Count.\n" +
                         "7. Выход.\n";
            MyHashTable<Car> table = new MyHashTable<Car>(0);
            int response;
            do
            {
                Console.WriteLine(Menu);
                response = VHS.Input("Ошибка! Введите целое число от 1 до 7!", 1, 7);
                Console.WriteLine();
                try
                {
                    switch (response)
                    {
                        case 1:
                            table = GenerateHashTable();
                            break;
                        case 2:
                            table.Print();
                            break;
                        case 3:
                            table = AddElement(table);
                            break;
                        case 4:
                            table = DeleteElementByData(table);
                            break;
                        case 5:
                            Search(table);
                            break;
                        case 6:
                            Console.WriteLine($"Capacity: {table.Capacity}; Count: {table.Count}");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } while (response != 7);
        }
    }
}
