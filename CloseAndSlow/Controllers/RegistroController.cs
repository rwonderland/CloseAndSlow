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

        /// <summary>
        /// Método que crea un nuevo usuario y lo inserta en la base de datos 
        /// </summary>

        [HttpPost]
        public ActionResult IndexRegistro(ClienteViewModel model)

        {
            //si lo que se reciba no es válido, lo devolvemos a la vista con los datos rellenados
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            using (var db = new CLOSEANDSLOWEntities())
            {

                cliente nuevoCliente = new cliente();
                nuevoCliente.nombre = model.Nombre;
                nuevoCliente.direccion = model.Direccion;
                nuevoCliente.nif = model.Nif;
                nuevoCliente.telefono = model.Telefono;
                nuevoCliente.num_tarjeta = model.Tarjeta;


                nuevoCliente.usuario = model.Usuario;
                nuevoCliente.mail = model.Email;

                //var encriptada = model.Contrasenha;
                //nuevoCliente.contraseña = Encrypt.GetSHA256(encriptada);
                nuevoCliente.contraseña = model.Contrasenha;
                db.cliente.Add(nuevoCliente);
                db.SaveChanges();
                //una vez creado el cliente le redirigimos a la página de login

                return Redirect(Url.Content("~/Login/IndexLogin"));

            }

        }

        /// <summary>
        /// Método que carga los datos del usuario que vamos a editar en la vista 
        /// </summary>
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

        /// <summary>
        /// Método que edita los datos de usuario y modifica el registro en la base de datos
        /// </summary>
        [HttpPost]
        public ActionResult EditarDatos(ClienteViewModel model)
        {


            using (var db = new CLOSEANDSLOWEntities())
            {
                var clienteActual = db.cliente.Find(model.Id);

                clienteActual.nombre = model.Nombre;
                clienteActual.direccion = model.Direccion;
                clienteActual.nif = model.Nif;
                clienteActual.telefono = model.Telefono;
                clienteActual.num_tarjeta = model.Tarjeta;
                clienteActual.usuario = model.Usuario;
                clienteActual.mail = model.Email;
                clienteActual.id_cliente = model.Id;



                db.Entry(clienteActual).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


            }
            return Redirect(Url.Content("~/Login/UsuariosRegistrados"));

        }



        /// <summary>
        /// Método que elimina la cuenta de usuario
        /// </summary>
        public ActionResult Eliminar(string id_cliente)

        {
            using (var db = new CLOSEANDSLOWEntities())
            {
                var clienteActual = db.cliente.Find(int.Parse(id_cliente));
                db.cliente.Remove(clienteActual);
                db.SaveChanges();
            }
            Session["id_cliente"] = null;

            return Redirect(Url.Content("~/Home/Index"));
        }
    }
}