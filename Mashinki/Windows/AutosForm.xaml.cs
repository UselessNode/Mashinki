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
using Mashinki.EF;

namespace Mashinki
{
    /// <summary>
    /// Логика взаимодействия для AddingForm.xaml
    /// </summary>
    public partial class AutosForm : Window
    {
        MainWindow mainWindow;
        public Auto auto;
        bool addingForm = false;

        public AutosForm(MainWindow mainWindow)
        {
            // Для добавления записей
            InitializeComponent();
            this.mainWindow = mainWindow;
            ComboBox_Types.ItemsSource = mainWindow.Entities.AutoTypes.ToList();
            this.addingForm = true;
            auto = new Auto();
            this.DataContext = auto;
        }

        public AutosForm(MainWindow mainWindow, Auto auto)
        {
            // Для редактирования записей
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ComboBox_Types.ItemsSource = mainWindow.Entities.AutoTypes.ToList();
            this.auto = auto;
            this.DataContext = auto;
            Button_Save.Content = "Сохранить";
        }



        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if(addingForm)
            {
                //Auto newAuto = new Auto();
                //ValidateData(newAuto);
                MessageBox.Show(auto.ToString());
                mainWindow.Entities.Auto.Add(auto);
            }
            else
            {//ValidateData(auto);

            }
            mainWindow.Entities.SaveChanges();
            mainWindow.ReadData();
            Hide();
        }

        Auto ValidateData(Auto auto)
        {
            auto ??= new Auto();
            auto.Name         = TextBox_Name.Text;
            auto.Size         = TextBox_Size.Text;
            auto.TypeID       = ComboBox_Types.SelectedIndex + 1;
            auto.Clarence     = int.Parse(TextBox_Clarence.Text);
            auto.Cost         = int.Parse(TextBox_Cost.Text);  
            auto.EngineVolume = int.Parse(TextBox_EngnVol.Text);
            auto.EnginePower  = int.Parse(TextBox_EnginePower.Text);
            return auto;
        }
    }
}
