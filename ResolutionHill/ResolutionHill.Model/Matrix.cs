namespace ResolutionHill.Model
{
    public class Matrix
    {
        private int _order;
        public int Order
        {
            get { return _order; }
            set { _order = value; _values = new int[_order, _order]; }
        }

        private int[,] _values = new int[0, 0];
        public int[,] Values  { get { return _values; }  }
    }
}
