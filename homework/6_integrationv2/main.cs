using System;

class main
{
    public static void Main()
    {
        integ my_integrator = new integ(0.001, 0.001);
        
        // Define functions and expected values
        Func<double, double>[] functions = {
            x => Math.Sqrt(x),
            x => 1 / Math.Sqrt(x),
            x => 4 * Math.Sqrt(1 - x * x),
            x => Math.Log(x) / Math.Sqrt(x)
        };
        
        double[] expectedValues = { 2.0 / 3.0, 2.0, Math.PI, -4.0 };

        bool isTolerable = true;
        double δ = my_integrator.getδ();
        double ε = my_integrator.getε();

        for (int i = 0; i < functions.Length; i++)
        {
            double result = my_integrator.integrate(functions[i], 0, 1);
            double expectedValue = expectedValues[i];
            double absoluteDifference = Math.Abs(result - expectedValue);
            double relativeDifference = absoluteDifference / Math.Abs(expectedValue); 

            Console.WriteLine($"Integral of function {i + 1} from 0 to 1: {result}");
            Console.WriteLine($"Expected value: {expectedValue}");
            isTolerable = absoluteDifference <= δ;
            Console.WriteLine($"Absolute Difference from expected value: {absoluteDifference}."); 
            Console.WriteLine($"This is {(isTolerable ? "within" : "above")} accuracy threshold of {δ}.");
            isTolerable = relativeDifference <= ε;
            Console.WriteLine($"Relative Difference from expected value: {relativeDifference:F10}."); 
            Console.WriteLine($"This is {(isTolerable ? "within" : "above")} accuracy threshold of {ε}.\n");
        }
        //Error function
        errorFct myErrorFct = new errorFct();
        double z = 2.0;
        double errFctVal = myErrorFct.erf(z);
        Console.WriteLine($"This is the error functon with z = {z}: \nerf({z}) = {errFctVal}");
        errorFct errorFunction = new errorFct();
        errorFunction.GenerateDataFile("erf.data.txt", -3, 3, 100);

    }
}
