using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject_IvanaKasalo.Models
{
    public class Stavka
    {
        public int IDStavka { get; set; }
        public short Kolicina { get; set; }
        public string Proizvod { get; set; }
        public string Potkategorija { get; set; }
        public string Kategorija { get; set; }
        public decimal CijenaPoKomadu { get; set; }
        public decimal PopustUPostocima { get; set; }
        public decimal UkupnaCijena { get; set; }
        public Racun Racun { get; set; }

    }
}