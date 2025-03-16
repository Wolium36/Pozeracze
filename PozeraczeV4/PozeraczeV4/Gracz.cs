using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Label = System.Windows.Controls.Label;

namespace PozeraczeV4
{
    internal class Gracz
    {
        private SolidColorBrush _kolor;

        private int _duzePionki;
        private int _sredniePionki;
        private int _malePionki;

        Label _pozostaleMale;
        Label _pozostaleSrenie;
        Label _pozostaleDuze;


        public Gracz(string kolor, int iloscPol, Label pozostaleMale, Label pozostaleSrednie, Label pozostaleDuze)
        {
            _duzePionki = iloscPol;
            _sredniePionki = iloscPol;
            _malePionki = iloscPol;

            _pozostaleMale = pozostaleMale;
            _pozostaleSrenie = pozostaleSrednie;
            _pozostaleDuze = pozostaleDuze;

            _pozostaleMale.Content = iloscPol.ToString();
            _pozostaleSrenie.Content = iloscPol.ToString();
            _pozostaleDuze.Content = iloscPol.ToString();



            switch (kolor)
            {
                case "Niebieski":
                    _kolor = new SolidColorBrush(Colors.LightBlue);
                    break;
                case "Pomarańczowy":
                    _kolor = new SolidColorBrush(Colors.Orange);
                    break;
                case "Różowy":
                    _kolor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 149));
                    break;
                case "Fioletowy":
                    _kolor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 131, 0, 191));
                    break;
            }


        }
        public SolidColorBrush getKolor()
        {
            return _kolor;
        }
        public void uzytoMalegoPionka()
        {
            _malePionki--;
            _pozostaleMale.Content = _malePionki.ToString();
        }
        public void uzytoSredniegoPionka()
        {
            _sredniePionki--;
            _pozostaleSrenie.Content = _sredniePionki.ToString();
        }
        public void uzytoDuzegoPionka()
        {
            _duzePionki--;
            _pozostaleDuze.Content = _duzePionki.ToString();
        }

        public int getMalePionki()
        {
            return _malePionki;
        }

        public int getSredniePionki()
        {
            return _sredniePionki;
        }

        public int getDuzePionki()
        {
            return _duzePionki;
        }
    }
}
