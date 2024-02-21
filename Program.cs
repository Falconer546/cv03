 Console.WriteLine("Zadejte počet řádků matice A:");
        int rowsa = int.Parse(Console.ReadLine());

        Console.WriteLine("Zadejte počet sloupců matice A:");
        int colsa = int.Parse(Console.ReadLine());

        Matrix A = new Matrix(rowsa, colsa);

        for (int i = 0; i < rowsa; i++)
        {
            for (int j = 0; j < colsa; j++)
            {
                Console.WriteLine($"Zadejte prvek pro řádek {i + 1} a sloupec {j + 1}:");
                int value = int.Parse(Console.ReadLine());
                A.AddData(i, j, value);
            }
        }

        Console.WriteLine("Matice:");
        A.Print();

         Console.WriteLine("Zadejte počet řádků matice:");
        int rowsb = int.Parse(Console.ReadLine());

        Console.WriteLine("Zadejte počet sloupců matice:");
        int colsb = int.Parse(Console.ReadLine());

        Matrix B = new Matrix(rowsb, colsb);

        for (int i = 0; i < rowsb; i++)
        {
            for (int j = 0; j < colsb; j++)
            {
                Console.WriteLine($"Zadejte prvek pro řádek {i + 1} a sloupec {j + 1}:");
                int value = int.Parse(Console.ReadLine());
                B.AddData(i, j, value);
            }
        }

        Console.WriteLine("Matice:");
        B.Print();

/* Console.WriteLine("A:\n{0}", A, "\n");
Console.WriteLine("B:\n{0}", B, "\n");
Console.WriteLine("A+B:\n{0}", A+B);
Console.WriteLine("A*B:\n{0}", A*B);
Console.WriteLine("A==B:\n{0}", A==B);
Console.WriteLine("A!=B:\n{0}", A!=B); */

public class Matrix
{
    private int[,] data;

    public Matrix(int rows, int cols)
    {
        data = new int[rows, cols];
    }

    public void AddData(int row, int col, int value)
    {
        data[row, col] = value;
    }

    public void Print()
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write(data[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }


    public static Matrix operator +(XXX){
        return new Matrix(
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    Console.Write(data[i, j] + "\t");
                }
                Console.WriteLine();
            });
    }

    public static Matrix operator -(Matrix a, Matrix b){
        return new Matrix(
            a.ma[0,0] - b.ma[0,0],
            a.ma[0,1] - b.ma[0,1],
            a.ma[1,0] - b.ma[1,0],
            a.ma[1,1] - b.ma[1,1]);
    }

    public static Matrix operator *(Matrix a, Matrix b){
    
        return new Matrix(
            (a.ma[0,0] * b.ma[0,0])+(a.ma[0,1] * b.ma[1,0]),
            (a.ma[0,0] * b.ma[0,1])+(a.ma[0,1] * b.ma[1,1]),
            (a.ma[1,0] * b.ma[0,0])+(a.ma[1,1] * b.ma[1,0]),
            (a.ma[1,0] * b.ma[0,1])+(a.ma[1,1] * b.ma[1,1]));
    }
/*
    public static bool operator ==(Matrix a, Matrix b){

        if( a.ma[0,0] != b.ma[0,0] &&
            a.ma[0,1] != b.ma[0,1] &&
            a.ma[1,0] != b.ma[1,0] &&
            a.ma[1,1] != b.ma[1,1]  )

        return true;
        else return false;
    }

    public static bool operator !=(Matrix a, Matrix b){

        if( a.ma[0,0] != b.ma[0,0] &&
            a.ma[0,1] != b.ma[0,1] &&
            a.ma[1,0] != b.ma[1,0] &&
            a.ma[1,1] != b.ma[1,1]  )

        return true;
        else return false;  
    }
    public override string ToString()
    {
        return string.Format("[{0}, {1}]\n[{2}, {3}]", ma[0, 0], ma[0, 1], ma[1, 0], ma[1, 1]);
    } */
}