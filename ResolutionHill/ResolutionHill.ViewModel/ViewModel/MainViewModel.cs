using System;
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
            return HillText.Key != null && HillText.Key.Order != null && HillText.ClearedText != null &&
                   HillText.ClearedText.Length % HillText.Key.Order == 0 && HillText.Key.IsInvertible();
        }
        public void FindCryptedText()
        {
            if (HillText.Key.Order != null)
            {
                int order = (int)HillText.Key.Order;
                string cryptedTextCorrect = HillText.ClearedText.OnlyAToZ();

                int textSegmentsCount = cryptedTextCorrect.Length / order;

                var cryptedTextBuilder = new StringBuilder(cryptedTextCorrect.Length);
                var temporaryTextBuilder = new StringBuilder(order);

                var temporaryMatrix = new Matrix(1, order);

                for (int i = 0; i < textSegmentsCount; i++)
                {
                    temporaryTextBuilder.Clear();

                    // Get N values of letter in cleared text
                    for (int j = 0; j < order; j++)
                        temporaryMatrix.Values[0, j].Value = cryptedTextCorrect[i * order + j].CharToIntModulo26();

                    // Calculate the new matrix using the previous values and the key matrix
                    temporaryMatrix = temporaryMatrix.Multiply(HillText.Key);

                    // Append all new crypted letter from the previous calculation matrix
                    for (int j = 0; j < order; j++)
                        temporaryTextBuilder.Append(temporaryMatrix.Values[0, j].Value.IntToCharModulo26());

                    // Add the the segment crypted text to the builder of the full crypted text
                    cryptedTextBuilder.Append(temporaryTextBuilder.ToString());
                }

                // get the final crypted and save it in the model
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
            return HillText.Key != null && HillText.Key.Order != null && HillText.CryptedText != null &&
                   HillText.CryptedText.Length % HillText.Key.Order == 0 && HillText.Key.IsInvertible();
        }
        public void FindClearedText()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}