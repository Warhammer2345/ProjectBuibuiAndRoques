﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Legislation
    {
        private List<Loi> lois;
        public Legislation()
        {
            this.lois = new List<Loi>();
        }

        public List<Loi> Lois { get => lois; set => lois = value; }
    }
}
