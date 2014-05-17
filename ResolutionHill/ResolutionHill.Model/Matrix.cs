namespace ResolutionHill.Model
{
    public class Matrix
    {
        public int? Order { get { return Height == Width ? (int?)Height : null; } }

        public int Height { get { return Values.GetLength(0); } }
        public int Width { get { return Values.GetLength(1); } }

        private int[,] _values = new int[0, 0];
        public int[,] Values
        {
            get { return _values; }
            set
            {
                _values = value;

                UnidimensionalValues = new int[Width * Height];
                for (int i = 0; i < Width; i++)
                    for (int j = 0; j < Height; j++)
                        UnidimensionalValues[i*Height + j] = _values[i, j];
            }
        }

        private int[] _unidimensionalValues = new int[0];
        public int[] UnidimensionalValues
        {
            get { return _unidimensionalValues; }
            set { _unidimensionalValues = value; }
        }
    }
}
