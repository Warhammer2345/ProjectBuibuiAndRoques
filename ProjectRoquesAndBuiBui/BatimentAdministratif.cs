﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class BatimentAdministratif : Tertiaire
    {
        private int nombreHabitantNecessaire;

        public BatimentAdministratif(int nombreHabitantNecessaire, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coutMensuel, nom, prix, taille, couleur)
        {
            this.nombreHabitantNecessaire = nombreHabitantNecessaire;
        }
    }
}
