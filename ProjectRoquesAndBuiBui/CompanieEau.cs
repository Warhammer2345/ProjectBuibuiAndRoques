using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class CompanieEau : Entreprise
    {
        private int eauProduite;
        public CompanieEau(int eauProduite, int NbrEmployeMaxAise, int NbrEmployeMaxMoyenne, int NbrEmployeMaxOuvriere, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(NbrEmployeMaxAise, NbrEmployeMaxMoyenne, NbrEmployeMaxOuvriere, coutMensuel, nom, prix, taille, couleur)
        {
            this.eauProduite = eauProduite;
        }
        public override string ToString()
        {
            return base.ToString()+"\nEau produite : "+eauProduite;
        }
    }
}
