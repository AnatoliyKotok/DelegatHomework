using System;

namespace DelegatHomework
{
    class Task_1
    {
        struct COORD
        {
            public int x { get; set; }
            public int y { get; set; }

            public COORD(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        class inT
        {
            public int i { get; set; }
            public inT(int i)
            {
                this.i = i;
            }
        }
        delegate bool MY_Predicate(object obj);
        static object Search(object[] obj, MY_Predicate pr)
        {

            return Array.Find(obj, pr.Invoke);
        }
        static bool DateTime_predicate(object obj)
        {
            return ((DateTime)obj).Year >= 2020;
        }
        static bool COORD_predicate(object obj)
        {
            return ((COORD)obj).x == ((COORD)obj).y;
        }
        static bool inT_predicate(object obj)
        {
            return ((inT)obj).i >= 7;
        }
        public static void main()
        {
            MY_Predicate[] pr = { DateTime_predicate, COORD_predicate, inT_predicate };
            object[] d = { new DateTime(1998, 4, 14), new DateTime(2020, 1, 1), new DateTime(1978, 1, 30) };
            Console.WriteLine((DateTime)Search(d, pr[0]));//  1/1/2020 12:00:00 AM
            object[] c = { new COORD(22, 14), new COORD(333, 333), new COORD(13, 2) };
            Console.WriteLine(((COORD)Search(c, pr[1])).x);// 333
            object[] i = { new inT(1), new inT(1234), new inT(2), new inT(3) };
            Console.WriteLine(((inT)Search(i, pr[2])).i);// 1234

        }
    }
    public class Task_2
    {
        abstract class Calculator
        {
            static Func<double, double, double> func;
            static void SetOperation(char operation)
            {
                switch (operation)
                {
                    case '+':
                        func = (x, y) => x + y;
                        break;
                    case '-':
                        func = (x, y) => x - y;
                        break;
                    case '*':
                        func = (x, y) => x * y;
                        break;
                    case '/':
                        func = (x, y) => x / y;
                        break;
                    default:
                        throw new ArgumentException("there is no such operator");
                }
            }
            public static double Calculate(double a, double b, char operation)
            {
                SetOperation(operation);
                return func(a, b);
            }
        }
        public static void main()
        {
            Console.WriteLine("5 + 7 = " + Calculator.Calculate(5, 7, '+'));
            Console.WriteLine("5 - 7 = " + Calculator.Calculate(5, 7, '-'));
            Console.WriteLine("5 * 7 = " + Calculator.Calculate(5, 7, '*'));
            Console.WriteLine("5 / 7 = " + Calculator.Calculate(5, 7, '/'));

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            Task_1.main();
            Console.WriteLine("\nTask 2");
            Task_2.main();
        }
    }

}
