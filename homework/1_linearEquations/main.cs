using static System.Console;
using System;
class main{
static void Main(){
	
	int dim = 5;
	double range = 100.0;
	WriteLine($"Here is a random {dim}x{dim} matrix A:");
	var A = new matrix(dim);
	A.FillWithRandom(-range,range);
	A.print();
	WriteLine("Doing QR-decomposition on A to get:");
	DateTime startTime = DateTime.Now; //start measuring time
	ValueTuple<matrix, matrix> QR = QRGS.decomp(A);
	DateTime endTime = DateTime.Now; //end measuring time
	matrix Q = QR.Item1;
	matrix R = QR.Item2;
	WriteLine("Q = ");
	Q.print();
	WriteLine("R = ");
	R.print();
	WriteLine("R should be uppper triangular.");

	TimeSpan elapsedTime = endTime - startTime;
	WriteLine($"This decomposition ran in time: {elapsedTime.TotalMilliseconds} milliseconds.\n");
	
	WriteLine($"Here is a random {dim}-vector");
	vector b = new vector(dim,-range,range); 
	b.print("b:");
	
	WriteLine("\nSolving the system Ax=b");

	vector resultVector = QRGS.solve(A,b);
	resultVector.print();  

	WriteLine("\nProduct of Q and R (should equal A):");
	var QRprod =  Q*R;
	QRprod.print();

	var det = QRGS.det(R);
	WriteLine($"The determinant of A: det(A) = {det}");
	
	WriteLine("\nInverse of R by Gram-Schmidt QR-decomp:");
	matrix inverse = QRGS.inverse(R);
	inverse.print();

	WriteLine("\nProduct of R and R^-1 should equal identity:");
	var RRinverse = R*inverse;
	RRinverse.print();
	}
}