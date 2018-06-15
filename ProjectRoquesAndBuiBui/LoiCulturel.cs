using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class LoiCulturel : Loi
    {
        public LoiCulturel(string nom, int prixLoi, int coutMensuel, double coefMalus, double coefBonus, int prixAnnulation, int cycleMin) : base(nom, prixLoi, coutMensuel, coefMalus, coefBonus, prixAnnulation, cycleMin)
        {

        }
    }
}
