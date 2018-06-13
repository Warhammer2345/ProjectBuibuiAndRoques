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

        Amenagement SelectionnerAmenagement()
        {
            Console.WriteLine(catalogue.Listing());

            int lecture = EssayerConvertirInt(Console.ReadLine());

            while(lecture <= 0 || lecture > catalogue.Catalogues.Count())
            {
                Console.WriteLine("Rentrer une valeur du catalogue");
                lecture = EssayerConvertirInt(Console.ReadLine());
            }
            return (Amenagement)catalogue.Catalogues[lecture - 1].Clone();
        }

       
        public Terrain Map
        {
            get { return map; }
        }

        public void AjoutAmenagement(Amenagement a)
        {
            amenagements.Add(a);
        }

        public void SupprimerAmenagement(Amenagement a)
        {
            amenagements.Remove(a);
        }

        public void PlacerUnAmenagement()
        {
            map.PlacerUnBatiment(SelectionnerAmenagement(), this);
        }

        public void ObserverLaCarte()
        {
            map.ObserverLaCarte(this);
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
                revenu += VenteProduit(a);
                revenu += ImpotEntreprise(a);
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

        private double Revenu(Amenagement batisse)
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

        private double ImpotEntreprise(Amenagement batisse)
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

        private double VenteProduit(Amenagement batisse)
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

        public void ModifierImpots()
        {
            bool continuer = true;
            int cpt = 0;
            Console.Clear();
            Console.WriteLine("Impot Aisee : ");
            AfficheSlideBar(1, coefImpotAisee, 2, 0.1);
            Console.WriteLine("Impot Moyenne : ");
            AfficheSlideBar(1, coefImpotMoyenne, 2, 0.1);
            Console.WriteLine("Impot Ouvriere : ");
            AfficheSlideBar(1, coefImpotOuvriere, 2, 0.1);

            while (continuer)
            {
                Console.SetCursorPosition(0, cpt * 2 + 1);
                ConsoleKey key = Console.ReadKey(true).Key;

                if(key == ConsoleKey.UpArrow)
                {
                    cpt -= 1;
                    if (cpt < 0) cpt = 0;
                }
                if(key == ConsoleKey.DownArrow)
                {
                    cpt += 1;
                    if (cpt > 2) cpt = 2;
                }
                if(key == ConsoleKey.RightArrow)
                {
                    ChangeCoefImpot(cpt, 0.1);
                }
                if (key == ConsoleKey.LeftArrow)
                {
                    ChangeCoefImpot(cpt, -0.1);
                }
                if (key == ConsoleKey.Escape)
                {
                    continuer = false;
                }

                Console.Clear();
                Console.WriteLine("Impot Aisee : ");
                AfficheSlideBar(1, coefImpotAisee, 2, 0.1);
                Console.WriteLine("Impot Moyenne : ");
                AfficheSlideBar(1, coefImpotMoyenne, 2, 0.1);
                Console.WriteLine("Impot Ouvriere : ");
                AfficheSlideBar(1, coefImpotOuvriere, 2, 0.1);

               
            }

        }

        void AfficheSlideBar(double valueMin, double value, double valueMax, double interval)
        {
            string temp = valueMin + " <";
            for(double i = valueMin; i < value; i += interval)
            {
                temp += "-";
            }
            temp += value;
            for(double i = value; i < valueMax; i += interval)
            {
                temp += "-";
            }
            temp += "> " + valueMax;
            Console.WriteLine(temp);
        }

        void ChangeCoefImpot(int cpt, double value)
        {
            if (cpt == 0) coefImpotAisee += value;
            if (coefImpotAisee > 2) coefImpotAisee = 2;
            if (coefImpotAisee < 1) coefImpotAisee = 1;
            if (cpt == 1) coefImpotMoyenne += value;
            if (coefImpotMoyenne > 2) coefImpotMoyenne = 2;
            if (coefImpotMoyenne < 1) coefImpotMoyenne = 1;
            if (cpt == 2) coefImpotOuvriere += value;
            if (coefImpotOuvriere > 2) coefImpotOuvriere = 2;
            if (coefImpotOuvriere < 1) coefImpotOuvriere = 1;
        }

        #region Convertion

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

        #endregion
    }
}
