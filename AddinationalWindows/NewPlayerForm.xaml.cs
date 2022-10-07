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

namespace FIFA_Market_Tracker
{
    /// <summary>
    /// Logika interakcji dla klasy NewPlayerForm.xaml
    /// </summary>
    public partial class NewPlayerForm : Window
    {
        public NewPlayerForm()
        {
            InitializeComponent();
        }

        private void createPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData())
            {
                GenerateNewPlayer();
                Close();
            }
        }

        private void GenerateNewPlayer()
        {
            Player player = new Player(name.Text, Int32.Parse(overall.Text));
            MainWindow.players.Add(player);
        }

        private bool ValidateData()
        {
            try
            {
                string fullname = name.Text;
                if (string.IsNullOrEmpty(fullname))
                {
                    MessageBox.Show("Enter a name");
                    return false;
                }
                int ovr = Int32.Parse(overall.Text);
                if (ovr <0 || ovr>99)
                {
                    MessageBox.Show("Overall out of range");
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter overall as a number");
                return false;
            }
            return true;
        }
    }
}
