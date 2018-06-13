using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class CompagnieEau : Entreprise, IParametrable
    {
        private int eauProduite;
        private int eauRestante;
        int productionMin;
        int productionMax;

        public CompagnieEau(int eauProduite, int NbrEmployeMaxAise, int NbrEmployeMaxMoyenne, int NbrEmployeMaxOuvriere, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(NbrEmployeMaxAise, NbrEmployeMaxMoyenne, NbrEmployeMaxOuvriere, coutMensuel, nom, prix, taille, couleur)
        {
            this.eauProduite = eauProduite;
            this.eauRestante = 0;
            productionMax = 10000;
            productionMin = 0;
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

        void AfficheSlideBar(double valueMin, double value, double valueMax, double interval)
        {
            string temp = valueMin + " <";
            for (double i = valueMin; i < value; i += interval)
            {
                temp += "-";
            }
            temp += value;
            for (double i = value; i < valueMax; i += interval)
            {
                temp += "-";
            }
            temp += "> " + valueMax;
            Console.WriteLine(temp);
        }

        public void ModifierParametre()
        {
            bool continuer = true;
            int interval = 100;
            Console.Clear();
            Console.WriteLine("Eau produite par cycle : ");
            AfficheSlideBar(productionMin, eauProduite, productionMax, interval);

            while (continuer)
            {
                Console.SetCursorPosition(0, 1);
                ConsoleKey key = Console.ReadKey(true).Key;

               
                if (key == ConsoleKey.RightArrow)
                {
                    eauProduite += interval;
                    if (eauProduite >= productionMax) eauProduite = productionMax;
                }
                if (key == ConsoleKey.LeftArrow)
                {
                    eauProduite -= interval;
                    if (eauProduite < productionMin) eauProduite = productionMin;
                }
                if (key == ConsoleKey.Escape)
                {
                    continuer = false;
                }

                Console.Clear();
                Console.WriteLine("Eau produite par cycle : ");
                AfficheSlideBar(productionMin, eauProduite, productionMax, interval);

            }
        }

    }
}
