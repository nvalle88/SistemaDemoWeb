using CityParkWeb.Entities.ModeloTranferencia;
using CityParkWeb.Entities.Negocio;
using CityParkWeb.Entities.Utils;
using CityParkWeb.Services.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CityParkWeb.Controllers
{

    public class AgentesController : Controller
    {
        // GET: Agentes
        public ActionResult VerAgentesTiempoReal()
        {
            return View();
        }


        public class PuntosRequest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public async Task<JsonResult> RecorridoDiario(int Id)
        {
            if (Id <= 0)
            {
                return Json(false);
            }

            var sector = new Agente { Id = Id };

            var response = await ApiServicio.Listar<Visita>(sector, new Uri(WebApp.BaseAddress), "api/Visitas/GetVisitasDiarias");

            if (response == null || response.Count==0)
            {
                return Json(false);
            }

            var listaRequest = new List<PuntosRequest>();

            foreach (var item in response)
            {
                listaRequest.Add(new PuntosRequest { lat = (Double)item.Cliente.Lat, lng = (Double)item.Cliente.Lon });
            }

            return Json(listaRequest);
        }

        private async Task<List<Agente>> ObtenerAgentes()
        {

            var listaAgentes = await ApiServicio.Listar<Agente>(
                                                             new Uri(WebApp.BaseAddress),
                                                             "api/Agentes/GetAgentes");
            return listaAgentes;
        }


        public async Task<ActionResult> Index()
        {
            var listaAgentes = await ObtenerAgentes();
            if (listaAgentes == null)
            {
                return View(new List<AgenteRequest>());
            }
            return View(listaAgentes);
        }


        public async Task<ActionResult> Recorrido(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agente = new Agente { Id = id };

            var sectorRequest = await ApiServicio.ObtenerElementoAsync1<Response>(agente,
                                                              new Uri(WebApp.BaseAddress),
                                                              "api/Agentes/GetAgente");
            if (!sectorRequest.IsSuccess)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = JsonConvert.DeserializeObject<Agente>(sectorRequest.Result.ToString());
            return View(result);
        }
    }
}