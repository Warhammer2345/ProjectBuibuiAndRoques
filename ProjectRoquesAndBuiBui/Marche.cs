using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Marche
    {
        private double electricite;
        private double eau;
        public Marche(double electricite, double eau)
        {
            this.electricite = electricite;
            this.eau = eau;
        }

        public double Electricite { get => electricite; set => electricite = value; }
        public double Eau { get => eau; set => eau = value; }
    }
}
