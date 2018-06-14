using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Loi
    {
        string nom;
        bool active;
        int prixLoi;
        int prixAnnulation;
        int cycleMin;
        int coutMensuel;
        double coefMalus;
        double coefBonus;

        public Loi(string nom, int prixLoi, int coutMensuel, double coefMalus, double coefBonus, int prixAnnulation, int cycleMin)
        {
            this.nom = nom;
            this.active = false;
            this.prixLoi = prixLoi;
            this.coutMensuel = coutMensuel;
            this.coefMalus = coefMalus;
            this.coefBonus = coefBonus;
            this.prixAnnulation = prixAnnulation;
            this.cycleMin = cycleMin;
        }

        public string Nom { get => nom; }
        public int CoutMensuel { get => coutMensuel;  }
        public bool Active { get => active; set => active = value; }
        public int PrixLoi { get => prixLoi;  }
        public double CoefMalus { get => coefMalus; }
        public double CoefBonus { get => coefBonus; }
        public int CycleMin { get => cycleMin; }
        public int PrixAnnulation { get => prixAnnulation; }
        
    }
}
