using System;
using System.Collections.Generic;
using static System.Math;

public class RKTwoStepExtra : RungeKutta
{
    // Function to perform one step of the two-step method with extra evaluation
    public static (vector, vector) twostep(
        Func<double, vector, vector> f, // the function f from dy/dx = f(x, y)
        double x0,                      // the previous value of the variable
        vector y0,                      // the previous value y(x0) of the sought function
        double x1,                      // the current value of the variable
        vector y1,                      // the current value y(x1) of the sought function
        double h                        // the step to be taken
    )
    {
        double t = x1 + h;
        vector y1_prime = f(x1, y1);
        vector c = (y0 - y1 + y1_prime * (x1 - x0)) / Pow(x1 - x0, 2);

        vector p2 = y1 + y1_prime * h + c * Pow(h, 2);
        
        // Evaluating at t = x1 + h
        vector f_t_p2 = f(t, p2);
        vector d = (f_t_p2 - y1_prime - c * 2.0 * (t - x1)) / ( (t - x1) * 2.0 * (t - x0) + Pow(t - x1, 2));

        vector p3 = p2 + d * Pow(h, 2) * (h + x1 - x0); 
        vector δy = p3 - p2;

        return (p3, δy);
    }

    public string WhatClassIsThis()
    {
        return "RKTwoStep";
    }

    // Function to adaptively solve the ODE from start-point a to end-point b
    public (List<double>, List<vector>) driver(
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
        System.Console.WriteLine("This is two step RK driver with extra evaluation");

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
            else
            {
                Console.WriteLine($"Rejected step: h = {h}, x = {x1}, y = ({y1}), err = {err}, tol = {tol}");
            }

            h *= Min(Pow(tol / err, 0.25) * 0.95, 2); // readjust step-size
            if (h < 1e-10)
            {
                throw new Exception("Step size became too small.");
            }
        } while (true);
    }
}
