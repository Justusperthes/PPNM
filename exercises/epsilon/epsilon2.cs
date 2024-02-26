using static System.Console;
using static System.Math;

public class Epsilon2
{
	static void Main()
	{
		double x=1; while(1+x!=1){x/=2;} x*=2;
		float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F; 
		Write($"Pow(2,-52) is {Pow(2,-52)} and machine epsilon for double is {x}\n");
		Write($"Pow(2,-23) is {Pow(2,-23)} and machine epsilon for float is {y}\n");
	}

}

