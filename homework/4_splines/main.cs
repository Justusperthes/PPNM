using static System.Math;
using static System.Console;
using System.IO;
using System.Diagnostics;
class main{
    static void Main(){
        int n = 10;
        double[] x = new double[n];
        double[] y = new double[n];
        double steppy = 10.0 / (n - 1);
        // populate x list with values dependent on step size steppy
        for (int i = 0; i < n; i++)
        {
            x[i] = i * steppy;
        }
        // populate y list with cos(x_i)
        for (int i = 0; i < n; i++)
        {
            y[i] = Cos(x[i]);
        }
        double z = 9; // where to evaluate

        // lsplines
        var my_lspline = new lspline(x,y,z);
        double lIntegrateResult = my_lspline.integrate();
        double lEvalResult = my_lspline.evaluate();
        WriteLine($"Antiderivative from 0 to {z} using lsplines: {lIntegrateResult}");
        WriteLine($"The linearly interpolated value at {z} is {lEvalResult}");
        
        // lsplines: generate interpolated data points
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

        // lsplines: define file paths
        string lDataFilePath1 = "l_data.dat";
        string lDataFilePath2 = "l_interp_data.dat";
        string lPlotFilePath = "l_cos_plot.png";

        // lsplines: plot original and interpolated data points
        GnuPlotHelper.PlotData(x, y, xInterp, yInterp, lDataFilePath1, lDataFilePath2, lPlotFilePath, "Lin Interpolation of Cos(x)");

        // qsplines
        var my_qspline = new qspline(x,y,z);
        double QintegrateResult = my_qspline.Integral();
        WriteLine($"Antiderivative from 0 to {z} using qsplines: {QintegrateResult}");
        double qEvalResult = my_qspline.Evaluate();
        WriteLine($"The quadratically interpolated value at {z} is {qEvalResult}");

        // qsplines: generate interpolated data points
        for (int i = 0; i < numInterpolatedPoints; i++)
        {
            xInterp[i] = x[0] + i * step;
            my_qspline = new qspline(x, y, xInterp[i]);
            yInterp[i] = my_qspline.Evaluate();
        }

        // qsplines: define file paths
        string qDataFilePath1 = "q_data.dat";
        string qDataFilePath2 = "q_interp_data.dat";
        string qPlotFilePath = "q_cos_plot.png";

        // qsplines: plot original and interpolated data points
        GnuPlotHelper.PlotData(x, y, xInterp, yInterp, qDataFilePath1, qDataFilePath2, qPlotFilePath, "Q Interpolation of Cos(x)");


    }
}