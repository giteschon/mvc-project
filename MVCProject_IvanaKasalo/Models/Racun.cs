using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject_IvanaKasalo.Models
{
    public class Racun
    {
        public int IDRacun { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumIzdavanja { get; set; }

        [Required]
        [RacunValidator]
        public string BrojRacuna { get; set; }
        public Kupac Kupac { get; set; }
        [Required]
        public string Komercijalist { get; set; }
        [Required]
        [CreditCard]
        public string Broj { get; set; }
        [Required]
        public string Tip { get; set; }

    }
}