using System;
using static System.Math;
public static class main{
    public static void Main(string[] args) {
        Func<vector, vector> f = (vector point) => {
            double x = point[0];
            double y = point[1];
            return new vector(x * x - 4, y * y - 4); // f(x, y) = (x^2 - 4, y^2 - 4)
            };
        vector start = new vector(1, 1);
        vector root = Roots.Newton(f, start);
        root.print();
    }
}