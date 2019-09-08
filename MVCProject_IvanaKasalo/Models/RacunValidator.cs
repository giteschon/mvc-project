using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject_IvanaKasalo.Models
{
    public class RacunValidator :ValidationAttribute
    {
           

        protected override ValidationResult IsValid(object invoice, ValidationContext validationContext)
        {
            if (invoice.ToString().Length > 7)
            {
                return new ValidationResult("Broj racuna je predugačak. Dozovoljeno je unijeti 25 znakova");
            }

            string line = invoice.ToString().Substring(0, 2);
            if (!line.ToUpper().Equals("SO"))
            {
                return new ValidationResult("Broj racuna treba počinjati sa SO.");
            }

            line= invoice.ToString().Substring(2, invoice.ToString().Length);
           
            if (line.All(char.IsDigit))
            {
                return ValidationResult.Success;
            }
           
            else
            {
                return new ValidationResult("Račun može sadržavati samo brojeve nakon SO");
            }
        }
    }


}
