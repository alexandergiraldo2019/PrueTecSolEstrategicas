using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using clNegocio;


namespace WebAppComprimir.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CompresionBasica(string CadIni, string CadComp, string mensaje)
        {
            ViewModel.VMConsulta obj = new ViewModel.VMConsulta();

            if (CadIni != null)
            {
                if (CadIni.Length > 0)
                {
                    obj.CadenaInicial = CadIni;
                }
            }

            if (CadComp != null)
            {
                if (CadComp.Length > 0)
                {
                    obj.CadenaComprimida= CadComp;
                }
            }

            if (mensaje != null)
            {
                if (mensaje.Length > 0)
                {
                    ViewBag.Error = mensaje;
                }
            }


            return View(obj);
        }


        [HttpPost]
        public ActionResult CompresionBasica(ViewModel.VMConsulta  oVMConsulta)
        {
            string CadInicial = string.Empty;
            string CadComprimida = string.Empty;
            string sMensaje = string.Empty;

            clNegocio.Cadenas comp = new Cadenas();
            sMensaje = "";

            if (oVMConsulta != null)
            {
                if (oVMConsulta.CadenaInicial != null)
                {
                    if (oVMConsulta.CadenaInicial.Length > 0)
                    {
                        CadInicial = oVMConsulta.CadenaInicial;
                        CadComprimida = comp.ComprimirBasico(CadInicial);
                    }
                    else
                    {
                        sMensaje = "Debe ingresar una cadena inicial";
                    }
                }
                else
                {
                    sMensaje = "Debe ingresar una cadena inicial";
                }
            }
            else
            {
                sMensaje = "Informacion sin datos para comprimir";
            }

            return RedirectToAction("CompresionBasica",new { CadIni = CadInicial, CadComp = CadComprimida, mensaje = sMensaje  });
        }
    }
}