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
    /// Interaction logic for TilføjBilNy.xaml
    /// </summary>
    public partial class TilføjBilNy : Page
    {
        public MainWindow mainwindow;
        public TilføjBilNy()
        {
            InitializeComponent();
            mainwindow = (MainWindow)Application.Current.MainWindow;
        }

        private void ButtonTilføjBil_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.taxasystem.TilføjBil(TextBoxTilBilNavn.Text, TextBoxTilBilÅrgang.Text, TextBoxTilBilMærke.Text);
            mainwindow.MainFrame.Navigate(new Operatø());
        }
    }
}
