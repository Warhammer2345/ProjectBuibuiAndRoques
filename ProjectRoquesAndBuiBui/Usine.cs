using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Usine : Entreprise
    {
        public Usine(int NbrEmployeMaxAise, int NbrEmployeMaxMoyenne, int NbrEmployeMaxOuvriere, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(0.2,1.1,NbrEmployeMaxAise,NbrEmployeMaxMoyenne,NbrEmployeMaxOuvriere, coutMensuel, nom, prix, taille, couleur)
        {
            
        }
    }
}
