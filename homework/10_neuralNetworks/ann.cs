using System;
using static System.Math;
using CommonClasses;
public class ann{
   int n; /* number of hidden neurons */
   Func<double,double> f = x => x*Exp(-x*x); /* activation function */
   vector p; /* network parameters */
   ann(int n){/* constructor */}
   double response(double x){
      /* return the response of the network to the input signal x */
     }
   void train(vector x,vector y){
      /* train the network to interpolate the given table {x,y} */
   }
}