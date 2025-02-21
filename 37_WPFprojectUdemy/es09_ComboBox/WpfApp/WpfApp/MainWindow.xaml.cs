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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // sender è di tipo object, è un riferimento generico a un oggetto che ha scatenato l'evento.
            ComboBox cBox = (ComboBox)sender;       //faccio il cast per poter accedere alle proprieta della classe ComboBox
            //cBox.SelectedItem rappresenta l'elemento selezionato all'interno del ComboBox.
            // gli elementi di un ComboBox sono di tipo ComboBoxItem 
            ComboBoxItem cbItem = (ComboBoxItem)cBox.SelectedItem;
            string newFontSize = (string)cbItem.Content;

            int temp;
            if(Int32.TryParse(newFontSize, out temp))
            {
                if(myTextBox!= null)
                {
                    myTextBox.FontSize = temp;
                }
            }
        }
    }
}
