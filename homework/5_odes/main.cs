using System;
class main{
    static void Main(){
        Func<double, vector, vector> f = (double x, vector y) => {
            double dydx = -x; 
            return new vector(dydx);
        };
        double xx = 1;
        var yy = new vector(0);
        double h = 0.1;
        RK_integrator my_RK = new RK_integrator(f,xx,yy,h);
        var result = my_RK.driver(f,(0,10),yy,0.125,0.01,0.01);
        System.Console.WriteLine(result);
    }
}