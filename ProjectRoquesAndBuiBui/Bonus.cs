using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    delegate void EffetBonus();

    class Bonus
    {
        EffetBonus effetBonus;
        string nom;

        public Bonus(string nom, EffetBonus effet)
        {
            effetBonus = effet;
            this.nom = nom;
        }
    }
}
