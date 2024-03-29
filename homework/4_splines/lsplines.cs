using System;
using static System.Math;
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

        double dy = y[i + 1] - y[i];
        double dx = x[i + 1] - x[i];
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
    public double integrate(){
        
        int n = x.Length;
        if (n <= 1 || z < x[0] || z > x[n - 1])
            throw new ArgumentException("Invalid input parameters");
        int i = binsearch(x,z);
        double dy = y[i + 1] - y[i];
        double dx = x[i + 1] - x[i];
        if (dx <= 0)
            throw new ArgumentException("Invalid input parameters");
        return y[i] * (z - x[i]) + dy/dx * Pow(z - x[i],2) / 2;
    }
}