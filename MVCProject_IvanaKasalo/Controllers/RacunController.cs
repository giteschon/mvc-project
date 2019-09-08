using MVCProject_IvanaKasalo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject_IvanaKasalo.Controllers
{
    public class RacunController : MyController
    {
        [Authorize]
        public ActionResult Index(int id)
        {
            ViewBag.komercijalisti = repo.GetGradovi();
            TempData["ID"] = repo.DohvatiRacuneZaKupca(id);

            return View(repo.DohvatiRacuneZaKupca(id));
        }
        


        [Authorize]
        public ActionResult Details(int id)
        {
            return View(repo.DohvatiStavkeZaRacun(id));
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
    }
}
