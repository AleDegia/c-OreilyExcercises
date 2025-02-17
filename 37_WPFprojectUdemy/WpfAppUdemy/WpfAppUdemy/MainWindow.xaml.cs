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

namespace WpfAppUdemy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyButton.FontSize = 50;
            MyButton.Content = "Helloo";    //sovrascrive poichè è dopo l'InitializeComponent()
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Ottieni l'URL dal parametro 'Uri' dell'evento
            string url = e.Uri.AbsoluteUri;

            // Usa Process.Start per aprire l'URL nel browser predefinito
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true // Apre l'URL nel browser
            });

            // Evita che l'evento venga ulteriormente gestito
            e.Handled = true;

        }
    }
}
