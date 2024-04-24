using System;

public static class main{
    public static void Main(string[] args) {
        Func<vector, double> f = (vector point) => {
            double x = point[0];
            double y = point[1];
            double distance = Math.Sqrt(x * x + y * y);
            return distance <= 1 ? 1 : 0;
        };

        vector a = new vector(-1, -1); // lower bounds
        vector b = new vector(1, 1);   // upper bounds
        int N = 100; // samples

        var result = mc.plainmc(f, a, b, N);

        Console.WriteLine($"Estimated integral value with {N} samples: {result.Item1}");
        Console.WriteLine($"Estimated error: {result.Item2}");

        //Making a plot of error as a function of number of samples
        mc.GenerateDataFile("error.data.txt", f, a, b, 100000);

    }
}

