using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    delegate void EffetDeLaLoi();

    class Loi
    {
        string nom;
        bool active;
        EffetDeLaLoi effetDeLaLoi;
    }
}
