using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat0203
{
    internal class Meres
    {
        public Meres(DateTime datum, int pM10, int pM2_5)
        {
            Datum = datum;
            PM10 = pM10;
            PM2_5 = pM2_5;
        }
        public Meres(string sor)
        {
            string[] adatok = sor.Split(';');
            Datum = DateTime.Parse(adatok[0]);
            PM10 = int.Parse(adatok[1]);
            PM2_5 = int.Parse(adatok[2]);
        }

        public DateTime Datum { get; set; }
        public int PM10 { get; set; }
        public int PM2_5 { get; set; }

        public override string ToString()
        {
            return $"{Datum};{PM10};{PM2_5}";
        }

        public string Minosites()
        {
            if (PM2_5 >= 25)
                return "Szennyezett";
            return "Megfelelő";
        }
    }
}
