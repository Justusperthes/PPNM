using System;
class main{
    static void Main(){
        Func<double, vector, vector> f = (double x, vector y) =>
        {
            double dydx = -x;

            return new vector(dydx);
        }; 
        var yy = new vector(1);
        var (xlist,ylist) = RK_integrator.driver(f,(0,10),yy,h:0.125,acc:0.01,eps:0.01);
	    for(int i=0;i<xlist.size;i++){
		    System.Console.WriteLine($"main: result: {xlist[i]} {ylist[i][0]}");
        }
    }
}




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