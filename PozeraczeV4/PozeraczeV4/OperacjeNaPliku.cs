using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Label = System.Windows.Controls.Label;

namespace PozeraczeV4
{
    internal class OperacjeNaPliku
    {
        public OperacjeNaPliku()
        {

        }

        public void zapisz(string czas)
        {
            string sciezka = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "../../", "czasy.txt");
            StreamReader odczyt = new StreamReader(sciezka);

            List<string> wyniki = new List<string>();
            int iloscLini = 0;
            string linia = "";


            while ((linia = odczyt.ReadLine()) != null)
            {
                wyniki.Add(linia);
                iloscLini++;
            }

            odczyt.Close();

            wyniki.Add(czas);
            wyniki.Sort();
            wyniki.Reverse();

            if (wyniki.Count > 10)
            {
                wyniki.RemoveAt(wyniki.Count - 1);
            }

            System.IO.File.WriteAllText(sciezka, string.Empty);

            foreach (string wynik in wyniki)
            {
                File.AppendAllText(sciezka, wynik + Environment.NewLine, Encoding.UTF8);
            }
        }

        public string odczyt()
        {
            string sciezka = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "../../", "czasy.txt");
            StreamReader odczyt = new StreamReader(sciezka);

            string wynik = "";
            string linia = "";
            int licznik = 1;

            while ((linia = odczyt.ReadLine()) != null)
            {
                wynik += licznik.ToString() + ". " + linia + "\r\n";
                licznik++;
            }

            return wynik;
        }
    }
}
