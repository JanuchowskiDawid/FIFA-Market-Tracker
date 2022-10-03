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
        public static int inClub = 77001;
        public static int profit = 0;

        public MainWindow()
        {
            Player Lewa = new Player("Lewa", 97);
            players.Add(Lewa);
            Deal Deal = new Deal(7000, Lewa);
            Deal Deal2 = new Deal(70001, Lewa);
            deals.Add(Deal);
            deals.Add(Deal2);
            InitializeComponent();
            UpdateDeals();
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
            archivePlayersStackpanel.Children.Clear();
            foreach (Deal deal in deals)
            {
                if (!deal.isSold)
                {
                    ShowInClub(deal);
                }
                else
                {
                    ShowArchive(deal);
                }
            }
            UpdateBudgeds();
        }

        public void UpdateBudgeds()
        {
            inClubBudged.Text = "In club Value: " + inClub.ToString();
            transferProfit.Text = "Transfer profit: " + profit.ToString();
        }

        private void ShowInClub(Deal deal)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            TextBlock txtblock = new TextBlock();
            txtblock.Text = deal.Present;
            Button sellButton = deal.sellButton;
            sellButton = new Button();
            sellButton.Content = "Sell";
            sellButton.DataContext = deal;
            sellButton.Click += sellButton_Click;
            stackPanel.Children.Add(txtblock);
            stackPanel.Children.Add(sellButton);
            boughtPlayersStackpanel.Children.Add(stackPanel);
        }

        private void ShowArchive(Deal deal)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            TextBlock txtblock = new TextBlock();
            txtblock.Text = deal.Present;
            stackPanel.Children.Add(txtblock);
            archivePlayersStackpanel.Children.Add(stackPanel);
        }

        private void sellButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Deal deal = (Deal)btn.DataContext;
            SoldFor sellWindow = new SoldFor();
            sellWindow.ShowDialog();            
            int value = sellWindow.value;
            deal.sellPlayer(value);
            UpdateDeals();
           
        }
    }
}
