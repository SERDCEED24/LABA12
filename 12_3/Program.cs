using CarsLibrary;

namespace _12_3
{
    internal class Program
    {
        static bool HasElems(MyTree<Car> tree)
        {
            if (tree.Count == 0)
            {
                Console.WriteLine("Дерево пустое! Сначала сформируйте его!");
                return false;
            }
            else
            {
                return true;
            }
        }
        static MyTree<Car> GenerateTree()
        {
            Console.WriteLine("Введите кол-во элементов в дереве:");
            int size = VHS.Input("Ошибка! Введите целое неотрицательное число!", 0);
            MyTree<Car> tree = new MyTree<Car>(size);
            Console.WriteLine("\nДерево сгенерировано.");
            return tree;
        }
        static void PrintNumberOfLeaves(MyTree<Car> tree)
        {
            Console.WriteLine($"Количество листьев в дереве: {tree.NumberOfLeaves()}");
        }
        static MyTree<Car> DeleteElementByData(MyTree<Car> tree)
        {
            Console.WriteLine();
            return tree;
        }
        static void Main(string[] args)
        {
            string Menu = "\nВыберите действие с бинарным деревом:\n" +
                         "1. Сформировать дерево.\n" +
                         "2. Распечатать дерево.\n" +
                         "3. Найти количество листьев в дереве.\n" +
                         "4. Преобразовать идеально сбалансированное дерево в дерево поиска.\n" +
                         "5. Удалить из дерева поиска элемент с заданным ключом.\n" +
                         "6. Удалить дерево из памяти.\n" +
                         "7. Выход.\n";
            MyTree<Car> tree = new MyTree<Car>(0);
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
                            tree = GenerateTree();
                            break;
                        case 2:
                            if (HasElems(tree))
                                tree.ShowTree();
                            break;
                        case 3:
                            PrintNumberOfLeaves(tree);
                            break;
                        case 4:
                            tree = DeleteElementByData(tree);
                            break;
                        case 5:
                            tree = DeleteElementByData(tree);
                            break;
                        case 6:
                            tree = DeleteElementByData(tree);
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
