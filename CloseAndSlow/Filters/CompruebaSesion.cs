using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using CloseAndSlow.Controllers;
using CloseAndSlow.Models;

namespace CloseAndSlow.Filters
{
    //clase que comprueba que el usuario tenga un inicio de sesión válido, si no es así 
    public class CompruebaSesion : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //verificamos el usuario existe
        //    var usuario = (cliente)HttpContext.Current.Session["User"];
        //    //si devuleve null no tiene sesión
        //    if (usuario == null)
        //    {
        //        if (filterContext.Controller is ReservaController == true)
        //        {
        //            //si iba dirigido al filtro de lo redirigimos 
        //            //ya veré a donde 
        //            filterContext.HttpContext.Response.Redirect("~/Login/IndexLogin");
        //        }

        //    }


        //    base.OnActionExecuting(filterContext);

        //}
    }
}