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
            var matrix = new Matrix
            {
                Values = new[,]
                {
                    {3, 1},
                    {5, 2}
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
            var matrix = new Matrix
            {
                Values = new[,]
                {
                    {1,2,3},
                    {4,5,6},
                    {7,8,9}
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
            var matrix1 = new Matrix
            {
                Values = new[,]
                {
                    {3, 1}
                }
            };

            var matrix2 = new Matrix
            {
                Values = new[,]
                {
                    {3, 1},
                    {5, 2}
                }
            };

            // act
            var resultMatrix = matrix1.Multiply(matrix2);

            // assert
            Assert.AreEqual(14, resultMatrix.Values[0, 0]);
            Assert.AreEqual(5, resultMatrix.Values[0, 1]);
        }

        [TestMethod]
        public void Is_Matrix_Invertible()
        {
            // arrange
            var matrix = new Matrix
            {
                Values = new[,]
                {
                    {7, 3},
                    {2, 3}
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
            var matrix = new Matrix
            {
                Values = new[,]
                {
                    {9, 3},
                    {2, 4}
                }
            };

            // act
            bool isInvertible = matrix.IsInvertible();

            // assert
            Assert.IsFalse(isInvertible);
        }
    }
}
