using static System.Math;
using static System.Console;
using System;
using System.Collections.Generic;

public static class main{
     public static void Main()
    {
        // g(x) = Cos(5*x - 1) * Exp(-x*x)
        Func<double, double> g = x => Math.Cos(5 * x - 1) * Math.Exp(-x * x); //2*x;

        //training data
        List<double> x_train = new List<double>();
        List<double> y_train = new List<double>();
        Random rand = new Random();
        for (int i = 0; i < 100; i++)
        {
            double x = -1 + 2 * rand.NextDouble(); // random x in [-1, 1]
            x_train.Add(x);
            y_train.Add(g(x)); // y = g(x)
        }

        //create and train network
        int numHiddenNeurons = 20;
        ann myAnn = new ann(numHiddenNeurons);
        myAnn.Train(x_train, y_train);

        //test network
        for (double x = -1; x <= 1; x += 0.1)
        {
            Console.WriteLine($"x = {x:F2}, g(x) = {g(x):F4}, ANN(x) = {myAnn.Response(x):F4}");
        }
    }
}