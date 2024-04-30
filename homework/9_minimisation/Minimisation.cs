using System;
using static System.Math;
using CommonClasses;

public static class Minimisation{
    public static vector Newton(
        Func<vector,double> φ, /* objective function */
        vector x,              /* starting point */
        double acc=1e-3        /* accuracy goal, on exit |∇φ| should be < acc */
    ){
        double λmin = 0.01;
        do{ /* Newton's iterations */
            var del_φ = Gradient(φ,x);
            if(del_φ.norm() < acc) break; /* job done */
            var H = Hessian(φ,x);
            var dx = QRGS.solve(H,-del_φ);
            double λ=1,φx=φ(x);
            do{ /* linesearch */
                if( φ(x+λ*dx) < φx ) break; /* good step: accept */
                if( λ < λmin ) break; /* accept anyway */
                λ/=2;
            }while(true);
            x+=λ*dx;
        }while(true);
        return x;
    }//Newton

    public static vector Gradient(Func<vector,double> φ,vector x){
	vector del_φ = new vector(x.size);
	double φx = φ(x); /* no need to recalculate at each step */
	for(int i=0;i<x.size;i++){
		double dx=Max(Abs(x[i]),1)*Pow(2,-26);
		x[i]+=dx;
		del_φ[i]=(φ(x)-φx)/dx;
		x[i]-=dx;
	    }
	return del_φ;
    }//Gradient
    
    public static Matrix Hessian(Func<vector,double> φ,vector x){
	Matrix H=new Matrix(x.size);
	vector del_φx=Gradient(φ,x);
	for(int j=0;j<x.size;j++){
		double dx=Max(Abs(x[j]),1)*Pow(2,-13); /* for numerical Gradient */
		x[j]+=dx;
		vector d_del_φ=Gradient(φ,x)-del_φx;
        Console.WriteLine(d_del_φ.GetType());
		for(int i=0;i<x.size;i++) H[i,j]=d_del_φ[i]/dx; //changed from dx[j];
		x[j]-=dx;
	    }
	//return H;
	return (H+H.T)/2; // you think?
    }//Hessian
}