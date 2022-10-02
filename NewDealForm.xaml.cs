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
using System.Xml.Linq;

namespace FIFA_Market_Tracker
{
    /// <summary>
    /// Logika interakcji dla klasy NewDealForm.xaml
    /// </summary>
    public partial class NewDealForm : Window
    {
        Player selectedPlayer = null;
        public NewDealForm()
        {
            InitializeComponent();
            playerCombo.ItemsSource = MainWindow.players;
        }

        private void createPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData())
            {
                GenerateNewDeal();
                Close();
            }
        }

        private void GenerateNewDeal()
        {
            Deal deal = new Deal(Int32.Parse(value.Text), selectedPlayer);
            MainWindow.deals.Add(deal);
        }

        private void playerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPlayer = (Player)playerCombo.SelectedItem;
        }

        private bool ValidateData()
        {
            try
            {
                if(selectedPlayer == null)
                {
                    MessageBox.Show("Choose a player");
                    return false;
                }
                int val = Int32.Parse(value.Text);
                if (val < 0)
                {
                    MessageBox.Show("Value must be positive");
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
