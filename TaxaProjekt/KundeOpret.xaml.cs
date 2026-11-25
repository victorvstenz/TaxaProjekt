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
using System.Text.Json;
using System.IO;

namespace TaxaProjekt
{
    /// <summary>
    /// Interaction logic for KundeOpret.xaml
    /// </summary>
    public partial class KundeOpret : Page
    {
        public KundeOpret()
        {
            InitializeComponent();
            mainwindow = (MainWindow)Application.Current.MainWindow;
        }
        public MainWindow mainwindow;
        TaxaSystem taxasystem = new TaxaSystem();
        private void ButtonOpretKonto_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.taxasystem.TilføjKunde(TextBoxUsernameOpret.Text, TextBoxPasswordOpret.Text);
        }
    }
}
