using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Route : Amenagement, IComparable<Route>
    {
        bool estSortie;
        public Route(string nom, int prix, int taille, ConsoleColor couleur, int x, int y, bool estSortie) : this(nom, prix, taille, couleur, estSortie)
        {
            PosX = x;
            PosY = y;
        }

        public Route(string nom, int prix, int taille, ConsoleColor couleur, bool estSortie) : base(nom, prix, taille, couleur)
        {
            this.estSortie = estSortie;
        }

        public int CompareTo(Route other)
        {
            return IdAmenagement.CompareTo(other.IdAmenagement);
        }

        public bool EstSortie
        {
            get { return estSortie; }
        }
    }
}
