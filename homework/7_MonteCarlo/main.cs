using System;

public static class main{
    public static void Main(string[] args) {
        Func<vector, double> f = (vector point) => {
            double x = point[0];
            double y = point[1];
            double distance = Math.Sqrt(x * x + y * y);
            return distance <= 1 ? 1 : 0;
        };

        vector a = new vector(-1, -1); // Lower bounds
        vector b = new vector(1, 1);   // Upper bounds
        int N = 10000000; // Number of samples

        var result = mc.plainmc(f, a, b, N);

        Console.WriteLine($"Estimated integral value: {result.Item1}");
        Console.WriteLine($"Estimated error: {result.Item2}");
    }
}

