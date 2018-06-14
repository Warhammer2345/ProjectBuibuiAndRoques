using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Tourisme : Tertiaire
    {
        private int impactTourisme;
        public Tourisme(int impactTourisme,int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coutMensuel, nom, prix, taille, couleur)
        {
            this.impactTourisme = impactTourisme;
        }

        public int ImpactTourisme { get => impactTourisme; set => impactTourisme = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
