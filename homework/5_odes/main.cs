using System;
class main{
    static void Main(){
        Func<double, vector, vector> f = (double x, vector y) => {
            double dydx = x; 
            return new vector(dydx);
        };
        double xx = 1;
        var yy = new vector(1);
        double h = 0.1;
        RK_integrator my_RK = new RK_integrator(f,xx,yy,h);
        var (xlist,ylist) = my_RK.driver(f,(0,10),yy,h:0.125,acc:0.01,eps:0.01);
	for(int i=0;i<xlist.size;i++)
		System.Console.WriteLine($"main: result: {xlist[i]} {ylist[i][0]}");
        //var item1 = result.Item1;
        //item1.Print();
        /* var item2 = result.Item2;
        item2.Print(); */
    }
} 
