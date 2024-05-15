using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
public class main
{
    public static void Main()
    {
        // Define the function to interpolate
        Func<double, double> g = z => Math.Cos(5 * z - 1) * Math.Exp(-z * z);

        // Sample the function at several points on [-1, 1]
        int numSamples = 100;
        List<double> x = new List<double>(numSamples);
        List<double> y = new List<double>(numSamples);
        for (int i = 0; i < numSamples; i++)
        {
            double xi = -1 + 2.0 * i / (numSamples - 1);
            x.Add(xi);
            y.Add(g(xi));
        }

        // Create and train the neural network
        ANN ann = new ANN(10); // 10 hidden neurons
        ann.Train(x, y, 1000, 0.01); // 1000 epochs, learning rate 0.01

        // Test the network
        for (int i = 0; i < numSamples; i++)
        {
            double xi = x[i];
            double yi = y[i];
            double fi = ann.Response(xi);
            Console.WriteLine($"x: {xi}, y: {yi}, f(x): {fi}");
        }
    }
}
