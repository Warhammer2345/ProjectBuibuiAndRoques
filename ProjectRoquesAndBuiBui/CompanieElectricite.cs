using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class CompanieElectricite :Entreprise
    {
        private int energieProduite;
        public CompanieElectricite(int energieProduite, int NbrEmployeMaxAise, int NbrEmployeMaxMoyenne, int NbrEmployeMaxOuvriere, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(NbrEmployeMaxAise, NbrEmployeMaxMoyenne, NbrEmployeMaxOuvriere, coutMensuel, nom, prix, taille, couleur)
        {
            this.energieProduite = energieProduite;
        }
        public override string ToString()
        {
            return base.ToString() + "\nEnergie produite : "+energieProduite;
        }
    }
}
