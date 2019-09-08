using MVCProject_IvanaKasalo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCProject_IvanaKasalo.Controllers
{
    public class KupacController : MyController
    {
        [Authorize]
        public ActionResult Index(int id)
        {
            
            try
            {
                return View(repo.DohvatiKupceZaGrad(id));
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.GetBaseException().Message;
                return View("Error");

            }
        }



        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        // GET: Kupac/Create
        public ActionResult Create()
        {
            ViewBag.gradovi = repo.GetGradovi();
            return View();
        }

        [Authorize]
        // POST: Kupac/Create
        [HttpPost]
        public ActionResult Create(Kupac kupac)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    kupac.Grad = repo.GetGrad(kupac.Grad.Naziv);
                    repo.AddKupac(kupac);

                    return RedirectToAction("Index", "Drzava");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            return View();


        }

        [Authorize]
        // GET: Kupac/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.gradovi = repo.GetGradovi();
            return View(repo.GetKupac(id));
        }

        // POST: Kupac/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Kupac kupac)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    kupac.Grad = repo.GetGrad(kupac.Grad.Naziv);
                    repo.UrediKupca(kupac);

                    return RedirectToAction("Index", "Drzava");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.GetBaseException().Message;
                    return View("Error");
                }
            }
            return View(repo.GetKupac(kupac.IDKupac));
        }

        // GET: Kupac/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(repo.GetKupac(id));
        }

        // POST: Kupac/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                repo.DeleteKupac(id);

                return RedirectToAction("Index", "Drzava");
            }
            catch
            {
               
                return View("Error");
            }
        }
    }
}
