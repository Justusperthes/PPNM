public class inputoutput{
	public static void Main(){
		// double x = 1.23;
		// System.Console.Out.WriteLine($"{x}"); /* or, equivalently */
		// System.Console.WriteLine($"{x}"); /* or */
		// System.IO.TextWriter /* or just var */ stdout = System.Console.Out;
		// stdout.WriteLine($"{x}"); /* Console.Out is a TextWriter */

		// double y = 1.25;
		// System.Console.Error.WriteLine($"{y}"); /* or */
		// System.IO.TextWriter /* or just var */ stderr = System.Console.Error;
		// stderr.WriteLine($"{y}");

		// double z = 1.24;
		// var outfile = new System.IO.StreamWriter("out2.txt",append:true);
		// outfile.WriteLine($"{z}");
		// outfile.Close(); /* do not forget this! */
		var my_reader = new System.IO.StreamReader("input.txt");
		string s="asdf";
		while (s!=null){
			s = my_reader.ReadLine();
			double x = double.Parse(s);
			System.Console.Out.WriteLine(x);
		}
		
		my_reader.Close();
	}
}
