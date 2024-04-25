using System;
using static System.Math;
using System.Diagnostics;

public static class plotter{
    public static void ExecuteGnuplotScript(string script)
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
    public static void writeDataToFile(double lambda, double a){
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("data.txt"))
        {
            for (double x = 0; x <= 15; x += 0.1)
            {
                double y = a * Exp(-lambda * x);
                file.WriteLine($"{x} {y}");
            }
        }
    }
    public static string createGnuplotScript(){
        string plotScript = @"
            set terminal pngcairo enhanced font 'arial,10' size 800,600
            set output 'plot.png'
            set xlabel 't (days)'
            set ylabel 'activity'
            plot 'data.txt' with lines title 'Exponential Fit', '-' with yerrorbars title 'Data Points'
        ";
        return plotScript;
    }
    public static void runPlotScript(vector X, vector Y, vector DY, string plotScript){
        // Append data and errors to the script
        for (int i = 0; i < X.size; i++) 
        {
            plotScript += $"{X[i]} {Y[i]} {DY[i]}\n";
        } 

        // Append 'e' to signify the end of data
        plotScript += "e";

        ExecuteGnuplotScript(plotScript);
    }
    public static vector CalculateNaturalLog(vector data)
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