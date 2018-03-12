﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        public ActionResult IndexCajeros()
        {
            return View(db.CajeroCoopPolicia.ToList());
        }

        public async Task<JsonResult> GetCajeros()
        {
            var response = db.CajeroCoopPolicia.ToList();

            if (response == null || response.Count == 0)
            {
                return Json(false);
            }

            return Json(response);
        }

        public async Task<JsonResult> GetCajerosBanRed()
        {
            var response = db.CajeroCompetencia.ToList();

            if (response == null || response.Count == 0)
            {
                return Json(false);
            }

            return Json(response);
        }

        public async Task<JsonResult> GetPuntosMapaCalor()
        {
            var response = db.MapaConcentracion.ToList();

            if (response == null || response.Count == 0)
            {
                return Json(false);
            }

            return Json(response);
        }

        public ActionResult Recorrido()
        {
            return View();
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
            cajeroCoopPolicia.Latitud.ToString().Replace(",", ".");
            cajeroCoopPolicia.Latitud.ToString().Replace(",", ".");
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
        //[ValidateAntiForgeryToken]
        public JsonResult Create( string nombreCajero,string modelocajero, string flatitud, string flongitud)
        {
            try
            {
                var a = new CajeroCoopPolicia
                {
                    Longitud = Convert.ToDouble( flongitud.Replace(".", ",")),
                    Latitud = Convert.ToDouble(flatitud.Replace(".", ",")),
                    Codigo = nombreCajero,
                    Modelo = modelocajero
                    
                };
                db.CajeroCoopPolicia.Add(a);
                db.SaveChanges();
                return Json(true);
                
            }
            catch (Exception)
            {

                return Json(false);
            }
            
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
            cajeroCoopPolicia.Latitud.ToString().Replace(",",".");
            cajeroCoopPolicia.Latitud.ToString().Replace(",", ".");
            return View(cajeroCoopPolicia);
        }

        // POST: CajeroCoopPolicias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(CajeroCoopPolicia cajeroCoopPolicia)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cajeroCoopPolicia).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("IndexCajeros");
        //    }
        //    return View(cajeroCoopPolicia);
        //}
        [HttpPost]
        public async Task<JsonResult> Edit(string nombreCajero, string modelocajero, string flatitud, string flongitud, int id)
        {
            try
            {
                var a = new CajeroCoopPolicia
                {
                    Id = id,
                    Longitud = Convert.ToDouble(flongitud.Replace(".", ",")),
                    Latitud = Convert.ToDouble(flatitud.Replace(".", ",")),
                    Codigo = nombreCajero,
                    Modelo = modelocajero

                };
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true);

            }
            catch (Exception ex)
            {

                return Json(false);
            }

        }

        public ActionResult Delete(int id)
        {
            CajeroCoopPolicia cajeroCoopPolicia = db.CajeroCoopPolicia.Find(id);
            db.CajeroCoopPolicia.Remove(cajeroCoopPolicia);
            db.SaveChanges();
            return RedirectToAction("IndexCajeros");
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
