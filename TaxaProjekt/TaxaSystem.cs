using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Windows;

namespace TaxaProjekt
{
    public class TaxaSystem
    {
        public Kunde kunde;
        public Database database;
        public MainWindow mainwindow;
        public Chauffør chauffør;
        public Bestilling bestilling;
       
        public void TilføjKunde(string navn, string kode)
        {
            Kunde kunde = new Kunde(navn, kode);
            database.kundeliste.Add(kunde);
            database.GemKunder();
            MessageBox.Show($"""
                Bruger oprettet!
                Username: {kunde.Navn}
                Password: {kunde.Kode}
                """);
            KundeOpretFærdig();
        }

        private void KundeOpretFærdig()
        {
            mainwindow.MainFrame.Navigate(null);
        }

        public void TilføjChauffør(string navn, string kode, string arbejdstid)
        {
            Chauffør chauffør = new Chauffør(navn, kode, arbejdstid);
            database.chaufførliste.Add(chauffør);
            database.GemChauffør();
            MessageBox.Show($"""
                Bruger oprettet!
                Username: {chauffør.Navn}
                Password: {chauffør.Kode}
                """);
            ChaufførOpretFærdig();
        }

        private void ChaufførOpretFærdig()
        {
            mainwindow.MainFrame.Navigate(new Operatø());
        }
        
        public void OpretBestilling(string adresse, string destination, string navn, string tid, string telefonnummer)
        {
            Bestilling bestilling = new Bestilling(adresse, destination, navn, tid, telefonnummer);
            database.bestillingsliste.Add(bestilling);
            database.GemBestilling();
            MessageBox.Show("Taxa Bestilt");
        }

        public void LogIn()
        {
            bool LoggedIn = database.kundeliste.Any(kunde => mainwindow.TextBoxUsername.Text == kunde.Navn &&
mainwindow.PasswordBoxPassword.Password == kunde.Kode);

            bool LoggedInChauffør = false;

            foreach (Chauffør chaufførOn in database.chaufførliste)
            {
                if (mainwindow.TextBoxUsername.Text == chaufførOn.Navn &&
                    mainwindow.PasswordBoxPassword.Password == chaufførOn.Kode)
                {
                    chauffør = chaufførOn;
                    LoggedInChauffør = true;
                    break;
                }
            }

            bool LoggedInOperatør = database.operatørliste.Any(Operatør => mainwindow.TextBoxUsername.Text == Operatør.Navn &&
mainwindow.PasswordBoxPassword.Password == Operatør.Kode);

            if (LoggedIn)
            {
                MessageBox.Show("Godkendt");
                mainwindow.MainFrame.Navigate(new KundeMenu());
            }
            else if (LoggedInChauffør)
            {
                MessageBox.Show("Godkendt");
                mainwindow.MainFrame.Navigate(new ChaufførMenu());
            }
            else if (LoggedInOperatør)
            {
                MessageBox.Show("Godkendt");
                mainwindow.MainFrame.Navigate(new Operatø());
            }

            else
            {
                MessageBox.Show("Forkert");
            }
        }
        public double SamletTid()
        {
            Chauffør cha = mainwindow.taxasystem.chauffør;

            if (cha.CheckIndTid != null && cha.CheckUdTid != null)
            {
                cha.Tid += (cha.CheckUdTid.Value - cha.CheckIndTid.Value).TotalMinutes;
            }
            return cha.Tid;
        }
        public void TilføjBil(string navn, string årgang, string mærke)
        {
            Biler bil = new Biler(navn, årgang, mærke);
            database.billiste.Add(bil);
            database.GemBiler();
            MessageBox.Show("Bil tilføjet");
        }
    }
}
