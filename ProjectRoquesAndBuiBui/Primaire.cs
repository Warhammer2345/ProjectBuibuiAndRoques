using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    abstract class Primaire : Batiment
    {
        public Primaire(int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur):base(coutMensuel,nom,prix,taille,couleur)
        { }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
