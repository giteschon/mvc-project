using MVCProject_IvanaKasalo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject_IvanaKasalo.dal
{
   public interface IRepo
    {
        
        Drzava DohvatiDrzavu(int idDrzava);
        List<Grad> DohvatiGradoveZaDrzavu(int idDrzava);
        Grad DohvatiGrad(int idGrad);
        List<Kupac> DohvatiKupceZaGrad(int idgrad);
        List<Racun> DohvatiRacuneZaKupca(int idKupac);
        List<Stavka> DohvatiStavkeZaRacun(int idRacun);

        void UrediKupca(Kupac kupac);

        List<Drzava> DohvatiDrzave();

        void AddDrzava(Drzava drzava);
        void EditDrzava(Drzava drzava);
        void DeleteDrzava(int id);

        void AddGrad(Grad grad);
        void EditGrad(Grad grad);
        void DeleteGrad(int idGrad);

        Drzava GetDrzava(string naziv);
        Kupac GetKupac(int idKupac);
        void AddKupac(Kupac kupac);
        void DeleteKupac(int idKupac);
        Grad GetGrad(string naziv);
        List<Grad> GetGradovi();

    }
}
