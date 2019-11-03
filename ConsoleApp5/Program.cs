using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();

            Console.WriteLine("Первая окружность задается по умолчанию.");
            
            Console.WriteLine("Введите координаты 2-ой окружности.");
            Console.Write("x2: ");
            int x2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y2: ");
            int y2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите радиус второй окружности: ");
            int r2 = Convert.ToInt32(Console.ReadLine());
            bool flag2 = true;
            while(flag2)
            {
                if (r2 <= 0)
                {
                    Console.WriteLine("Радиус должен быть больше 0");
                    Console.Write("Введите радиус: ");
                    r2 = Convert.ToInt32(Console.ReadLine());
                    flag2 = true;
                }
                else
                    flag2 = false;
            }

            Circle c2 = new Circle(x2, y2, r2);

            Console.WriteLine("Введите координаты 3-ей окружности.");
            Console.Write("x3: ");
            int x3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y3: ");
            int y3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите радиус 3-ей окружности: ");
            int r3 = Convert.ToInt32(Console.ReadLine());
            bool flag3 = true;
            while (flag3)
            {
                if (r3 <= 0)
                {
                    Console.WriteLine("Радиус должен быть больше 0");
                    Console.Write("Введите радиус: ");
                    r3 = Convert.ToInt32(Console.ReadLine());
                    flag3 = true;
                }
                else
                    flag3 = false;
            }

            Circle c3 = new Circle(x3, y3, r3);

            printHead();
            printMiddle();
            Console.Write("║  1  ║");
            printCircleParametrs(c1);
            IsOneQuart(c1);

            printMiddle();
            Console.Write("║  2  ║");
            printCircleParametrs(c2);
            IsOneQuart(c2);

            printMiddle();
            Console.Write("║  3  ║");
            printCircleParametrs(c3);
            IsOneQuart(c3);
            printEnd();

            Console.WriteLine("Проверка на пересечение окружностей");
            Console.WriteLine("1-ая и 2-ая: ");
            IsIntersection(c1, c2);
            Console.WriteLine("2-ая и 3-ая: ");
            IsIntersection(c2, c3);
            Console.WriteLine("1-ая и 3-ая: ");
            IsIntersection(c1, c3);

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Вы можете изменить параметры 1-ой окружности");
            Console.WriteLine("Что вы хотите изменить\n 1 - координаты центра окружности\n 2 - радиус окружности");
            Console.WriteLine("Любой другой выбор оставит все без изменения!");
            Console.Write("Ваш выбор: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите координаты центра 1-ой окружности");
                    Console.Write("x1: ");
                    int x1 = int.Parse(Console.ReadLine());
                    Console.Write("y1: ");
                    int y1 = int.Parse(Console.ReadLine());
                    c1.ChangeCoords(x1, y1);
                    break;
                case 2:
                    Console.WriteLine("Введите радиус 1-ой окружности");
                    Console.Write("r1: ");
                    int r1 = int.Parse(Console.ReadLine());
                    c1.ChangeRadius(r1);
                    break;
                default:
                    Console.WriteLine("Вы оставили параметры 1-ой окружности без изменения");
                    break;
            }

            Console.WriteLine("Координаты 1-ой окружности!");
            printHead();
            printMiddle();
            Console.Write("║  1  ║");
            printCircleParametrs(c1);
            IsOneQuart(c1);
            printEnd();
        }

        static void printHead() // шапка
        {
            Console.WriteLine("╔═════╦═════════════╦════════╦═════════╦═════════════════════════╗");
            Console.WriteLine("║№п/п ║    Центр    ║ Радиус ║  Длина  ║     Лежит ли в 1-ой     ║");
            Console.WriteLine("║     ║             ║        ║         ║  координатной плоскости ║");
        }

        static void printMiddle() // середина
        {
            Console.WriteLine("╠═════╬═════════════╬════════╬═════════╬═════════════════════════╣");
        }

        static void printEnd() // конец
        {
            Console.WriteLine("╚═════╩═════════════╩════════╩═════════╩═════════════════════════╝");
        }

        static void printCircleParametrs(Circle c) // координаты Центра окружности
        {
            Console.Write($"  ({c.GetCenterX(),2};{c.GetCenterY(),2})    ║    {c.GetRadius(),1}   ║  {c.GetCircumference(),2:f2}   ║");
        }

        static void IsOneQuart(Circle c)
        {
            if (c.OneQuarterCoords())
                Console.WriteLine("           ДА!           ║");
            else
                Console.WriteLine("           НЕТ!          ║");
        }

        static void IsIntersection(Circle c1, Circle c2)
        {
            if (!Circle.CircleIntersection(c1, c2))
                Console.WriteLine("Пересекаются");
            else
                Console.WriteLine("Непересекаются");
        }
    }
}
