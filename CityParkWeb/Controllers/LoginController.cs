using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CityParkWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Video()
        {
            return Redirect("http://developmentds.eastus.cloudapp.azure.com:93/index.html");
        }
    }
}