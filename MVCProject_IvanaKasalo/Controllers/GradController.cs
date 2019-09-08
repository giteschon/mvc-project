using MVCProject_IvanaKasalo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject_IvanaKasalo.Controllers
{
    public class GradController : MyController
    {


        //// GET: Grad
        //public ActionResult Index(int id)
        //{
        //    //partial bi trebo bit
        //    Session["idDrzava"] = id;
        //    return View(repo.DohvatiGradoveZaDrzavu(id));
        //}

       [Authorize]
        public ActionResult Ajax(int id)
        {
                       return PartialView("_Ajax",repo.DohvatiGradoveZaDrzavu(id));
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.drzave = repo.DohvatiDrzave();           

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Grad grad)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    grad.Drzava = repo.GetDrzava(grad.Drzava.Naziv);
                    repo.AddGrad(grad);

                    return RedirectToAction("Index", "Drzava");
                }
                catch
                {
                    return View("Error");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.drzave = repo.DohvatiDrzave();
            return View(repo.DohvatiGrad(id));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Grad grad)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    grad.Drzava = repo.GetDrzava(grad.Drzava.Naziv);
                    repo.EditGrad(grad);

                    return RedirectToAction("Index", "Drzava");
                }
                catch
                {
                    return View("Error");
                }
            }
            return View(repo.DohvatiGrad(grad.IDGrad));
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(repo.DohvatiGrad(id));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                repo.DeleteGrad(id);

                return RedirectToAction("Index", "Drzava");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
