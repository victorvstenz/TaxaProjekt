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
    /// Interaction logic for ChaufførMenu.xaml
    /// </summary>
    public partial class ChaufførMenu : Page
    {
        public MainWindow mainwindow;
        public TaxaSystem taxasystem;
        public ChaufførMenu()
        {
            InitializeComponent();
            mainwindow = (MainWindow)Application.Current.MainWindow;
            taxasystem = mainwindow.taxasystem;
            ListBoxStatus1.Items.Add(mainwindow.taxasystem.chauffør);
            ListBoxBilAktivitet1.ItemsSource = mainwindow.taxasystem.database.billiste;
            ListBoxBilAktivitet1.Items.Refresh();
            ListBoxAktivOrdre.ItemsSource = mainwindow.taxasystem.database.chaufførliste;
            ListBoxAktivOrdre.Items.Add(mainwindow.taxasystem.chauffør.bestilling);
            ListBoxAktivOrdre.Items.Refresh();
            if (mainwindow.taxasystem.chauffør.PåArbejde == true)
            {
                ButtonAktivInaktiv.Content = "Check ud";
            }
            ComboBoxVælgBil.ItemsSource = mainwindow.database.billiste;
            ComboBoxVælgBil.DisplayMemberPath = "Navn"; // Viser kun bilens navn.
            ListBoxBilValgt.DisplayMemberPath = "Navn"; // Viser kun bilens navn.
        }

        private void ButtonStatusLedig_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.taxasystem.chauffør.Status = "Ledig";
            mainwindow.taxasystem.database.GemChauffør();
            ListBoxStatus1.Items.Refresh();
        }

        private void ButtonStatusUtilgængelig_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.taxasystem.chauffør.Status = "Utilgængelig";
            mainwindow.taxasystem.database.GemChauffør();
            ListBoxStatus1.Items.Refresh();
        }

        private void ButtonStatusPause_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.taxasystem.chauffør.Status = "Pause";
            mainwindow.taxasystem.database.GemChauffør();
            ListBoxStatus1.Items.Refresh();
        }

        private void ButtonStatusFri_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.taxasystem.chauffør.Status = "Fri";
            mainwindow.taxasystem.database.GemChauffør();
            ListBoxStatus1.Items.Refresh();
        }

        private void ButtonAktivInaktiv_Click(object sender, RoutedEventArgs e)
        {
            Chauffør chauffør = mainwindow.taxasystem.chauffør;

            if (chauffør.PåArbejde == false)
            {
                chauffør.PåArbejde = true;
                chauffør.CheckIndTid = DateTime.Now;
                chauffør.Status = "Ledig";
                ListBoxBilAktivitet1.Items.Refresh();
                ButtonAktivInaktiv.Content = "Check ud";
            }
            else
            {
                chauffør.PåArbejde = false;
                chauffør.CheckUdTid = DateTime.Now;
                chauffør.Status = "Fri";
                taxasystem.SamletTid();
                taxasystem.database.GemChauffør();
                chauffør.biler.Aktivitet = "Ledig";
                ListBoxBilAktivitet1.Items.Refresh();
                taxasystem.database.GemChauffør();
                taxasystem.database.GemBiler();
                ListBoxBilAktivitet1.Items.Refresh();
                ButtonAktivInaktiv.Content = "Check ind";

                VisArbejdsTid();
            }
            mainwindow.database.GemChauffør();
            ListBoxStatus1.Items.Refresh();
        }

        private void ListBoxChaufførTid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void VisArbejdsTid()
        {
            Chauffør chauffør = mainwindow.taxasystem.chauffør;
            ListBoxChaufførTid.Items.Clear();
            ListBoxChaufførTid.Items.Add(chauffør.Tid.ToString("F2") + " timer");
        }

        private void ComboBoxVælgBil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Biler valgtbil = (Biler)ComboBoxVælgBil.SelectedItem;
            if(valgtbil != null)
            {
                ListBoxBilValgt.Items.Add(valgtbil);
                mainwindow.taxasystem.chauffør.biler = valgtbil; // Nu får chaufføren den unikke bil.
                mainwindow.taxasystem.chauffør.biler.Aktivitet = "Optaget"; // Nu er bilens aktivitet ændret.
                mainwindow.taxasystem.database.GemChauffør();
                mainwindow.taxasystem.database.GemBiler();
            }
        }

        private void ListBoxBilAktivitet1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
