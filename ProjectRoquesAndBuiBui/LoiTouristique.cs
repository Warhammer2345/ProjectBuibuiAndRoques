using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class LoiTouristique : Loi
    {
        public LoiTouristique(string nom, int prixLoi, int coutMensuel, EffetDeLaLoi effetDeLaLoi) : base(nom, prixLoi, coutMensuel, effetDeLaLoi)
        {

        }
    }
}
