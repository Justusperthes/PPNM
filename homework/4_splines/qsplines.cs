using System;
using static System.Math;
using System;

using System;

public class qspline
{
    private double[] xs, ys, bs, cs;
    private double z;

    public qspline(double[] xs, double[] ys, double z)
    {
        this.xs = xs;
        this.ys = ys;
        this.z = z;
        CalculateBC();
    }

    private void CalculateBC()
    {
        int n = xs.Length;
        bs = new double[n - 1];
        cs = new double[n - 1];

        double[] ps = new double[n - 1];
        double[] hs = new double[n - 1];

        for (int i = 0; i < n - 1; i++)
        {
            hs[i] = xs[i + 1] - xs[i];
            ps[i] = (ys[i + 1] - ys[i]) / hs[i];
        }

        cs[0] = 0;

        for (int i = 0; i < n - 2; i++)
        {
            cs[i + 1] = (ps[i + 1] - ps[i] - cs[i] * hs[i]) / hs[i + 1];
        }

        cs[n - 2] /= 2;

        for (int i = n - 3; i >= 0; i--)
        {
            cs[i] = (ps[i + 1] - ps[i] - cs[i + 1] * hs[i + 1]) / hs[i];
        }

        for (int i = 0; i < n - 1; i++)
        {
            bs[i] = ps[i] - cs[i] * hs[i];
        }
    }

    public double Evaluate()
    {
        int i = FindSegmentIndex();
        double h = z - xs[i];
        return ys[i] + h * (bs[i] + h * cs[i]);
    }

    public double Derivative()
    {
        int i = FindSegmentIndex();
        double h = z - xs[i];
        return bs[i] + 2 * cs[i] * h;
    }

    public double Integral()
    {
        int i = FindSegmentIndex();
        double sum = 0;

        for (int j = 0; j < i; j++)
        {
            double h = xs[j + 1] - xs[j];
            sum += ys[j] * h + bs[j] * h * h / 2 + cs[j] * h * h * h / 3;
        }
   
        double hz = z - xs[i];
        sum += ys[i] * hz + bs[i] * hz * hz / 2 + cs[i] * hz * hz * hz / 3;

        return sum;
    }

    private int FindSegmentIndex()
    {
        for (int i = 0; i < xs.Length - 1; i++)
        {
            if (z >= xs[i] && z <= xs[i + 1])
                return i;
        }

        return xs.Length - 2;
    }
}
