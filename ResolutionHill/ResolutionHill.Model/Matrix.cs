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
            set { _values = value; }
        }
    }
}
