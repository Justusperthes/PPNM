class main{
    static void Main(){
        //var B= new matrix(10);
        var A= new matrix(5);
        //B.FillWithRandom(-10,10);
        //jacobi.timesJ(A,2,3,2);s
        //B.print();
        //make a symmetric, random matrix
        A.MakeSymmetric(-10,10);
        A.print();
        var Aj = jacobi.cyclic(A);
        
        var V = Aj.Item2;
        var Vt = V.T;
        
        System.Console.WriteLine("A (the original symmetric) matrix");
        A.print();
        System.Console.WriteLine("Orthogonal V matrix of eigenvectors");
        V.print();
        
        System.Console.WriteLine("V*V^T=1:");
        matrix prodOfVVt = V*Vt;
        prodOfVVt.print();
        
        System.Console.WriteLine("V^T*V=1:");
        matrix prodOfVtV = Vt*V;
        prodOfVtV.print();

        System.Console.WriteLine("Diagonal matrix D of eigenvalues");
        vector w = Aj.Item1;
        matrix D = new matrix(w);
        D.print();

        System.Console.WriteLine("Vt*A*V = D");
        matrix VtAV = Vt*A*V;
        VtAV.print();

        
    }
}   