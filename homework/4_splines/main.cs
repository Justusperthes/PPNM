class main{
    static void Main(){
        double[] x = {1.0, 2.0, 3.0, 4.0, 5.0};
        double[] y = {2.0, 3.0, 5.0, 7.0, 11.0};
        double z = 3.5;
        /* double result = lsplines.linterp(x,y,z);
        System.Console.WriteLine(result); */
        /* int find_i = lsplines.binsearch(y,z);
        System.Console.WriteLine(find_i); */
        double result = lsplines.linterpInteg(x,y,z);
        System.Console.WriteLine(result);
    }

}   