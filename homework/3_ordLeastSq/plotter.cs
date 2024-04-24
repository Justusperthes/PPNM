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
}