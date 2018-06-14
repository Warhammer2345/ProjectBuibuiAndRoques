using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Logement :Secondaire
    {
        int capaciteMax;
        ClasseSocial classe;
        double nivBonheur;
        int minOccupation;//En dessous de cette valeur, l'état paye des charges pour l'entretien
        int occupationActuelle;
        public Logement(int capaciteMax, ClasseSocial classe, double nivBonheur, int minOccupation,int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coutMensuel, nom, prix, taille, couleur)
        {
            this.capaciteMax = capaciteMax;
            this.classe = classe;
            this.nivBonheur = nivBonheur;
            this.minOccupation = minOccupation;
            this.occupationActuelle = 0;
        }

        public int MinOccupation { get => minOccupation;  }
        public int OccupationActuelle { get => occupationActuelle; set => occupationActuelle = value; }
        public ClasseSocial Classe { get => classe;  }
        public int CapaciteMax { get => capaciteMax; set => capaciteMax = value; }

        public override string ToString()
        {
            return base.ToString()+"\nCapacité Max logement : "+capaciteMax+"\nClasse sociale du logement : "+Convert.ToString(classe)+"\nNiveau de bonheur du logement : "+nivBonheur+"\nMinimum Occupation : "+minOccupation;
        }
    }
    public enum ClasseSocial { aisee, moyenne, ouvriere}
}
