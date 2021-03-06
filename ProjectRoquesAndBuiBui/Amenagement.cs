﻿using System;
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
        private static int globalIdAmenagement = 0;
        int posX;
        int posY;

        public Amenagement(string nom, int prix, int taille, ConsoleColor couleur)
        {
            this.nom = nom;
            this.idAmenagement = globalIdAmenagement;
            this.prix = prix;
            this.taille = taille;
            this.couleur = couleur;
            globalIdAmenagement += 1;
        }
        public override string ToString()
        {
            return "\nID Aménagement : " + idAmenagement + "\nnom : " + nom + "\nCouleur : " + Couleur;
        }

        public object Clone()
        {
            Amenagement amenagement = (Amenagement)MemberwiseClone();
            amenagement.idAmenagement = globalIdAmenagement;
            globalIdAmenagement += 1;
            return amenagement;
        }

        public int Taille
        {
            get { return taille; }
        }

        public string Nom { get => nom; }
        public ConsoleColor Couleur { get => couleur; }
        public int IdAmenagement { get => idAmenagement; set => idAmenagement = value; }
        public int Prix { get => prix; }
        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
    }
}
