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
            var matrix = new Matrix {Order = 2 };
            matrix.Values[0, 0] = 3;
            matrix.Values[0, 1] = 1;
            matrix.Values[1, 0] = 5;
            matrix.Values[1, 1] = 2;

            // act
            var det = matrix.Determinant();

            // assert
            Assert.AreEqual(1, det);
        }

        [TestMethod]
        public void Can_Calulate_Determinant_Matrix_Order_3()
        {
            // arrange
            var matrix = new Matrix { Order = 3 };
            matrix.Values[0, 0] = 1;
            matrix.Values[0, 1] = 2;
            matrix.Values[0, 2] = 3;

            matrix.Values[1, 0] = 4;
            matrix.Values[1, 1] = 5;
            matrix.Values[1, 2] = 6;

            matrix.Values[2, 0] = 7;
            matrix.Values[2, 1] = 8;
            matrix.Values[2, 2] = 9;

            // act
            var det = matrix.Determinant();

            // assert
            Assert.AreEqual(0, det);
        }
    }
}
