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
        double sum = 0;
        var x = new vector(dim);
        var haltonSequences = new List<Halton>();
        for (int k = 0; k < dim; k++)
        {
            haltonSequences.Add(new Halton(k + 2));
        }
        for (int i = 0; i < N; i++)
        {
            for (int k = 0; k < dim; k++)
            {
                x[k] = a[k] + haltonSequences[k].Next() * (b[k] - a[k]);
            }
            double fx = f(x); sum += fx;
        }
        double mean = sum / N;
        return (mean * V, 0); // <error  not estimated by variance in quasi-random
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
            var halton1 = quasirandommc(f, a, b, N);
            var halton2 = quasirandommc(f, a, b, N);
            double error = Abs(halton1.Item1 - halton2.Item1);
            writer.WriteLine($"{N} {error}");
        }
    }
}
