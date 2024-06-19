using System;
using static System.Math;
using System.IO;
using System.Collections.Generic;

public static class mc
{
    public static (double, double) plainmc(Func<vector, double> f, vector a, vector b, int N)
    {
        int dim = a.size; double V = 1;
        for (int i = 0; i < dim; i++)
        {
            V *= b[i] - a[i];
        }
        double sum = 0, sum2 = 0;
        var x = new vector(dim);
        var rnd = new Random();
        for (int i = 0; i < N; i++)
        {
            for (int k = 0; k < dim; k++)
            {
                x[k] = a[k] + rnd.NextDouble() * (b[k] - a[k]);
            }
            double fx = f(x); sum += fx; sum2 += fx * fx;
        }
        double mean = sum / N, sigma = Sqrt(sum2 / N - mean * mean);
        var result = (mean * V, sigma * V / Sqrt(N));
        return result;
    }

    public static (double, double) quasirandommc(Func<vector, double> f, vector a, vector b, int N)
    {
        int dim = a.size; double V = 1;
        for (int i = 0; i < dim; i++)
        {
            V *= b[i] - a[i];
        }
        double sum1 = 0, sum2 = 0;
        var x1 = new vector(dim);
        var x2 = new vector(dim);
        var haltonSequences1 = new List<Halton>();
        var haltonSequences2 = new List<Halton>();
        for (int k = 0; k < dim; k++)
        {
            haltonSequences1.Add(new Halton(k + 2));
            haltonSequences2.Add(new Halton(k + 3)); // Using different bases for the second sequence
        }
        for (int i = 0; i < N; i++)
        {
            for (int k = 0; k < dim; k++)
            {
                x1[k] = a[k] + haltonSequences1[k].Next() * (b[k] - a[k]);
                x2[k] = a[k] + haltonSequences2[k].Next() * (b[k] - a[k]);
            }
            double fx1 = f(x1); sum1 += fx1;
            double fx2 = f(x2); sum2 += fx2;
        }
        double mean1 = sum1 / N;
        double mean2 = sum2 / N;
        double mean = (mean1 + mean2) / 2;
        double error = Abs(mean1 - mean2);
        return (mean * V, error * V);
    }

    public static void GenerateDataFile(string filename, Func<vector, double> f, vector a, vector b, int N)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            for (int n = 100; n <= N; n += 1000)
            {
                var y = plainmc(f, a, b, n);
                double error = y.Item2; 
                writer.WriteLine($"{n} {error}"); 
            }
        }
    }

    public static void GenerateQuasiRandomDataFile(string filename, Func<vector, double> f, vector a, vector b, int N)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            for (int n = 100; n <= N; n += 1000)
            {
                var y = quasirandommc(f, a, b, n);
                double error = y.Item2;
                writer.WriteLine($"{n} {error}");
            }
        }
    }
}
