using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITS.DichiarativiMVC.Web.Models;

namespace ITS.DichiarativiMVC.Web.Controllers
{
    public class DichiarativiController : Controller
    {
        private DichiarativiContext db = new DichiarativiContext();

        // GET: Dichiarativi
        public ActionResult Index()
        {
            var query =
                db.Dichiarativi.Select(xx => new DichiarativoIndexViewModel { 
                    DichiarativoId = xx.DichiarativoId
                    ,
                    CodiceFiscale = xx.CodiceFiscale
                    ,
                    Anno = xx.Anno
                    ,
                    RNTotale = xx.RN02
                    ,
                    RSTotale = xx.RS02 ?? 0
                    ,
                    Totale = xx.Totale
                });
            var data = query.ToList();
            return View(data);
        }

        // GET: Dichiarativi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dichiarativi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DichiarativoId,CodiceFiscale,Anno,RN01,RN02,RS01,RS02,Totale")] Dichiarativo dichiarativo)
        {
            if (ModelState.IsValid)
            {
                db.Dichiarativi.Add(dichiarativo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dichiarativo);
        }

        // GET: Dichiarativi/Edit/5
        public ActionResult RN(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuadroRNDTO rn = 
                db
                .Dichiarativi
                .Where(xx => xx.DichiarativoId == id)
                .Select(xx => new QuadroRNDTO
                {
                    DichiarativoId = xx.DichiarativoId
                    ,
                    CodiceFiscale = xx.CodiceFiscale
                    ,
                    Anno = xx.Anno
                    ,
                    RN01 = xx.RN01
                    ,
                    RN02 = xx.RN02
                }).SingleOrDefault();
            if (rn == null)
            {
                return HttpNotFound();
            }
            return View(rn);
        }
        
        // POST: Dichiarativi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RN(int id, [Bind(Include = "RN01,RN02")] QuadroRNViewModel rn)
        {
            if (ModelState.IsValid)
            {
                var dichiarazione = db.Dichiarativi.Single(xx => xx.DichiarativoId == id);
                dichiarazione.RN01 = rn.RN01;
                dichiarazione.RN02 = rn.RN02;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rn);
        }


        // GET: Dichiarativi/Edit/5
        public ActionResult AddizionaleRN(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuadroRNDTO rn =
                db
                .Dichiarativi
                .Where(xx => xx.DichiarativoId == id)
                .Select(xx => new QuadroRNDTO
                {
                    DichiarativoId = xx.DichiarativoId
                    ,
                    CodiceFiscale = xx.CodiceFiscale
                    ,
                    Anno = xx.Anno
                    ,
                    RN01 = xx.RN01
                    ,
                    RN02 = xx.RN02
                }).SingleOrDefault();
            if (rn == null)
            {
                return HttpNotFound();
            }
            return View(rn);
        }

        // POST: Dichiarativi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddizionaleRN(
            [Bind(Include = "DichiarativoId, Addizionale")] AddizionaleRNCommand rn)
        {
            if (ModelState.IsValid)
            {
                var dichiarazione = db.Dichiarativi.Single(xx => xx.DichiarativoId == rn.DichiarativoId);
                dichiarazione.RN01 += rn.Addizionale;
                dichiarazione.RN02 += rn.Addizionale;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rn);
        }

        // GET: Dichiarativi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dichiarativo dichiarativo = db.Dichiarativi.Find(id);
            if (dichiarativo == null)
            {
                return HttpNotFound();
            }
            return View(dichiarativo);
        }

        // POST: Dichiarativi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DichiarativoId,CodiceFiscale,Anno,RN01,RN02,RS01,RS02,Totale")] Dichiarativo dichiarativo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dichiarativo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dichiarativo);
        }

        // GET: Dichiarativi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dichiarativo dichiarativo = db.Dichiarativi.Find(id);
            if (dichiarativo == null)
            {
                return HttpNotFound();
            }
            return View(dichiarativo);
        }

        // POST: Dichiarativi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dichiarativo dichiarativo = db.Dichiarativi.Find(id);
            db.Dichiarativi.Remove(dichiarativo);
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
