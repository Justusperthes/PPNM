using static System.Console;
using System;
class main{
static void Main(){
	vector ve;
	//ve=new vector(n:1); ve.print("ve=");
	ve=new vector(5,2); ve.print("ve=");
	//ve=new vector(7,8,9,8,7); ve.print("ve=");
	var A=new matrix("1 2 ; 3 4");
	//ma1.print();
	var ma2=new matrix("11 21 31 ; 15 16 7 ; 18 2 15");
	WriteLine("A");
	A.print();
	ValueTuple<matrix, matrix> QR = QRGS.decomp(A);
	matrix Q = QR.Item1;
	matrix R = QR.Item2;
	WriteLine("Q");
	Q.print();
	WriteLine("R");
	R.print();
	var ma3 = QRGS.backsub(R,ve);
	WriteLine("Result");
	vector resultVector = QRGS.solve(A,ve);
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
