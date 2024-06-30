using System;
using static System.Console;
using static System.Math;
using System.Linq;
using System.IO;

class main{
    public static void Main()
    {
        // set potential: "harmonic", "vanderpol", "duffing", "custom"
        string potentialType = "duffing";

        // Region of integration
        double start = 0.0;
        double end = 50.0;

        Func<double, vector, vector> selectedPotential;
        vector ystart;

        RungeKutta my_RKOneStep = new RungeKutta();
        RKTwoStep my_RKTwoStep = new RKTwoStep();
        RKTwoStepExtra my_RKTwoStepExtra = new RKTwoStepExtra();        

        switch (potentialType.ToLower())
        {
            case "harmonic": 
                selectedPotential = TestPotentials.HarmonicOscillator();
                ystart = new vector(1.0, 0.0); // Initial conditions
                break;

            case "vanderpol":
                selectedPotential = TestPotentials.VanDerPolOscillator(5.0);
                ystart = new vector(2.0, 0.0); // Initial conditions
                break;

            case "duffing":
                double delta = 0.2;
                double alpha = -1.0;
                double beta = 1.0;
                double gamma = 0.3;
                double omega = 1.0;
                selectedPotential = TestPotentials.DuffingOscillator(delta, alpha, beta, gamma, omega);
                ystart = new vector(1.0, 0.0); // Initial conditions
                break;

            case "custom":
                selectedPotential = CustomPotential();
                ystart = new vector(1.0, 0.0); //initial conditions
                break;

            default:
                WriteLine("Invalid potential type. Choose 'harmonic', 'vanderpol', or 'duffing'.");
                return;
        }

        // Solve by different methods
        SolveAndSaveResults(my_RKOneStep, selectedPotential, ystart, start, end, "output_one_step.txt");
        SolveAndSaveResults(my_RKTwoStep, selectedPotential, ystart, start, end, "output_two_step.txt");
        SolveAndSaveResults(my_RKTwoStepExtra, selectedPotential, ystart, start, end, "output_two_step_extra.txt");
        
        /* // Analytic function
        for (int i = 0; i < xlist2.Count; i++)
        {
            WriteLine($"x = {xlist2[i]:F2}, y = {Cos(xlist2[i])}");
        } */
    }
    // Define custom potential
     private static Func<double, vector, vector> CustomPotential()
    {
        return (x, y) =>
        {
            // Custom potential: nonlinear oscillator
            double a = -1.0; // linear term
            double b = -1.0; // nonlinear term
            return new vector(y[1], a * y[0] + b * Pow(y[0], 3));
        };
    }
    private static void SolveAndSaveResults(dynamic solver, Func<double, vector, vector> f, vector ystart, double start, double end, string outputPath)
    {
        var result = solver.driver(f, (start, end), ystart);
        var xlist = result.Item1;
        var ylist = result.Item2;

        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            for (int i = 0; i < xlist.Count; i++)
            {
                sw.WriteLine($"{xlist[i]:F2} {ylist[i][0]:F4} {ylist[i][1]:F4}");
            }
        }
    }
}