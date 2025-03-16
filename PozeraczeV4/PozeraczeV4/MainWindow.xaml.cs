using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PozeraczeV4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OperacjeNaPliku odczyt = new OperacjeNaPliku();
            miejsceNaWynki.Content = odczyt.odczyt();
        }

        bool walidacja()
        {
            string kolor1 = kolorGracza1.Text;
            string kolor2 = kolorGracza2.Text;

            string rozmiarPlanszy = TextBoxRozmiarPlanszy.Text;
            int test = 0;

            bool czyLiczba = int.TryParse(rozmiarPlanszy, out test);

            return !czyLiczba || rozmiarPlanszy == "" || kolor1 == "" || kolor2 == "" || test >= 10 || kolor1 == kolor2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (walidacja()) return;

            miejsceNaPlansze.Children.Clear();

            Start.Visibility = Visibility.Collapsed;
            Gra.Visibility = Visibility.Visible;

            int iloscPol = int.Parse(TextBoxRozmiarPlanszy.Text);

            string kolor1 = kolorGracza1.Text;
            string kolor2 = kolorGracza2.Text;

            Gracz gracz1 = new Gracz(kolor1, iloscPol, pozostaleMaleGracz1, pozostaleSrednieGracz1, pozostaleDuzeGracz1);
            Gracz gracz2 = new Gracz(kolor2, iloscPol, pozostaleMaleGracz2, pozostaleSrednieGracz2, pozostaleDuzeGracz2);

            pokazKolorGracza1.Content = kolor1;
            pokazKolorGracza1.Foreground = gracz1.getKolor();

            pokazKolorGracza2.Content = kolor2;
            pokazKolorGracza2.Foreground = gracz2.getKolor();

            Plansza plansza = new Plansza(iloscPol, gracz1, gracz2, this);

            miejsceNaPlansze.Children.Add(plansza.getCanvas());
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            Start.Visibility = Visibility.Visible;
            Gra.Visibility = Visibility.Collapsed;
            zwyciestwo.Visibility = Visibility.Collapsed;

            OperacjeNaPliku odczyt = new OperacjeNaPliku();
            miejsceNaWynki.Content = odczyt.odczyt();
        }
    }
}
