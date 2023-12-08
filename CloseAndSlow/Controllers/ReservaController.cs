using CloseAndSlow.Models;
using CloseAndSlow.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloseAndSlow.Controllers
{
    public class ReservaController : Controller
    {
        /// <summary>
        /// Método que recoge los datos del hotel y usuario para gestionar la reserva
        /// </summary>
        public ActionResult IndexReserva()

        {
            ReservaViewModel model = new ReservaViewModel();
          
            var id_cliente = Session["id_cliente"];
            if (id_cliente != null)
            {
                model.IdCliente = int.Parse(id_cliente.ToString());
                model.IdHotel = int.Parse(Request.Form["id_hotel"]);
                model.IdHabitacion = int.Parse(Request.Form["id_habitacion"]);
                ViewBag.nombre_hotel = Request.Form["nombre_hotel"];
                return View(model);
            }
            else { return Redirect(Url.Content("~/Login/IndexLogin")); }
          
            
        }
        /// <summary>
        /// Método que recibe el modelo con los datos necesarios para crear la reserva
        /// </summary>
        [HttpPost]
    
        public ActionResult CreateReserva( ReservaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //request del formulario de todos los datos necesarios e insert a la base de datos

            using (var db = new CLOSEANDSLOWEntities())
            {
                reserva nuevaReserva= new reserva();
                nuevaReserva.fecha_reserva=DateTime.Now;
                nuevaReserva.fecha_entrada = DateTime.Parse(model.FechaDesde);
                nuevaReserva.fecha_salida = DateTime.Parse(model.FechaHasta);
                nuevaReserva.anulada = false;
                nuevaReserva.fecha_anulacion = DateTime.Parse("01-01-1900");
                //numero de dias *precio noche
                var dias = nuevaReserva.fecha_salida.Subtract(nuevaReserva.fecha_entrada);
                var diff = dias.TotalDays;
                var coste = diff * 50;
                nuevaReserva.precio_total= int.Parse(coste.ToString());
                nuevaReserva.id_cliente=model.IdCliente;
                nuevaReserva.id_hotel= model.IdHotel;
                nuevaReserva.id_habitacion = model.IdHabitacion;
                db.reserva.Add(nuevaReserva);
                db.SaveChanges();


            }

            return Redirect(Url.Content("~/Login/UsuariosRegistrados"));   
        }

        public ActionResult ReadReserva( )
        {
            var id_cliente = int.Parse(Session["id_cliente"].ToString());
           
            List<ReservaViewModel> list;
            using (CLOSEANDSLOWEntities db = new CLOSEANDSLOWEntities())
            {
                var precio = 
                list = (from d in db.reserva
                        where d.id_cliente==id_cliente
                        select new ReservaViewModel 
                        {
                            FechaReserva = d.fecha_reserva,
                            FechaDesde = d.fecha_entrada.ToString(),
                            FechaHasta = d.fecha_salida.ToString(),
                           
            }).ToList();

            }

            return View(list);
        }



    }

}