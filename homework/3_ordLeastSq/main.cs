using System;
using static System.Math;
using System.Diagnostics;

class main
{
    static void Main()
    {
        // Rutherford data
        vector X = new vector(1, 2, 3, 4, 6, 9, 10, 13, 15);
        vector Y = new vector(117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1);
        vector DY = new vector(6, 5, 4, 4, 4, 3, 3, 2, 2);

        // Calculate the natural logarithm of Y
        vector lnY = CalculateNaturalLog(Y);   

        // Linear least squares fit and define useful variables
        var fittingResult = PerformLinearLeastSquaresFit(X, lnY, DY);
        var Sigma = fittingResult.Item2;
        double a = Exp(fittingResult.Item1[0]); // Extracting 'a' from the intercept
        double lambda = -fittingResult.Item1[1]; // Extracting 'lambda' from the slope
    
        // Write data to a file and run Gnuplot script
        plotter.writeDataToFile(lambda,a);
        string plotScript = plotter.createGnuplotScript();
        plotter.runPlotScript(X,Y,DY,plotScript);

        //Half-life
        double T_half = Log(2)/lambda;
        Console.WriteLine($"The half-life is T_1/2 = {T_half.ToString("F" + 2)} d, compared with " +
        "the modern value of 3.6319 d.");
    } 
    
}