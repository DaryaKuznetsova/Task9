using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class Program
    {
        class Point
        {
            public int data;
            public Point next, pred;
            public Point()
            {
                data = 0;
                next = null;
                pred = null;
            }

            public Point(int d)
            {
                data = d;
                next = null;
                pred = null;
            }

            public override string ToString()
            {
                return data + " ";
            }
        }

        static Random rnd = new Random();

        static Point MakePoint(int name)
        {
            Point p = new Point(name);
            return p;
        }

        static Point MakeList2(int size, bool rand) //формирование двунаправленного списка
                                                     //добавление в начало
        {
            int info = 0;
           
            if (size == 0) return null;
            if (size != 0)
            {
                if (rand)
                    info = rnd.Next(0, 100);
                else
                {
                    Console.WriteLine("введите элементы списка");
                    info = ReadAnswer();
                }
            }
            Point beg = MakePoint(info);
            for (int i = 1; i < size; i++)
                beg = AddPointToEnd(beg, rand);

            Console.WriteLine("список сформирован");
            return beg;
        }

        static Point AddPointToEnd(Point beg, bool rand)
        {
            int info = 0;
            if (rand)
                info = rnd.Next(0, 100);
            else
                info = ReadAnswer();

            Point p = MakePoint(info); // выделяем память для нового элемента
            Point buf = beg;
            while (buf.next != null) buf = buf.next;
            buf.next = p;
            p.pred = buf;
            buf = p;

            return beg;
        } //добавить элемент в конец списка
        

        static void ShowList(Point beg)
        {

            Point p = beg;
            if (beg != null)
            {
                while (p.next != null)
                {
                    Console.Write(p);
                    p = p.next;
                }
                Console.Write(p);
                Console.WriteLine();
            }
            else Console.WriteLine("список пуст");
        }

        static int Total(Point beg)
        {
            int result = 0;
            int del2 = 0;
            int del = 0;
            if (beg != null)
            {
                Point p = beg;
                while (p != null)
                {
                    if (p.data % 2 == 0) del2 += p.data;
                    else del += p.data;
                    p = p.next;
                }
                result = Math.Abs(del - del2);
            }
            else Console.WriteLine("список пуст");
            return result;
        }

        public static int ReadAnswer()
        {
            int a = 0;
            bool ok = false;
            do
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Пожалуйста, введите целое число.");
                    ok = false;
                }
            } while (!ok);
            return a;
        }


        static void Main(string[] args)
        {
            Point p = new Point();
            p = MakeList2(5, true);
            ShowList(p);
            int r = Total(p);
            Console.WriteLine(r);
        }
    }
}
