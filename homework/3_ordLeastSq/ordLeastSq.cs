using System;
using static System.Math;
public static class ordLeastSq{

    public static (vector,matrix) lsfit(Func<double, double>[] fs, vector x, vector y, vector dy){
        int n = x.size, m=fs.Length;
        var A = new matrix(n,m);
        var b = new vector(n);
        for (int i=0; i<n; i++){
            b[i]=y[i]/dy[i];
            for (int k=0; k<m; k++){
                A[i,k] = fs[k](x[i])/dy[i];
            }
        }
        vector c = QRGS.solve(A,b); // solves ||A∗c−b||−>min
        matrix AI = QRGS.inverse(A); // calculates pseudoinverse
        matrix Sigma = AI*AI.T;
        return (c,Sigma);
    }
}