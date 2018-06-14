using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Ville
    {
        private double argent;
        private int population;
        private int populationAisee;
        private int populationMoyenne;
        private int populationOuvriere;
        private int capaciteLogementAisee;
        private int capaciteLogementMoyenne;
        private int capaciteLogementOuvriere;
        private double attractivite;//entre 0 et 100
        private double culture;//entre 0 et 100
        private double bonheur;//entre 0 et 100
        private double bonheurAisee;//entre 0 et 100
        private double bonheurOuvriere;//entre 0 et 100
        private double bonheurMoyenne;//entre 0 et 100
        private int nourriture;
        private double coefImpotAisee;
        private double coefImpotMoyenne;
        private double coefImpotOuvriere;
        private double coefImpotEntreprise;
        private double impotParCycle;
        private double depenseParCycle;
        private double energieConsomme;
        private double eauConsomme;
        private int capaciteLogement;
        private Marche marcheFinancier;
        private List<Amenagement> amenagements;
        private List<Bonus> bonus;
        private List<Loi> lois;
        private Catalogue catalogue;
        private Terrain map;

        public Ville(double argent, double attractivite, double bonheur,int taille, double valEau,double valElectricite)
        {
            this.argent = argent;
            this.population = 0;
            this.capaciteLogement = 0;
            this.attractivite = attractivite;
            this.bonheur = 50;
            this.bonheurAisee = 50;
            this.bonheurMoyenne = 50;
            this.bonheurOuvriere = 50;
            this.coefImpotAisee = 1;
            this.coefImpotMoyenne = 1;
            this.coefImpotOuvriere = 1;
            this.coefImpotEntreprise = 1;
            this.populationAisee = 0;
            this.populationMoyenne = 0;
            this.populationOuvriere = 0;
            this.culture = 0;
            this.impotParCycle = 0;
            this.depenseParCycle = 0;
            amenagements = new List<Amenagement>();
            bonus = new List<Bonus>();
            catalogue = new Catalogue();
            map = new Terrain(taille);
            lois = new List<Loi>();
            marcheFinancier = new Marche(valElectricite, valEau);
        }
        public override string ToString()
        {
            return "Argent : "+argent+"\nPopulation : "+population+"\nCapacité Logement : "+capaciteLogement+"\nCulture : "+culture+"\nAttractivité : "+attractivite;
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

        public List<Amenagement> Amenagements { get => amenagements; }

        public void AjoutAmenagement(Amenagement a)
        {
            if (a.Prix <= argent)
            {
                if (a is Logement)
                {
                    AjoutLogement((a as Logement));
                }
                amenagements.Add(a);
                argent -= a.Prix;
            }
            else
            {
                Console.WriteLine("Vous n'avez pas assez d'argent");
            }
        }

        public void SupprimerAmenagement(Amenagement a)
        {
            if(a is Logement)
            {
                RetirerLogement((a as Logement));
            }
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
       
        #region Méthode thread
        public void EvolutionVariablesParTour()
        {
            while (true)
            {


                CalculCulture();
                CalculAttractivite();
                CalculRevenu();
                CalculerPopulation();
                CalculBonheur();
                Console.WriteLine(ToString());
                Thread.Sleep(10000);
            }
        }
        #region Calcul Revenu par tour
        /// <summary>
        /// Renvoie le revenu à chaque tour à mettre dans un thread
        /// </summary>
        /// <returns></returns>
        public void CalculRevenu()
        {
            double revenu = 0;
            foreach (Amenagement a in amenagements)
            {
                revenu -= CoutEntretien(a);
                revenu -= CoutProduction(a);
                revenu += VenteProduit(a);
                revenu += ImpotEntreprise(a);
            }
            revenu -= CoutMensuelLoi();
            revenu += ImpotParticulier();
            argent += revenu;
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
            foreach (Loi a in lois)
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
        private double ImpotParticulier()
        {
            double recette = 0;
            recette += populationAisee * 8500 * coefImpotAisee;
            recette += populationMoyenne * 3500 * coefImpotMoyenne;
            recette += populationOuvriere * 1500 * coefImpotOuvriere;
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
        #endregion
        private void CalculBonheur()
        {
            if (population != 0)
            {
                bonheur = 0;
                //Bonheur en fonction de la nourriture
                if (nourriture > population && nourriture < population * 1.2)//La population ne veut pas gâcher
                    bonheur += 20;
                else if (nourriture < population || nourriture > population * 2)
                    bonheur += 0;
                else
                    bonheur += 10;
                //Bonheur en fonction de l'eau
                if (eauConsomme == 0)//La population ne veut pas gâcher
                    bonheur += 15;
                else
                    bonheur += 0;
                //Bonheur en fonction de l'electricité
                if (energieConsomme == 0)//La population ne veut pas gâcher
                    bonheur += 10;
                else
                    bonheur += 0;
                //Bonheur en fonction la culture
                bonheur += culture * 0.15;
                //Bonheur en fonction la culture
                bonheur += attractivite * 0.05;
                //Bonheur en fonction des impots et du bonheur par classe
                CalculBonheurParClasse();
            }


        }
        private void CalculBonheurParClasse()
        {
        
            bonheurAisee=bonheur+20* (1 - Math.Sqrt(coefImpotAisee));
            bonheurMoyenne = bonheur + 20 * (1 - Math.Sqrt(coefImpotMoyenne));
            bonheurOuvriere = bonheur + 20 * (1 - Math.Sqrt(coefImpotOuvriere));
            if (capaciteLogementAisee > populationAisee)
                bonheurAisee += 15;
            else if (capaciteLogementAisee > populationAisee * 0.98)
                bonheurAisee += 7.5;
            if (capaciteLogementMoyenne > populationMoyenne)
                bonheurMoyenne += 15;
            else if (capaciteLogementMoyenne > populationMoyenne * 0.98)
                bonheurMoyenne += 7.5;
            if (capaciteLogementOuvriere > populationOuvriere)
                bonheurOuvriere += 15;
            else if (capaciteLogementOuvriere > populationOuvriere * 0.9)
                bonheurOuvriere += 7.5;
            
            double proportionPopAisee = Convert.ToDouble(populationAisee) / Convert.ToDouble((population+1));
            double proportionPopMoyenne = Convert.ToDouble(populationMoyenne) / Convert.ToDouble(population+1);
            double proportionPopOuvriere = 1 - proportionPopAisee - proportionPopMoyenne;
            bonheur = proportionPopAisee * bonheurAisee + proportionPopMoyenne * bonheurMoyenne + proportionPopOuvriere * bonheurOuvriere;
        }
        private void CalculerPopulation()
        {
            int nombreArrivee = 0;
            if(bonheur>=50&&capaciteLogement>=population)
            {
                if (population < 100)
                {
                    nombreArrivee = 50;
                    population += 50;
                    populationAisee += 10;
                    populationOuvriere += 15;
                    populationMoyenne += 25;
                }
                else if(population <1000)
                {
                    nombreArrivee = 50 + Convert.ToInt32(population * 0.3);
                    populationAisee += Convert.ToInt32(nombreArrivee * 0.2);
                    populationMoyenne += Convert.ToInt32(nombreArrivee * 0.5);
                    populationOuvriere += Convert.ToInt32(nombreArrivee * 0.3);
                }
                else if (population < 10000)
                {
                    nombreArrivee = Convert.ToInt32(population * 0.2);
                    populationAisee += Convert.ToInt32(nombreArrivee * 0.2);
                    populationMoyenne += Convert.ToInt32(nombreArrivee * 0.5);
                    populationOuvriere += Convert.ToInt32(nombreArrivee * 0.3);
                }
                else if (population < 50000)
                {
                    nombreArrivee = Convert.ToInt32(population * 0.1);
                    populationAisee += Convert.ToInt32(nombreArrivee * 0.2);
                    populationMoyenne += Convert.ToInt32(nombreArrivee * 0.5);
                    populationOuvriere += Convert.ToInt32(nombreArrivee * 0.3);
                }
                else if (population < 100000)
                {
                    nombreArrivee = Convert.ToInt32(population * 0.05);
                    populationAisee += Convert.ToInt32(nombreArrivee * 0.2);
                    populationMoyenne += Convert.ToInt32(nombreArrivee * 0.5);
                    populationOuvriere += Convert.ToInt32(nombreArrivee * 0.3);
                }
                else
                {
                    nombreArrivee = Convert.ToInt32(population * 0.02);
                    populationAisee += Convert.ToInt32(nombreArrivee * 0.2);
                    populationMoyenne += Convert.ToInt32(nombreArrivee * 0.5);
                    populationOuvriere += Convert.ToInt32(nombreArrivee * 0.3);
                }

            }
            if (bonheur > 70 && capaciteLogement > population)
            {
                if (population < 100)
                {
                    nombreArrivee = 100;
                    population += 100;
                    populationAisee += 20;
                    populationOuvriere += 30;
                    populationMoyenne += 50;
                }
                else if (population < 1000)
                {
                    nombreArrivee = 100 + Convert.ToInt32(population * 0.4);
                    populationAisee += Convert.ToInt32(nombreArrivee * 0.2);
                    populationMoyenne += Convert.ToInt32(nombreArrivee * 0.5);
                    populationOuvriere += Convert.ToInt32(nombreArrivee * 0.3);
                }
                else if (population < 10000)
                {
                    nombreArrivee = Convert.ToInt32(population * 0.3);
                    populationAisee += Convert.ToInt32(nombreArrivee * 0.2);
                    populationMoyenne += Convert.ToInt32(nombreArrivee * 0.5);
                    populationOuvriere += Convert.ToInt32(nombreArrivee * 0.3);
                }
                else if (population < 50000)
                {
                    nombreArrivee = Convert.ToInt32(population * 0.2);
                    populationAisee += Convert.ToInt32(nombreArrivee * 0.2);
                    populationMoyenne += Convert.ToInt32(nombreArrivee * 0.5);
                    populationOuvriere += Convert.ToInt32(nombreArrivee * 0.3);
                }
                else if (population < 100000)
                {
                    nombreArrivee = Convert.ToInt32(population * 0.1);
                    populationAisee += Convert.ToInt32(nombreArrivee * 0.2);
                    populationMoyenne += Convert.ToInt32(nombreArrivee * 0.5);
                    populationOuvriere += Convert.ToInt32(nombreArrivee * 0.3);
                }
                else
                {
                    nombreArrivee = Convert.ToInt32(population * 0.05);
                    populationAisee += Convert.ToInt32(nombreArrivee * 0.2);
                    populationMoyenne += Convert.ToInt32(nombreArrivee * 0.5);
                    populationOuvriere += Convert.ToInt32(nombreArrivee * 0.3);
                }

            }
            else if(bonheur>50 &&capaciteLogement<population)
            {
                nombreArrivee = 40;
                if (capaciteLogementAisee < populationAisee)
                {
                    populationAisee += 20;
                    nombreArrivee -= 20;
                }
                if(capaciteLogementMoyenne<populationMoyenne)
                {
                    populationMoyenne += 20;
                    nombreArrivee -= 20;
                }
                populationOuvriere += nombreArrivee;

            }
            else if(bonheur<50&&bonheur>30)
            {
                
                populationAisee = populationAisee * (18 / 19);
                populationMoyenne = populationMoyenne * (24 / 25);
                populationOuvriere = populationOuvriere * (24 / 25);
                population = populationAisee + populationMoyenne + populationOuvriere;
            }
            else if(bonheur<30)
            {
                
                populationAisee = populationAisee *(13/16);
                populationMoyenne = populationMoyenne * (15/16);
                populationOuvriere = populationOuvriere * (15/16);
                population = populationAisee + populationMoyenne + populationOuvriere;
            }
        }
        private void CalculPopulationParClasse()
        {
            if (bonheurAisee < 60 && bonheurAisee > 40)
                populationAisee = populationAisee * (13 / 16);
            else if (bonheurAisee < 40)
                populationAisee = populationAisee * (2 / 3);
            else if (bonheurAisee > 80)
                populationAisee = populationAisee * (23 / 21);
            if (bonheurMoyenne < 50 && bonheurMoyenne > 30)
                populationMoyenne = populationMoyenne * (7 / 8);
            else if (bonheurMoyenne < 30)
                populationMoyenne = populationMoyenne * (5 / 7);
            else if (bonheurMoyenne > 70)
                populationMoyenne = populationMoyenne * (8 / 7);
            if (bonheurOuvriere < 40 && bonheurOuvriere > 20)
                populationOuvriere = populationOuvriere * (7 / 8);
            else if (bonheurOuvriere < 20)
                populationOuvriere = populationOuvriere * (3 / 4);
            else if (bonheurOuvriere > 70)
                populationOuvriere = populationOuvriere * (9 / 7);
        }
        private void CalculAttractivite()
        {
            double sommeMultiplicateur = 0;
            double coefMultiplicateur=0;
            attractivite = 0;//Repars de 0
            int compteur = 0;
            int niveauTourisme = 0;
            foreach(Amenagement a in amenagements)
            {
                if(a is Batiment)
                {
                    if ((a as Batiment).CoefAttractivite != 1.1)//Vérifie que le bâtiment à un impact sur l'attractivité
                    {
                        sommeMultiplicateur += (a as Batiment).CoefAttractivite;//Somme les coefficients d'attractivité
                        compteur++;
                    }
                    if(a is Tourisme)
                    {
                        niveauTourisme+=(a as Tourisme).ImpactTourisme;//Somme l'impact des monuments sur le tourisme
                    }
                }
            }
            if(compteur!=0)
            coefMultiplicateur = sommeMultiplicateur/ compteur;//Récupère le coef d'attractivité de la ville en elle-même (chiffre compris entre 0 et 1)
            attractivite = 50 * coefMultiplicateur;//Représente la moitié du pourcentage d'attractivité

            //On considère qu'une ville est très attractive lorsqu'elle a un niveau de tourisme pour 500 habitants
            double inter = ((population+500) / 500);//On récupère le nombre de paquets de 500 habitants que l'on a et on a rajouté 500 pour les cas de début de partie
            if (inter < niveauTourisme)//S'il y a plus d'un niveau de tourisme pour 500 habitants
                attractivite += 50;//La ville est très attractive de ceux point de vue
            else if (inter != 0)
                attractivite += 50 * (niveauTourisme / inter);

        }

        private void CalculCulture()
        {
            double sommeMultiplicateur = 0;
            double coefMultiplicateur = 0;
            attractivite = 0;//Repars de 0
            int compteur = 0;
            int niveauCulture = 0;
            foreach (Amenagement a in amenagements)
            {
                if (a is Batiment)
                {
                    if ((a as Batiment).CoefCulture != 1.1)//Vérifie que le bâtiment à un impact sur l'attractivité
                    {
                        sommeMultiplicateur += (a as Batiment).CoefCulture;//Somme les coefficients d'attractivité
                        compteur++;
                    }
                    if (a is Culture)
                    {
                        niveauCulture += (a as Culture).NiveauCulture;//Somme l'impact des monuments sur le tourisme
                    }
                }
            }
            if(compteur!=0)
            coefMultiplicateur = sommeMultiplicateur / compteur;//Récupère le coef d'attractivité de la ville en elle-même (chiffre compris entre 0 et 1)
            attractivite = 50 * coefMultiplicateur;//Représente la moitié du pourcentage d'attractivité

            //On considère qu'une ville est très attractive lorsqu'elle a un niveau de tourisme pour 500 habitants
            double inter = ((population + 500) / 500);//On récupère le nombre de paquets de 500 habitants que l'on a et on a rajouté 500 pour les cas de début de partie
            if (inter < niveauCulture)//S'il y a plus d'un niveau de tourisme pour 500 habitants
                attractivite += 50;//La ville est très attractive de ceux point de vue
            else if (inter != 0)
                attractivite += 50 * (niveauCulture / inter);

        }
        #endregion
        private void AjoutLogement(Logement a)
        {
            if (a.Classe == ClasseSocial.ouvriere)
                capaciteLogementOuvriere += a.CapaciteMax;
            else if (a.Classe == ClasseSocial.moyenne)
                capaciteLogementMoyenne += a.CapaciteMax;
            else
                capaciteLogementAisee += a.CapaciteMax;

            capaciteLogement += a.CapaciteMax;
        }
        private void RetirerLogement(Logement a)
        {

            if (a.Classe == ClasseSocial.ouvriere)
                capaciteLogementOuvriere -= a.CapaciteMax;
            else if (a.Classe == ClasseSocial.moyenne)
                capaciteLogementMoyenne -= a.CapaciteMax;
            else
                capaciteLogementAisee -= a.CapaciteMax;

            capaciteLogement -= a.CapaciteMax;
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
