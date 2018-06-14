using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class LoiEconomique : Loi
    {
        bool pontuel;

        public LoiEconomique(string nom, int prixLoi, int coutMensuel, EffetDeLaLoi effetDeLaLoi) : base(nom, prixLoi, coutMensuel, effetDeLaLoi)
        {

        }
    }
}
