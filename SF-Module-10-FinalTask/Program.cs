using System;

namespace SF_Module_10_FinalTask
{
    class Program
    {
        static ILogger Logger { get; set; }

        static void Main(string[] args)
        {
            while (true)
            {
                int a = GetNumber("Enter first number (A): ");
                int b = GetNumber("Enter second number (B): ");

                Calc calc = new Calc();
                Console.WriteLine($"    Result: {a} + {b} = {calc.Sum(a, b)}\n");
            }            
        }

        static int GetNumber(string message)
        {
            Logger = new Logger();
            var worker = new Worker(Logger);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                try
                {                    
                    int num = Convert.ToInt32(Console.ReadLine());
                    worker.Work(num);
                    return num;
                }
                catch (Exception ex)
                {
                    worker.ErrorMessage(ex);
                }
            }
        }
    }

    public interface ICalc
    {
        public int Sum(int a, int b);       
    }

    public class Calc : ICalc
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        public void Event(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message)
        {
            Console.WriteLine(message);
        }        
    }

    public interface IWorker
    {
        void Work(int num);
    }
}

