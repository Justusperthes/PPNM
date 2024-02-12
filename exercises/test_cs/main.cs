using static System.Console;
using static System.Math;

class Program
{
        static void Main()
        {
                Write("testing some hello stuff\n");
                Write("and some more...\n");
                double sqrt2 = Sqrt(2.0);
                Write($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2)\n");
                Write($"this is gamma of 9: "+sfuns.fgamma(9.0));
        }
}
