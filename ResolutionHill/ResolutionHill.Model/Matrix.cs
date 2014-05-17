namespace ResolutionHill.Model
{
    public class Matrix
    {
        #region Properties

        public int? Order { get { return Height == Width ? (int?)Height : null; } }

        public int Height { get { return Values.GetLength(0); } }
        public int Width { get { return Values.GetLength(1); } }

        private MatrixCell[,] _values = new MatrixCell[0, 0];
        public MatrixCell[,] Values
        {
            get { return _values; }
            set
            {
                _values = value;

                UnidimensionalValues = new MatrixCell[Width * Height];
                for (int i = 0; i < Height; i++)
                    for (int j = 0; j < Width; j++)
                        UnidimensionalValues[i * Width + j] = _values[i, j];
            }
        }

        private MatrixCell[] _unidimensionalValues = new MatrixCell[0];
        public MatrixCell[] UnidimensionalValues
        {
            get { return _unidimensionalValues; }
            set { _unidimensionalValues = value; }
        }

        #endregion


        #region Constuctor

        public Matrix(int height, int width)
        {
            _values = new MatrixCell[height, width];

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    Values[i, j] = new MatrixCell();

            UnidimensionalValues = new MatrixCell[Width * Height];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    UnidimensionalValues[i * Width + j] = _values[i, j];
        }

        #endregion
    }
}
