using System;
using static System.Math;
public static class main{
    public static void Main(string[] args) {
        /* Func<vector, vector> f = (vector x) =>
        {
            double y1 = x[0] * x[0] - 4;
            return new vector(y1);
        };
        vector start = new vector(0.0);
        vector root = Roots.Newton(f, start);
        root.print(); */
    
        /* Func<vector, vector> f = (vector v) =>
            {
                double x = v[0];
                double y = v[1];
                vector result = new vector(x - 7, y - 9);
                return result;
            };
        
            vector start = new vector(1.5, 1.5);
            vector root = Roots.Newton(f, start);

            Console.WriteLine("Root: x = " + root[0] + ", y = " + root[1]); */

        Func<vector, vector> Rosenbrock = (vector v) =>
            {
                double x = v[0];
                double y = v[1];
                double dx = -2*(1-x)+100*2*(y-x*x)*(-2)*x;
                double dy = 100*2*(y-x*x);
                vector result = new vector(dx, dy);
                return result;
            };
        
        vector start = new vector(1.5, 1.5);
        vector root = Roots.Newton(Rosenbrock, start);
        double r1 = root[0];
        double r2 = root[1];
        Console.WriteLine("Roots of gradient of Rosenbrock function: x = " + r1 + ", y = " + r2);
        Console.WriteLine($"-2*(1-x)+100*2*(y-x*x)*(-2)*x with above values of x,y should yield 0:  {-2*(1-r1)+100*2*(r2-r1*r1)*(-2)*r1}");
        Console.WriteLine("100*2*(y-x*x) with above values of x,y should yield 0: " + 100*2*(r2-r1*r1));

        Func<vector,vector> Himmelblau = (vector v) =>
        {
            double x = v[0];
            double y = v[1];
            double dx = 2 * (-7 + x + y*y + 2 * x * (-11 + x*x + y));
            double dy = 2 * (-11 + x*x + y + 2 * y * (-7 + x + y*y));
            vector result = new vector(dx,dy);
            return result;
        };

        start = new vector(2.5, 1.5);
        root = Roots.Newton(Himmelblau, start);
        r1 = root[0];
        r2 = root[1];
        Console.WriteLine("\nRoots of gradient of Himmelblau function: x = " + r1 + ", y = " + r2);
        Console.WriteLine($"2 * (-7 + x + y*y + 2 * x * (-11 + x*x + y)) with above values of x,y should yield 0:  {2 * (-7 + r1 + r2*r2 + 2 * r1 * (-11 + r1*r1 + r2))}");
        Console.WriteLine($"2 * (-11 + x*x + y + 2 * y * (-7 + x + y*y)) with above values of x,y should yield 0:  + {2 * (-11 + r1*r1 + r2 + 2 * r2 * (-7 + r1 + r2*r2))})");

    }   
}
