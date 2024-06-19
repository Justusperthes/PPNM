using System;
using System.Linq;
using System.IO;
using static System.Math;

public static class main
{
    public static void Main(string[] args)
    {
        //area of unit circle by Monte Carlo
        Func<vector, double> f = (vector point) =>
        {
            double x = point[0];
            double y = point[1];
            double distance = Sqrt(x * x + y * y);
            return distance <= 1 ? 1 : 0;
        };
        vector a = new vector(-1, -1); // lower left corner
        vector b = new vector(1, 1);   // upper right corner
        int N = 10000; // number of samples

        var result = mc.plainmc(f, a, b, N);
        Console.WriteLine($"Estimated integral value with {N} samples: {result.Item1}. Should equal PI.");
        Console.WriteLine($"Estimated error: {result.Item2}");

        // generating data files for pseudo- and quasi-random
        mc.GenerateDataFile("error.data.txt", f, a, b, 100000);
        mc.GenerateQuasiRandomDataFile("quasierror.data.txt", f, a, b, 100000);

        // defining variables for writing data
        string[] lines = File.ReadAllLines("error.data.txt");
        double[][] data = lines.Select(line => line.Split().Select(double.Parse).ToArray()).ToArray();

        // square each value and take inverse
        for (int i = 0; i < data.Length; i++)
        {
            data[i][1] = 1.0 / (data[i][1] * data[i][1]);
        }

        //write modified data to file
        using (StreamWriter writer = new StreamWriter("linerror.data.txt"))
        {
            foreach (var row in data)
            {
                writer.WriteLine(string.Join(" ", row));
            }
        }

        try
        {
            //hyperspherical integral
            Func<vector, double> g = (vector point) =>
            {
                if (point.size != 3)
                    throw new IndexOutOfRangeException($"Vector does not have 3 dimensions, it has {point.size}.");
                double x = point[0];
                double y = point[1];
                double z = point[2];
                double value = Pow(PI, -3) * 1 / (1 - Cos(x) * Cos(y) * Cos(z));
                return value;
            };

            vector c = new vector(0.0, 0.0, 0.0);
            vector d = new vector(PI, PI, PI);

            int M = 1000000; // number of samples
            var result2 = mc.plainmc(g, c, d, M);
            Console.WriteLine($"Estimated integral value with {M} samples: {result2.Item1}. Should equal approx 1.3932.");
            Console.WriteLine($"Estimated error: {result2.Item2}");

            //quasi-random integration unit circle
            var quasiResult = mc.quasirandommc(f, a, b, N);
            Console.WriteLine($"Estimated integral value with {N} quasi-random samples: {quasiResult.Item1}. Should equal PI.");
            Console.WriteLine($"Estimated quasi-random error with {N} samples: {quasiResult.Item2}");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}
