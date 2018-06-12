using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class CompagnieTransport :Secondaire
    {
        int nombreTransport;
        int capaciteTransport;
        double prixTransport;
        int frequentation;
        public CompagnieTransport(int nombreTransport, int capaciteTransport,double prixTransport, int frequentation, int coutMensuel, string nom, int prix, int taille, ConsoleColor couleur) : base(coutMensuel, nom, prix, taille, couleur)
        {
            this.nombreTransport = nombreTransport;
            this.capaciteTransport = capaciteTransport;
            this.prixTransport = prixTransport;
            this.frequentation = frequentation;
        }

        public int NombreTransport { get => nombreTransport; set => nombreTransport = value; }
        public double PrixTransport { get => prixTransport; set => prixTransport = value; }
        public int Frequentation { get => frequentation; set => frequentation = value; }

        public override string ToString()
        {
            return base.ToString()+"\nNombre de Transport : "+nombreTransport+"\nCapacité des transports : "+capaciteTransport+"\nPrix du ticket : "+prixTransport+"\nFréquentation : "+frequentation;
        }
    }
}
