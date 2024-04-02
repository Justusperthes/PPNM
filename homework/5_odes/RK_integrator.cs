using System;
using static System.Math;
public class RK_integrator{
    private Func<double,vector,vector> f;
    private double x;
    private vector y;
    private double h;

    public RK_integrator(Func<double,vector,vector> f,double x,vector y,double h){
        this.f = f; /* the f from dy/dx=f(x,y) */
        this.x = x; /* the current value of the variable */
        this.y = y; /* the current value y(x) of the sought function */
        this.h = h; /* the step to be taken */
    }
    public (vector, vector) RKstep12(){
        vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
        vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
        vector yh = y+k1*h;              /* y(x+h) estimate */
        vector δy = (k1-k0)*h;           /* error estimate */
        return (yh,δy);
    }
    public (genlist<double>,genlist<vector>) driver(
        Func<double,vector,vector> F,/* the f from dy/dx=f(x,y) */
        (double,double) interval,    /* (start-point,end-point) */
        vector ystart,               /* y(start-point) */
        double h=0.125,              /* initial step-size */
        double acc=0.01,             /* absolute accuracy goal */
        double eps=0.01              /* relative accuracy goal */
    ){
    var (a,b)=interval; double x=a; vector y=ystart.copy();
    var xlist=new genlist<double>(); xlist.add(x);
    var ylist=new genlist<vector>(); ylist.add(y);
    do{
        if(x>=b) return (xlist,ylist); /* job done */
        if(x+h>b) h=b-x;               /* last step should end at b */
        var (yh,δy) = RKstep12();
        double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
        double err = δy.norm();
            if(err<=tol){ // accept step
		    x+=h; y=yh;
		    xlist.add(x);
		    ylist.add(y);
		    }
	    h *= Min( Pow(tol/err,0.25)*0.95 , 2); // readjust stepsize
        }while(true);
    }//driver
    public class genlist<T>{               /* "T" is the type parameter */
        private T[] data;                   /* we keep items in the array "data" */
        public int size => data.Length;     /* I think that "size" sounds better than "Length" */
        public T this[int i] => data[i];     /* we get items from our list using [i] notation */
        public genlist(){ data = new T[0]; }  /* constructor creates empty list */
        public void add(T item){              /* add item of the type "T" to the list */
            T[] newdata = new T[size+1];   /* we need a larger array (inefective but uses minimal memory) */
            Array.Copy(data,newdata,size); /* here you do O(size) operations */
            newdata[size]=item;            /* add the item at the end of the list */
            data=newdata;                  /* old data should be garbage collected, no worry here */
        }
    }
}