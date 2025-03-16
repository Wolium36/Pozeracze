using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Label = System.Windows.Controls.Label;

namespace PozeraczeV4
{
    internal class Plansza
    {

        private int rozmiar;
        Canvas wygladPlanszy;
        Pole[,] plansza;

        private Gracz _gracz1;
        private Gracz _gracz2;

        private GameLogic _gameLogic;
        Window _window;

        public Plansza(int iloscPol, Gracz gracz1, Gracz gracz2, Window window)
        {
            _gracz1 = gracz1;
            _gracz2 = gracz2;
            _window = window;


            plansza = new Pole[iloscPol, iloscPol];

            _gameLogic = new GameLogic(iloscPol, ref plansza, window);

            StworzPlansze(iloscPol);
            stowrzWygladPlanszy(iloscPol);


        }

        private void StworzPlansze(int iloscPol)
        {
            int rozmiarPyczcisku = (300 / iloscPol) - 1;
            for (int i = 0; i < iloscPol; i++)
            {
                for (int j = 0; j < iloscPol; j++)
                {
                    plansza[i, j] = new Pole(rozmiarPyczcisku, _gracz1, _gracz2, _gameLogic, _window);
                }
            }
        }

        private void stowrzWygladPlanszy(int iloscPol)
        {
            wygladPlanszy = new Canvas();

            wygladPlanszy.HorizontalAlignment = HorizontalAlignment.Left;
            wygladPlanszy.VerticalAlignment = VerticalAlignment.Top;

            Border border = new Border();
            border.BorderThickness = new Thickness(1);
            border.Background = new SolidColorBrush(Colors.Black);

            int pozycjaPrzycisku = (300 / iloscPol) - 1;

            for (int i = 0; i < iloscPol; i++)
            {
                for (int j = 0; j < iloscPol; j++)
                {
                    wygladPlanszy.Children.Add(plansza[i, j].getPole());
                    Canvas.SetTop(border, i * pozycjaPrzycisku);
                    Canvas.SetTop(plansza[i, j].getPole(), i * pozycjaPrzycisku);

                    Canvas.SetTop(border, j * pozycjaPrzycisku);
                    Canvas.SetLeft(plansza[i, j].getPole(), j * pozycjaPrzycisku);
                }
            }
        }

        public Canvas getCanvas()
        {
            return wygladPlanszy;
        }

        public Pole getPole(int i, int j)
        {
            return plansza[i, j];
        }
    }
}
