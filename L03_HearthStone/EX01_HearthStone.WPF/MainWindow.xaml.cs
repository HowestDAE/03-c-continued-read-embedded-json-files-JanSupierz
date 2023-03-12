using EX01_HearthStone.WPF.Repository;
using L03_HearthStone.LIB;
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

namespace EX01_HearthStone.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var types = CardRepository.GetCardTypes();
            var type = CardRepository.GetCardType(5);

            var cards = CardRepository.GetCards();

            lstCards.ItemsSource = cards;
        }

        private void lstCards_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (lstCards.SelectedItem != null)
            {
                BaseCard card = lstCards.SelectedItem as BaseCard;

                MessageBox.Show(card.Text, $"[{card.GetType().Name}] {card.DisplayName}");

            }
        }
    }
}
