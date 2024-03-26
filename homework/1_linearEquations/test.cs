public class test{
    public static double rnd(){
        var rnd = new System.Random(1); /* or any other seed */
        double x = rnd.NextDouble();
        double y = rnd.NextDouble();
        double z = rnd.NextDouble(); 
    }
}
// QR-decomp - decomp
//generate a random tall (n>m) matrix A (of a modest size);

//factorize it into QR;
// check that R is upper triangular;
// check that QTQ=1;
// check that QR=A;

// QR-decomp - solve
// generate a random square matrix A (of a modest size);
// generate a random vector b (of the same size);
// factorize A into QR;
// solve QRx=b;
// check that Ax=b;

// inverse by GS QR factorization
// generate a random square matrix A (of a modest size);
// factorize A into QR;
// calculate the inverse B;
// check that AB=I, where I is the identity matrix;