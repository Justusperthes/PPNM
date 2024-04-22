using System;
using static System.Math;
using System.Diagnostics;

class main
{
    static void Main()
    {
        vector X = new vector(1, 2, 3, 4, 6, 9, 10, 13, 15);
        vector Y = new vector(117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1);
        vector DY = new vector(6, 5, 4, 4, 4, 3, 3, 2, 2);

        // Calculate the natural logarithm of Y
        vector lnY = new vector(Y.size);
        for (int i = 0; i < Y.size; i++)
        {
            lnY[i] = Log(Y[i]);
        }   

        Func<double, double>[] fs = new Func<double, double>[]
        {
            x => 1,
            x => x
        };

        var c_Sigma = ordLeastSq.lsfit(fs, X, lnY, DY);
 
        double a = Exp(c_Sigma.Item1[0]); // Extracting 'a' from the intercept
        double lambda = -c_Sigma.Item1[1]; // Extracting 'lambda' from the slope
  　
        // Writing data to a file
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

        ExecuteGnuplotScript(plotScript);

        //Half-life
        double T_half = Log(2)/lambda;
        Console.WriteLine($"The half-life is T_1/2 = {T_half.ToString("F" + 2)} d, compared with " +
        "the modern value of 3.6319 d.");
    }

    static void ExecuteGnuplotScript(string script)
    {
        using (Process process = new Process())
        {
            process.StartInfo.FileName = "gnuplot";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;

            process.Start();

            // Write script to Gnuplot process
            process.StandardInput.WriteLine(script);
            process.StandardInput.Flush();
            process.StandardInput.Close();

            process.WaitForExit();
        }
    }
}
