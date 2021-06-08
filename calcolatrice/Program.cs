using System;

namespace calcolatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var operazione = Console.Readline();
        }
    }

    interface IOperation 
    {
        double Execute(int a, int b);
    }

    class Somma :IOperation
    {
        public double Execute(int a,int b)
        {
           throw new NotImplementedException();
        }
    }

    class Sottrazione :IOperation
    {
        public double Execute(int a,int b)
        {
           throw new NotImplementedException();
        }
    }

    class Moltiplicazione :IOperation
    {
        public double Execute(int a,int b)
        {
           throw new NotImplementedException();
        }
    }

    class Divisione :IOperation
    {
        public double Execute(int a,int b)
        {
           throw new NotImplementedException();
        }
    }
}
