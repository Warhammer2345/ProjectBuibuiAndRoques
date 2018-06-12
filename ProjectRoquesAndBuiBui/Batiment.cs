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
        double coefAttractivite;
        int coutMensuel;
        public Batiment(int coutMensuel,string nom, int prix, int taille, ConsoleColor couleur): base(nom,prix,taille,couleur)
        {
            this.coefBonheur = 1;
            this.coefAttractivite = 1;
            this.coutMensuel = coutMensuel;
        }

        public int CoutMensuel { get => coutMensuel; set => coutMensuel = value; }

        public override string ToString()
        {
            return base.ToString()+"\nCoefficient bonheur : "+this.coefBonheur+"\nCoefficient Attractivité : "+this.coefAttractivite+"\nCoût mensuel : "+this.coutMensuel;
        }
    }
}
