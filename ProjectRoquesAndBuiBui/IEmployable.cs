using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    interface IEmployable
    {
        int NbrEmployeActuelAise { get; set; }
        int NbrEmployeActuelMoyenne { get; set; }
        int NbrEmployeActuelOuvriere { get; set; }
        int NbrEmployeMaxAise { get; set; }
        int NbrEmployeMaxMoyenne { get; set; }
        int NbrEmployeMaxOuvriere { get; set; }
    }
}
