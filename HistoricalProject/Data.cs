using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalProject
{
    public class Data
    {
        public int Id { get; set; }
        public double Potrosnja { get; set; }
        public string Adresa { get; set; }
        public string Mesec { get; set; }

        public Data(int id, double potrosnja, string adresa, string mesec)
        {
            Id = id;
            Potrosnja = potrosnja;
            Adresa = adresa;
            Mesec = mesec;
        }

        public override string ToString()
        {
            return Id + "|" + Potrosnja + "|" + Adresa + "|" + Mesec;
        }
    }
}
