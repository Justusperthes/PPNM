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
        f = x => x * Math.Exp(-x * x); // Gaussian activation function
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

    // Training the network
    public void Train(List<double> x, List<double> y)
    {
        // Gradient descent parameters
        double learningRate = 0.01;
        int epochs = 100000;

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

            // Optional: Log progress every 1000 epochs
            if (epoch % 1000 == 0)
            {
                Console.WriteLine($"Epoch {epoch}: Error = {ComputeError(x, y)}");
            }
        }
    }

    // Compute the total error for the training set
    public double ComputeError(List<double> x, List<double> y)
    {
        double totalError = 0.0;
        for (int i = 0; i < x.Count; i++)
        {
            double response = Response(x[i]);
            double error = response - y[i];
            totalError += error * error;
        }
        return totalError / x.Count;
    }

}
