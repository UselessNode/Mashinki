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
    /// Логика взаимодействия для PurchasesForm.xaml
    /// </summary>
    public partial class PurchasesForm : Window
    {
        MainWindow mainWindow;
        bool addingForm = false;
        Purchase purchase;

        // 📝 Creating Form
        public PurchasesForm(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.addingForm = true;
            this.Button_Save.Content = "📝 | Добавить запись";
            LoadData();
            
        }

        // 🔄 Updating Form
        public PurchasesForm(MainWindow mainWindow, Purchase purchase)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.purchase = purchase;
            this.Button_Save.Content = "💾 | Сохранить изменения";
            LoadData();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (addingForm)
            {
                Purchase newPurchase = new Purchase();
                ValidateData(newPurchase);
                mainWindow.Entities.Purchase.Add(newPurchase);
            }
            else
                ValidateData(purchase);
            mainWindow.Entities.SaveChanges();
            mainWindow.ReadData();
            Hide();
        }

        Purchase ValidateData(Purchase purchase)
        {
            purchase ??= new Purchase();
            purchase.ClientId = ComboBox_ClientId.SelectedIndex;
            purchase.AutoId = ComboBox_AutoID.SelectedIndex;
            purchase.DateOfPurchase = DateTime.Parse(TextBox_Date.Text);
            return purchase;
        }

        void LoadData()
        {
            ComboBox_AutoID.ItemsSource = mainWindow.Entities.Auto.ToList();
            ComboBox_ClientId.ItemsSource = mainWindow.Entities.Client.ToList();
        }
    }
}
