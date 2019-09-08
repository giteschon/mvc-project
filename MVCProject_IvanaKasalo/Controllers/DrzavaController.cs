using MVCProject_IvanaKasalo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject_IvanaKasalo.Controllers
{
    public class DrzavaController : MyController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View(repo.DohvatiDrzave());
        }

        [Authorize]
        // GET: Drzava/Details/5
        public ActionResult DohvatiDrzavu(int id)
        {
            return View(repo.DohvatiDrzavu(id));
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.AddDrzava(drzava);

                    return RedirectToAction("Index");
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
            return View(repo.DohvatiDrzavu(id));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Drzava drzava)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    repo.EditDrzava(drzava);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View("Error");
                }
            }
            return View(repo.DohvatiDrzavu(drzava.IDDrzava));
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(repo.DohvatiDrzavu(id));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection )
        {
            try
            {
                repo.DeleteDrzava(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
