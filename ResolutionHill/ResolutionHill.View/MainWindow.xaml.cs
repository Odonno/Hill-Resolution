using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ResolutionVigenere.View.ViewModel;

namespace ResolutionHill.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties

        private MainViewModel _mainViewModel = Application.Current.Resources.Values.OfType<MainViewModel>().FirstOrDefault();

        #endregion


        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            RefreshMatrixGrid();
        }

        #endregion


        #region Methods

        private void KeyOrder_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshMatrixGrid();
        }

        private void RefreshMatrixGrid()
        {
            if (_mainViewModel != null && gridMatrixKey != null)
            {
                // Clear grid
                gridMatrixKey.Children.Clear();
                gridMatrixKey.RowDefinitions.Clear();
                gridMatrixKey.ColumnDefinitions.Clear();

                // Redefine rows and columns
                for (int i = 0; i < _mainViewModel.KeyOrder; i++)
                {
                    gridMatrixKey.RowDefinitions.Add(new RowDefinition());
                    gridMatrixKey.ColumnDefinitions.Add(new ColumnDefinition());
                }

                // Recreate textboxes (values of the key matrix)
                for (int i = 0; i < _mainViewModel.HillText.Key.Width; i++)
                    for (int j = 0; j < _mainViewModel.HillText.Key.Height; j++)
                    {
                        var textBoxMatrixValue = new TextBox
                        {
                            VerticalContentAlignment = VerticalAlignment.Center,
                            HorizontalContentAlignment = HorizontalAlignment.Center
                        };

                        // set binding for the value
                        var binding = new Binding
                        {
                            Source = _mainViewModel.HillText.Key,
                            Mode = BindingMode.TwoWay,
                            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                            Path = new PropertyPath(string.Format("UnidimensionalValues[{0}]", i * _mainViewModel.HillText.Key.Height + j))
                        };
                        textBoxMatrixValue.SetBinding(TextBox.TextProperty, binding);

                        // set the position in the matrix grid
                        Grid.SetRow(textBoxMatrixValue, i);
                        Grid.SetColumn(textBoxMatrixValue, j);

                        gridMatrixKey.Children.Add(textBoxMatrixValue);
                    }
            }
        }

        #endregion
    }
}
