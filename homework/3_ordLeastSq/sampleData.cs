using System;
using System.Diagnostics;

namespace SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data
            double[] x = {1,  2,  3, 4, 6, 9,   10,  13,  15};
            double[] y = {117,100,88,72,53,29.5,25.2,15.2,11.1};
            double[] errors = {6,5,4,4,4,3,3,2,2};

            // Create a Gnuplot script
            string script = @"
                set terminal pngcairo enhanced font 'arial,10' size 800,600
                set output 'plot.png'
                set xlabel 't (days)'
                set ylabel 'activity'
                plot '-' with yerrorbars title 'Error'
            ";

            // Append data and errors to the script
            for (int i = 0; i < x.Length; i++)
            {
                script += $"{x[i]} {y[i]} {errors[i]}\n";
            }

            // Append 'e' to signify the end of data
            script += "e";

            // Execute Gnuplot script
            ExecuteGnuplotScript(script);

            // View the plot
            ViewPlot("plot.png");

            Console.WriteLine("Plot generated successfully.");
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

        static void ViewPlot(string filename)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "eog";
                process.StartInfo.Arguments = filename;

                process.Start();
            }
        }
    }
}
