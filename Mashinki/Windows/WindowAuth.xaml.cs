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
    /// Логика взаимодействия для WindowAuth.xaml
    /// </summary>
    public partial class WindowAuth : Window
    {
        public WindowAuth()
        {
            InitializeComponent();
            Enter();
        }

        private void loginButtonClick(object sender, RoutedEventArgs e)
        {            
            if (PasswordInput.Password.Equals(Properties.Settings.Default.Password))
            {
                Enter();
            }
            else
                MessageBox.Show("Неверный пароль");
        }

        private void Enter()
        {
            MainWindow mainWindow = new MainWindow(true);
            mainWindow.Show();
            Hide();
        }

        private void Button_Guest_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(false);
            mainWindow.Show();
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
