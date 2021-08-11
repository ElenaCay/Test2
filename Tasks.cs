using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
I tasks sono oggetti che possiedono:
-una descrizione
- una data di scadenza
- un livello di priorità (Alto, Medio, Basso)*/

namespace Test2
{
    class Tasks
    {
        public string Descrizione { get; set; }
        public DateTime Scadenza { get; set; }
        public Livello Priorita { get; set; }

        public Tasks()
        {

        }

        public enum Livello
        {
            Basso,
            Medio,
            Alto
        }
    }
}
