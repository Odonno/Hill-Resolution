﻿using System;
using System.Text;
using ResolutionHill.Model;

namespace ResolutionHill.ViewModel.Helpers
{
    public static class MatrixHelper
    {
        public static int Determinant(this Matrix matrix)
        {
            int i, j, j1, j2;

            if (matrix.Order == null)
                throw new Exception();

            if (matrix.Order < 1)
                throw new Exception();

            if (matrix.Order == 1)
                return matrix.Values[0, 0].Value;

            if (matrix.Order == 2)
                return matrix.Values[0, 0].Value * matrix.Values[1, 1].Value - matrix.Values[1, 0].Value * matrix.Values[0, 1].Value;

            int det = 0;
            var subMatrix = new Matrix((int)matrix.Order - 1, (int)matrix.Order - 1);

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
                det += (int)Math.Pow(-1.0, 1.0 + j1 + 1.0) * matrix.Values[0, j1].Value * Determinant(subMatrix);
            }

            return det;
        }

        public static Matrix Multiply(this Matrix matrix1, Matrix matrix2)
        {
            var resultMatrix = new Matrix(matrix1.Height, matrix2.Width);

            for (int i = 0; i < resultMatrix.Height; i++)
                for (int j = 0; j < resultMatrix.Width; j++)
                {
                    resultMatrix.Values[i, j].Value = 0;

                    for (int k = 0; k < matrix1.Width; k++)
                        resultMatrix.Values[i, j].Value += matrix1.Values[i, k].Value * matrix2.Values[k, j].Value;
                }

            return resultMatrix;
        }

        public static Matrix InvertibleMatrix(this Matrix matrix)
        {
            if (!matrix.IsInvertible())
            throw new Exception();

            int determinant = matrix.Determinant();
            int inverseDeterminant = ValueHelper.InverseModulo26(ValueHelper.Modulo26(determinant));

            var resultMatrix = new Matrix(matrix.Height, matrix.Width);

            // get the inverse of a matrix
            // TODO : do it generic (not only for order 2)
            resultMatrix.Values[0, 0].Value = matrix.Values[1, 1].Value;
            resultMatrix.Values[0, 1].Value = -matrix.Values[0, 1].Value;
            resultMatrix.Values[1, 0].Value = -matrix.Values[1, 0].Value;
            resultMatrix.Values[1, 1].Value = matrix.Values[0, 0].Value;

            for (int i = 0; i < resultMatrix.Height; i++)
                for (int j = 0; j < resultMatrix.Width; j++)
                    // multiply each value of the matrix by the "inverseDeterminant" and take care of the modulo (26)
                    resultMatrix.Values[i, j].Value = ValueHelper.Modulo26(resultMatrix.Values[i, j].Value * inverseDeterminant);

            return resultMatrix;
        }

        public static bool IsInvertible(this Matrix matrix)
        {
            int determinant = matrix.Determinant();
            return (determinant != 0 && ValueHelper.PGCD(determinant, 26) == 1);
        }

        public static Matrix ConvertStringToMatrix(this string text)
        {
            var matrix = new Matrix(1, text.Length);
            for (int i = 0; i < matrix.Width; i++)
                matrix.Values[0, i].Value = text[i].CharToIntModulo26();

            return matrix;
        }

        public static string ConvertMatrixToString(this Matrix matrix)
        {
            var stringBuilder = new StringBuilder(matrix.Width);
            for (int i = 0; i < matrix.Width; i++)
                stringBuilder.Append(matrix.Values[0, i].Value.IntToCharModulo26());

            return stringBuilder.ToString();
        }
    }
}
