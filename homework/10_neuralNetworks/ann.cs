using System;
using System.Collections.Generic;
using System.Linq;

public class ann
{
    int n; // number of hidden neurons
    Func<double, double> f; // activation function
    List<double> p; // network parameters

    // Constructor
    public ann(int n)
    {
        this.n = n;
        f = x => Math.Exp(-x * x); // Gaussian activation function
        p = new List<double>(new double[3 * n]); // parameters a_i, b_i, w_i
    }

    // Network response
    public double Response(double x)
    {
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            double a_i = p[3 * i];
            double b_i = p[3 * i + 1];
            double w_i = p[3 * i + 2];
            sum += f((x - a_i) / b_i) * w_i;
        }
        return sum;
    }

    // Training the network
    public void Train(List<double> x, List<double> y)
    {
        // Gradient descent parameters
        double learningRate = 0.01;
        int epochs = 10000;

        for (int epoch = 0; epoch < epochs; epoch++)
        {
            List<double> gradients = new List<double>(new double[3 * n]);

            // Compute gradients
            for (int i = 0; i < x.Count; i++)
            {
                double x_k = x[i];
                double y_k = y[i];
                double response = Response(x_k);
                double error = response - y_k;

                for (int j = 0; j < n; j++)
                {
                    double a_j = p[3 * j];
                    double b_j = p[3 * j + 1];
                    double w_j = p[3 * j + 2];
                    double z_j = (x_k - a_j) / b_j;
                    double f_z_j = f(z_j);
                    double df_z_j = -2 * z_j * Math.Exp(-z_j * z_j);

                    gradients[3 * j] += 2 * error * w_j * df_z_j / b_j;
                    gradients[3 * j + 1] += 2 * error * w_j * df_z_j * z_j / (b_j * b_j);
                    gradients[3 * j + 2] += 2 * error * f_z_j;
                }
            }

            // Update parameters
            for (int i = 0; i < 3 * n; i++)
            {
                p[i] -= learningRate * gradients[i] / x.Count;
            }
        }
    }
