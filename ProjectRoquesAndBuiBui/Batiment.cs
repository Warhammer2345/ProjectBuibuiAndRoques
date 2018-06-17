using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    abstract class Batiment : Amenagement
    {
        double coefBonheur;
        double coefAttractivite;//1 est le maximum et 0 est le minimum
        double coefCulture;//1 est le maximum et 0 est le minimum
        int coutMensuel;
        bool estConnecte; // true si le batiment est relié à la sortie de la ville par une route

        public Batiment(int coutMensuel,string nom, int prix, int taille, ConsoleColor couleur): base(nom,prix,taille,couleur)
        {
            this.coefBonheur = 1.1;
            this.coefAttractivite = 1.1;
            this.coefCulture = 1.1;
            this.coutMensuel = coutMensuel;
            estConnecte = false;
        }
        public Batiment(double coefAttractivite,double coefCulture,int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(nom, prix, taille, couleur)
        {
            this.coefBonheur = 1.1;
            this.coefAttractivite = coefAttractivite;
            this.coefCulture = coefCulture;
            this.coutMensuel = coutMensuel;
            estConnecte = false;
        }

        public int CoutMensuel { get => coutMensuel; set => coutMensuel = value; }
        public double CoefAttractivite { get => coefAttractivite; set => coefAttractivite = value; }
        public double CoefCulture { get => coefCulture; set => coefCulture = value; }
        public double CoefBonheur { get => coefBonheur; set => coefBonheur = value; }
        public bool EstConnecte { get => estConnecte; set => estConnecte = value; }

        public override string ToString()
        {
            return base.ToString() + "\nCoefficient bonheur : " + coefBonheur + "\nCoefficient Attractivité : " + coefAttractivite + "\nCoût mensuel : " + coutMensuel;
        }
    }
}
