using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class CompagnieEau : Entreprise
    {
        private int eauProduite;
        private int eauRestante;
        public CompagnieEau(int eauProduite, int NbrEmployeMaxAise, int NbrEmployeMaxMoyenne, int NbrEmployeMaxOuvriere, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(NbrEmployeMaxAise, NbrEmployeMaxMoyenne, NbrEmployeMaxOuvriere, coutMensuel, nom, prix, taille, couleur)
        {
            this.eauProduite = eauProduite;
            this.eauRestante = 0;
        }

        public int EauProduite { get => eauProduite; set => eauProduite = value; }
        public int EauRestante { get => eauRestante; set => eauRestante = value; }

        public override string ToString()
        {
            return base.ToString()+"\nEau produite : "+eauProduite;
        }
        /// <summary>
        /// Prend en paramètre l'eau nécessaire et déduit l'eau produite par la pompe
        /// </summary>
        /// <param name="eauNecessaire">Retourne l'eau encore nécessaire à prélever dans d'autres compagnies</param>
        /// <returns></returns>
        public int EauUtilisee(int eauNecessaire)
        {
            int eauRenvoyee = eauNecessaire - eauProduite;
            if (eauRenvoyee < 0)
            {
                eauRestante = -eauRenvoyee;//Met en paramètre l'eau stocké qui ne servira plus à rien
                eauRenvoyee = 0;
            }
            else
            {
                eauRestante = 0;
            }
            return eauRenvoyee;
        }
    }
}
