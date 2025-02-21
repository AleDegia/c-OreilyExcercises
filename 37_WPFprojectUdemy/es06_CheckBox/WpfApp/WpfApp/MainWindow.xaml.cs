using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cbCheese_Checked(object sender, RoutedEventArgs e)
        {
            lbCheese.Background = Brushes.Gray;
        }

        private void cbCheese_Unchecked(object sender, RoutedEventArgs e)
        {
            lbCheese.Background = Brushes.White;
        }

        private void cbParentCheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (cbParent.IsChecked == true);
            cbCheese.IsChecked = newVal;
            cbPeperoni.IsChecked = newVal;
            cbTuna.IsChecked = newVal;

            // Assicurati che cbParent non entri mai nello stato "Indeterminate"
            cbParent.IsChecked = newVal ? (bool?)true : (bool?)false;
        }

        private void cbParentUncheckedChanged(object sender, RoutedEventArgs e)
        {
            //cbParent.IsChecked = null;
            bool newVal = (cbParent.IsChecked == true);
            cbCheese.IsChecked = newVal;
            cbPeperoni.IsChecked = newVal;
            cbTuna.IsChecked = newVal;
        }

        private void cbToppingCheckedChanged(object sender, RoutedEventArgs e)
        {
            cbParent.IsChecked = null;
            if (cbCheese.IsChecked == true && cbPeperoni.IsChecked == true && cbTuna.IsChecked == true)
            {
                cbParent.IsChecked = true;
            }
            else if(cbCheese.IsChecked == false && cbPeperoni.IsChecked == false && cbTuna.IsChecked == false)
            {
                cbParent.IsChecked = false;
            }
        }
    }
}
