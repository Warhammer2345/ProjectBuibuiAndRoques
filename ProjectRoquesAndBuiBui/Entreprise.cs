using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    abstract class Entreprise : Secondaire,IEmployable
    {
        int nbrEmployeActuelAise;
        int nbrEmployeActuelMoyenne;
        int nbrEmployeActuelOuvriere;
        int nbrEmployeMaxAise;
        int nbrEmployeMaxMoyenne;
        int nbrEmployeMaxOuvriere;
        double coefOccupation;

        public Entreprise(int nbrEmployeMaxAise, int nbrEmployeMaxMoyenne, int nbrEmployeMaxOuvriere,int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coutMensuel, nom, prix, taille, couleur)
        {
            this.nbrEmployeActuelAise = 0;
            this.nbrEmployeActuelMoyenne = 0;
            this.nbrEmployeActuelOuvriere = 0;
            this.nbrEmployeMaxAise = nbrEmployeMaxAise;
            this.nbrEmployeMaxMoyenne = nbrEmployeMaxMoyenne;
            this.nbrEmployeMaxOuvriere = nbrEmployeMaxOuvriere;
            coefOccupation = 0;
        }
        public Entreprise(double coefAttractivite, double coefCulture,int nbrEmployeMaxAise, int nbrEmployeMaxMoyenne, int nbrEmployeMaxOuvriere, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coefAttractivite,coefCulture, coutMensuel, nom, prix, taille, couleur)
        {
            this.nbrEmployeActuelAise = 0;
            this.nbrEmployeActuelMoyenne = 0;
            this.nbrEmployeActuelOuvriere = 0;
            this.nbrEmployeMaxAise = nbrEmployeMaxAise;
            this.nbrEmployeMaxMoyenne = nbrEmployeMaxMoyenne;
            this.nbrEmployeMaxOuvriere = nbrEmployeMaxOuvriere;
            coefOccupation = 0;
        }

        public int NbrEmployeActuelAise { get => nbrEmployeActuelAise; set => nbrEmployeActuelAise = value; }
        public int NbrEmployeActuelMoyenne { get => nbrEmployeActuelMoyenne; set => nbrEmployeActuelMoyenne = value; }
        public int NbrEmployeActuelOuvriere { get => nbrEmployeActuelOuvriere; set => nbrEmployeActuelOuvriere = value; }
        public int NbrEmployeMaxAise { get => nbrEmployeMaxAise; set => nbrEmployeMaxAise = value; }
        public int NbrEmployeMaxMoyenne { get => nbrEmployeMaxMoyenne; set => nbrEmployeMaxMoyenne = value; }
        public int NbrEmployeMaxOuvriere { get => nbrEmployeMaxOuvriere; set => nbrEmployeMaxOuvriere = value; }
        public double CoefOccupation { get => coefOccupation; set => coefOccupation = value; }

        public override string ToString()
        {
            return base.ToString()+"\nNombre d'employé aisé : "+nbrEmployeActuelAise+"\nNombre d'employé moyen : "+nbrEmployeActuelMoyenne+"\nNombre d'emplyé ouvrier : "+nbrEmployeActuelOuvriere;
        }
    }
}
