using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Circle
    {
        struct Coords
        {
            public int x, y;
        }

        private Coords Center;
        private double Radius;
        private const double pi = 3.14;
        private double circum;

        public Circle() // конструктор по умолчанию
        {
            Center.x = 0;
            Center.y = 0;

            Radius = 1;

            Circumference();
        }

        public Circle(int x, int y, int r) // параметризированный конструктор
        {
            Center.x = x;
            Center.y = y;
           
            Radius = r;          

            Circumference();
        }

        public int GetCenterX() => Center.x; // Свойства для доступа к полям класса (только для чтения).
        public int GetCenterY() => Center.y; // Свойства для доступа к полям класса (только для чтения).
        public double GetRadius() => Radius; // Свойства для доступа к полям класса (только для чтения).

        public void Circumference() // определяем длину окружности
        {
            circum = 2 * Radius * pi;
        }

        public double GetCircumference() => circum;

        public void ChangeCoords(int x, int y) // метод для смены местаположения центра окружности
        {
            Center.x += x;
            Center.y += y;
        }

        public void ChangeRadius(int r) // метод для изминения радиуса
        {
            Radius += r;
        }

        public bool OneQuarterCoords() // метод для определения лежит ли окружность в одной координатной четверти
        {
            if (Center.x > 0 && Center.y > 0 && Radius < Center.x && Radius < Center.y)
                return true;
            else if (Center.x > 0 && Center.y < 0 && Radius < Center.x && Radius < Math.Abs(Center.y))
                return true;
            else if (Center.x < 0 && Center.y > 0 && Radius < Math.Abs(Center.x) && Radius < Center.y)
                return true;
            else if (Center.x < 0 && Center.y < 0 && Radius < Math.Abs(Center.x) && Radius < Math.Abs(Center.y))
                return true;
            else
                return false;
        }

        /// <summary>
        /// В метод CircleIntersection передаем обекты класса.
        /// В этом методе определяем пересечение окружностей
        /// две окружности пересекаются тогда и только тогда,
        /// когда расстояния между центрами меньше суммы их радиусов, но больше модуля их разности, 
        /// что мы и проверяем if-ом
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>

        public static bool CircleIntersection(Circle c1, Circle c2) // определяем пересечение окружностей
        {
            if (Math.Sqrt((c1.GetCenterX() - c2.GetCenterX()) * (c1.GetCenterX() - c2.GetCenterX()) +
                (c1.GetCenterY() - c2.GetCenterY()) * (c1.GetCenterY() - c2.GetCenterY())) < c1.GetRadius() + c2.GetRadius() &&
                Math.Sqrt((c1.GetCenterX() - c2.GetCenterX()) * (c1.GetCenterX() - c2.GetCenterX()) +
                (c1.GetCenterY() - c2.GetCenterY()) * (c1.GetCenterY() - c2.GetCenterY())) < Math.Abs(c1.GetRadius() - c2.GetRadius()))
                return true;
            else
                return false;
        }
    }
}
