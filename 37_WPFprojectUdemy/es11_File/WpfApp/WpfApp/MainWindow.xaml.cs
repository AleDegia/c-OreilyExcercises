using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog, che è una finestra di dialogo standard per l'apertura di file
            OpenFileDialog openFile = new OpenFileDialog(); 
            if(openFile.ShowDialog() == true)       //true vuol dire che è stato selezionato un file
            {
                //FileName è una proprietà dell'oggetto openFile che restituisce il percorso completo del file selezionato dall'utente nella finestra di dialogo.
                myTextBox.Text = File.ReadAllText(openFile.FileName);
            }
        }
    }
}
