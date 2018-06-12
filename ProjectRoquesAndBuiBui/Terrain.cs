using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Terrain
    {
        Amenagement[,] carte;
        int taille;

        public Terrain(int taille)
        {
            this.taille = taille;
            carte = new Amenagement[taille, taille];
        }

        public void AfficherTerrain()
        {
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    if (carte[i, j] != null)
                    {
                        Console.ForegroundColor = carte[i, j].Couleur;
                        Console.Write("V");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine();
            }
        }

        public int Taille
        {
            get { return taille; }
        }

        public Amenagement[,] Carte
        {
            get { return carte; }
        }

    }
}
