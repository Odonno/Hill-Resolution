using System;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ResolutionHill.Model;
using ResolutionHill.ViewModel.Helpers;
using ResolutionHill.ViewModel.ViewModel;

namespace ResolutionVigenere.View.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        private readonly HillText _hillText = new HillText();
        public HillText HillText { get { return _hillText; } }

        public int _keyOrder = 2;
        public int KeyOrder
        {
            get { return _keyOrder; }
            set
            {
                if (value < 2)
                    value = 2;

                if (value == _keyOrder)
                    return;

                _keyOrder = value;
                HillText.Key.Values = new MatrixCell[value, value];
                RaisePropertyChanged("KeyOrder");
            }
        }

        public ICommand FindCryptedTextCommand { get; private set; }
        public ICommand FindKeyCommand { get; private set; }
        public ICommand FindClearedTextCommand { get; private set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            FindCryptedTextCommand = new RelayCommand(FindCryptedText, CanFindCryptedText);
            FindKeyCommand = new RelayCommand(FindKey, CanFindKey);
            FindClearedTextCommand = new RelayCommand(FindClearedText, CanFindClearedText);
        }

        #endregion


        #region Methods

        public bool CanFindCryptedText()
        {
            return HillText.Key != null && HillText.Key.Order != null && HillText.ClearedText != null && HillText.ClearedText.Length > HillText.Key.Order &&
                   HillText.ClearedText.Length % HillText.Key.Order == 0 && HillText.Key.IsInvertible();
        }
        public void FindCryptedText()
        {
            if (HillText.Key.Order != null)
            {
                int order = (int)HillText.Key.Order;
                string clearedText = HillText.ClearedText.OnlyAToZ();
                int textSegmentsCount = clearedText.Length / order;
                var cryptedTextBuilder = new StringBuilder(clearedText.Length);

                for (int i = 0; i < textSegmentsCount; i++)
                {
                    // Get N values of letter in cleared text
                    Matrix temporaryMatrix = clearedText.Substring(i * order, order).ConvertStringToMatrix();

                    // Calculate the new matrix using the previous values and the key matrix
                    temporaryMatrix = temporaryMatrix.Multiply(HillText.Key);

                    // Append all new crypted letter from the previous calculation matrix
                    string temporaryText = temporaryMatrix.ConvertMatrixToString();

                    // Add the the segment crypted text to the builder of the full crypted text
                    cryptedTextBuilder.Append(temporaryText);
                }

                // get the final crypted text and save it in the model
                HillText.CryptedText = cryptedTextBuilder.ToString();
            }
        }

        public bool CanFindKey()
        {
            return HillText.CryptedText != null && HillText.ClearedText != null &&
                   HillText.ClearedText.Length >= 4 && HillText.CryptedText.Length >= 4 &&
                   HillText.ClearedText.Length == HillText.CryptedText.Length;
        }
        public void FindKey()
        {
            throw new NotImplementedException();
        }

        public bool CanFindClearedText()
        {
            return HillText.Key != null && HillText.Key.Order != null && HillText.CryptedText != null && HillText.CryptedText.Length > HillText.Key.Order &&
                   HillText.CryptedText.Length % HillText.Key.Order == 0 && HillText.Key.IsInvertible();
        }
        public void FindClearedText()
        {
            if (HillText.Key.Order != null)
            {
                int order = (int)HillText.Key.Order;
                string cryptedText = HillText.CryptedText.OnlyAToZ();
                int textSegmentsCount = cryptedText.Length / order;
                var clearedTextBuilder = new StringBuilder(cryptedText.Length);
                var invertibleKeyMatrix = HillText.Key.InvertibleMatrix();

                for (int i = 0; i < textSegmentsCount; i++)
                {
                    // Get N values of letter in crypted text
                    Matrix temporaryMatrix = cryptedText.Substring(i * order, order).ConvertStringToMatrix();

                    // Calculate the new matrix using the previous values and the invertible key matrix
                    temporaryMatrix = temporaryMatrix.Multiply(invertibleKeyMatrix);

                    // Append all new crypted letter from the previous calculation matrix
                    string temporaryText = temporaryMatrix.ConvertMatrixToString();

                    // Add the the segment cleared text to the builder of the full cleared text
                    clearedTextBuilder.Append(temporaryText);
                }

                // get the final cleared text and save it in the model
                HillText.ClearedText = clearedTextBuilder.ToString();
            }
        }

        #endregion
    }
}