using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;


namespace laba12part2
{
    class Program
    {
        static void Menu()
        {
            Console.WriteLine("----------Главное меню---------------");
            Console.WriteLine("1. Создать дерево.");
            Console.WriteLine("2. Добавить элементы.");
            Console.WriteLine("3. Просмотреть количество элементов в деревое (свой-во Count).");
            Console.WriteLine("4. Просмотреть демонстрацию клона.");
            Console.WriteLine("5. Просмотерть демонстрацию поверхностного копирования.");
            Console.WriteLine("6. Вывод дерева на экран.");
            Console.WriteLine("7. Удалить дерево из памяти.");
            Console.WriteLine("8. Проверить существование элемента.");
            Console.WriteLine("9. Выход.");
            Console.WriteLine("--------------------------------------");
        }

        static SearchTree<Person> CreateTree()
        {
            int size = ParseInt("Введите количество элементов: ");
            return new SearchTree<Person>(size);
        }

        static SearchTree<Person> AddElements(SearchTree<Person> sTr)
        {
            int size = ParseInt("Введите количество элементов: ");
            sTr.InsertMany(size);
            return sTr;
        }

        static void DemonstrClone(SearchTree<Person> sTr)
        {
            Console.WriteLine("Создадим клон нашего дерева.");
            SearchTree<Person> clone = sTr.CloneTree();
            Console.WriteLine("Добавим элемент и выведем на экран оба дерева (исходный и клон)");
            clone.InsertMany(1);
            Console.WriteLine("Исходный:");
            sTr.PrintTree(sTr.top, 10);
            Console.WriteLine("Клон:");
            clone.PrintTree(clone.top, 10);
            Console.WriteLine("Вывод: если что-то поменять в клоне, то это не изменится в исходном дереве - в этом суть глубокого клонирования.");
        }

        static void DemonstrCopy(SearchTree<Person> sTr)
        {
            Console.WriteLine("Создадим копию нашего дерева.");
            SearchTree<Person> copy = sTr.Copy();
            Console.WriteLine("Добавим элемент и выведем на экран оба дерева (исходный и копия)");
            copy.InsertMany(1);
            Console.WriteLine("Исходный:");
            sTr.PrintTree(sTr.top, 10);
            Console.WriteLine("Копия:");
            copy.PrintTree(copy.top, 10);
            Console.WriteLine("Вывод: если что-то поменять в копии, то это изменится в исходном дереве - в этом проблема поверхностного копирования.");
        }

        static void CheckExistance(SearchTree<Person> sTr)
        {
            int age = ParseInt("Введите возраст, который хотите проверить: ");
            Console.WriteLine("Ответ: " + sTr.Exists(age, sTr.top));
        }

        static void Print(SearchTree<Person> sTr)
        {
            if (sTr.top == null)
                Console.WriteLine("Дерево пусто!");
            else
                sTr.PrintTree(sTr.top, 10);
        }

        static void Main(string[] args)
        {
            bool finish = false;
            int i;
            SearchTree<Person> tree = new SearchTree<Person>();

            while (!finish)
            {
                Menu();
                i = ParseInt("Ваш выбор: ");
                switch (i)
                {
                    case 1:
                        tree = CreateTree();
                        Print(tree);
                        break;
                    case 2:
                        tree = AddElements(tree);
                        Print(tree);
                        break;
                    case 3:
                        Print(tree);
                        Console.WriteLine("Количество элементов в дереве = " + tree.Count);
                        break;
                    case 4:
                        DemonstrClone(tree);
                        break;
                    case 5:
                        DemonstrCopy(tree);
                        break;
                    case 6:
                        Print(tree);
                        break;
                    case 7:
                        tree.Delete();
                        break;
                    case 8:
                        Print(tree);
                        CheckExistance(tree);
                        break;
                    case 9:
                        finish = true;
                        break;
                    case 10:
                        tree.DeleteLeaves(tree.top);
                        Print(tree);
                        break;
                    default:
                        Console.WriteLine("Данного пункта нет в меню!");
                        break;
                }
            }
        }

        static int ParseInt(string input)
        {
            int n;
            bool ok;
            Console.Write(input);
            do
            {
                string str = Console.ReadLine();
                ok = int.TryParse(str, out n);
                if (!((ok) && (n >= 0)))
                {
                    ok = false;
                    Console.WriteLine("Число должно быть целым и неотрицательным!");
                }
            }
            while (!ok);
            return n;
        }

        static double ParseDouble(string input)
        {
            double n;
            bool ok;
            Console.WriteLine(input);
            do
            {
                string str = Console.ReadLine();
                ok = double.TryParse(str, out n);
                if (!ok)
                    Console.WriteLine("Число должно быть целым!");
            }
            while (!ok);
            return n;
        }
    }
}
