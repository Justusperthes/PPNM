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
}