using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;

public class ANN
{
    private int n; // Number of hidden neurons
    private Func<double, double> f; // Activation function
    private List<double> parameters; // Network parameters (a_i, b_i, w_i for each neuron)

    public ANN(int numNeurons)
    {
        n = numNeurons;
        f = x => x * Math.Exp(-x * x); // Gaussian wavelet activation function
        parameters = new List<double>(3 * n); // 3 parameters per neuron
        var rand = new Random();
        for (int i = 0; i < 3 * n; i++)
        {
            parameters.Add(rand.NextDouble() * 2 - 1); // Initialize parameters randomly between -1 and 1
        }
    }

    // Compute the response of the network to the input signal x
    public double Response(double x)
    {
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            double a = parameters[3 * i];
            double b = parameters[3 * i + 1];
            double w = parameters[3 * i + 2];
            sum += f((x - a) / b) * w;
        }
        return sum;
    }

    // Train the network to interpolate the given table {x, y}
    public void Train(List<double> x, List<double> y, int epochs, double learningRate)
    {
        int N = x.Count;
        for (int epoch = 0; epoch < epochs; epoch++)
        {
            for (int k = 0; k < N; k++)
            {
                double xk = x[k];
                double yk = y[k];
                double Fpx = Response(xk);
                double error = Fpx - yk;

                // Update parameters using gradient descent
                for (int i = 0; i < n; i++)
                {
                    double a = parameters[3 * i];
                    double b = parameters[3 * i + 1];
                    double w = parameters[3 * i + 2];

                    double dF_dai = -2 * error * w * ((xk - a) / (b * b)) * f((xk - a) / b) * (1 - 2 * (xk - a) * (xk - a) / (b * b));
                    double dF_dbi = -2 * error * w * ((xk - a) * (xk - a) / (b * b * b)) * f((xk - a) / b) * (2 * (xk - a) * (xk - a) / (b * b) - 1);
                    double dF_dwi = -2 * error * f((xk - a) / b);

                    parameters[3 * i] -= learningRate * dF_dai;
                    parameters[3 * i + 1] -= learningRate * dF_dbi;
                    parameters[3 * i + 2] -= learningRate * dF_dwi;
                }
            }
        }
    }
}
