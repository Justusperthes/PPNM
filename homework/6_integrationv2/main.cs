using System;
class main{
    public static void Main()
    {
        integ my_integrator = new integ();
        double δtolerable;
        bool δOK;
        Func<double, double> f1 = x => Math.Sqrt(x); // Define the function x^0.5
        Func<double, double> f2 = x => 1/Math.Sqrt(x); 
        Func<double, double> f3 = x => 4*Math.Sqrt(1-x*x); 
        Func<double, double> f4 = x => Math.Log(x) / Math.Sqrt(x); 
        double result1 = my_integrator.integrate(f1, 0, 1, 0.1, 0.1); 
        double result2 = my_integrator.integrate(f2, 0, 1); 
        double result3 = my_integrator.integrate(f3, 0, 1); 
        double result4 = my_integrator.integrate(f4, 0, 1); 
        Console.WriteLine("Integral of x^0.5 from 0 to 1: " + result1);
        δtolerable = Math.Abs(result1-2/3.0);
        Console.WriteLine("Difference from 2/3: " + δtolerable);
        
        Console.WriteLine("Integral of x^-0.5 from 0 to 1: " + result2);
        δtolerable = Math.Abs(result2-2.0);
        Console.WriteLine("Difference from 2: " + δtolerable);

        Console.WriteLine("Integral of 4*(1-x^2)^0.5 from 0 to 1: " + result3);
        δtolerable = Math.Abs(result3-Math.PI);
        Console.WriteLine("Difference from pi: " + δtolerable);

        Console.WriteLine("Integral of ln(x)/x^0.5 from 0 to 1: " + result4);
        δtolerable = Math.Abs(result4-(-4.0));
        Console.WriteLine("Difference from -4: " + δtolerable);

    }
}