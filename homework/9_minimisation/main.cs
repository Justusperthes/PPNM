using System;
using CommonClasses;

public static class main{
    public static void Main(string[] args) {
        Func<vector,double> Rosenbrock = (vector v) =>
            {
                double x = v[0];
                double y = v[1];
                double z = Math.Pow((1-x),2)+100*Math.Pow((y-Math.Pow(x,2)),2);
                return z;
            };

        vector startingPoint = new vector(1.5, 1.5);

        vector result = Minimisation.Newton(Rosenbrock, startingPoint);

        Console.WriteLine("Solution found at (x,y) = ");
        result.print();

        double objectiveValue = Rosenbrock(result);
        Console.WriteLine("Value of f(x,y) at the minimum: " + objectiveValue);

        
    }
}