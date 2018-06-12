using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Route : Amenagement, IComparable<Route>
    {
        int x, y;
        bool estSortie;
        public Route(string nom, int prix, int taille, ConsoleColor couleur, int x, int y, bool estSortie) : base(nom, prix, taille, couleur)
        {
            this.x = x;
            this.y = y;
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

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }
    }
}
