using System;
using System.Collections.Generic;
using System.Linq;

public class ann
{
    int n; // number of hidden neurons
    Func<double, double> f; // activation function
    List<double> p; // network parameters

    public ann(int n)
    {
        this.n = n;
        f = x => x * Math.Exp(-x * x); // Gaussian wavelet activation function
        p = new List<double>();

        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            // Initialize parameters to reasonable values
            p.Add(rand.NextDouble() * 2 - 1); // a_i in [-1, 1]
            p.Add(rand.NextDouble() * 2 + 0.1); // b_i in [0.1, 2.1] to avoid division by zero
            p.Add(rand.NextDouble() * 2 - 1); // w_i in [-1, 1]
        }
    }

    // Network response
    public double Response(double x)
    {
        double sum = 0.0;
        for (int i = 0; i < n; i++)
        {
            double a_i = p[3 * i];
            double b_i = p[3 * i + 1];
            double w_i = p[3 * i + 2];
            double argument = (x - a_i) / b_i;
            double activation = f(argument);
            sum += activation * w_i;
        }
        return sum;
    }

    // Compute the cost function
    public double CostFunction(vector parameters, List<double> x, List<double> y)
    {
        // Update the network parameters with the new vector
        for (int i = 0; i < parameters.size; i++)
        {
            p[i] = parameters[i];
        }

        double totalError = 0.0;
        for (int i = 0; i < x.Count; i++)
        {
            double response = Response(x[i]);
            double error = response - y[i];
            totalError += error * error;
        }
        return totalError;
    }

    // Train the network using the Minimisation class
    public void Train(List<double> x, List<double> y, double accuracy = 1e-3)
    {
        // Define the cost function for minimisation
        Func<vector, double> costFunc = parameters => CostFunction(parameters, x, y);

        // Convert the initial parameters to vector type
        vector initialParameters = new vector(p.ToArray());

        // Minimize the cost function using the Minimisation class
        var result = Minimisation.Newton(costFunc, initialParameters, accuracy);
        vector optimalParameters = result.Item1;

        // Update the network parameters with the optimal values
        for (int i = 0; i < optimalParameters.size; i++)
        {
            p[i] = optimalParameters[i];
        }

        Console.WriteLine($"Optimization completed in {result.Item2} steps.");
    }
}
