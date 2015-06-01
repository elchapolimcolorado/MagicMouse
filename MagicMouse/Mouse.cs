using System;
using System.Drawing;
using System.Windows.Forms;

namespace MagicMouse
{
    static class Mouse
    {
        private static double speed = 0.05;

        public static double Speed
        {
            get { return Mouse.speed; }
            set { Mouse.speed = value; }
        }

        public static void MoveMouse(double dx, double dy)
        {
            int x0 = Cursor.Position.X;
            int y0 = Cursor.Position.Y;
            int x1 = x0 - (int)Math.Round(dx * speed, 0, MidpointRounding.ToEven);
            int y1 = y0 - (int)Math.Round(dy * speed, 0, MidpointRounding.ToEven);
            BresenhamLineMouse(x0, y0, x1, y1);
        }

        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        private static void BresenhamLineMouse(int x0, int y0, int x1, int y1)
        {
            if (x0 == x1 && y0 == y1)
                return;

            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0); // Проверяем рост отрезка по оси икс и по оси игрек
            // Отражаем линию по диагонали, если угол наклона слишком большой
            if (steep)
            {
                Swap(ref x0, ref y0); // Перетасовка координат вынесена в отдельную функцию для красоты
                Swap(ref x1, ref y1);
            }

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2;  // Здесь используется оптимизация с умножением на dx, чтобы избавиться от лишних дробей
            int ystep = (y0 < y1) ? 1 : -1; // Выбираем направление роста координаты y
            int xstep = (x0 < x1) ? 1 : -1; // Выбираем направление роста координаты x
            int y = y0;
            int x = x0;
            while (x != x1)
            {
                x += xstep;
                Cursor.Position = new Point(steep ? y : x, steep ? x : y); // Не забываем вернуть координаты на место
                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }
    }
}