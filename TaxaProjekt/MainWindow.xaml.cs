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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            database = new Database();
            database.LoadKunder();
            database.LoadChauffør();
            database.UploadOperatør();
            database.LoadBestilling();
            database.LoadBiler();

            taxasystem = new TaxaSystem();

            taxasystem.database = database;
            taxasystem.mainwindow = this;
        }
        public Database database;
        public TaxaSystem taxasystem;

        private void ButtonOpretBruger_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new KundeOpret());
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            taxasystem.LogIn();
        }
    }
}