using System;
using System.Linq;
using System.IO;
using static System.Math;
public static class main{
    public static void Main(string[] args) {
        // Area of unit circle by Monte Carlo
        Func<vector, double> f = (vector point) => {
            double x = point[0];
            double y = point[1];
            double distance = Sqrt(x * x + y * y);
            return distance <= 1 ? 1 : 0;
        };
        vector a = new vector(-1, -1); // lower left corner
        vector b = new vector(1, 1);   // upper right corner
        int N = 100; // no. of samples
        var result = mc.plainmc(f, a, b, N);
        Console.WriteLine($"Estimated integral value with {N} samples: {result.Item1}");
        Console.WriteLine($"Estimated error: {result.Item2}");

        // Make plot of error as function of number of samples
        mc.GenerateDataFile("error.data.txt", f, a, b, 100000);

        // Define variables for writing data
        string[] lines = File.ReadAllLines("error.data.txt");
        double[][] data = lines.Select(line => line.Split().Select(double.Parse).ToArray()).ToArray();
 
        // Square each value and take the inverse
        for (int i = 0; i < data.Length; i++)
        {
            data[i][1] = 1.0 / (data[i][1] * data[i][1]);
        }

        // Write the modified data to a new file
        using (StreamWriter writer = new StreamWriter("linerror.data.txt"))
        {
            foreach (var row in data)
            {
                writer.WriteLine(string.Join(" ", row));
            }
        }

        // Calculate difficult hyperspherical integral
        Func<vector, double> g = (vector point) => {
            double x = point[0];
            double y = point[1]; 
            double z = point[2];
            double something = 1/Pow(PI,3)*1/(1-Cos(x)*Cos(y)*Cos(z));
            return something <= 1 ? 1 : 0;
        };
        vector c = new vector(0,0,0);
        vector d = new vector(PI,PI,PI);
        int M = 100;
        var result2 = mc.plainmc(g, c, d, M);
        Console.WriteLine(result2.Item1);
    }
}