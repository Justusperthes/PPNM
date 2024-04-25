using System;
using static System.Math;
using System.IO;

public static class mc{ 
    public static (double,double) plainmc(Func<vector,double> f,vector a,vector b,int N){
        int dim=a.size; double V=1; 
        for(int i=0;i<dim;i++){
            V*=b[i]-a[i];
            }
        double sum=0,sum2=0;
    	var x = new vector(dim);
	    var rnd = new Random();
        for(int i=0;i<N;i++){
                for(int k=0;k<dim;k++){
                    x[k]=a[k]+rnd.NextDouble()*(b[k]-a[k]);
                    }
                double fx=f(x); sum+=fx; sum2+=fx*fx;
                }
        double mean = sum/N, sigma=Sqrt(sum2/N-mean*mean);
        var result = (mean*V,sigma*V/Sqrt(N));
        return result;
    } 
    public static void GenerateDataFile(string filename, Func<vector,double> f, vector a, vector b, int N) {
        using (StreamWriter writer = new StreamWriter(filename)) {
            for (int n = 100; n <= N; n += 1000) { 
                var y = plainmc(f,a,b,n);
                double error = y.Item2;
                writer.WriteLine($"{n} {error}");
            }
        }
    } 
}