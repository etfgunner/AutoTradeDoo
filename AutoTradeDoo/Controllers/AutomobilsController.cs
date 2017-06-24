using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoTradeDoo.Models;

namespace AutoTradeDoo.Controllers
{
    public class AutomobilsController : Controller
    {
        private AutoTradeDooDb db = new AutoTradeDooDb();

        // GET: Automobils
        public ActionResult Index()
        {
            return View(db.automobili.ToList());
        }

        // GET: Automobils/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobil automobil = db.automobili.Find(id);
            if (automobil == null)
            {
                return HttpNotFound();
            }
            return View(automobil);
        }

        // GET: Automobils/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Automobils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Image,Proizvodjac,Model,Godiste,Kilometraza,Gorivo,EmisioniStandard,BrojVrata,Tip,VelicinaFelgi,Transmisija,BrojStepeniPrijenosa")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files[0];
                byte[] imageSize = new byte[file.ContentLength];
                file.InputStream.Read(imageSize, 0, (int)file.ContentLength);
                automobil.Image = imageSize;
                db.automobili.Add(automobil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(automobil);
        }

        // GET: Automobils/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobil automobil = db.automobili.Find(id);
            if (automobil == null)
            {
                return HttpNotFound();
            }
            return View(automobil);
        }

        // POST: Automobils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Proizvodjac,Model,Godiste,Kilometraza,Gorivo,EmisioniStandard,BrojVrata,Tip,VelicinaFelgi,Transmisija,BrojStepeniPrijenosa")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automobil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(automobil);
        }

        // GET: Automobils/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobil automobil = db.automobili.Find(id);
            if (automobil == null)
            {
                return HttpNotFound();
            }
            return View(automobil);
        }

        // POST: Automobils/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automobil automobil = db.automobili.Find(id);
            db.automobili.Remove(automobil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
