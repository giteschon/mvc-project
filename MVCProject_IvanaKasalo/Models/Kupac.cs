using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject_IvanaKasalo.Models
{
    public class Kupac
    {
        public int IDKupac { get; set; }
        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        [Phone]
        public string Telefon { get; set; }


        public Grad Grad { get; set; }
    }
}