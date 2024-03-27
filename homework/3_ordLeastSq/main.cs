using static System.Math;
using System;
class main{
    static void Main(){
        vector X = new vector(1,2,3,4,6,9,10,13,15);
        vector Y = new vector(117,100,88,72,53,29.5,25.2,15.2,11.1);
        vector DY = new vector(6,5,4,4,4,3,3,2,2);
        Func<double, double>[] fs = new Func<double, double>[]{
            x => 1,
            x => x,
            x => x*x
        };
        ordLeastSq.lsfit(fs, X, Y, DY);
    }
}