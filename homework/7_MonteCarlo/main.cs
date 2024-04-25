using System;
using System.Linq;
using System.IO;
public static class main{
    public static void Main(string[] args) {
        Func<vector, double> f = (vector point) => {
            double x = point[0];
            double y = point[1];
            double distance = Math.Sqrt(x * x + y * y);
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

        // Error follows 1/sqrt(N)?
            //fetch data from file
            //square each point and take inverse
            //plot and see if linear

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
    }
}