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

namespace WpfApp4
{
    /// <summary>
    /// Klasa okna dziedzicząca z window, (renderuje okno)
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Inicjalizacja Okna, dodanie danych do DataDridów
        /// </summary>
        /// 
        public MainWindow()
        {
            InitializeComponent();
            Database1Entities db = new Database1Entities();
            var req = from d in db.Clients
                      select new {
                      name = d.name,
                      email = d.email,
                      password = d.password
                      };

            this.DataGridClients.ItemsSource = req.ToList();

            Database1Entities2 db2 = new Database1Entities2();
            var req2 = from a in db2.accountsTypes
                       select new {
                           type = a.accountType
                       };

            this.DataGridAccTypes.ItemsSource = req2.ToList();
        }

        private void inputUserButton_Click(object sender, RoutedEventArgs e)
        {
            Database1Entities db = new Database1Entities();
            Client clientObj = new Client() {
                name = inputName.Text,
                email = inputEmail.Text,
                password = inputPassword.Text
            };
            db.Clients.Add(clientObj);
            db.SaveChanges();
        }

        private void ReLoad_Click(object sender, RoutedEventArgs e)
        {
            Database1Entities db = new Database1Entities();
            this.DataGridClients.ItemsSource = db.Clients.ToList();
        }

        private void DataGridClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(this.DataGridClients.SelectedItems);
        }

        private void inputTypeButton_Click(object sender, RoutedEventArgs e)
        {
            Database1Entities2 db2 = new Database1Entities2();
            accountsType typeObj = new accountsType()
            {
                accountType = inputAccountType.Text,
            };
            db2.accountsTypes.Add(typeObj);
            db2.SaveChanges();
        }

        private void ReLoad2_Click(object sender, RoutedEventArgs e)
        {
            Database1Entities2 db2 = new Database1Entities2();
            this.DataGridAccTypes.ItemsSource = db2.accountsTypes.ToList();

        }
    }
}
