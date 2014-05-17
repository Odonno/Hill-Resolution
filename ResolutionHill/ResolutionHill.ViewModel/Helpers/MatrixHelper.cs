using System;
using ResolutionHill.Model;

namespace ResolutionHill.ViewModel.Helpers
{
    public static class MatrixHelper
    {
        public static int Determinant(this Matrix matrix)
        {
            int i, j, j1, j2;

            if (matrix.Order < 1)
                throw new Exception();

            if (matrix.Order == 1)
                return matrix.Values[0, 0];

            if (matrix.Order == 2)
                return matrix.Values[0, 0] * matrix.Values[1, 1] - matrix.Values[1, 0] * matrix.Values[0, 1];

            int det = 0;
            var subMatrix = new Matrix { Order = matrix.Order - 1 };

            for (j1 = 0; j1 < matrix.Order; j1++)
            {
                for (i = 1; i < matrix.Order; i++)
                {
                    j2 = 0;

                    for (j = 0; j < matrix.Order; j++)
                    {
                        if (j == j1)
                            continue;
                        subMatrix.Values[i - 1, j2] = matrix.Values[i, j];
                        j2++;
                    }
                }
                det += (int)Math.Pow(-1.0, 1.0 + j1 + 1.0) * matrix.Values[0, j1] * Determinant(subMatrix);
            }

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

        public static bool IsInversible(this Matrix matrix)
        {
            int determinant = matrix.Determinant();
            return (determinant != 0 && ValueHelper.PGCD(determinant, 26) == 1);
        }
    }
}
