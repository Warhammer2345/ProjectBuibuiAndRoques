using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class LoiEconomique : Loi
    {
        bool ponctuelle;

        public LoiEconomique(string nom, int prixLoi, int coutMensuel, double coefMalus, double coefBonus, int prixAnnulation, int cycleMin, bool ponctuelle) : base(nom, prixLoi, coutMensuel, coefMalus, coefBonus, prixAnnulation, cycleMin)
        {
            this.ponctuelle = ponctuelle;
        }

        public bool Ponctuelle { get => ponctuelle; }
    }
}
