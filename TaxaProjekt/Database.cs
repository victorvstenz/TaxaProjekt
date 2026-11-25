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
using System.Security.Cryptography.Xml;

namespace TaxaProjekt
{
    public class Database
    {
        public Chauffør chauffør;

        public List<Chauffør> chaufførliste = new List<Chauffør>();


        public List<Kunde> kundeliste = new List<Kunde>();

        public List<Operatør> operatørliste = new List<Operatør>();

        public List<Bestilling> bestillingsliste = new List<Bestilling>();
        public List<Biler> billiste = new List<Biler>(); // Laver listen med bilerne.

        public void UploadOperatør()
        {
            Operatør operatør1 = new Operatør("op1", "op1");
            Operatør operatør2 = new Operatør("op2", "op2");

            operatørliste.Add(operatør1);
            operatørliste.Add(operatør2);
        }
        public void GemKunder()
        {
            string json = JsonSerializer.Serialize(kundeliste);
            File.WriteAllText("kunder.json", json);
        }

        public void LoadKunder()
        {
            if (File.Exists("kunder.json"))
            {
                string json = File.ReadAllText("kunder.json");
                kundeliste = JsonSerializer.Deserialize<List<Kunde>>(json)
                    ?? new List<Kunde>();
            }
        }

        public void GemChauffør()
        {
            string json = JsonSerializer.Serialize(chaufførliste);
            File.WriteAllText("chauffører.json", json);
        }

        public void LoadChauffør()
        {
            if (File.Exists("chauffører.json"))
            {
                string json = File.ReadAllText("chauffører.json");
                chaufførliste = JsonSerializer.Deserialize<List<Chauffør>>(json)
                    ?? new List<Chauffør>();
            }
        }
        public void GemBestilling()
        {
            string json = JsonSerializer.Serialize(bestillingsliste);
            File.WriteAllText("bestillinger.json", json);
        }

        public void LoadBestilling()
        {
            if (File.Exists("bestillinger.json"))
            {
                string json = File.ReadAllText("bestillinger.json");
                bestillingsliste = JsonSerializer.Deserialize<List<Bestilling>>(json)
                    ?? new List<Bestilling>();
            }
        }
        public void GemBiler()
        {
            string json = JsonSerializer.Serialize(billiste);
            File.WriteAllText("biler.json", json);
        }
        public void LoadBiler()
        {
            if (File.Exists("biler.json"))
            {
                string json = File.ReadAllText("biler.json");
                billiste = JsonSerializer.Deserialize<List<Biler>>(json)
                    ?? new List<Biler>();
            }
        }
    }

}