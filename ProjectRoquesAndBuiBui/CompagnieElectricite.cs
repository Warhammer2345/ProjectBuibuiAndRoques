using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class CompagnieElectricite :Entreprise
    {
        private int energieProduite;
        private int energieRestante;
        public CompagnieElectricite(int energieProduite, int NbrEmployeMaxAise, int NbrEmployeMaxMoyenne, int NbrEmployeMaxOuvriere, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(NbrEmployeMaxAise, NbrEmployeMaxMoyenne, NbrEmployeMaxOuvriere, coutMensuel, nom, prix, taille, couleur)
        {
            this.energieProduite = energieProduite;
        }

        public int EnergieProduite { get => energieProduite; set => energieProduite = value; }
        public int EnergieRestante { get => energieRestante; set => energieRestante = value; }

        public override string ToString()
        {
            return base.ToString() + "\nEnergie produite : "+energieProduite;
        }
        public int EnergieUtilisee(int energieNecessaire)
        {
            int energieRenvoyee = energieNecessaire - energieProduite;
            if (energieRenvoyee < 0)
            {
                energieRestante = -energieRenvoyee;
                energieRenvoyee = 0;
            }
            else
            {
                energieRestante = 0;
            }
            return energieRenvoyee;
        }
    }
}
