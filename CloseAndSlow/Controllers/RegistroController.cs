using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloseAndSlow.Models;
using CloseAndSlow.Models.ViewModels;


namespace CloseAndSlow.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro

        public ActionResult IndexRegistro()
        {
            return View();
        }



        [HttpPost]
        public ActionResult IndexRegistro(ClienteViewModel model)

        {
            //si lo que se reciba no es válido, lo devolvemos a la vista con los datos rellenados
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //  comprobamos que no exista nif ni mail, hacemos el insert y devolvemos mensaje usuario creado
            //correctamente. En caso de error devolvemos mensaje correspondiente

            using (var db = new CLOSEANDSLOWEntities())         
            {

                cliente nuevoCliente = new cliente();
                // if(db.cliente.Find(nuevoCliente.mail) != null)
                nuevoCliente.nombre = model.Nombre;
                nuevoCliente.direccion = model.Direccion;
                nuevoCliente.nif = model.Nif;
                nuevoCliente.telefono = model.Telefono;
                nuevoCliente.num_tarjeta = model.Tarjeta;
                nuevoCliente.mail = model.Email;
                nuevoCliente.contraseña = model.Contrasenha;
                db.cliente.Add(nuevoCliente);
                db.SaveChanges();
                //una vez creado el cliente le redirigimos a la página de login
                return Redirect(Url.Content("~/Login/IndexLogin"));

            }




        }




    }
}