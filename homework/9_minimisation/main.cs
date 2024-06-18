using System;
using CommonClasses;

public static class main{
    public static void Main(string[] args) {
        double x;
        double y;
        double f;
        vector startingPoint;
        vector result;
        int steps;
        double objectiveValue;

        //Rosenbrock
        Func<vector,double> Rosenbrock = (vector v) =>
            { 
                x = v[0];
                y = v[1];
                f = Math.Pow((1-x),2)+100*Math.Pow((y-Math.Pow(x,2)),2);
                return f;
            };
        //find minimum of Rosenbrock fct
        startingPoint = new vector(1.5, 1.5);
        (result, steps) = Minimisation.Newton(Rosenbrock, startingPoint);
        Console.WriteLine("Rosenbrock function has minimum at (x,y) = ");
        result.print();
        objectiveValue = Rosenbrock(result);
        Console.WriteLine("Value of f(x,y) at the minimum: " + objectiveValue);
        Console.WriteLine($"Completed in {steps} steps.");
        
        //Himmelblau
        Func<vector,double> Himmelblau = (vector v) =>
            {
                x = v[0];
                y = v[1];
                f = Math.Pow((x*x+y-11),2)+Math.Pow((x+y*y-7),2);
                return f;
            };
        double[] xs = {-6.0, 6.0};
        double[] ys = {-6.0, 6.0};
        //Find minima of Himmelblau fct
        for (int i = 0; i < 2; i++){
            for (int j = 0; j < 2; j++){
                startingPoint = new vector(xs[i],ys[j]);
                (result, steps) = Minimisation.Newton(Himmelblau, startingPoint);
                Console.WriteLine("Himmelblau function has one minimum at (x,y) = ");
                result.print();
                objectiveValue = Himmelblau(result);
                Console.WriteLine("Value of f(x,y) at this minimum: " + objectiveValue);
                Console.WriteLine($"Completed in {steps} steps.");
            }
        }
    }
}