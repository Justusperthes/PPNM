using System;

class main{
    public static void Main()
    {
        // Define the function dy/dx = f(x, y)
        Func<double, vector, vector> f = (x, y) =>
        {
            // Example: simple harmonic oscillator u'' = -u; transform into two first-order ODEs
            // Let y[0] = u and y[1] = u', then we have dy[0]/dx = y[1] and dy[1]/dx = -y[0]
            return new vector(y[1], -y[0]);
        };

        // Initial conditions
        vector ystart = new vector(1.0, 0.0); // u(0) = 1, u'(0) = 0

        // Solve the ODE from x=0 to x=10
        var (xlist, ylist) = RungeKutta.driver(f, (0.0, 10.0), ystart);

        // Print the results
        for (int i = 0; i < xlist.Count; i++)
        {
            Console.WriteLine($"x = {xlist[i]:F2}, y = ({ylist[i]})");
        }
    }
}