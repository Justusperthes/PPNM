using static System.Math;
using static System.Console;
using System.IO;
using System.Diagnostics;
class main{
    static void Main(){
        /* double[] x = {0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0};
        double[] y = {0,1,4,9,16,25,36,49,64,81,100}; */
        int n = 10;
        double[] x = new double[n];
        double[] y = new double[n];

        double steppy = 10.0 / (n - 1);
        for (int i = 0; i < n; i++)
        {
            x[i] = i * steppy;
        }
        
        for (int i = 0; i < n; i++)
        {
            y[i] = Cos(x[i]);
        }

        double z = 9;
        var my_lspline = new lspline(x,y,z);
        double integrateResult = my_lspline.integrate();
        double evalResult = my_lspline.evaluate();
        WriteLine(integrateResult);
        WriteLine(evalResult);
        var my_qspline = new qspline(x,y,z);
        double QintegrateResult = my_qspline.Integral();
        System.Console.WriteLine(QintegrateResult);
        
        // Generate interpolated data points
        int numInterpolatedPoints = 1000;
        double[] xInterp = new double[numInterpolatedPoints];
        double[] yInterp = new double[numInterpolatedPoints];

        double step = (x[x.Length - 1] - x[0]) / (numInterpolatedPoints - 1);
        for (int i = 0; i < numInterpolatedPoints; i++)
        {
            xInterp[i] = x[0] + i * step;
            my_lspline = new lspline(x, y, xInterp[i]);
            yInterp[i] = my_lspline.evaluate();
        }

        // Define file paths
        string dataFilePath1 = "data.dat";
        string dataFilePath2 = "interp_data.dat";
        string plotFilePath = "combined_plot.png";

        // Plot original and interpolated data points
        GnuPlotHelper.PlotData(x, y, xInterp, yInterp, dataFilePath1, dataFilePath2, plotFilePath);
    }
}