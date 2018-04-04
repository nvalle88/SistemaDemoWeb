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


       



        public async Task<JsonResult> GetClientes()
        {
            var response = await ApiServicio.Listar<ClienteRequest>(new Uri(WebApp.BaseAddress), "Simed/api/Clientes");

            if (response == null || response.Count == 0)
            {
                return Json(false);
            }
           
            return Json(response);
        }

        public async Task<JsonResult> RecorridoDiario(int Id, string fechaActual)
        {
            if (Id <= 0)
            {
                return Json(false);
            }

            var fecha = new DateTime();
            if (fechaActual == "")
            {
                fecha = DateTime.Now;
            }
            else
            {
             fecha = Convert.ToDateTime(fechaActual).Date;
            }
            
            var visitaDiaria = new VisitaDiaria { IdAgente = Id, Fecha=fecha };

            var response = await ApiServicio.Listar<PuntosRequest>(visitaDiaria, new Uri(WebApp.BaseAddress), "Simed/api/Visitas/GetVisitasDiarias");

            if (response == null || response.Count==0)
            {
                return Json(false);
            }
            return Json(response);
        }

        private async Task<List<AgenteRequest>> ObtenerAgentes()
        {

            var listaAgentes = await ApiServicio.Listar<AgenteRequest>(
                                                             new Uri(WebApp.BaseAddress),
                                                             "Simed/api/Agentes/GetAgentes");
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
                                                              "Simed/api/Agentes/GetAgente");
            if (!sectorRequest.IsSuccess)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = JsonConvert.DeserializeObject<Agente>(sectorRequest.Result.ToString());
            result.Fecha = DateTime.Now;
            return View(result);
        }


        [HttpPost]
        public async Task<ActionResult> Recorrido(Agente agente)
        {
            if (agente.Id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agenteRequest = new Agente { Id = agente.Id};

            var sectorRequest = await ApiServicio.ObtenerElementoAsync1<Response>(agenteRequest,
                                                              new Uri(WebApp.BaseAddress),
                                                              "Simed/api/Agentes/GetAgente");
            if (!sectorRequest.IsSuccess)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = JsonConvert.DeserializeObject<Agente>(sectorRequest.Result.ToString());
            result.Fecha = agente.Fecha;
            return View(result);
        }
    }
}