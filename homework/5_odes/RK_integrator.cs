using System;
using static System.Math;
public static class RK_integrator{
    /* private Func<double,vector,vector> f;
    private double x;
    private vector y;
    private double h; */

    //public RK_integrator(Func<double,vector,vector> f,double x,vector y,double h){
    //    this.f = f; /* the f from dy/dx=f(x,y) */
    //    this.x = x; /* the current value of the variable */
    //    this.y = y; /* the current value y(x) of the sought function */
    //    this.h = h; /* the step to be taken */
    //}
    public static (vector, vector) RKstep12(Func<double,vector,vector> f,double x,vector y,double h){
        vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
        vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
        vector yh = y+k1*h;              /* y(x+h) estimate */
        vector δy = (k1-k0)*h;           /* error estimate */
        return (yh,δy);
    }//stepper
    public static (genlist<double>,genlist<vector>) driver(
        Func<double,vector,vector> f,/* the f from dy/dx=f(x,y) */
        (double,double) interval,    /* (start-point,end-point) */
        vector ystart,               /* y(start-point) */
        double h,              /* initial step-size */
        double acc,             /* absolute accuracy goal */
        double eps              /* relative accuracy goal */
    ){
        var (a,b)=interval; double x=a; vector y=ystart.copy();
        var xlist=new genlist<double>(); xlist.add(x);
        var ylist=new genlist<vector>(); ylist.add(y);
        do{
            Console.WriteLine("Inside do loop");
            if(x>=b) return (xlist,ylist); /* job done */
            if(x+h>b) h=b-x;               /* last step should end at b */
            var (yh,δy) = RKstep12(f,x,y,h);
            double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
            double err = δy.norm();
            System.Console.WriteLine($"driver: err={err} tol={tol} h={h}");
                if(err<=tol){ // accept step
                x+=h; y=yh;
                xlist.add(x);
                ylist.add(y);
                }
            h *= Min( Pow(tol/err,0.25)*0.95 , 2); // readjust stepsize
            }while(true);
    }//driver
    public class genlist<T>
    {
        private T[] data;
        public int size => data.Length;
        public T this[int i] => data[i];

        public genlist()
        {
            data = new T[0];
        }

        public void add(T item)
        {
            T[] newdata = new T[size + 1];
            Array.Copy(data, newdata, size);
            newdata[size] = item;
            data = newdata;
        }

        public void Print()
        {
            foreach (T item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}