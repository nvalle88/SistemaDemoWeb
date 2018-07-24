using CityParkWeb.Models;
using CityParkWeb.Utiles;
using Microsoft.Reporting.WebForms;
using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CityParkWeb.Controllers
{
   
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Report()
        {
            
            ReportViewer rptViewer = new ReportViewer();

            // ProcessingMode will be Either Remote or Local  
            rptViewer.ProcessingMode = ProcessingMode.Remote;
            rptViewer.SizeToReportContent = true;
            rptViewer.ZoomMode = ZoomMode.PageWidth;
            rptViewer.Width = Unit.Percentage(100);
            rptViewer.Height = Unit.Percentage(100);
            rptViewer.AsyncRendering = true;


            IReportServerCredentials irsc = new CustomReportCredentials(Constantes.UsuarioReport, Constantes.Contrasena);

            rptViewer.ServerReport.ReportServerCredentials = irsc;

            rptViewer.ServerReport.ReportServerUrl = new Uri(Constantes.ServerReportUrl);

            rptViewer.ServerReport.ReportPath = Constantes.ReporteCuelloPath;

            ViewBag.ReportViewer = rptViewer;
            return View();
        }
    }
}