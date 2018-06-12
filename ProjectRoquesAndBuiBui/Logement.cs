using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Logement
    {
        int capaciteMax;
        ClasseSocial classe;
        double nivBonheur;
        int minOccupation;//En dessous de cette valeur, l'état paye des charges pour l'entretien
    }
    public enum ClasseSocial { aisee, moyenne, ouvriere}
}
