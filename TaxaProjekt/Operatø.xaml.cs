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
    /// Interaction logic for Operatø.xaml
    /// </summary>
    public partial class Operatø : Page
    {
        public Operatø()
        {
            InitializeComponent();
            mainwindow = (MainWindow)Application.Current.MainWindow;

            ListBoxStatus.Items.Refresh(); //Er den her nødvendig?
            ListBoxStatus.ItemsSource = mainwindow.taxasystem.database.chaufførliste;
            ListBoxStatus.Items.Refresh();
            VisAllesArbejdsTid();
            ListBoxBilAktivitet.ItemsSource = mainwindow.taxasystem.database.billiste;
            ListBoxBilAktivitet.Items.Refresh();
            ListBoxBestillinger.ItemsSource = mainwindow.taxasystem.database.bestillingsliste;
            ListBoxBilAktivitet.Items.Refresh();
        }
        public MainWindow mainwindow;
        private void ButtonOpretKonto_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.MainFrame.Navigate(new OpretChauffør());
        }

        private void ListBoxAlleChaufførTid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void VisAllesArbejdsTid()
        {
            ListBoxAlleChaufførTid.Items.Clear();

            foreach (Chauffør chauffør in mainwindow.database.chaufførliste)
            {
                ListBoxAlleChaufførTid.Items.Add(chauffør.Navn + " - " + chauffør.Tid.ToString("F2") + " timer");
            }
        }

        private void ButtonSletChauffør_Click(object sender, RoutedEventArgs e)
        {
            Chauffør valgtchauffør = (Chauffør)ListBoxStatus.SelectedItem;
            if(valgtchauffør != null)
            {
                mainwindow.database.chaufførliste.Remove(valgtchauffør);
                ListBoxStatus.Items.Refresh();
                VisAllesArbejdsTid();
            }
        }

        private void ButtonTilføjBil_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.MainFrame.Navigate(new TilføjBilNy());
        }

        private void ButtonTilegnOrdre_Click(object sender, RoutedEventArgs e)
        {
            Bestilling valgtbestilling = (Bestilling)ListBoxBestillinger.SelectedItem;
            Chauffør valgtchauffør = (Chauffør)ListBoxStatus.SelectedItem;

            valgtchauffør.bestilling = valgtbestilling;
            mainwindow.database.GemChauffør();
            mainwindow.database.GemBestilling();
            MessageBox.Show($"Ordre: {valgtbestilling.Navn} tilegnet: {valgtchauffør.Navn}");
        }
    }
}
