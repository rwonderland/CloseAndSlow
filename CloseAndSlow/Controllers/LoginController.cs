using CloseAndSlow.Models;
using CloseAndSlow.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloseAndSlow.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult IndexLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Acceso(ClienteViewModel user)
        {
            try{
                //buscamos al usuario en la base de datos para ver si existe. Si existe creamos su sesión
                using(CLOSEANDSLOWEntities db=new CLOSEANDSLOWEntities())
                {
                    var usuario= db.cliente.Where(d => d.usuario==user.Usuario).FirstOrDefault();
                    if (usuario == null)
                    {
                        user.Error = "El usuario o la contraseña no son correctos";
                        return View("IndexLogin",user);
                    }
                    else
                    {
                        Session["id_cliente"] = usuario.id_cliente;
                        Session["nombre"] = usuario.nombre;
                        return RedirectToAction("UsuariosRegistrados","Login");
                    }
                }

            }catch (Exception ex)
            {
              return Content(ex.Message + "Ocurrió un error");
            }

            
        }

        public ActionResult UsuariosRegistrados( )
        {
            
            return View();
        }



        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }









    }
}