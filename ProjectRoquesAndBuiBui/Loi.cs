using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    delegate double EffetDeLaLoi();

    class Loi
    {
        string nom;
        bool active;
        int prixLoi;
        int coutMensuel;
        EffetDeLaLoi effetDeLaLoi;

        public Loi(string nom, int prixLoi, int coutMensuel, EffetDeLaLoi effetDeLaLoi)
        {
            this.nom = nom;
            this.active = false;
            this.prixLoi = prixLoi;
            this.coutMensuel = coutMensuel;
            this.effetDeLaLoi = effetDeLaLoi;
        }

        public void Executer()
        {
            effetDeLaLoi();
        }


        public int CoutMensuel { get => coutMensuel;  }
        public bool Active { get => active; set => active = value; }
        public int PrixLoi { get => prixLoi;  }
    }
}
