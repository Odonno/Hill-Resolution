using System;
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
                HillText.Key.Values = new int[value, value];
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
            return HillText.Key.IsInvertible();
        }
        public void FindCryptedText()
        {
            throw new NotImplementedException();
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
            return HillText.Key.IsInvertible();
        }
        public void FindClearedText()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}