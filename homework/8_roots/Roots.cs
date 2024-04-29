using System;
using static System.Math;
using CommonClasses;
public static class Roots{
    public static vector Newton(
        Func<vector,vector> f,  // the function to find the root of 
        vector start,           // the start point
        double acc=1e-2,        // accuracy goal: on exit ‖f(x)‖ should be <acc 
        vector δx=null          // optional δx-vector for calculation of jacobian 
        ){
    // check input
    for (int i = 0; i < start.size; i++)
    {
        if (start[i]==0.0)
        {
            throw new ArgumentException("Start vector must contain only non-zero values.");
        }
    }
    double λmin = 0.01;
    vector x=start.copy();
    vector fx=f(x),z,fz;
    do{ // Newton's iterations
        if(fx.norm() < acc) break; // job done 
        Matrix J=Jacobian(f,x,fx,δx);
        vector Dx = QRGS.solve(J,-fx); // Newton's step by Gram-Schmidt decomp
        double λ=1;
        do{ // linesearch 
            z=x+λ*Dx;
            fz=f(z);
            if( fz.norm() < (1-λ/2)*fx.norm() ) break;
            if( λ < λmin ) break;
            λ/=2;
            }while(true);
        x=z; fx=fz;
        }while(true);
    return x;
    }
    public static Matrix Jacobian(
        Func<vector,vector> f,
        vector x,
        vector fx=null,
        vector dx=null){
        if(dx == null){ 
            dx = x.map(xi => Abs(xi)*Pow(2,-26));
            }
        if(fx == null){ 
            fx = f(x);
            }
	//x.print("jacobian x=");
	//fx.print("jacobian fx=");
        Matrix J=new Matrix(x.size);
        for(int j=0;j < x.size;j++){
            x[j]+=dx[j];
            //Console.WriteLine($"x[{j}]=" + x[j]);
            vector df=f(x)-fx;
            for(int i=0;i < x.size;i++)
            { 
                J[i,j]=df[i]/dx[j];
                //Console.WriteLine($"J=df[{i}]/dx[{j}]=" + J[i,j]);
                }
            x[j]-=dx[j];
            }
        return J;
        }
}
