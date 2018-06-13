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
        int productionMin;
        int productionMax;

        public CompagnieElectricite(int energieProduite, int NbrEmployeMaxAise, int NbrEmployeMaxMoyenne, int NbrEmployeMaxOuvriere, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(NbrEmployeMaxAise, NbrEmployeMaxMoyenne, NbrEmployeMaxOuvriere, coutMensuel, nom, prix, taille, couleur)
        {
            this.energieProduite = energieProduite;
            productionMax = 10000;
            productionMin = 0;
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
            AfficheSlideBar(productionMin, energieProduite, productionMax, interval);

            while (continuer)
            {
                Console.SetCursorPosition(0, 1);
                ConsoleKey key = Console.ReadKey(true).Key;


                if (key == ConsoleKey.RightArrow)
                {
                    energieProduite += interval;
                    if (energieProduite >= productionMax) energieProduite = productionMax;
                }
                if (key == ConsoleKey.LeftArrow)
                {
                    energieProduite -= interval;
                    if (energieProduite < productionMin) energieProduite = productionMin;
                }
                if (key == ConsoleKey.Escape)
                {
                    continuer = false;
                }

                Console.Clear();
                Console.WriteLine("Eau produite par cycle : ");
                AfficheSlideBar(productionMin, energieProduite, productionMax, interval);

            }
        }
    }
}
