using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaxaProjekt
{
    /// <summary>
    /// Interaction logic for KundeMenu.xaml
    /// </summary>
    public partial class KundeMenu : Page
    {
        public MainWindow mainwindow;
        public KundeMenu()
        {
            InitializeComponent();
            mainwindow = (MainWindow)Application.Current.MainWindow;
        }

        TaxaSystem taxasystem = new TaxaSystem();
        private void ButtonOpretOrder_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.taxasystem.OpretBestilling(TextBoxKundeAdresse.Text, TextBoxKundeDestination.Text, TextBoxKundeNavn.Text, TextBoxKundeTid.Text, TextBoxTelefonNummer.Text);
        }
    }
}
