using static System.Console;
using System;
using System.Collections.Generic;
namespace CommonClasses{
    public static class QRGS{
        static QRGS()
        {
            Matrix myMatrix = new Matrix(3,3);
        }
        public static vector backsub(Matrix U, vector c){
            //obs: U must be upper triangular
            if(checkSqUpTri(U)==false){
                vector failVector = new vector(6,6,6);
                return failVector;
                }
                for (int i=c.size-1; i >=0; i--){
                    double sum=0;
                    for (int k=i+1; k<c.size; k++) sum+=U[i,k]*c[k];
                    c[i]=(c[i]-sum)/U[i,i]; } 
                    return c;}
        public static bool checkSqUpTri(Matrix U){
            if(U.size1!=U.size2)
                return false;
            int dim = U.size1;
            for(int k=1; k<dim;k++){ 
                for(int j=0; j<dim-1;j++)
                    if(U[k,k-1]!=0){
                        System.Console.WriteLine(k);
                        System.Console.WriteLine(U[k,0]);
                        return false;
                        }
                    }
            return true;
        }
        public static ValueTuple<Matrix, Matrix> decomp(Matrix A){
            //decomp() should perform stabilized Gram-Schmidt 
            //orthogonalization of an n×m (where n≥m) 
            //Matrix A and calculate R.
            int m = A.size2; 
            Matrix Q=A.copy(), R=new Matrix(m,m);
            for(int i =0; i<m; i++){
                R[i,i]=Q[i].norm(); /* Q[i] point s to the i−th columb */
                if (R[i, i] != 0)
                {
                    Q[i] /= R[i, i];
                }
                else
                {
                // Handle division by zero error
                // For example, set Q[i] to a default value or throw an exception
                // throw new DivideByZeroException("Division by zero encountered.");
                }
                for (int j=i +1;j<m; j++){
                    R[i,j]=Q[i].dot(Q[j]);
                    Q[j]-=Q[i]*R[i,j];}}
            (Matrix Q,Matrix R) QR = (Q,R);
            return QR;
        }
        public static vector solve(Matrix A, vector b){
            //should use the matrices Q and R from "decomp" 
            //and solve the equation QRx=b for the given 
            //right-hand-side "b".
            
            // call decomp(A) to make A triangular form
            ValueTuple<Matrix, Matrix> QR = decomp(A);
            // make Q into Q^T, multiply Q^T with b
            Matrix Q = QR.Item1;
            Matrix R = QR.Item2;
            // call backsub(A_tri,Q^Tb) to solve 
            vector result = backsub(R,Q.T*b);
            return result;
        }
        public static double det(Matrix A){
        //should return the determinant of Matrix R which is 
        //equal to the determinant of the original Matrix. 
        //For QR-decomposition the determinant is product
        //of diagonal of R
            int sizeOfMatrix = A.size1;
            double result = 1.0;
            for(int i=0;i < sizeOfMatrix;i++){
                result = result*A[i,i];
            }
            return result;
        }
        public static Matrix inverse(Matrix A){
            //Solve Ax_1=e_1, Ax_2=e_2,..., Ax_n=e_n.
            //Put the vectors x_1,...,x_n together as columns in Matrix A^-1
            int sizeOfMatrix = A.size1;
            List<vector> vectorList = new List<vector>();
            Matrix resultMatrix = new Matrix(sizeOfMatrix);
            //solve each SoLE
            for(int i =0;i<sizeOfMatrix;i++){
                vector e = vector.UnitVector(sizeOfMatrix,i);
                vector resultVector = solve(A,e);
                vectorList.Add(resultVector);
                }
            //create resultMatrix from list of vectors
            resultMatrix = Matrix.FromColumns(vectorList);
            return resultMatrix;
        }
    }
}