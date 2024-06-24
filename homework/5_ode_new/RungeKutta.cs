using System;
using System.Collections.Generic;
using static System.Math;
public class RungeKutta
{
    // Function to perform one step of the embedded RK method
    // 1 is the lower-order (Euler) method
    // 2 is the higher-order method
    public static (vector, vector) rkstep12(
        Func<double, vector, vector> f, // the function f from dy/dx = f(x, y)
        double x,                       // the current value of the variable
        vector y,                       // the current value y(x) of the sought function
        double h                        // the step to be taken
    )
    {
        vector k0 = f(x, y);             // embedded lower order formula (Euler)
        vector k1 = f(x + h / 2, y + k0 * (h / 2)); // higher order formula (midpoint)
        vector yh = y + k1 * h;          // y(x+h) estimate
        vector δy = (k1 - k0) * h;       // error estimate
        return (yh, δy);
    }

    // Function to perform one step of the two-step method
    public static (vector, vector) twostep(
        Func<double, vector, vector> f, // the function f from dy/dx = f(x, y)
        double x0,                      // the previous value of the variable
        vector y0,                      // the previous value y(x0) of the sought function
        double x1,                      // the current value of the variable
        vector y1,                      // the current value y(x1) of the sought function
        double h                        // the step to be taken
    )
    {
        vector y1_prime = f(x1, y1);
        vector c = (y0 - y1 + y1_prime * (x1 - x0)) / Pow(x1 - x0, 2);
        vector yh = y1 + y1_prime * h + c * Pow(h, 2);
        vector δy = c * Pow(h, 2);
        return (yh, δy);
    }

    // Function to adaptively solve the ODE from start-point a to end-point b
    public static (List<double>, List<vector>) driver(
        Func<double, vector, vector> F,  // the function f from dy/dx = f(x, y)
        (double, double) interval,       // (start-point, end-point)
        vector ystart,                   // y(start-point)
        double h = 0.125,                // initial step-size
        double acc = 0.01,               // absolute accuracy goal
        double eps = 0.01                // relative accuracy goal
    )
    {
        var (a, b) = interval;
        double x = a;
        vector y = ystart.copy();
        var xlist = new List<double> { x };
        var ylist = new List<vector> { y };

        // Initial step using rkstep12
        var (y1, δy1) = rkstep12(F, x, y, h);
        double x1 = x + h;
        xlist.Add(x1);
        ylist.Add(y1);

         do
        {
            if (x1 >= b) return (xlist, ylist); // job done
            if (x1 + h > b) h = b - x1;          // last step should end at b

            var (yh, δy) = twostep(F, x, y, x1, y1, h);
            double tol = (acc + eps * yh.norm()) * Sqrt(h / (b - a));
            double err = δy.norm();

            if (err <= tol)
            {
                // accept step
                x = x1;
                y = y1;
                x1 += h;
                y1 = yh;
                xlist.Add(x1);
                ylist.Add(y1);
            }

            h *= Min(Pow(tol / err, 0.25) * 0.95, 2); // readjust step-size
        } while (true);
    }
}
