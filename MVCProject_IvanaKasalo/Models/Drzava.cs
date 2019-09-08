using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject_IvanaKasalo.Models
{
    public class Drzava
    {
        public int IDDrzava { get; set; }

        
        [Required] [StringLength(50)]
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}