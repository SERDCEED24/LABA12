using CarsLibrary;

namespace _12_1
{
    internal class Program
    {
        static MyList<Car> GenerateList()
        {
            Random rnd = new Random();
            Console.WriteLine("Введите длину списка:");
            int size = VHS.Input("Ошибка! Введите целое неотрицательное число!", 0);
            MyList<Car> list = new MyList<Car>();
            int typeOfCar;
            for (int i = 0; i < size; i++)
            {
                typeOfCar = rnd.Next(1, 5);
                switch(typeOfCar)
                {
                    case 1:
                        Car car = new Car();
                        car.RandomInit(); 
                        list.AddToEnd(car);
                        break;
                    case 2:
                        PassengerCar pcar = new PassengerCar();
                        pcar.RandomInit();
                        list.AddToEnd(pcar);
                        break;
                    case 3:
                        SUV suv = new SUV();
                        suv.RandomInit();
                        list.AddToEnd(suv);
                        break;
                    case 4:
                        Truck truck = new Truck();
                        truck.RandomInit();
                        list.AddToEnd(truck);
                        break;
                }
            }
            Console.WriteLine("\nСписок сгенерирован.");
            return list;
        }
        static MyList<Car> AddElementByNumber(MyList<Car> list)
        {
            Console.WriteLine("Введите номер добавляемого элемента:");
            int number = VHS.Input("Ошибка! Введите натуральное число не больше длины списка + 1!", 1, list.Count + 1);
            number--;
            Car Item = MyList<Car>.MakeRandomItem();
            if (number == 0)
            {
                list.AddToBegin(Item);
            }
            else if (number == list.Count)
            {
                list.AddToEnd(Item);
            }
            else
            {
                Point<Car> Data = new Point<Car>(Item);
                Point<Car>? current = list.GetBeg();
                for (int i = 0; i <= number; i++)
                {
                    if (i == number)
                    {
                        current.Prev.Next = Data;
                        Data.Prev = current.Prev;
                        Data.Next = current;
                        current.Prev = Data;
                    }
                    current = current.Next;
                }
            }
            Console.WriteLine("\nЭлемент добавлен.");
            return list;
        }
        static MyList<Car> DeleteElementsByData(MyList<Car> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пустой.");
            }
            else
            {
                Console.WriteLine("Введите данные элемента для удаления:");
                Car car = new Car();
                car.Init();
                Point<Car>? item = list.FindItem(car);
                if (item == null)
                {
                    Console.WriteLine("\nЭлемент с заданными данными не был найден.");
                }
                else
                {
                    if (item.Prev == null)
                    {
                        list.Clear();
                    }
                    else
                    {
                        item.Prev.Next = null;
                        item.Prev = null;
                    }
                    Console.WriteLine("\nЭлементы были успешно удалены из списка.");
                }
            }
            return list;
        }
        static void CloneAndPrint(MyList<Car> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пустой.");
            }
            else
            {
                MyList<Car> clone = list.Clone();
                Console.WriteLine("\nКлон:");
                clone.Print();
                clone.GetBeg().Data.RandomInit();
                Console.WriteLine("\nИзменённый клон:");
                clone.Print();
            }
        }
        static void Main(string[] args)
        {
            string Menu = "\nВыберите действие с двунаправленным списком:\n" +
                          "1. Сформировать список.\n" +
                          "2. Распечатать список.\n" +
                          "3. Добавить в список элемент с заданным номером.\n" +
                          "4. Удалить из списка все элементы, начиная с элемента с заданным информационным полем, и до конца списка.\n" +
                          "5. Выполнить глубокое клонирование списка и распечатать клон.\n" +
                          "6. Удалить список из памяти.\n" +
                          "7. Выход.\n";
            MyList<Car> list = new MyList<Car>();
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
                            list = GenerateList();
                            break;
                        case 2:
                            list.Print();
                            break;
                        case 3:
                            list = AddElementByNumber(list);
                            break;
                        case 4:
                            list = DeleteElementsByData(list);
                            break;
                        case 5:
                            CloneAndPrint(list);
                            break;
                        case 6:
                            list.Clear();
                            Console.WriteLine("Список удалён из памяти.");
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
