using CloseAndSlow.Models;
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

        public ActionResult Acceso(string user, string password)
        {
            try{
                //buscamos al usuario en la base de datos para ver si existe. Si existe creamos su sesión
                using(CLOSEANDSLOWEntities db=new CLOSEANDSLOWEntities())
                {
                    var usuario= from d in db.cliente where d.usuario == user && d.contraseña == password 
                                 select d;
                    if(usuario.Count() > 0)
                    {
                        //la almacenamos en una variable de tipo cliente(nuestra tabla)
                        cliente cliente = usuario.First();
                        Session["User"]= cliente;
                        return Content("1");
                    }
                    else
                    {
                        return Content( "El usuario o la contraseña no son correctos");
                    }
                }

            }catch (Exception ex)
            {
              return Content(ex.Message + "Ocurrió un error");
            }

            
        }

        public ActionResult UsuariosRegistrados()
        {
            return View();
        }













    }
}