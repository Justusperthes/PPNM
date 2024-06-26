// Taken from 3_ordLeastSq in case I want to use it for the 1/sqrtN showcasing.
// Im not sure what to do, yet...

using System;
using static System.Math;
public static class ordLeastSq{

    public static (vector,matrix,vector) LSfit(Func<double, double>[] fs, vector x, vector y, vector dy){
        //input: data to fit {xi,yi,dyi} and fitting function
        //output: best fit coef {c_k} and uncertainty vector {delta_c_k}
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
        vector delta_c = new vector(m);
        for (int k=0; k<m; k++){
            delta_c[k] = Sqrt(Sigma[k,k]); // Standard deviation of coefficients
        } 
        return (c,Sigma,delta_c);
    }
}
