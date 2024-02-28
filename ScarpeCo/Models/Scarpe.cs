using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScarpeCo.Models
{
    public class Scarpe
    {
            public int IdArticolo { get; set; }
            public string Nome { get; set; }
            public string Descrizione { get; set; }
            public decimal Prezzo { get; set; }
            public string ImgPath { get; set; }
            public string  ImgAlt1 { get; set; }
            public string ImgAlt2 { get; set; }
            public bool Visibile { get; set; }

       
    }
}