﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    abstract class Secondaire : Batiment
    {
        public Secondaire(int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coutMensuel, nom, prix, taille, couleur)
        { }
        public Secondaire(double coefAttractivite, double coefCulture,int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coefAttractivite, coefCulture, coutMensuel, nom, prix, taille, couleur)
        { }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
