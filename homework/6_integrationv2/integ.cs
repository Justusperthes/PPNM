using System;

public class integ
{
    double δ;
    double ε;

    public integ()
    {
        this.δ = 0.001;
        this.ε = 0.001;
    }

    public integ(double δ, double ε)
    {
        this.δ = δ;
        this.ε = ε;
    }

    public void setδ(double δ)
    {
        this.δ = δ;
    }
    public void setε(double ε)
    {
        this.ε = ε;
    }
    public double getδ(){
        return δ;
    }
    public double getε(){
            return ε;
        }
    public double integrate(Func<double, double> f, double a, double b,
        double f2 = double.NaN, double f3 = double.NaN)
    {
        double h = b - a;
        if (double.IsNaN(f2)) { f2 = f(a + 2 * h / 6); f3 = f(a + 4 * h / 6); } // first call, no points to reuse
        double f1 = f(a + h / 6), f4 = f(a + 5 * h / 6);
        double Q = (2 * f1 + f2 + f3 + 2 * f4) / 6 * (b - a); // higher order rule
        double q = (f1 + f2 + f3 + f4) / 4 * (b - a); // lower order rule
        double err = Math.Abs(Q - q);
        if (err <= δ + ε * Math.Abs(Q)) return Q;
        else return integrate(f, a, (a + b) / 2, f1, f2) +
                    integrate(f, (a + b) / 2, b, f3, f4);
    }
}
