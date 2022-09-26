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
            Close();
        }
    }
}
