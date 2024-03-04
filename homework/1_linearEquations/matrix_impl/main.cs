using static System.Console;
using System;
class main{
static void Main(){
	vector ve;
	//ve=new vector(n:1); ve.print("ve=");
	ve=new vector(5,2); ve.print("ve=");
	//ve=new vector(7,8,9,8,7); ve.print("ve=");
	var ma1=new matrix("1 2 ; 3 4");
	//ma1.print();
	var ma2=new matrix("11 21 31 ; 15 16 7 ; 18 2 15");
	WriteLine("A");
	ma1.print();
	ValueTuple<matrix, matrix> QR = QRGS.decomp(ma1);
	matrix Q = QR.Item1;
	matrix R = QR.Item2;
	WriteLine("Q");
	Q.print();
	WriteLine("R");
	R.print();
	var ma3 = QRGS.backsub(R,ve);
	WriteLine("Result");
	vector resultVector = QRGS.solve(ma1,ve);
	resultVector.print();
	var QRprod =  Q*R;
	QRprod.print();

	// ma3.print();
	//(ma1+ma1.T).print();
	//var matProd=ma2*ma1;
	//matProd.print();
	//(matrix.id(3)).print();
	//var sol = QRGS.backsub(ma2,ve);
	//sol.print();
	//WriteLine(QRGS.decomp());
}
}
