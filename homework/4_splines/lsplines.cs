using System.Collections.Generic;
using System;
using static System.Math;
using System.IO;
public class lspline{
    private double[] x;
    private double[] y;
    private double z;
    //constructor
    public lspline(double[] x, double[] y, double z){
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public double evaluate(){
        int n = x.Length;
        if (n <= 1 || z < x[0] || z > x[n - 1])
            throw new ArgumentException("Invalid input parameters");

        int i = binsearch(x,z); //use binsearch to find appropriate interval 

        double dy=y[i+1]-y[i];
        double dx=x[i+1]-x[i];
        if (dx <= 0)
            throw new ArgumentException("Invalid input parameters");

        return y[i] + dy / dx * (z - x[i]);
        }
    public int binsearch(double[] x, double z){
        /* locates the interval for z by bisection */ 
        if( z<x[0] || z>x[x.Length-1] ) throw new Exception("binsearch: bad z");
        int i=0, j=x.Length-1;
        while(j-i>1){
            int mid=(i+j)/2;
            if(z>x[mid]) i=mid; else j=mid;
            }
        return i;
	}
    public double integrate() {
    int n = x.Length;
    if (n <= 1 || z < x[0] || z > x[n - 1])
        throw new ArgumentException("Invalid input parameters");

    double integral = 0.0;

    // Sum the integrals of all intervals [x[k], x[k+1]] where x[k+1] <= z
    for (int i = 0; i < n - 1 && x[i + 1] <= z; i++) {
        double dx = x[i + 1] - x[i];
        double dy = y[i + 1] - y[i];
        integral += y[i] * dx + dy / dx * Math.Pow(dx, 2) / 2;
    }

    // Find the interval containing z
    int idx = binsearch(x, z);
    double dx_last = z - x[idx];
    double dy_last = y[idx + 1] - y[idx];
    integral += y[idx] * dx_last + dy_last / (x[idx + 1] - x[idx]) * Math.Pow(dx_last, 2) / 2;

    return integral;
    }
    public List<Tuple<double, double>> GenerateInterpolatedPoints(int numPoints)
    {
        List<Tuple<double, double>> points = new List<Tuple<double, double>>();

        double step = (x[x.Length - 1] - x[0]) / (numPoints - 1);
        for (double xi = x[0]; xi <= x[x.Length - 1]; xi += step)
        {
            double yi = evaluateAt(xi);
            points.Add(new Tuple<double, double>(xi, yi));
        }

        return points;
    }

    private double evaluateAt(double xi)
    {
        int i = binsearch(x, xi);

        double dy = y[i + 1] - y[i];
        double dx = x[i + 1] - x[i];
        if (dx <= 0)
            throw new ArgumentException("Invalid input parameters");

        return y[i] + dy / dx * (xi - x[i]);
    }
}