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
        private List<Amenagement> amenagements;
        private List<Bonus> bonus;
        private Legislation legislation;
        private Catalogue catalogue;
        private Terrain map;

        public Ville(double argent, double attractivite, double bonheur,int taille)
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

        public void CalculRevenu()
        {
            double revenu = 0;
            foreach(Amenagement a in amenagements)
            {
                revenu += CoutEntretien(a);


            }
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
        /*private double CoutProduction(Amenagement batisse)
        {
            if(batisse is)
        }*/
    }
}
