using System;

public static class main{
    public static void Main(){
        Func<vector, double> f = (vector point) =>
        {
            double x = point[0]; // x-coordinate
            double y = point[1]; // y-coordinate
            return x * x + y * y; // Function value at (x, y)
        };
        vector a = new vector(0, 0);
        vector b = new vector(1, 1);
        //number of random samples used in integration
        int N = 10000; 
        // Call the plainmc method to estimate the integral
        var result = mc.plainmc(f, a, b, N);

        // Retrieve the integral and error from the result tuple
        double integral = result.Item1;
        double error = result.Item2;

        Console.WriteLine($"Estimated integral: {integral}");
        Console.WriteLine($"Error estimate: {error}");
    }

}