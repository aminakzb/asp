using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class AvionsController : Controller
    {
        private BD_AeroportEntities db = new BD_AeroportEntities();

        // GET: Avions
        public ActionResult Index()
        {
            return View(db.Avions.ToList());
        }

        // GET: Avions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avion avion = db.Avions.Find(id);
            if (avion == null)
            {
                return HttpNotFound();
            }
            return View(avion);
        }

        // GET: Avions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avions/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Num_Av,Nom_Av,Capacite,Localisation")] Avion avion)
        {
            if (ModelState.IsValid)
            {
                db.Avions.Add(avion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avion);
        }

        // GET: Avions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avion avion = db.Avions.Find(id);
            if (avion == null)
            {
                return HttpNotFound();
            }
            return View(avion);
        }

        // POST: Avions/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Num_Av,Nom_Av,Capacite,Localisation")] Avion avion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avion);
        }

        // GET: Avions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avion avion = db.Avions.Find(id);
            if (avion == null)
            {
                return HttpNotFound();
            }
            return View(avion);
        }

        // POST: Avions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avion avion = db.Avions.Find(id);
            db.Avions.Remove(avion);
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
