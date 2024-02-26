using static System.Console;
using static System.Math;

class Program
{
        static void Main()
        {	
		//blahboablah
		double sqrt2=Sqrt(2.0);
		double pot1fifth = Pow(2.0,0.2);
		double eToPi = Pow(E,PI);
		double piToE = Pow(PI,E);
                Write($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2)\n");
		Write($"pot1fifth^5 = {pot1fifth*pot1fifth*pot1fifth*pot1fifth*pot1fifth} (should equal 2)\n");
		Write($"eToPi = {eToPi} (should equal approx 23)\n");
		Write($"piToE = {piToE} (should equal approx 22)\n");
                for (int i = 1; i<=10; i++)
		{
			Write($"this is gamma of {i}: {sfuns.fgamma(i)}\n");
		}
		for (int i = 1; i<=10;i++)
		{
			Write($"this is lngamma of {i}: {sfuns.lngamma(i)}\n");
		}
	}
}

