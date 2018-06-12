using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Catalogue
    {
        List<Amenagement> catalogues;
        public Catalogue()
        {
            catalogues = new List<Amenagement>();
            catalogues.Add(new CompanieEau(150,5, 10, 50, 0, "Central d'eau", 1000000, 2, ConsoleColor.Blue));
            catalogues.Add(new CompanieElectricite(150, 5, 10, 50, 0, "Central nucléaire", 1000000, 3, ConsoleColor.Yellow));
            catalogues.Add(new CompanieTransport(1,200,2,0,10000, "Bus RATP", 1000000, 3, ConsoleColor.Green));
            catalogues.Add(new Usine(5, 10, 50, 0, "Usine de base", 1000000, 2, ConsoleColor.Red));
            catalogues.Add(new Logement(20,ClasseSocial.ouvriere,50,5 ,0, "Immeuble ouvrier", 500000, 1, ConsoleColor.Cyan));
        }

       public List<Amenagement> Catalogues { get => catalogues;}

        public void Affichage()
        {
            foreach(Amenagement a in catalogues)
            {
                Console.WriteLine(a.ToString());
            }
        }
        public string Listing()
        {
            int compteur = 1;
            string liste = "";
            foreach(Amenagement a in catalogues)
            {
                if (liste != "")
                    liste += "\n";
                liste+=compteur+". "+a.Nom;
                compteur++;
            }
            return liste;
        }
    }
}
