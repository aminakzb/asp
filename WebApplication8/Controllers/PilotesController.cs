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
    public class PilotesController : Controller
    {
        private BD_AeroportEntities db = new BD_AeroportEntities();

        // GET: Pilotes
        public ActionResult Index()
        {
            //afficher les pilotes dont le nom contient I
            //var pquery = db.Pilotes.Where(p=>p.Nom_pil.Contains("I"));

            //afficher les pilotes habitant à rabat et touchent plus de 18000
            //var pquery = db.Pilotes.Where(p => p.Ville_Domicile == "Rabat" && p.Salaire > 18000);

            //afficher les noms et prénoms des pilotes triés par salaire décroissant
            //var pquery = db.Pilotes.OrderByDescending(p => p.Salaire);

            //afficher le max le min total moy des salaires

            //afficher les pilotes casablancais qui touchent mois 20000dh
            // var pquery = db.Pilotes.Where(p => p.Ville_Domicile == "Casablanca" && p.Salaire < 20000);

            //pilotes qui effectuer des vols en sep 2017 et le nom d'avion
            var pquery = (from p in db.Pilotes join v in db.Vols on p.Num_pil equals v.Num_pil join );
            
            return View(pquery.ToList());
      

        // GET: Pilotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilote pilote = db.Pilotes.Find(id);
            if (pilote == null)
            {
                return HttpNotFound();
            }
            return View(pilote);
        }

        // GET: Pilotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pilotes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Num_pil,Nom_pil,Prenom_pil,Ville_Domicile,Num_tel,Email,Salaire")] Pilote pilote)
        {
            if (ModelState.IsValid)
            {
                db.Pilotes.Add(pilote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pilote);
        }

        // GET: Pilotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilote pilote = db.Pilotes.Find(id);
            if (pilote == null)
            {
                return HttpNotFound();
            }
            return View(pilote);
        }

        // POST: Pilotes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Num_pil,Nom_pil,Prenom_pil,Ville_Domicile,Num_tel,Email,Salaire")] Pilote pilote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pilote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pilote);
        }

        // GET: Pilotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilote pilote = db.Pilotes.Find(id);
            if (pilote == null)
            {
                return HttpNotFound();
            }
            return View(pilote);
        }

        // POST: Pilotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pilote pilote = db.Pilotes.Find(id);
            db.Pilotes.Remove(pilote);
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
