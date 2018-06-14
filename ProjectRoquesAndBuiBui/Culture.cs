using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Culture :Tertiaire
    {
        int niveauCulture;
        public Culture(int niveauCulture, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coutMensuel, nom, prix, taille, couleur)
        {
            this.niveauCulture = niveauCulture;
        }

        public int NiveauCulture { get => niveauCulture; set => niveauCulture = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
