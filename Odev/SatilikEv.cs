using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    public class SatilikEv : Ev
    {
        private double satisFiyati;

        public double SatisFiyati
        {
            get { return satisFiyati; }
            set { satisFiyati = Math.Abs(value); }
        }

        public override string ToString()
        {
            return base.ToString() + $", Satış Fiyatı: {SatisFiyati}";
        }
    }
}
