using System;
class main{
    static void Main(){
        
        Func<double, vector, vector> f = (double x, vector y) =>
        {
            double dydx = -x;

            return new vector(dydx);
        }; 
        var yy = new vector(1);
        var (xlist,ylist) = RK_integrator.driver(f,(0,10),ystart:yy,h:0.125,acc:0.01,eps:0.01);
	    for(int i=0;i<xlist.size;i++){
		    System.Console.WriteLine($"main: result: {xlist[i]} {ylist[i][0]}");
        }
    }
}
/*  
public static vector f(double x, vector y)
    {
        double u = y[0]; // First component of the vector y is u
        double v = y[1]; // Second component of the vector y is v

        double du_dx = v; // u' = v
        double dv_dx = -u; // v' = -u

        return new vector(du_dx, dv_dx);
    }

    public static void Main(string[] args)
    {
        double a = 0; // Start of the interval
        double b = 1; // End of the interval
        vector ystart = new vector(1, 0); // Initial values of u and v at x=a
        double h = 0.1; // Initial step size
        double acc = 1e-6; // Absolute accuracy goal
        double eps = 1e-6; // Relative accuracy goal

        var result = RK_integrator.driver(f, (a, b), ystart, h, acc, eps);

        // printing result 
        result.Item1.Print();
        result.Item2.Print();
    } */



/* Func<double, vector, vector> f = (x, y) =>
        {
            double dy1dx = y[1];
            double dy2dx = -y[0];

            return new vector(dy1dx, dy2dx);
        }; */


        /* Func<double, vector, vector> f = (double x, vector y) => {
            double dydx = x; 
            return new vector(dydx);
        };  */