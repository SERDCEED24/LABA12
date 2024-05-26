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
            if (HasElems(tree))
            {
                Console.WriteLine($"Количество листьев в дереве: {tree.NumberOfLeaves()}");
            }
        }
        static MyTree<Car> DeleteElementByData(MyTree<Car> tree)
        {
            if (HasElems(tree))
            {
                Car carToRemove = new Car();
                carToRemove.Init();
                bool isRemoved = tree.Remove(carToRemove);
                if (isRemoved)
                    Console.WriteLine("\nЭлемент был успешно удалён из дерева поиска!");
                else
                    Console.WriteLine("\nЭлемент не был найден в дереве поиска!");
            }
            return tree;
        }
        static MyTree<Car> CreateSearchTree(MyTree<Car> tree)
        {
            if (HasElems(tree))
            {
                MyTree<Car> searchTree = tree.Clone();
                searchTree.TransformToSearchTree();
                Console.WriteLine("Дерево поиска было сформировано.");
                return searchTree;
            }
            return new MyTree<Car>(0);
        }
        static void Main(string[] args)
        {
            string Menu = "\nВыберите действие с бинарным деревом:\n" +
                         "1. Сформировать дерево.\n" +
                         "2. Распечатать дерево.\n" +
                         "3. Найти количество листьев в дереве.\n" +
                         "4. Преобразовать идеально сбалансированное дерево в дерево поиска.\n" +
                         "5. Распечатать дерево поиска.\n" +
                         "6. Удалить из дерева поиска элемент с заданным ключом.\n" +
                         "7. Удалить дерево из памяти.\n" +
                         "8. Выход.\n";
            MyTree<Car> tree = new MyTree<Car>(0);
            MyTree<Car> searchTree = new MyTree<Car>(0);
            int response;
            do
            {
                Console.WriteLine(Menu);
                response = VHS.Input("Ошибка! Введите целое число от 1 до 8!", 1, 8);
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
                            searchTree = CreateSearchTree(tree);
                            break;
                        case 5:
                            if (searchTree.Count != 0)
                               searchTree.ShowTree();
                            else
                                Console.WriteLine("Ошибка! Попробуйте сформировать дерево поиска!");
                            break;
                        case 6:
                            if (searchTree.Count != 0)
                                searchTree = DeleteElementByData(searchTree);
                            else
                                Console.WriteLine("Ошибка! Попробуйте сформировать дерево поиска!");
                            break;
                        case 7:
                            if (HasElems(tree))
                            {
                                tree.Clear();
                                searchTree.Clear();
                                Console.WriteLine("Дерево удалено из памяти.");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } while (response != 8);
        }
    }
}
