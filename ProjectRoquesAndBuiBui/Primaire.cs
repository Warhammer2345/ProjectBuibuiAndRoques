using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Primaire : Batiment, IEmployable
    {
        private int nourritureFabrique;
        private int nourritureRestante;
        int productionMin;
        int productionMax;
        int nbrEmployeActuelAise;
        int nbrEmployeActuelMoyenne;
        int nbrEmployeActuelOuvriere;
        int nbrEmployeMaxAise;
        int nbrEmployeMaxMoyenne;
        int nbrEmployeMaxOuvriere;
        double coefOccupation;
        public Primaire(int nbrEmployeMaxOuvriere, int nbrEmployeMaxMoyenne, int nbrEmployeMaxAise,int productionMax, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur):base(0.4,1.1,coutMensuel,nom,prix,taille,couleur)
        {
            this.nbrEmployeMaxOuvriere = nbrEmployeMaxOuvriere;
            this.nbrEmployeMaxMoyenne = nbrEmployeMaxMoyenne;
            this.nbrEmployeMaxAise = nbrEmployeMaxAise;
            this.nourritureFabrique = productionMax / 2;
            this.nourritureRestante = 0;
            this.productionMin = 0;
            this.productionMax = productionMax;
            coefOccupation = 0;
        }
        public int NbrEmployeActuelAise { get => nbrEmployeActuelAise; set => nbrEmployeActuelAise = value; }
        public int NbrEmployeActuelMoyenne { get => nbrEmployeActuelMoyenne; set => nbrEmployeActuelMoyenne = value; }
        public int NbrEmployeActuelOuvriere { get => nbrEmployeActuelOuvriere; set => nbrEmployeActuelOuvriere = value; }
        public int NbrEmployeMaxAise { get => nbrEmployeMaxAise; set => nbrEmployeMaxAise = value; }
        public int NbrEmployeMaxMoyenne { get => nbrEmployeMaxMoyenne; set => nbrEmployeMaxMoyenne = value; }
        public int NbrEmployeMaxOuvriere { get => nbrEmployeMaxOuvriere; set => nbrEmployeMaxOuvriere = value; }
        public int NourritureFabrique { get => nourritureFabrique; set => nourritureFabrique = value; }
        public int NourritureRestante { get => nourritureRestante; set => nourritureRestante = value; }
        public double CoefOccupation { get => coefOccupation; set => coefOccupation = value; }

        public int NourritureUtilisee(int nourritureNecessaire)
        {
            int nourritureRenvoyee = nourritureNecessaire - nourritureFabrique;
            if (nourritureRenvoyee < 0)
            {
                nourritureRestante = -nourritureRenvoyee;
                nourritureRenvoyee = 0;
            }
            else
            {
                nourritureRestante = 0;
            }
            return nourritureRenvoyee;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
