using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matan_3_Console
{
    class Program
    {
        public static double function(double variable, double val1, double val2, double val3)
        {
            return val1 * Math.Pow(variable, 3) + val2 * Math.Sin(variable) + val3;
        }

        static void Main(string[] args)
        {
            int str_num2 = 3;
            Console.WriteLine($"val1 * x^3 + val2 * sin(x) + val3 = 0");

            double value1, value2, value3;
            Console.Write($"\nval1 = ");
            value1 = double.Parse(Console.ReadLine());
            Console.Write($"val2 = ");
            value2 = double.Parse(Console.ReadLine());
            Console.Write($"val3 = ");
            value3 = double.Parse(Console.ReadLine());

            double epsilon;
            Console.Write($"\nEpsilon = ");
            epsilon = double.Parse(Console.ReadLine());

            bool ifA = false;
            bool ifB = false;

            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());

            double[,] table = new double[str_num2, 2];
            table[0, 0] = a;
            table[0, 1] = function(table[0, 0], value1, value2, value3);
            table[1, 0] = b;
            table[1, 1] = function(table[1, 0], value1, value2, value3);

            double f_a = table[0, 1];
            double f_b = table[1, 1];

            double f1_a = value1 * 3 * Math.Pow(a, 2) + value2 * Math.Cos(a);
            double f1_b = value1 * 3 * Math.Pow(b, 2) + value2 * Math.Cos(b);

            double f2_a = value1 * 6 * a + value2 * (-Math.Sin(a));
            double f2_b = value1 * 6 * b + value2 * (-Math.Sin(b));

            if (f_a * f_b < 0)
            {
                if (f_a < 0 && f_b > 0 && f2_b > 0)
                {
                    ifA = true;
                }
                if (f_a > 0 && f_b < 0 && f2_a > 0)
                {
                    ifB = true;
                }
                if (f_a > 0 && f_b < 0 && f2_b < 0)
                {
                    ifA = true;
                }
                if (f_a < 0 && f_b > 0 && f2_a < 0)
                {
                    ifB = true;
                }
                if (ifA)
                {
                    table[str_num2 - 1, 0] = table[0, 0] - (table[0, 1] / (table[1, 1] - table[0, 1])) * (table[1, 0] - a);
                }
                if (ifB)
                {
                    table[str_num2 - 1, 0] = table[1, 0] - table[1, 1] / (table[1, 1] - table[0, 1]) * (b - table[0, 0]);
                }
                table[str_num2 - 1, 1] = function(table[str_num2 - 1, 0], value1, value2, value3);

                while (true)
                {
                    str_num2++;
                    double[,] auxtable = new double[str_num2, 2];
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        for (int j = 0; j < table.GetLength(1); j++)
                        {
                            auxtable[i, j] = table[i, j];
                        }
                    }
                    if (ifA)
                    {
                        auxtable[str_num2 - 1, 0] = auxtable[str_num2 - 2, 0] - (auxtable[str_num2 - 2, 1] / 
                            (auxtable[0, 0]) - auxtable[str_num2 - 2, 1]) * (b - auxtable[str_num2 - 2, 0]);
                    }
                    if (ifB)
                    {
                        auxtable[str_num2 - 1, 0] = auxtable[str_num2 - 2, 0] - (auxtable[str_num2 - 2, 1] / 
                            (auxtable[str_num2 - 2, 1] - auxtable[0, 1])) * (auxtable[str_num2 - 2, 0] - a);
                    }
                    auxtable[str_num2 - 1, 1] = function(auxtable[str_num2 - 1, 0], value1, value2, value3);

                    table = new double[str_num2, 2];
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        for (int j = 0; j < table.GetLength(1); j++)
                        {
                            table[i, j] = auxtable[i, j];
                        }
                    }
                    if (table[str_num2 - 1, 1] < epsilon && table[str_num2 - 1, 1] > -epsilon)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine();
            if (f_a * f_b < 0)
            {
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        Console.Write(table[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"\nAnswer: {table[str_num2 - 1, 0]}");
            }
            else
            {
                Console.WriteLine($"f(a) * f(b) > 0");
            }
            Console.ReadKey();
        }
    }
}
