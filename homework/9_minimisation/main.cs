using System;
using CommonClasses;

public static class main{
    public static void Main(string[] args) {
        
        // Define an objective function
        Func<vector, double> objectiveFunction = x =>
        {
            // Example objective function: f(x) = x^2
            return x[0] * x[0] + + 3*x[0] + 1;
        };

        // Choose a starting point
        vector startingPoint = new vector(1); // Assuming 1-dimensional problem
        startingPoint[0] = 3.0; // Starting point x = 3

        // Call the Newton method
        vector result = Minimisation.Newton(objectiveFunction, startingPoint);

        // Print the result
        Console.WriteLine("Optimal solution found:");
        result.print();

        // You can also print the value of the objective function at the optimal solution
        double objectiveValue = objectiveFunction(result);
        Console.WriteLine("Objective function value at the optimal solution: " + objectiveValue);
    }
}