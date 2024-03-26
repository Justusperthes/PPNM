using System;

class matrixGenerator
{

        // Define the size of the matrix
        int rows = 30;
        int cols = 30;

        // Create an instance of the Random class
        Random rand = new Random();

        // Create a 2D array to store the matrix
        double[,] matrix = new double[rows, cols];

        // Fill the matrix with random numbers
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Generate a random number between 0 and 1
                matrix[i, j] = rand.NextDouble();
            }
        }

        // Print the matrix
        PrintMatrix(matrix);
    }

    static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

