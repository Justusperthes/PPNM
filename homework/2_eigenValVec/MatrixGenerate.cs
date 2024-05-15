using System;

class MatrixGenerate
{

        // Define the size of the Matrix
        int rows = 30;
        int cols = 30;

        // Create an instance of the Random class
        Random rand = new Random();

        // Create a 2D array to store the Matrix
        double[,] Matrix = new double[rows, cols];

        // Fill the Matrix with random numbers
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Generate a random number between 0 and 1
                Matrix[i, j] = rand.NextDouble();
            }
        }

        // Print the Matrix
        PrintMatrix(Matrix);
    }

    static void PrintMatrix(double[,] Matrix)
    {
        int rows = Matrix.GetLength(0);
        int cols = Matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(Matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}