using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResolutionHill.Model;
using ResolutionHill.ViewModel.Helpers;

namespace ResolutionHill.Tests
{
    /// <summary>
    /// Description résumée pour MatrixUnitTest
    /// </summary>
    [TestClass]
    public class MatrixUnitTest
    {
        [TestMethod]
        public void Can_Calulate_Determinant_Matrix_Order_2()
        {
            // arrange
            var matrix = new Matrix(2, 2)
            {
                Values = new[,]
                {
                    {new MatrixCell {Value = 3}, new MatrixCell {Value = 1}},
                    {new MatrixCell {Value = 5}, new MatrixCell {Value = 2}}
                }
            };

            // act
            var det = matrix.Determinant();

            // assert
            Assert.AreEqual(1, det);
        }

        [TestMethod]
        public void Can_Calulate_Determinant_Matrix_Order_3()
        {
            // arrange
            var matrix = new Matrix(3, 3)
            {
                Values = new[,]
                {
                    {new MatrixCell {Value = 1}, new MatrixCell {Value = 2}, new MatrixCell {Value = 3}},
                    {new MatrixCell {Value = 4}, new MatrixCell {Value = 5}, new MatrixCell {Value = 6}},
                    {new MatrixCell {Value = 7}, new MatrixCell {Value = 8}, new MatrixCell {Value = 9}}
                }
            };

            // act
            var det = matrix.Determinant();

            // assert
            Assert.AreEqual(0, det);
        }

        [TestMethod]
        public void Can_Multiply_Matrix_Order_2()
        {
            // arrange
            var matrix1 = new Matrix(1, 2)
            {
                Values = new[,]
                {
                    {new MatrixCell {Value = 3}, new MatrixCell {Value = 1}}
                }
            };

            var matrix2 = new Matrix(2, 2)
            {
                Values = new[,]
                {
                    {new MatrixCell {Value = 3}, new MatrixCell {Value = 1}},
                    {new MatrixCell {Value = 5}, new MatrixCell {Value = 2}}
                }
            };

            // act
            var resultMatrix = matrix1.Multiply(matrix2);

            // assert
            Assert.AreEqual(14, resultMatrix.Values[0, 0].Value);
            Assert.AreEqual(5, resultMatrix.Values[0, 1].Value);
        }

        [TestMethod]
        public void Is_Matrix_Invertible()
        {
            // arrange
            var matrix = new Matrix(2, 2)
            {
                Values = new[,]
                {
                    {new MatrixCell {Value = 7}, new MatrixCell {Value = 3}},
                    {new MatrixCell {Value = 2}, new MatrixCell {Value = 3}}
                }
            };

            // act
            bool isInvertible = matrix.IsInvertible();

            // assert
            Assert.IsTrue(isInvertible);
        }

        [TestMethod]
        public void Is_Matrix_Not_Invertible()
        {
            // arrange
            var matrix = new Matrix(2, 2)
            {
                Values = new[,]
                {
                    {new MatrixCell {Value = 9}, new MatrixCell {Value = 3}},
                    {new MatrixCell {Value = 2}, new MatrixCell {Value = 4}}
                }
            };

            // act
            bool isInvertible = matrix.IsInvertible();

            // assert
            Assert.IsFalse(isInvertible);
        }
    }
}
