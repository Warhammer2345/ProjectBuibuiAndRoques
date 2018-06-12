using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Ville
    {
        private double argent;
        private int population;
        private double attractivite;
        private double bonheur;
        private double coefImpotAisee;
        private double coefImpotMoyenne;
        private double coefImpotOuvriere;
        private double coefImpotEntreprise;
        private double impotParCycle;
        private double depenseParCycle;
        private double energieConsomme;
        private double eauConsomme;
        private Marche marcheFinancier;
        private List<Amenagement> amenagements;
        private List<Bonus> bonus;
        private Legislation legislation;
        private Catalogue catalogue;
        private Terrain map;

        public Ville(double argent, double attractivite, double bonheur,int taille, double valEau,double valElectricite)
        {
            this.argent = argent;
            this.population = 0;
            this.attractivite = attractivite;
            this.bonheur = bonheur;
            this.coefImpotAisee = 1;
            this.coefImpotMoyenne = 1;
            this.coefImpotOuvriere = 1;
            this.coefImpotEntreprise = 1;
            this.impotParCycle = 0;
            this.depenseParCycle = 0;
            amenagements = new List<Amenagement>();
            bonus = new List<Bonus>();
            this.legislation = new Legislation();
            catalogue = new Catalogue();
            map = new Terrain(taille);
            marcheFinancier = new Marche(valElectricite, valEau);
        }

        public Amenagement AjouterAmenagement()
        {
            Console.WriteLine(catalogue.Listing());
            int lecture = EssayerConvertirInt(Console.ReadLine());
            while(lecture <= 0 || lecture > catalogue.Catalogues.Count())
            {
                Console.WriteLine("Rentrer une valeur du catalogue");
                lecture = EssayerConvertirInt(Console.ReadLine());
            }
            amenagements.Add((Amenagement)catalogue.Catalogues[lecture - 1].Clone());
            return amenagements[amenagements.Count - 1];
        }

        private int EssayerConvertirInt(string aConvertir)
        {
            int aRetourner;
            try
            {
                aRetourner = Convert.ToInt32(aConvertir);
            }
            catch
            {
                aRetourner = -1;
            }
            return aRetourner;
        }

        private bool EssayerConvertirBool(string aConvertir)
        {
            bool aRetourner;
            try
            {
                aRetourner = Convert.ToBoolean(aConvertir);
            }
            catch
            {
                aRetourner = false;
            }
            return aRetourner;
        }

        private double EssayerConvertirDouble(string aConvertir)
        {
            double aRetourner;
            try
            {
                aRetourner = Convert.ToDouble(aConvertir);
            }
            catch
            {
                aRetourner = -1;
            }
            return aRetourner;
        }

        public Terrain Map
        {
            get { return map; }
        }

        /// <summary>
        /// Renvoie le revenu à chaque tour à mettre dans un thread
        /// </summary>
        /// <returns></returns>
        public double CalculRevenu()
        {
            double revenu = 0;
            foreach(Amenagement a in amenagements)
            {
                revenu -= CoutEntretien(a);
                revenu -= CoutProduction(a);
                revenu += venteProduit(a);
                revenu += impotEntreprise(a);
            }
            revenu -= CoutMensuelLoi();
            return revenu;
        }

        private int CoutEntretien(Amenagement batisse)
        {
            int revenu = 0;
            if (batisse is Bureau)
            {
                if ((batisse as Bureau).MinOccupation > (batisse as Bureau).PlacesOccupees)
                    revenu += (batisse as Bureau).CoutMensuel;

            }
            else if (batisse is Logement)
            {
                if ((batisse as Logement).MinOccupation > (batisse as Logement).OccupationActuelle)
                    revenu += (batisse as Logement).CoutMensuel;
            }
            else
            {
                if (!(batisse is Route))
                    revenu += (batisse as Batiment).CoutMensuel;
            }
            return revenu;
        }
        private double CoutProduction(Amenagement batisse)
        {
            double depense = 0;
            if (batisse is CompagnieEau)
            {
                depense += (batisse as CompagnieEau).EauProduite * 1.5;
            }
            else if (batisse is CompagnieElectricite)
                depense += (batisse as CompagnieElectricite).EnergieProduite * 0.10;
            else if (batisse is CompagnieTransport)
                depense += (batisse as CompagnieTransport).NombreTransport * 200;
            return depense;
        }
        private double CoutMensuelLoi()
        {
            double depense = 0;
            foreach(Loi a in legislation.Lois)
            {
                if (a.Active)
                    depense += a.CoutMensuel;
            }
            return depense;
        }
        private double revenu(Amenagement batisse)
        {
            double recette = 0;
            if (batisse is Bureau)
                recette += (batisse as Bureau).PlacesOccupees * (batisse as Bureau).PrixLocation;
            else if (batisse is Usine)
                recette += 2000;
            else if (batisse is Commercant)
                recette += (batisse as Commercant).ProduitVendu * (batisse as Commercant).PrixVente * 0.2;
            else if (batisse is CompagnieTransport)
                recette += (batisse as CompagnieTransport).PrixTransport * (batisse as CompagnieTransport).Frequentation;
            return recette;
        }
        private double impotEntreprise(Amenagement batisse)
        {
            double recette = 0;
            if (batisse is Bureau)
                recette += (batisse as Bureau).PlacesOccupees * 1500;
            if (batisse is Usine)
                recette += ((batisse as Usine).NbrEmployeActuelOuvriere + (batisse as Usine).NbrEmployeActuelMoyenne + (batisse as Usine).NbrEmployeActuelAise) * 100;
            if (batisse is Commercant)
                recette += ((batisse as Commercant).NbrEmployeActuelAise + (batisse as Commercant).NbrEmployeActuelMoyenne + (batisse as Commercant).NbrEmployeActuelOuvriere) * 100;
            return recette;
        }
        private double venteProduit(Amenagement batisse)
        {
            double recette = 0;
            if (batisse is CompagnieElectricite)
            {
                recette += ((batisse as CompagnieElectricite).EnergieProduite - (batisse as CompagnieElectricite).EnergieRestante) * marcheFinancier.Electricite;
                (batisse as CompagnieElectricite).EnergieRestante = 0;
            }
            else if (batisse is CompagnieEau)
            {
                recette += ((batisse as CompagnieEau).EauProduite - (batisse as CompagnieEau).EauRestante) * marcheFinancier.Eau;
                (batisse as CompagnieEau).EauRestante = 0;
            }
            return recette;

        }
    }
}
