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
    /// Logika interakcji dla klasy BoughtFor.xaml
    /// </summary>
    public partial class SoldFor : Window
    {
        public SoldFor()
        {
            InitializeComponent();
        }
        public int value
        {
            get { return Int32.Parse(soldFor.Text); }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData())
            {
                Close();
            }
        }

        private bool ValidateData()
        {
            try
            {
                int val = Int32.Parse(soldFor.Text);
                if (val <= 0)
                {
                    MessageBox.Show("Value must be positive");
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter value as a number");
                return false;
            }
            return true;
        }
    }
}
