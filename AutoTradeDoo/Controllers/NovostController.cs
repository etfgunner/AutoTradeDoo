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
    public class NovostController : Controller
    {
        private AutoTradeDooDb db = new AutoTradeDooDb();

        // GET: Novost
        public ActionResult Index()
        {
            return View(db.novosti.ToList());
        }


        // GET: Novost/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Novost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Image,Sadrzaj")] Novost novost)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files[0];
                byte[] imageSize = new byte[file.ContentLength];
                file.InputStream.Read(imageSize, 0, (int)file.ContentLength);
                novost.Image = imageSize;
                db.novosti.Add(novost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(novost);
        }



        // GET: Novost/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Novost novost = db.novosti.Find(id);
            if (novost == null)
            {
                return HttpNotFound();
            }
            return View(novost);
        }

        // POST: Novost/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Novost novost = db.novosti.Find(id);
            db.novosti.Remove(novost);
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
