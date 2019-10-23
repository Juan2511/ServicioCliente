using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicioCliente.Entidades;
using ServicioCliente.Negocios;
using ServicioCliente.UI.Models;

namespace ServicioCliente.UI.Controllers
{
    [Route("serviciocliente")]
    public class ServicioClienteController : Controller
    {
        CNCalificacionEvaluacion objCNCalificacionEvaluacion = new CNCalificacionEvaluacion();
        CNEvaluacionServicio objCNEvaluacionServicio = new CNEvaluacionServicio();
        CNDetalleEvaluacionServicio objCNDetalleEvaluacionServicio = new CNDetalleEvaluacionServicio();

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            DataTable dt = new DataTable();

            dt = objCNCalificacionEvaluacion.Listar();

            ViewBag.servicio = MaperServicio(dt);

            return View();
        }

        [Route("Nuevo")]
        public IActionResult Nuevo(Servicio servicio)
        {
            CEEvaluacionServicio objCEEvaluacionServicio = new CEEvaluacionServicio();
            CERepuesta objCERepuesta = new CERepuesta();

            objCEEvaluacionServicio = MaperServicioModelo(servicio);
            objCNEvaluacionServicio.Agregar(objCEEvaluacionServicio);

            return RedirectToAction("Index");
        }

        private List<Servicio> MaperServicio(DataTable dt)
        {
            Servicio servicio = new Servicio();
            List<Servicio> listadoServicio = new List<Servicio>();


            foreach (DataRow fila in dt.Rows)
            {
                servicio = new Servicio();
                servicio.Correo   = fila["ClienteCorreo"].ToString();
                servicio.Nombres = fila["ClienteNombres"].ToString();

                listadoServicio.Add(servicio);
            }

            return listadoServicio;
        }

        private CEEvaluacionServicio MaperServicioModelo(Servicio servicio)
        {
            CEEvaluacionServicio objCEEvaluacionServicio = new CEEvaluacionServicio();

            objCEEvaluacionServicio.Correo = servicio.Correo;
            objCEEvaluacionServicio.Nombres = servicio.Nombres;
            objCEEvaluacionServicio.Detalle.Calificacion = servicio.Detalle.Calificacion;
            objCEEvaluacionServicio.Detalle.Fecha = servicio.Detalle.Fecha;

            return objCEEvaluacionServicio;
        }
    }
}