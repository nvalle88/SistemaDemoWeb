using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CityParkWeb.ModelosDatos;

namespace CityParkWeb.Controllers
{
    public class CajeroCoopPoliciasController : Controller
    {
        private Model db = new Model();

        // GET: CajeroCoopPolicias
        public ActionResult Index()
        {
            return View(db.CajeroCoopPolicia.ToList());
        }

        // GET: CajeroCoopPolicias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajeroCoopPolicia cajeroCoopPolicia = db.CajeroCoopPolicia.Find(id);
            if (cajeroCoopPolicia == null)
            {
                return HttpNotFound();
            }
            return View(cajeroCoopPolicia);
        }

        // GET: CajeroCoopPolicias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CajeroCoopPolicias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Provincia,Canton,Sector,Codigo,Ubicación,Direccion,Tipo,Modelo,Latitud,Longitud,TrxPropia,TrxBanred")] CajeroCoopPolicia cajeroCoopPolicia)
        {
            if (ModelState.IsValid)
            {
                db.CajeroCoopPolicia.Add(cajeroCoopPolicia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cajeroCoopPolicia);
        }

        // GET: CajeroCoopPolicias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajeroCoopPolicia cajeroCoopPolicia = db.CajeroCoopPolicia.Find(id);
            if (cajeroCoopPolicia == null)
            {
                return HttpNotFound();
            }
            return View(cajeroCoopPolicia);
        }

        // POST: CajeroCoopPolicias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Provincia,Canton,Sector,Codigo,Ubicación,Direccion,Tipo,Modelo,Latitud,Longitud,TrxPropia,TrxBanred")] CajeroCoopPolicia cajeroCoopPolicia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cajeroCoopPolicia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cajeroCoopPolicia);
        }

        // GET: CajeroCoopPolicias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CajeroCoopPolicia cajeroCoopPolicia = db.CajeroCoopPolicia.Find(id);
            if (cajeroCoopPolicia == null)
            {
                return HttpNotFound();
            }
            return View(cajeroCoopPolicia);
        }

        // POST: CajeroCoopPolicias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CajeroCoopPolicia cajeroCoopPolicia = db.CajeroCoopPolicia.Find(id);
            db.CajeroCoopPolicia.Remove(cajeroCoopPolicia);
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
