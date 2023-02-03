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
    /// Логика взаимодействия для AutoTypesForm.xaml
    /// </summary>
    public partial class AutoTypesForm : Window
    {
        MainWindow mainWindow;
        bool addingForm = false;
        AutoTypes autoType;

        // 📝 Creating Form
        public AutoTypesForm(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.addingForm = true;
            Button_Save.Content = "📝 | Добавить запись";
        }

        // 🔄 Updating Form
        public AutoTypesForm(MainWindow mainWindow, AutoTypes autoType)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.autoType = autoType;
            this.DataContext = autoType;
            Button_Save.Content = "💾 | Сохранить изменения";
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if (addingForm)
            {
                AutoTypes newAutoType = new AutoTypes();
                ValidateData(newAutoType);
                mainWindow.Entities.AutoTypes.Add(newAutoType);
            }
            else
                ValidateData(autoType);
            mainWindow.Entities.SaveChanges();
            mainWindow.ReadData();
            Hide();
        }

        AutoTypes ValidateData(AutoTypes autoType)
        {
            autoType ??= new AutoTypes();
            autoType.TypeName = TextBox_TypeName.Text;
            return autoType;
        }
    }
}
