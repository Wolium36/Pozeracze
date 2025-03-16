using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Label = System.Windows.Controls.Label;

namespace PozeraczeV4
{
    internal class GameLogic
    {
        private Label _ktoGra;
        private int _tura;
        int rozmiar;
        private Stopwatch _czasomierz;

        private int _iloscPol;
        Pole[,] _plansza;
        Window _window;

        public GameLogic(int iloscPol, ref Pole[,] plansza, Window window)
        {
            _iloscPol = iloscPol;
            _plansza = plansza;
            _window = window;
            _ktoGra = ((Label)_window.FindName("ktoGra"));

            _czasomierz = new Stopwatch();
            _czasomierz.Start();

            _tura = 0;
        }

        public void zmienTure()
        {
            if (_tura == 0)
            {
                _ktoGra.Content = "Tura gracza 2";
                _tura = 1;
            }
            else
            {
                _ktoGra.Content = "Tura gracza 1";
                _tura = 0;
            }
        }

        public int getTura()
        {
            return _tura;
        }

        private void zwyciestwo(string gracz)
        {
            _czasomierz.Stop();
            ((Grid)_window.FindName("Gra")).Visibility = Visibility.Collapsed;
            ((Grid)_window.FindName("zwyciestwo")).Visibility = Visibility.Visible;

            ((Label)_window.FindName("zwyciezca")).Content = "Zwyciężył gracz: ";
            ((Label)_window.FindName("zwyciezca")).Content += gracz;


            ((Label)_window.FindName("czas")).Content = "Rozgrywka trwała: ";
            ((Label)_window.FindName("czas")).Content = ((Label)_window.FindName("czas")).Content + _czasomierz.Elapsed.ToString();
            OperacjeNaPliku zapisz = new OperacjeNaPliku();
            zapisz.zapisz(_czasomierz.Elapsed.ToString());


        }

        public bool czyWygrana()
        {
            int polaPoziomeGracz1 = 0;
            int polaPoziomeGracz2 = 0;

            int polaPionoweGracz1 = 0;
            int polaPionoweGracz2 = 0;

            for (int i = 0; i < _iloscPol; i++)
            {
                for (int j = 0; j < _iloscPol; j++)
                {
                    if (_plansza[j, i].getZajetyPrzez() == 0)
                    {
                        polaPionoweGracz1++;
                    }
                    else if (_plansza[j, i].getZajetyPrzez() == 1)
                    {
                        polaPionoweGracz2++;
                    }

                    if (_plansza[i, j].getZajetyPrzez() == 0)
                    {
                        polaPoziomeGracz1++;
                    }
                    else if (_plansza[i, j].getZajetyPrzez() == 1)
                    {
                        polaPoziomeGracz2++;
                    }
                }

                if (polaPionoweGracz1 == _iloscPol || polaPoziomeGracz1 == _iloscPol)
                {
                    zwyciestwo("gracz 1");
                }
                else if (polaPionoweGracz2 == _iloscPol || polaPoziomeGracz2 == _iloscPol)
                {
                    zwyciestwo("gracz 2");
                }


                polaPionoweGracz1 = 0;
                polaPoziomeGracz1 = 0;

                polaPoziomeGracz2 = 0;
                polaPionoweGracz2 = 0;
            }

            int polaSkosneGracz1 = 0;
            int polaSkosneGracz2 = 0;

            for (int i = 0, j = 0; i < _iloscPol; i++, j++)
            {
                if (_plansza[j, i].getZajetyPrzez() == 0)
                {
                    polaSkosneGracz1++;
                }
                else if (_plansza[j, i].getZajetyPrzez() == 1)
                {
                    polaSkosneGracz2++;
                }
            }

            if (polaSkosneGracz1 == _iloscPol)
            {
                zwyciestwo("gracz 1");
            }
            else if (polaSkosneGracz2 == _iloscPol)
            {
                zwyciestwo("gracz 2");
            }

            polaSkosneGracz1 = 0;
            polaSkosneGracz2 = 0;

            for (int i = 0, j = _iloscPol - 1; i < _iloscPol; i++, j--)
            {
                if (_plansza[j, i].getZajetyPrzez() == 0)
                {
                    polaSkosneGracz1++;
                }
                else if (_plansza[j, i].getZajetyPrzez() == 1)
                {
                    polaSkosneGracz2++;
                }
            }

            if (polaSkosneGracz1 == _iloscPol)
            {
                zwyciestwo("gracz 1");
            }
            else if (polaSkosneGracz2 == _iloscPol)
            {
                zwyciestwo("gracz 2");
            }

            return false;
        }
    }
}
