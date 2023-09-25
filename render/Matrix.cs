using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace render
{
    internal class Matrix
    {
        public float[,] value;
        public int rows;
        public int columns;
        
        public Matrix(float[,] value)
        {
            // [row, column]
            this.value = value;
            this.rows = value.GetLength(0);
            this.columns = value.GetLength(1);
        }

        public static Matrix Empty4x4 = new Matrix(
            new float[,]{
                { 0, 0, 0, 0},
                { 0, 0, 0, 0},
                { 0, 0, 0, 0},
                { 0, 0, 0, 0}
            });
        public static Matrix Identity4x4 = new Matrix(
            new float[,]{
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            });

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.columns != b.rows) throw new ArithmeticException("Cannot multiply incompatible matricies");

            float temp = 0;
            float[,] kHasil = new float[a.rows, b.columns];

            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < b.columns; j++)
                {
                    temp = 0;
                    for (int k = 0; k < a.columns; k++)
                    {
                        temp += a.value[i, k] * b.value[k, j];
                    }
                    kHasil[i, j] = temp;
                }
            }
            return new Matrix(kHasil);
        }

        public static Vector3 operator *(Matrix m, Vector3 v)
        {
            Matrix result = m * v.ToMatrix1x4();
            return new Vector3(result.value[0, 0], result.value[1, 0], result.value[2, 0]);
        }

        public override string ToString()
        {
            string buffer = "";
            for(int i = 0; i < rows; i++)
            {
                buffer += "[\t";
                for(int j = 0; j < columns; j++)
                {
                    buffer += value[i,j].ToString() + "\t";
                }
                buffer += "]\n";
            }
            return buffer;
        }
    }
}
