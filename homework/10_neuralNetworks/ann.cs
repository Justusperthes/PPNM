using System;
using System.Collections.Generic;
using System.Linq;
using CommonClasses;

public class ann
{
    int n; // number of hidden neurons
    Func<double, double> f; // activation function
    List<double> p; // network parameters
    List<double> x, y; // training data

    public ann(int n) 
    {
        this.n = n;
        //sigmoid activation function. Gaussian wavelet f = x => x * Math.Exp(-x * x);
        f = x => 1.0 / (1.0 + Math.Exp(-x));
        p = new List<double>();

        Random rand = new Random();
        for (int i = 0; i < n; i++) 
        {
            p.Add(i / (double)n); 
            p.Add(1.0); 
            p.Add(1.0); 
        } 
    }  
    public double Response(double x, vector p)
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

    public double Response(double x)
    {
        vector currentParams = new vector(p.ToArray());
        return Response(x, currentParams);
    }

    public double CostFunction(vector p)
    {
        double totalError = 0.0;
        for (int i = 0; i < x.Count; i++)
        { 
            double response = Response(x[i], p);
            double error = response - y[i];
            totalError += error * error;
        }   
        return totalError;  
    } 
  
    public void Train(List<double> x, List<double> y)
    {
        this.x = x;  
        this.y = y;     
 
        vector initialParams = new vector(p.ToArray()); // Convert List<double> to vector
        Func<vector, double> costFunc = CostFunction;
     
        Console.WriteLine("Starting Newton's optimization..."); 
        var result = Minimisation.Newton(costFunc, initialParams, 1e-1, 100000);
        p = new List<double>(result.Item1); // Explicit conversion from vector to List<double>
        Console.WriteLine($"Training completed in {result.Item2} steps with final cost {costFunc(result.Item1)}.");
    }
 
    public double ComputeError(List<double> x, List<double> y)
    {
        double totalError = 0.0;
        vector currentParams = new vector(p.ToArray()); // Convert List<double> to vector
        for (int i = 0; i < x.Count; i++)
        {
            double response = Response(x[i], currentParams); // Pass currentParams
            double error = response - y[i];
            totalError += error * error;
        }
        return totalError / x.Count;
    }
}
