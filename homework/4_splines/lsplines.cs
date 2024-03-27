using System;
using static System.Math;
public static class lsplines{

    public static double linterp(double[] x, double[] y, double z){
        int n = x.Length;
        if (n <= 1 || z < x[0] || z > x[n - 1])
            throw new ArgumentException("Invalid input parameters");

        int i = binsearch(x,z); //use binsearch to find appropriate interval 

        double dy = y[i + 1] - y[i];
        double dx = x[i + 1] - x[i];
        if (dx <= 0)
            throw new ArgumentException("Invalid input parameters");

        return y[i] + dy / dx * (z - x[i]);
        }
    public static int binsearch(double[] x, double z){
        /* locates the interval for z by bisection */ 
        if( z<x[0] || z>x[x.Length-1] ) throw new Exception("binsearch: bad z");
        int i=0, j=x.Length-1;
        while(j-i>1){
            int mid=(i+j)/2;
            if(z>x[mid]) i=mid; else j=mid;
            }
        return i;
	}
    public static double linterpInteg(double[] x, double[] y, double z){
        /* Implement a function that calculates the integral of the linear spline from the point x[0] to the given point z.
        This should probably sum up in some way, maybe using linterp() */
        int n = x.Length;
        if (n <= 1 || z < x[0] || z > x[n - 1])
            throw new ArgumentException("Invalid input parameters");
        int i = binsearch(x,z);
        System.Console.WriteLine($"i = {i}");
        double dy = y[i + 1] - y[i];
        System.Console.WriteLine($"dy = {dy}");
        double dx = x[i + 1] - x[i];
        System.Console.WriteLine($"dx = {dx}");
        if (dx <= 0)
            throw new ArgumentException("Invalid input parameters");
        return y[i] * (z - x[i]) + dy/dx * Pow(z - x[i],2) / 2;
    }
}