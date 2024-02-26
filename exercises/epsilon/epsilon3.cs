using static System.Math;
using static System.Console;

class tiny_epsilon
{
	static void Main(){
		double epsilon=Pow(2,-52);
		double tiny=epsilon/2;
		double a=1+tiny+tiny;
		double b=tiny+tiny+1;
		Write($"a==b ? {a==b}\n");
		Write($"a>1  ? {a>1}\n");
		Write($"b>1  ? {b>1}\n");
		Write("hello");
	}
}
