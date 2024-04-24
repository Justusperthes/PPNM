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
    
        // Write data to a file
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("data.txt"))
        {
            for (double x = 0; x <= 15; x += 0.1)
            {
                double y = a * Exp(-lambda * x);
                file.WriteLine($"{x} {y}");
            }
        }
 
        // Create a Gnuplot script for both fit and data points with error bars
        string plotScript = @"
            set terminal pngcairo enhanced font 'arial,10' size 800,600
            set output 'plot.png'
            set xlabel 't (days)'
            set ylabel 'activity'
            plot 'data.txt' with lines title 'Exponential Fit', '-' with yerrorbars title 'Data Points'
        ";

        // Append data and errors to the script
        for (int i = 0; i < X.size; i++)
        {
            plotScript += $"{X[i]} {Y[i]} {DY[i]}\n";
        }

        // Append 'e' to signify the end of data
        plotScript += "e";

        plotter.ExecuteGnuplotScript(plotScript);

        //Half-life
        double T_half = Log(2)/lambda;
        Console.WriteLine($"The half-life is T_1/2 = {T_half.ToString("F" + 2)} d, compared with " +
        "the modern value of 3.6319 d.");
    }
    static vector CalculateNaturalLog(vector data)
    {
        vector lnData = new vector(data.size);
        for (int i = 0; i < data.size; i++)
        {
            lnData[i] = Log(data[i]);
        }
        return lnData;
    }
    public static (vector, matrix, vector) PerformLinearLeastSquaresFit(vector X, vector Y, vector DY)
    {
        // Fitting to linear combination of {1,x}
        Func<double, double>[] fs = new Func<double, double>[]
        {
            x => 1,
            x => x
        };

        return ordLeastSq.lsfit(fs, X, Y, DY);
    }
    public static (vector, matrix, vector) PerformRootFit(vector X, vector Y, vector DY)
    {
        // for future development...
        vector x = new vector(1);
        matrix y = new matrix(2);
        vector dy = new vector(3);
        return (x,y,dy);
    }
}
