class main{
    static void Main(){
        double[] x = {1.0, 2.0, 3.0, 4.0, 5.0};
        double[] y = {2.0, 3.0, 5.0, 7.0, 11.0};
        double z = 3.5;
        var my_lspline = new lspline(x,y,z);
        double integrateResult = my_lspline.integrate();
        double evalResult = my_lspline.evaluate();
        System.Console.WriteLine(integrateResult);
        System.Console.WriteLine(evalResult);
        var my_qspline = new qspline(x,y,z);
        double QintegrateResult = my_qspline.Integral();
        System.Console.WriteLine(QintegrateResult);
    }

}   