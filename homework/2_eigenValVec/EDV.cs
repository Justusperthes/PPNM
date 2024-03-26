public class EVD{
public vector w;
public matrix V;
public static void timesJ(matrix A, int p, int q, double theta){/*...*/}
public static void Jtimes(matrix A, int p, int q, double theta){/*...*/}
public EVD(matrix M){
	matrix A=M.copy();
	V=matrix.id(M.size1);
	w=new vector(M.size1);
	/* run Jacobi rotations on A and update V */
	/* copy diagonal elements into w */
	}
}