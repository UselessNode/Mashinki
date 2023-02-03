using Mashinki.EF;
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
using System.Windows.Shapes;

namespace Mashinki
{
    /// <summary>
    /// Логика взаимодействия для ClientsForm.xaml
    /// </summary>
    public partial class ClientsForm : Window
    {
        MainWindow mainWindow;
        bool addingForm = false;
        Client client;

        // 📝 Creating Form
        public ClientsForm(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.addingForm = true;
            Button_Save.Content = "📝 | Добавить запись";
        }

        // 🔄 Updating Form
        public ClientsForm(MainWindow mainWindow, Client client)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.client = client;
            this.DataContext = client;
            Button_Save.Content = "💾 | Сохранить изменения";
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (addingForm)
            {
                Client newClient = new Client();
                ValidateData(newClient);
                mainWindow.Entities.Client.Add(newClient);
            }
            else
                ValidateData(client);
            mainWindow.Entities.SaveChanges();
            mainWindow.ReadData();
            Hide();
        }

        Client ValidateData(Client client)
        {
            client ??= new Client();
            client.FirstName          = TextBox_FirstName.Text;
            client.MiddleName         = TextBox_MiddleName.Text;
            client.LastName           = TextBox_LastName.Text;
            client.Gender             = TextBox_Gender.Text;
            client.DateOfBirth        = DateTime.Parse(TextBox_DateOfBirth.Text);
            client.DateOfRegistration = DateTime.Parse(TextBox_DateOfRegistration.Text);
            return client;

        }
    }
}
