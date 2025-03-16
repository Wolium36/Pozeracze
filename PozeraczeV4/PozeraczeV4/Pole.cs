using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Label = System.Windows.Controls.Label;

namespace PozeraczeV4
{
    internal class Pole
    {
        Label _pole;

        private Gracz _gracz1;
        private Gracz _gracz2;
        private GameLogic _gameLogic;

        RadioButton _maly;
        RadioButton _sredni;
        RadioButton _duzy;

        SolidColorBrush _kolorPola;

        private int _zajetyPrzez; //-1 - przez nikogo, 0 - gracz1, 1 - gracz2
        private int _zajety;

        private int _malyRozmiar;
        private int _sredniRozmiar;
        private int _DuzyRozmiar;

        public Pole(int rozmiar, Gracz gracz1, Gracz gracz2, GameLogic gameLogic, Window window)
        {
            _pole = new Label();

            _gracz1 = gracz1;
            _gracz2 = gracz2;
            _gameLogic = gameLogic;

            _maly = (RadioButton)window.FindName("maly");
            _sredni = (RadioButton)window.FindName("sredni");
            _duzy = (RadioButton)window.FindName("duzy");

            _kolorPola = new SolidColorBrush(Color.FromRgb(32, 32, 32));
            _pole.BorderThickness = new Thickness(1);
            _pole.BorderBrush = new SolidColorBrush(Color.FromRgb(37, 37, 37));
            _pole.Height = rozmiar;
            _pole.Width = rozmiar;
            _pole.FontSize = rozmiar / 3;
            _pole.HorizontalContentAlignment = HorizontalAlignment.Center;
            _pole.VerticalContentAlignment = VerticalAlignment.Center;

            _zajety = 0;
            _zajetyPrzez = -1;

            _pole.MouseEnter += _pole_MouseEnter;
            _pole.MouseLeave += _pole_MouseLeave;
            _pole.MouseDown += _pole_MouseDown;

        }


        private bool czyMoznaPostwaic()
        {
            if (_maly.IsChecked == true && _zajety < 1 && ((_gameLogic.getTura() == 0 && _gracz1.getMalePionki() > 0) || (_gameLogic.getTura() == 1 && _gracz2.getMalePionki() > 0)))
            {
                return true;
            }
            else if (_sredni.IsChecked == true && _zajety < 2 && ((_gameLogic.getTura() == 0 && _gracz1.getSredniePionki() > 0) || (_gameLogic.getTura() == 1 && _gracz2.getSredniePionki() > 0)))
            {
                return true;
            }
            else if (_duzy.IsChecked == true && _zajety < 3 && ((_gameLogic.getTura() == 0 && _gracz1.getDuzePionki() > 0) || (_gameLogic.getTura() == 1 && _gracz2.getDuzePionki() > 0)))
            {
                return true;
            }


            return false;
        }
        private void _pole_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!czyMoznaPostwaic())
            {
                return;
            }

            if (_maly.IsChecked == true)
            {
                _zajety = 1;
                _zajetyPrzez = _gameLogic.getTura();
                _pole.Content = "1";

                if (_gameLogic.getTura() == 0)
                {
                    _gracz1.uzytoMalegoPionka();
                }
                else
                {
                    _gracz2.uzytoMalegoPionka();
                }

            }
            else if (_sredni.IsChecked == true)
            {
                _zajety = 2;
                _zajetyPrzez = _gameLogic.getTura();
                _pole.Content = "2";

                if (_gameLogic.getTura() == 0)
                {
                    _gracz1.uzytoSredniegoPionka();
                }
                else
                {
                    _gracz2.uzytoSredniegoPionka();
                }
            }
            else if (_duzy.IsChecked == true)
            {
                _zajety = 3;
                _zajetyPrzez = _gameLogic.getTura();
                _pole.Content = "3";

                if (_gameLogic.getTura() == 0)
                {
                    _gracz1.uzytoDuzegoPionka();
                }
                else
                {
                    _gracz2.uzytoDuzegoPionka();
                }
            }



            if (_gameLogic.getTura() == 0)
            {
                _kolorPola = _gracz1.getKolor();
            }
            else
            {
                _kolorPola = _gracz2.getKolor();
            }

            _pole.Background = _kolorPola;

            _gameLogic.czyWygrana();
            _gameLogic.zmienTure();
        }

        private void _pole_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _pole.Background = _kolorPola;
        }

        private void _pole_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!czyMoznaPostwaic())
            {
                return;
            }

            _pole.Background = new SolidColorBrush(Colors.LightGreen);
        }

        public Label getPole() { return _pole; }

        public int getZajetyPrzez() { return _zajetyPrzez; }

        public void dodaj()
        {

        }


    }
}
