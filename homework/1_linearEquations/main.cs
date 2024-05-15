using static System.Console;
using System;
using CommonClasses;
class main{
static void Main(){
	
	int n = 7;
	int m = 5;
	double range = 100.0;
	WriteLine($"Here is a random {n}x{m} Matrix A:");
	var A = new Matrix(n,m);
	A.FillWithRandom(-range,range);
	A.print();
	WriteLine("Doing QR-decomposition on A to get:");
	DateTime startTime = DateTime.Now; //start measuring time
	ValueTuple<Matrix, Matrix> QR = QRGS.decomp(A);
	DateTime endTime = DateTime.Now; //end measuring time
	Matrix Q = QR.Item1;
	Matrix R = QR.Item2;
	WriteLine("Q = ");
	Q.print();
	WriteLine("R = ");
	R.print();
	WriteLine("R should be uppper triangular.");

	TimeSpan elapsedTime = endTime - startTime;
	WriteLine($"This decomposition ran in time: {elapsedTime.TotalMilliseconds} milliseconds.\n");
	
	WriteLine($"Here is a random {n}-vector");
	vector b = new vector(n,-range,range); 
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
	Matrix inverse = QRGS.inverse(R);
	inverse.print();

	WriteLine("\nProduct of R and R^-1 should equal identity:");
	var RRinverse = R*inverse;
	RRinverse.print();
	}
}
