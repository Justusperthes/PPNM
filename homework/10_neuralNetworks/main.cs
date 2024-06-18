using static System.Math;
using static System.Console;
using System;
using System.Collections.Generic;

public static class main
{
    public static void Main()
    {
        //int seed = 101;
        // g(x) = Cos(5*x - 1) * Exp(-x*x)
        Func<double, double> g = x => 2*x; 

        //training data
        List<double> x_train = new List<double>();
        List<double> y_train = new List<double>();
        Random rand = new Random();
        for (int i = 0; i < 20; i++)
        {
            double x = -1 + 2 * rand.NextDouble(); // Random x in [-1, 1]
            x_train.Add(x);
            y_train.Add(g(x)); // y = g(x)
        }

        //create and train network
        int numHiddenNeurons = 4; 
        ann myAnn = new ann(numHiddenNeurons);
        WriteLine("Running training now...");
        myAnn.Train(x_train, y_train);

        // Test network
        for (double x = -1; x <= 1; x += 0.1)
        {
            WriteLine($"x = {x:F2}, g(x) = {g(x):F4}, ANN(x) = {myAnn.Response(x):F4}");
        }
    }
}
