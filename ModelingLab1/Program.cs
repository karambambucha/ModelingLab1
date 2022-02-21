using System;
using System.Collections.Generic;

//границы от 0 до 2/лямбда
namespace ModelingLab1
{
    class Program
    {
        static Random rnd = new Random();
        static double c; //левая граница
        static double d; //правая граница
        static double lambda; //лямбда
        static double F(double x, double lambda)
        {
            return lambda * x - Math.Pow(lambda, 2) * Math.Pow(x, 2) / 4;
        }
        static double GenerateRandomVariable(double lambda, double cy, double dy)
        {
            double y = cy + rnd.NextDouble() * (dy-cy);
            return 2 * (1 - Math.Sqrt(1 - y)) / lambda;
        }
        static List<double> GenerateSelection(double amount, double c, double d, double lambda)
        {
            double cy, dy;
            if (d<c)
                (d, c) = (c, d); //смена границ если d < c

            if (c < 0)
                cy = F(0, lambda);
            else 
                cy = F(c, lambda);

            if (d < 0)
                dy = F(0, lambda);
            else
                dy = F(d, lambda);

            List<double> Selection = new List<double>();
            for (int i = 0; i < amount; i++)
            {
                Selection.Add(GenerateRandomVariable(lambda, cy, dy));
            }
            return Selection;
        }
        static void Main(string[] args)
        {
            c = 0.5;
            d = 1.5;
            lambda = 1;
            List<double> Selection = new List<double>();
            Selection = GenerateSelection(100, c, d, lambda);

            foreach(double d in Selection)
            {
                Console.WriteLine(d);
            }
        }
    }
}
