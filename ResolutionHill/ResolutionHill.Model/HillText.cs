using System.ComponentModel;

namespace ResolutionHill.Model
{
    public class HillText : INotifyPropertyChanged
    {
        #region Properties

        private string _clearedText;
        public string ClearedText
        {
            get { return _clearedText; }
            set { _clearedText = value; RaisePropertyChanged("ClearedText"); }
        }

        private Matrix _key = new Matrix { Values = new int[2, 2] };
        public Matrix Key
        {
            get { return _key; }
            set { _key = value; RaisePropertyChanged("Key"); }
        }

        private string _cryptedText;
        public string CryptedText
        {
            get { return _cryptedText; }
            set { _cryptedText = value; RaisePropertyChanged("CryptedText"); }
        }

        #endregion

        #region PropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
