using System;

namespace L7
{
    class Program
    {
        static void Calculate()
        {
            Console.Write("Input first number: ");
            RacionalNumber num1 = RacionalNumber.StringToRational(Console.ReadLine());
            Console.Write("Input second number: ");
            RacionalNumber num2 = RacionalNumber.StringToRational(Console.ReadLine());
            if (num1 == null || num2 == null)
            {
                Console.WriteLine("Input error");
                Console.ReadKey();
                return;
            }
            else
            {
                RacionalNumber a = num1 + num2;
                Console.WriteLine($"Addiction: {(int)(num1 + num2)} or {(double)(num1 + num2)} or {(num1 + num2).RationalToString()}");
                Console.WriteLine($"Subtraction: {(int)(num1 - num2)} or {(double)(num1 - num2)} or {(num1 - num2).RationalToString()}");
                Console.WriteLine($"Multiplication: {(int)(num1 * num2)} or {(double)(num1 * num2)} or {(num1 * num2).RationalToString()}");
                Console.WriteLine($"Division: {(int)(num1 / num2)} or {(double)(num1 / num2)} or {(num1 / num2).RationalToString()}");
                Console.WriteLine($"Comparison:");
                Console.WriteLine($"{num1.RationalToString()} < {num2.RationalToString()} --- {num1 < num2}");
                Console.WriteLine($"{num1.RationalToString()} > {num2.RationalToString()} --- {num1 > num2}");
                Console.WriteLine($"{num1.RationalToString()} <= {num2.RationalToString()} --- {num1 <= num2}");
                Console.WriteLine($"{num1.RationalToString()} >= {num2.RationalToString()} --- {num1 >= num2}");
                Console.WriteLine($"{num1.RationalToString()} == {num2.RationalToString()} --- {num1.Equals(num2)}");
                Console.WriteLine($"{num1.RationalToString()} != {num2.RationalToString()} --- {!num1.Equals(num2)}");
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Input two rational numbers and show all operation");
                Console.WriteLine("2. Exit");
                Console.WriteLine("Input your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Calculate();
                        break;
                    case 2:
                        return;
                }
            } while (choice != 2);
        }
    }
}