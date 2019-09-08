using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using MVCProject_IvanaKasalo.Models;

namespace MVCProject_IvanaKasalo.dal
{
    public class Repository : IRepo
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static DataSet ds;

        public List<Drzava> DohvatiDrzave()
        {
            List<Drzava> list = new List<Drzava>();

            ds = SqlHelper.ExecuteDataset(cs, "GetCountries");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Drzava
                {
                    IDDrzava = (int)row[nameof(Drzava.IDDrzava)],
                    Naziv = row[nameof(Drzava.Naziv)].ToString()
                });
            }
            return list;
        }

        public void UrediKupca(Kupac customer)
        {
            SqlHelper.ExecuteNonQuery(cs, "EditCustomer", customer.IDKupac,customer.Ime,customer.Prezime,customer.Email,customer.Telefon, customer.Grad.IDGrad);
        }
    

        public List<Grad> DohvatiGradoveZaDrzavu(int idDrzava)
        {
            List<Grad> list = new List<Grad>();

            ds = SqlHelper.ExecuteDataset(cs, "GetCitiesForCountry", idDrzava);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Grad
                {
                    IDGrad = (int)row[nameof(Grad.IDGrad)],
                    Naziv = row[nameof(Grad.Naziv)].ToString()
                });
            }
            return list;
        }

        public Grad DohvatiGrad(int idGrad)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetCity", idGrad);
            DataRow row = ds.Tables[0].Rows[0];

            Grad c = new Grad();
            c.IDGrad = idGrad;
            c.Naziv = row[nameof(Grad.Naziv)].ToString();

            return c;
        }

        public Drzava DohvatiDrzavu(int idDrzava)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetCountry", idDrzava);
            DataRow row = ds.Tables[0].Rows[0];

            Drzava d = new Drzava();
            d.IDDrzava= idDrzava;
            d.Naziv = row[nameof(Drzava.Naziv)].ToString();

            return d;
        }

        public List<Kupac> DohvatiKupceZaGrad(int idCity)
        {
            List<Kupac> list = new List<Kupac>();

            ds = SqlHelper.ExecuteDataset(cs, "GetCustomersForCity", idCity);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Kupac
                {
                    IDKupac = (int)row[nameof(Kupac.IDKupac)],
                    Ime = row[nameof(Kupac.Ime)].ToString(),
                    Prezime = row[nameof(Kupac.Prezime)].ToString(),
                    Email = row[nameof(Kupac.Email)].ToString(),
                    Telefon = row[nameof(Kupac.Telefon)].ToString(),
                    Grad = DohvatiGrad((int)row["GradID"])
                });
            }
            return list;
        }

        public List<Racun> DohvatiRacuneZaKupca(int idCustomer)
        {
            List<Racun> list = new List<Racun>();

            ds = SqlHelper.ExecuteDataset(cs, "GetInInvoicesForCustomer", idCustomer);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Racun
                {
                    IDRacun = (int)row[nameof(Racun.IDRacun)],
                    DatumIzdavanja=DateTime.Parse(row[nameof(Racun.DatumIzdavanja)].ToString()),
                    BrojRacuna = row[nameof(Racun.BrojRacuna)].ToString(),
                    Komercijalist = row[nameof(Racun.Komercijalist)].ToString(),
                    Broj = row[nameof(Racun.Broj)].ToString(),
                    Tip = row[nameof(Racun.Tip)].ToString(),
                });
            }
            return list;
        }

        public List<Stavka> DohvatiStavkeZaRacun(int idInvoice)
        {
            List<Stavka> list = new List<Stavka>();

            ds = SqlHelper.ExecuteDataset(cs, "getItemsPerInvoice", idInvoice);
            foreach (DataRow row in ds.Tables[0].Rows)
            {

                Stavka s = new Stavka();

                s.IDStavka = (int)row[nameof(Stavka.IDStavka)];
                s.Kolicina = (short)row[nameof(Stavka.Kolicina)];
                s.CijenaPoKomadu = (decimal)row[nameof(Stavka.CijenaPoKomadu)];
                s.PopustUPostocima = (decimal)row[nameof(Stavka.PopustUPostocima)];
                s.UkupnaCijena = (decimal)row[nameof(Stavka.UkupnaCijena)];
                    s.Proizvod = row[nameof(Stavka.Proizvod)].ToString();
                s.Potkategorija = row[nameof(Stavka.Potkategorija)].ToString();
                    s.Kategorija = row[nameof(Stavka.Kategorija)].ToString();


                list.Add(s);

            }
            return list;
        }

        public void AddDrzava(Drzava drzava)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddDrzava", drzava.Naziv);
        }

        public void EditDrzava(Drzava drzava)
        {
            SqlHelper.ExecuteNonQuery(cs, "EditDrzava", drzava.Naziv, drzava.IDDrzava);
        }

        public void DeleteDrzava(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteDrzava", id);
        }

        public void AddGrad(Grad grad)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddGrad", grad.Naziv, grad.Drzava.IDDrzava);
        }

        public void EditGrad(Grad grad)
        {
            SqlHelper.ExecuteNonQuery(cs, "EditGrad", grad.Naziv,grad.Drzava.IDDrzava, grad.IDGrad);
        }

        public void DeleteGrad(int idGrad)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteGrad", idGrad);
        }

        public Drzava GetDrzava(string naziv)
        {
            ds = SqlHelper.ExecuteDataset(cs, "getDrzava", naziv);
            DataRow row = ds.Tables[0].Rows[0];

            Drzava d = new Drzava();
            d.IDDrzava = (int)row[nameof(Drzava.IDDrzava)];
            d.Naziv = row[nameof(Drzava.Naziv)].ToString();

            return d;
        }

        public Kupac GetKupac(int idKupac)
        {
            ds = SqlHelper.ExecuteDataset(cs, "getKupac", idKupac);
            DataRow row = ds.Tables[0].Rows[0];

            Kupac k = new Kupac();
            k.IDKupac = (int)row[nameof(Kupac.IDKupac)];
            k.Ime = row[nameof(Kupac.Ime)].ToString();
            k.Prezime = row[nameof(Kupac.Prezime)].ToString();
            k.Email = row[nameof(Kupac.Email)].ToString();
            k.Telefon = row[nameof(Kupac.Telefon)].ToString();
            k.Grad = DohvatiGrad((int)row["GradID"]);

            return k;
        }

        public void AddKupac(Kupac kupac)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddKupac", kupac.Ime,kupac.Prezime,kupac.Email,kupac.Telefon,kupac.Grad.IDGrad);
        }

        public void DeleteKupac(int idKupac)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteKupac", idKupac);
        }

        public Grad GetGrad(string naziv)
        {
            ds = SqlHelper.ExecuteDataset(cs, "getGrad", naziv);
            DataRow row = ds.Tables[0].Rows[0];

            Grad g = new Grad();
            g.IDGrad = (int)row[nameof(Grad.IDGrad)];
            g.Naziv = row[nameof(Grad.Naziv)].ToString();
            //g.Drzava = DohvatiDrzavu((int)row["DrzavaID"]);

            return g;
        }

        public List<Grad> GetGradovi()
        {
            List<Grad> list = new List<Grad>();

            ds = SqlHelper.ExecuteDataset(cs, "getGradovi");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Grad
                {
                    IDGrad = (int)row[nameof(Grad.IDGrad)],
                    Naziv = row[nameof(Grad.Naziv)].ToString()
                });
            }
            return list;
        }
    }
}
