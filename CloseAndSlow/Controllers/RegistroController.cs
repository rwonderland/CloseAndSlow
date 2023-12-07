using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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


                nuevoCliente.usuario = model.Usuario;
                nuevoCliente.mail = model.Email;
                //falta encriptar contraseña
                nuevoCliente.contraseña = model.Contrasenha;

                db.cliente.Add(nuevoCliente);
                db.SaveChanges();
                //una vez creado el cliente le redirigimos a la página de login

                    return Redirect(Url.Content("~/Login/IndexLogin"));

            }
            
        }


        [HttpGet]
        public ActionResult Editar(string id_cliente)
        {
            
            ClienteViewModel model = new ClienteViewModel();

            using (var db = new CLOSEANDSLOWEntities())
            {
                var clienteActual = db.cliente.Find(int.Parse(id_cliente));

                model.Nombre = clienteActual.nombre;
                model.Direccion = clienteActual.direccion;
                model.Nif = clienteActual.nif;
                model.Telefono = clienteActual.telefono;
                model.Tarjeta = clienteActual.num_tarjeta;
                model.Usuario = clienteActual.usuario;
                model.Email = clienteActual.mail;
                model.Id = clienteActual.id_cliente;
                //falta encriptar contraseña
                model.Contrasenha = clienteActual.contraseña;
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult EditarDatos(ClienteViewModel model)
        {
          
            
           using (var db = new CLOSEANDSLOWEntities())
            {
                var clienteActual = db.cliente.Find(model.Id);

                 clienteActual.nombre = model.Nombre  ;
                 clienteActual.direccion = model.Direccion;
                 clienteActual.nif = model.Nif;
                 clienteActual.telefono = model.Telefono ;
                 clienteActual.num_tarjeta = model.Tarjeta;
                 clienteActual.usuario = model.Usuario ;
                 clienteActual.mail = model.Email ;
                 clienteActual.id_cliente = model.Id ;
                
                 

                db.Entry(clienteActual).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            
        }
        return Redirect(Url.Content("~/Login/UsuariosRegistrados"));

         }




        public ActionResult Eliminar()
        {
            return View();  
        }
    }
}