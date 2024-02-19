using System.Globalization;
using System.Xml.XPath;

Matrix A = new Matrix(1,2,3,4);
Matrix B = new Matrix(5,6,7,8);

Console.WriteLine("A:\n{0}", A, "\n");
Console.WriteLine("B:\n{0}", B, "\n");
Console.WriteLine("A+B:\n{0}", A+B);
Console.WriteLine("A*B:\n{0}", A*B);
Console.WriteLine("A==B:\n{0}", A==B);
Console.WriteLine("A!=B:\n{0}", A!=B);

public class Matrix
{
    public double[,] ma;

    public Matrix(double a, double b, double c, double d)
    {
        ma = new double[2, 2];
        ma[0, 0] = a;
        ma[0, 1] = b;
        ma[1, 0] = c;
        ma[1, 1] = d;
    }

    public static Matrix operator +(Matrix a, Matrix b){
        return new Matrix(
            a.ma[0,0] + b.ma[0,0],
            a.ma[0,1] + b.ma[0,1],
            a.ma[1,0] + b.ma[1,0],
            a.ma[1,1] + b.ma[1,1]);
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
    }
}