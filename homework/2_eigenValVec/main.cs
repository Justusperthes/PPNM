using CommonClasses;
class main{
    static void Main(){
        //var B= new Matrix(10);
        var A= new Matrix(5);
        //B.FillWithRandom(-10,10);
        //jacobi.timesJ(A,2,3,2);s
        //B.print();
        //make a symmetric, random Matrix
        A.MakeSymmetric(-10,10);
        A.print();
        var Aj = Jacobi.cyclic(A);
        
        var V = Aj.Item2;
        var Vt = V.T;
        
        System.Console.WriteLine("A (the original symmetric) Matrix");
        A.print();
        System.Console.WriteLine("Orthogonal V Matrix of eigenvectors");
        V.print();
        
        System.Console.WriteLine("V*V^T=1:");
        Matrix prodOfVVt = V*Vt;
        prodOfVVt.print();
        
        System.Console.WriteLine("V^T*V=1:");
        Matrix prodOfVtV = Vt*V;
        prodOfVtV.print();

        System.Console.WriteLine("Diagonal Matrix D of eigenvalues");
        vector w = Aj.Item1;
        Matrix D = new Matrix(w);
        D.print();

        System.Console.WriteLine("Vt*A*V = D");
        Matrix VtAV = Vt*A*V;
        VtAV.print();

        
    }
}   