using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    abstract class Amenagement : ICloneable
    {
        string nom;
        int idAmenagement;
        int prix;
        int taille;
        ConsoleColor couleur;
        private static int globalIdAmenagement;
        public Amenagement(string nom, int prix, int taille,ConsoleColor couleur)
        {
            this.nom = nom;
            this.idAmenagement = Interlocked.Increment(ref globalIdAmenagement);
            this.prix = prix;
            this.taille = taille;
            this.couleur = couleur;
        }
        public override string ToString()
        {
            return "nom : " + this.nom + "\nCouleur : " + this.Couleur;
        }

        public object Clone()
        {
            Amenagement amenagement = (Amenagement)MemberwiseClone();
            amenagement.idAmenagement = Interlocked.Increment(ref globalIdAmenagement);
            return amenagement;
        }

        public int Taille
        {
            get { return taille; }
        }

        public string Nom { get => nom; }
        public ConsoleColor Couleur { get => couleur; }
        public int IdAmenagement { get => idAmenagement; set => idAmenagement = value; }
    }
}
