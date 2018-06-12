using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Bureau : Tertiaire
    {
        int placesDisponible;
        int placesOccupees;
        int minOccupation;
        double coefInstallation;
        double prixLocation;
        public Bureau(int placesDisponible, int placesOccupees, int minOccupation, double prixLocation,int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coutMensuel, nom, prix, taille, couleur)
        {
            this.placesDisponible = placesDisponible;
            this.placesOccupees = placesOccupees;
            this.minOccupation = minOccupation;
            this.coefInstallation = 1;
            this.prixLocation = prixLocation;
        }

        public int MinOccupation { get => minOccupation; }
        public int PlacesOccupees { get => placesOccupees;  }

        public override string ToString()
        {
            return base.ToString()+"\nPlaces occupées : "+placesOccupees+"\nPlaces disponibles : "+placesDisponible+"\nMinimum d'occupation : "+minOccupation+"\nCoefficient de chance d'installation : "+coefInstallation+"\nPrix location : "+prixLocation;
        }
    }
}
