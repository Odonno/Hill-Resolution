using System;
using ResolutionHill.Model;

namespace ResolutionHill.ViewModel.Helpers
{
    public static class MatrixHelper
    {
        public static int Determinant(this Matrix matrix)
        {
            int i;
            int det;

            for (i = 0; i < matrix.Order - 1; i++)
            {
                for (int j = i + 1; j < matrix.Order; j++)
                {
                    det = matrix.Values[j, i] / matrix.Values[i, i];
                    for (int k = i; k < matrix.Order; k++)
                        matrix.Values[j, k] = matrix.Values[j, k] - det * matrix.Values[i, k];
                }
            }
            det = 1;

            for (i = 0; i < matrix.Order; i++)
                det = det * matrix.Values[i, i];

            return det;
        }

        public static Matrix Multiply(this Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Order != matrix2.Order)
                throw new Exception();

            int order = matrix1.Order;
            var resultMatrix = new Matrix { Order = order };

            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    resultMatrix.Values[i, j] = 0;

                    for (int k = 0; k < order; k++)
                        resultMatrix.Values[i, j] += matrix1.Values[i, k] * matrix1.Values[k, j];
                }
            }
            return resultMatrix;
        }

        public static bool IsInvertible(this Matrix matrix)
        {
            int determinant = matrix.Determinant();
            return (determinant != 0 && ValueHelper.PGCD(determinant, 26) == 1);
        }
    }
}
