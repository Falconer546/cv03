using System.Globalization;
using System.Runtime.CompilerServices;

Console.WriteLine("Zadejte počet řádků matice A:");
        int rows_a = 2;
        //int.Parse(Console.ReadLine());

        Console.WriteLine("Zadejte počet sloupců matice A:");
        int cols_a = 3;
        //int.Parse(Console.ReadLine());

        Matrix A = new Matrix(rows_a, cols_a);

        for (int i = 0; i < rows_a; i++)
        {
            for (int j = 0; j < cols_a; j++)
            {
                //Console.WriteLine($"Zadejte prvek pro řádek {i + 1} a sloupec {j + 1}:");
                double value = i+j+1;
                A.AddData(i, j, value);
            }
        }

        Console.WriteLine("Matice B:");
        A.Print();

        //Console.WriteLine("Zadejte počet řádků matice:");
        int rows_b = 3;
        //int.Parse(Console.ReadLine());

        //Console.WriteLine("Zadejte počet sloupců matice:");
        int cols_b = 2;
        //int.Parse(Console.ReadLine());

        Matrix B = new Matrix(rows_b, cols_b);

        for (int i = 0; i < rows_b; i++)
        {
            for (int j = 0; j < cols_b; j++)
            {
                //Console.WriteLine($"Zadejte prvek pro řádek {i + 1} a sloupec {j + 1}:");
                double value = i+j+i;
                B.AddData(i, j, value);
            }
        }

        Console.WriteLine("Matice B:");
        B.Print();

        Console.WriteLine("Matice A+B");
        Matrix C = new Matrix(rows_a, cols_a);
        C = A + B;
        C.Print();

        Console.WriteLine("Matice A-B");
        Matrix D = new Matrix(rows_a, cols_a);
        D = A - B;
        D.Print();
                
        Console.WriteLine("Matice A*B");
        Matrix E = new Matrix(rows_a, cols_a);
        E = A * B;
        E.Print();

        Console.WriteLine("Jsou matice stejné?");
        bool F = A == B;
        Console.WriteLine(F);

        Console.WriteLine("Jsou matice různé?");
        bool G = A != B;
        Console.WriteLine(G);

        Console.WriteLine("Kterou matici chcete vypočítat determinant?");
        Console.WriteLine("Zadejte písmeno matice (A-E): ");
        char xDeterminant = char.ToUpper(Console.ReadLine()[0]);

        double det = 0;

        switch (xDeterminant)
        {
            case 'A':
                det = Matrix.Determinant(A);
                break;
            
            case 'B':
                det = Matrix.Determinant(B);
                break;

            case 'C':
                det = Matrix.Determinant(C);
                break;

            case 'D':
                det = Matrix.Determinant(D);
                break;

            case 'E':
                det = Matrix.Determinant(E);
                break;

            default:
                throw new ArgumentException("Neexistující matice!");
        }

        Console.WriteLine($"Determinant matice {xDeterminant} je: {det}");
public class Matrix
{
    private double[,] data;

    public Matrix(int rows, int cols)
    {
        data = new double[rows, cols];
    }

    public void AddData(int row, int col, double value)
    {
        data[row, col] = value;
    }

    public void Print()
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                string val_M = data[i,j].ToString();
                Console.Write(val_M + "\t");
            }
            Console.WriteLine();
        }
    }

// Přetěžování funkcí

    public static Matrix operator +(Matrix A, Matrix B)
    {
        int rows = A.data.GetLength(0);
        int cols = A.data.GetLength(1);

        if (rows != B.data.GetLength(0) || cols != B.data.GetLength(1))
            throw new ArgumentException("Matice mají různé rozměry a nelze je sečíst.");

        Matrix result = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result.data[i, j] = A.data[i, j] + B.data[i, j];
            }
        }

        return result;
    }
    
    public static Matrix operator -(Matrix A, Matrix B){
    
        int rows = A.data.GetLength(0);
        int cols = A.data.GetLength(1);
        
        if (rows != B.data.GetLength(0) || cols != B.data.GetLength(1))
            throw new ArgumentException("Matice mají různé rozměry a nejdou odčítat.");

        Matrix result = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result.data[i,j] = A.data[i, j] - B.data[i, j];
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix a, Matrix b){
    
        int rows_a = a.data.GetLength(0);
        int cols_a = a.data.GetLength(1);
        int rows_b = b.data.GetLength(0);
        int cols_b = b.data.GetLength(1);

        if (cols_a != rows_b)
            throw new ArgumentException("Nelze násobit - Rozdílný počet sloupců mat_A a řádků mat_B");

        Matrix result = new Matrix(rows_a, cols_b);

        for(int i = 0; i < rows_a; i++)
        {
            for(int j = 0; j < cols_b; j++)
            {
                double sum = 0;

                for(int k = 0; k < cols_a; k++)
                {
                    sum += a.data[i,k] * b.data[k,j];
                }
                result.data[i,j] = sum;
            }
        }
        return result;
    }

    public static bool operator ==(Matrix a, Matrix b){
    
        int rows_a = a.data.GetLength(0);
        int cols_a = a.data.GetLength(1);
        int rows_b = b.data.GetLength(0);
        int cols_b = b.data.GetLength(1);

        if(rows_a != rows_b || cols_a != cols_b)
            throw new ArgumentException("Rozdílné dimenze matic.");

        for (int i = 0; i < rows_a; i++)
            for (int j = 0; j < cols_a; j++)
                if(a.data[i,j] != b.data[i,j])
                    return false;
        return true;
    }

    public static bool operator !=(Matrix a, Matrix b){
    
        int rows_a = a.data.GetLength(0);
        int cols_a = a.data.GetLength(1);
        int rows_b = b.data.GetLength(0);
        int cols_b = b.data.GetLength(1);

        if(rows_a != rows_b || cols_a != cols_b)
            throw new ArgumentException("Rozdílné dimenze matic.");

        for (int i = 0; i < rows_a; i++)
            for (int j = 0; j < cols_a; j++)
                if(a.data[i,j] != b.data[i,j])
                    return true;
        return false;
    }

    public static double Determinant(Matrix a){

        int rows_a = a.data.GetLength(0);
        int cols_a = a.data.GetLength(1);
        double[,] matrix = a.data;

        if (a.data.GetLength(0) != a.data.GetLength(1))
        {
            throw new ArgumentException("Matice není čtvercová.");
        }

        if (a.data.GetLength(0) == 1)
        {
            return matrix[0, 0]; 
        }
        else if (n == 2)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }
        else
        {
            double det = 0;

            for (int j = 0; j < n; j++)
            {
                double[,] subMatrix = new double[n - 1, n - 1];
                for (int i = 1; i < n; i++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (k < j)
                            subMatrix[i - 1, k] = matrix[i, k];
                        else if (k > j)
                            subMatrix[i - 1, k - 1] = matrix[i, k];
                    }
                }
                
                det += (j % 2 == 0 ? 1 : -1) * matrix[0, j] * Determinant(subMatrix);
            }
            return det;
        }
    }
}