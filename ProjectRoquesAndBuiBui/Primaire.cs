using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Primaire : Batiment
    {
        private int nourritureFabrique;
        private int nourritureRestante;
        int productionMin;
        int productionMax;
        public Primaire(int productionMax, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur):base(coutMensuel,nom,prix,taille,couleur)
        {
            this.nourritureFabrique = productionMax / 2;
            this.nourritureRestante = 0;
            this.productionMin = 0;
            this.productionMax = productionMax;
        }

        public int NourritureFabrique { get => nourritureFabrique; set => nourritureFabrique = value; }
        public int NourritureRestante { get => nourritureRestante; set => nourritureRestante = value; }

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
