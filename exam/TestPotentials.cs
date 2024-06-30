using static System.Math;
using System;
public static class TestPotentials{
    public static Func<double, vector, vector> HarmonicOscillator()
    {
        // u'' = -u; transform into two first-order ODEs
        // Let y[0] = u and y[1] = u', then we have dy[0]/dx = y[1] and dy[1]/dx = -y[0]
        return (x, y) => new vector(y[1], -y[0]);
    }

    public static Func<double, vector, vector> VanDerPolOscillator(double mu)
    {
        // dy[0]/dx = y[1]
        // dy[1]/dx = mu * (1 - y[0]^2) * y[1] - y[0]
        return (x, y) => new vector(y[1], mu * (1 - y[0] * y[0]) * y[1] - y[0]);
    }

    public static Func<double, vector, vector> DuffingOscillator(double delta, double alpha, double beta, double gamma, double omega)
    {
        return (x, y) => new vector(y[1], gamma * Cos(omega * x) - delta * y[1] - alpha * y[0] - beta * Pow(y[0], 3));
    }
}