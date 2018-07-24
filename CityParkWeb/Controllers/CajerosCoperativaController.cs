using System;
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
    public class CajerosCoperativaController : Controller
    {
        private Model db = new Model();

        // GET: CajeroCoopPolicias
        
        public ActionResult IndexCajeros()
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
            //cajeroCoopPolicia.Latitud.ToString().Replace(",", ".");
            //cajeroCoopPolicia.Latitud.ToString().Replace(",", ".");
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
                    Latitud = Convert.ToDouble(flatitud),
                    Longitud = Convert.ToDouble(flongitud),
                    Clasificacion ="N",
                    //Longitud = Convert.ToDouble( flongitud.Replace(".", ",")),
                    //Latitud = Convert.ToDouble(flatitud.Replace(".", ",")),
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
            //cajeroCoopPolicia.Latitud.ToString().Replace(",",".");
            //cajeroCoopPolicia.Latitud.ToString().Replace(",", ".");
            return View(cajeroCoopPolicia);
        }

        
        [HttpPost]
        public async Task<JsonResult> Edit(string clasificacion, string nombreCajero, string modelocajero, string flatitud, string flongitud, int id)
        {
            try
            {
                var cajeroactualizar =await db.CajeroCoopPolicia.Where(x => x.Id == id).FirstOrDefaultAsync();
                cajeroactualizar.Id = id;
                cajeroactualizar.Latitud = Convert.ToDouble(flatitud);
                cajeroactualizar.Longitud = Convert.ToDouble(flongitud);
                //cajeroactualizar.Longitud = Convert.ToDouble(flongitud.Replace(".", ","));
                //cajeroactualizar.Latitud = Convert.ToDouble(flatitud.Replace(".", ","));
                cajeroactualizar.Codigo = nombreCajero;
                cajeroactualizar.Modelo = modelocajero;
                db.Entry(cajeroactualizar).State = EntityState.Modified;
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
