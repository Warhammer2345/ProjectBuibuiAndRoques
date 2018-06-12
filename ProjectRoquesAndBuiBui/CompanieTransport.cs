using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class CompanieTransport :Secondaire
    {
        int nombreTransport;
        int capaciteTransport;
        double prixTransport;
        int frequentation;
        public CompanieTransport(int nombreTransport, int capaciteTransport,double prixTransport, int frequentation, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coutMensuel, nom, prix, taille, couleur)
        {
            this.nombreTransport = nombreTransport;
            this.capaciteTransport = capaciteTransport;
            this.prixTransport = prixTransport;
            this.frequentation = frequentation;
        }
        public override string ToString()
        {
            return base.ToString()+"\nNombre de Transport : "+nombreTransport+"\nCapacité des transports : "+capaciteTransport+"\nPrix du ticket : "+prixTransport+"\nFréquentation : "+frequentation;
        }
    }
}
