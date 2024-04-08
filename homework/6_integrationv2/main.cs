using System;
class main{
    public static void Main()
    {
        Func<double, double> f1 = x => Math.Sqrt(x); // Define the function x^0.5
        Func<double, double> f2 = x => 1/Math.Sqrt(x); // Define the function x^0.5
        Func<double, double> f3 = x => 4*Math.Sqrt(1-x*x); // Define the function x^0.5
        Func<double, double> f4 = x => Math.Log(Math.Abs(x)) / Math.Sqrt(x); // Define the function x^0.5
        double result1 = integ.integrate(f1, 0, 1); // Call the integrate method
        double result2 = integ.integrate(f2, 0, 1); // Call the integrate method
        double result3 = integ.integrate(f3, 0, 1); // Call the integrate method
        double result4 = integ.integrate(f4, 0, 1); // Call the integrate method
        Console.WriteLine("Integral of x^0.5 from 0 to 1: " + result1);
        Console.WriteLine("Integral of x^-0.5 from 0 to 1: " + result2);
        Console.WriteLine("Integral of 4/(1-x^2) from 0 to 1: " + result3);
        Console.WriteLine("Integral of ln|x|/x^0.5 from 0 to 1: " + result4);


    }
}