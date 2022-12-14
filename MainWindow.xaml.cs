using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window
    {
        public static List<Player> players = new List<Player>();
        public static List<Deal> deals = new List<Deal>();
        public static int inClub = FileManager.ReadBudgeds()[0];
        public static int profit = FileManager.ReadBudgeds()[1];


        public MainWindow()
        {
            InitializeComponent();
            FileManager.ReadPlayers();
            FileManager.ReadDeals();
            UpdateDeals();
            UpdateBudgeds();
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
            FileManager.SavePlayers();
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
            FileManager.SaveDeals();
        }

        public void UpdateBudgeds()
        {
            inClubBudged.Text = "In club Value: " + inClub.ToString();
            transferProfit.Text = "Transfer profit: " + profit.ToString();
            FileManager.SaveBudgeds();
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
            txtblock.Text = deal.PresentArchive;
            stackPanel.Children.Add(txtblock);
            archivePlayersStackpanel.Children.Add(stackPanel);
        }

        private void sellButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Deal deal = (Deal)btn.DataContext;
            SoldFor sellWindow = new SoldFor();
            try
            {
                sellWindow.ShowDialog();
                int value = sellWindow.value;
                deal.sellPlayer(value);
                UpdateDeals();
                FileManager.SaveDeals();
            }
            catch
            {}
        }
    }
}
