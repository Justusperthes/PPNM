public static Minimisation{
    public static vector newton(
        Func<vector,double> φ, /* objective function */
        vector x,              /* starting point */
        double acc=1e-3        /* accuracy goal, on exit |∇φ| should be < acc */
    ){
        do{ /* Newton's iterations */
            var ∇φ = gradient(φ,x);
            if(∇φ.norm() < acc) break; /* job done */
            var H = hessian(φ,x);
            var QRH = givensQR(H);   /* QR decomposition */
            var dx = QRH.solve(-∇φ); /* Newton's step */
            double λ=1,φx=φ(x);
            do{ /* linesearch */
                if( φ(x+λ*dx) < φx ) break; /* good step: accept */
                if( λ < λmin ) break; /* accept anyway */
                λ/=2;
            }while(true);
            x+=λ*dx;
        }while(true);
        return x;
    }//newton
}