using static System.Console;
using System;
class main{
static void Main(){
	WriteLine("Here is a random 10x10 matrix A:\n");
	var K = new matrix(10);
	K.FillWithRandom(-10,10);
	K.print();
	
	WriteLine("Doing QR-decomposition on A to get:\n");

	/* var A=new matrix("1 2 ; 3 4");
	var ma2=new matrix("11 21 31 ; 15 16 7 ; 18 2 15");
	var ma4=new matrix("11 21 31 ; 15 16 7 ; 18 2 15 ; 1 2 3");
	ma4.print();
	WriteLine("A");
	A.print(); */

	ValueTuple<matrix, matrix> QR = QRGS.decomp(K);
	matrix Q = QR.Item1;
	matrix R = QR.Item2;
	WriteLine("Q");
	Q.print();
	WriteLine("R");
	R.print();

	WriteLine("Here is a random 10-vector b:\n");
	vector b = new vector(10,-10.0,10.0); 
	b.print("b:");
	
	
	WriteLine("Solving the system Kx=b");

	vector resultVector = QRGS.solve(K,b);
	ValueTuple<matrix, matrix> QR2 = QRGS.decomp(K);
	matrix Q2 = QR2.Item1;
	matrix R2 = QR2.Item2;
	WriteLine("Q2");
	Q2.print();
	WriteLine("R2");
	R2.print(); 
	System.Console.WriteLine("resultVector of A and ve system");
	resultVector.print();
	var QRprod =  Q*R;
	QRprod.print();
	var det = QRGS.det(R);
	WriteLine(det);
	// vector unitvector = vector.UnitVector(5,1);
	// unitvector.print();
	matrix inverse = QRGS.inverse(R);
	inverse.print();
	var RRinverse = R*inverse;
	RRinverse.print();
}
}
