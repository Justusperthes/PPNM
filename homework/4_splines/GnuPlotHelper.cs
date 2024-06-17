using System;
using System.Diagnostics;
using System.IO;

public class GnuPlotHelper
{
    public static void PlotData(double[] x, double[] y, double[] x2, double[] y2, string dataFilePath1, string dataFilePath2, string plotFilePath, string title)
    {
        // Write data points to a file
        using (StreamWriter writer = new StreamWriter(dataFilePath1))
        {
            for (int i = 0; i < x.Length; i++)
            {
                writer.WriteLine($"{x[i]} {y[i]}");
            }
        }

        // Write the second dataset to a file
        using (StreamWriter writer = new StreamWriter(dataFilePath2))
        {
            for (int i = 0; i < x2.Length; i++)
            {
                writer.WriteLine($"{x2[i]} {y2[i]}");
            }
        }

        // Generate the plot using gnuplot
        string gnuplotCommands = $@"
        set terminal pngcairo enhanced
        set output '{plotFilePath}'
        set title '{title}'
        set xlabel 'X'
        set ylabel 'Y'
        plot '{dataFilePath1}' with points pointtype 7 pointsize 1.5 linecolor 'blue' title 'Original Data', \
             '{dataFilePath2}' with lines linecolor 'red' title 'Interpolated Data'
        ";

        string gnuplotScriptPath = "plot.gnuplot";

        // Write the gnuplot commands to a file
        using (StreamWriter writer = new StreamWriter(gnuplotScriptPath))
        {
            writer.WriteLine(gnuplotCommands);
        }

        // Execute the gnuplot script
        Process gnuplotProcess = new Process();
        gnuplotProcess.StartInfo.FileName = "gnuplot";
        gnuplotProcess.StartInfo.Arguments = gnuplotScriptPath;
        gnuplotProcess.StartInfo.RedirectStandardOutput = true;
        gnuplotProcess.StartInfo.UseShellExecute = false;
        gnuplotProcess.StartInfo.CreateNoWindow = true;
        gnuplotProcess.Start();

        gnuplotProcess.WaitForExit();
    }
}
