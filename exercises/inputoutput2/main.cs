using static System.Console;
using static System.Math;
public class inputoutput{
	public static void Main(string[] args){
        
        char[] split_delimiters = {' ','\t','\n'};
        var split_options = StringSplitOptions.RemoveEmptyEntries;
        for( string line = ReadLine(); line != null; line = ReadLine() ){
            var numbers = line.Split(split_delimiters,split_options);
            foreach(var number in numbers){
                double x = double.Parse(number);
                Error.WriteLine($"{x} {Sin(x)} {Cos(x)}");
            }
        }
    }
}





// using static System.Console;
// using static System.Math;
// public class inputoutput{
// 	public static void Main(string[] args){
//         foreach(var arg in args){
//             var words = arg.Split(':');
//             if(words[0]=="-numbers"){
//                 var numbers=words[1].Split(',');
//                 foreach(var number in numbers){
//                     double x = double.Parse(number);
//                     WriteLine($"{x} {Sin(x)} {Cos(x)}");
//                 }
//             }
//         }
//         char[] split_delimiters = {' ','\t','\n'};
//         var split_options = StringSplitOptions.RemoveEmptyEntries;
//         for( string line = ReadLine(); line != null; line = ReadLine() ){
//             var numbers = line.Split(split_delimiters,split_options);
//             foreach(var number in numbers){
//                 double x = double.Parse(number);
//                 Error.WriteLine($"{x} {Sin(x)} {Cos(x)}");
//             }
//         }
//     }
// }