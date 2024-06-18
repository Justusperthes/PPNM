using System;

public class cspline
{
    private double[] xs, ys, bs, cs, ds;
    private double z;

    public cspline(double[] xs, double[] ys, double z)
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
        cs = new double[n];
        ds = new double[n - 1];

        double[] hs = new double[n - 1];
        double[] alpha = new double[n - 1];
        double[] l = new double[n];
        double[] mu = new double[n];
        double[] z = new double[n];

        for (int i = 0; i < n - 1; i++)
        {
            hs[i] = xs[i + 1] - xs[i];
            alpha[i] = (ys[i + 1] - ys[i]) / hs[i];
        }

        l[0] = 1.0;
        mu[0] = 0.0;
        z[0] = 0.0;

        for (int i = 1; i < n - 1; i++)
        {
            l[i] = 2.0 * (xs[i + 1] - xs[i - 1]) - hs[i - 1] * mu[i - 1];
            mu[i] = hs[i] / l[i];
            z[i] = (3.0 * (alpha[i] - alpha[i - 1]) - hs[i - 1] * z[i - 1]) / l[i];
        }

        l[n - 1] = 1.0;
        z[n - 1] = 0.0;
        cs[n - 1] = 0.0;

        for (int j = n - 2; j >= 0; j--)
        {
            cs[j] = z[j] - mu[j] * cs[j + 1];
            bs[j] = alpha[j] - hs[j] * (cs[j + 1] + 2.0 * cs[j]) / 3.0;
            ds[j] = (cs[j + 1] - cs[j]) / (3.0 * hs[j]);
        }
    }

    public double Evaluate()
    {
        int i = FindSegmentIndex();
        double h = z - xs[i];
        return ys[i] + h * (bs[i] + h * (cs[i] + h * ds[i]));
    }

    public double Derivative()
    {
        int i = FindSegmentIndex();
        double h = z - xs[i];
        return bs[i] + 2 * h * cs[i] + 3 * h * h * ds[i];
    }

    public double Integral()
    {
        int i = FindSegmentIndex();
        double sum = 0;

        for (int j = 0; j < i; j++)
        {
            double h = xs[j + 1] - xs[j];
            sum += ys[j] * h + bs[j] * h * h / 2 + cs[j] * h * h * h / 3 + ds[j] * h * h * h * h / 4;
        }

        double hz = z - xs[i];
        sum += ys[i] * hz + bs[i] * hz * hz / 2 + cs[i] * hz * hz * hz / 3 + ds[i] * hz * hz * hz * hz / 4;

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
