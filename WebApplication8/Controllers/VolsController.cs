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
    public class VolsController : Controller
    {
        private BD_AeroportEntities db = new BD_AeroportEntities();

        // GET: Vols
        public ActionResult Index()
        {
            //var vols = db.Vols.Include(v => v.Avion).Include(v => v.Pilote);

            //afficher les vols effectués en septembre 2017
            var pquery = db.Vols.Where(vol => vol.Date_arrivee.Value.Year == 2017 && vol.Date_arrivee.Value.Month == 9);

            return View(pquery.ToList());
        }

        // GET: Vols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vol vol = db.Vols.Find(id);
            if (vol == null)
            {
                return HttpNotFound();
            }
            return View(vol);
        }

        // GET: Vols/Create
        public ActionResult Create()
        {
            ViewBag.Num_Av = new SelectList(db.Avions, "Num_Av", "Nom_Av");
            ViewBag.Num_Pil = new SelectList(db.Pilotes, "Num_pil", "Nom_pil");
            return View();
        }

        // POST: Vols/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Num_Vol,Num_Pil,Num_Av,Ville_Depart,Ville_Arrivee,Date_depart,Date_arrivee")] Vol vol)
        {
            if (ModelState.IsValid)
            {
                db.Vols.Add(vol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Num_Av = new SelectList(db.Avions, "Num_Av", "Nom_Av", vol.Num_Av);
            ViewBag.Num_Pil = new SelectList(db.Pilotes, "Num_pil", "Nom_pil", vol.Num_Pil);
            return View(vol);
        }

        // GET: Vols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vol vol = db.Vols.Find(id);
            if (vol == null)
            {
                return HttpNotFound();
            }
            ViewBag.Num_Av = new SelectList(db.Avions, "Num_Av", "Nom_Av", vol.Num_Av);
            ViewBag.Num_Pil = new SelectList(db.Pilotes, "Num_pil", "Nom_pil", vol.Num_Pil);
            return View(vol);
        }

        // POST: Vols/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Num_Vol,Num_Pil,Num_Av,Ville_Depart,Ville_Arrivee,Date_depart,Date_arrivee")] Vol vol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Num_Av = new SelectList(db.Avions, "Num_Av", "Nom_Av", vol.Num_Av);
            ViewBag.Num_Pil = new SelectList(db.Pilotes, "Num_pil", "Nom_pil", vol.Num_Pil);
            return View(vol);
        }

        // GET: Vols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vol vol = db.Vols.Find(id);
            if (vol == null)
            {
                return HttpNotFound();
            }
            return View(vol);
        }

        // POST: Vols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vol vol = db.Vols.Find(id);
            db.Vols.Remove(vol);
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
