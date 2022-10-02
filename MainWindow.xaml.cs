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

namespace FIFA_Market_Tracker
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Player> players = new List<Player>();
        public static List<Deal> deals = new List<Deal>();
        public static int inClub = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void newDeal_Click(object sender, RoutedEventArgs e)
        {
            NewDealForm newDealForm = new NewDealForm();
            newDealForm.ShowDialog();
            UpdateDeals();
        }

        private void newPlayer_Click(object sender, RoutedEventArgs e)
        {
            NewPlayerForm newPlayerForm = new NewPlayerForm();
            newPlayerForm.ShowDialog();
        }

        private void UpdateDeals()
        {
            boughtPlayersStackpanel.Children.Clear();
            foreach(Deal deal in deals)
            {
                TextBlock txtblock = new TextBlock();
                txtblock.Text = deal.Present;
                boughtPlayersStackpanel.Children.Add(txtblock);
            }
            inClubBudged.Text = "In club Value: " + inClub.ToString();
        }
    }
}
